using System.Xml.Serialization;
using System.Xml;
using Npgsql;
using System.Reflection;
using System;


namespace Nfe
{
    public partial class Form1 : Form
    {
        List<XmlReaderTeste> xmlReaderTestes = new List<XmlReaderTeste>();
        List<ProdutosXML> xmlReaderProds = new List<ProdutosXML>();

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string arquivoXML in openFileDialog.FileNames)
                    {
                        ProcessarArquivoXML(arquivoXML);
                    }
                    //MessageBox.Show("Dados inseridos com sucesso!");
                    MessageBox.Show("OK!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na importação do XML: " + ex.Message);
            }
        }
        private void ProcessarArquivoXML(string caminhoArquivo)
        {
            XmlSerializer ser = new XmlSerializer(typeof(nfeProc));
            TextReader textReader = (TextReader)new StreamReader(caminhoArquivo);
            XmlTextReader reader = new XmlTextReader(textReader);
            reader.Read();

            try
            {
                nfeProc nota = (nfeProc)ser.Deserialize(reader);
                foreach (var item in nota.NFe.infNFe.det)
                {
                    //Informações ITENS(Dados cadastrais)
                    string CodProd = item.prod.cProd;
                    string Descricao = item.prod.xProd;
                    string NCM = item.prod.NCM;
                    uint cestCodigo = item.prod.CEST;
                    int ordemID = item.nItem;
                    

                    //Informações Nota(Dados fiscais)
                    string Chave = nota.protNFe.infProt.chNFe.ToString();
                    string Fornecedor = nota.NFe.infNFe.emit.xNome;
                    int Numero = nota.NFe.infNFe.ide.nNF;
                    int Serie = nota.NFe.infNFe.ide.serie;
                    int Modelo = nota.NFe.infNFe.ide.mod;
                    int Cfop = 0000;
                    DateTime dataEmissao = nota.NFe.infNFe.ide.dhEmi;
                    string UF = nota.NFe.infNFe.emit.enderEmit.UF;

                    //Informações ITENS(Dados ICMS)
                    decimal valorTotalItem = item.prod.vProd;
                    decimal valorBCItem = 0;
                    decimal aliquotaIcms = 0;
                    decimal valorICMS = 0;
                    decimal valorICMSST = 0;
                    int codCST = 90;                    

                    //Informações Nota(Totais)
                    decimal valorTotalNota = nota.NFe.infNFe.total.ICMSTot.vNF;
                    decimal valorTotalIcms = nota.NFe.infNFe.total.ICMSTot.vICMS;
                    decimal valorTotalBase = nota.NFe.infNFe.total.ICMSTot.vBC;
                    decimal valorTotalBaseST = nota.NFe.infNFe.total.ICMSTot.vBCST;
                    decimal valorTotalIPI = nota.NFe.infNFe.total.ICMSTot.vIPI;

                    // Verificar se o ICMS está presente e acessar o valor
                    if (item.imposto.ICMS != null)
                    {
                        if (item.imposto.ICMS.ICMS00 != null)
                        {
                            Cfop = item.prod.CFOP;
                            valorICMS = item.imposto.ICMS.ICMS00.vICMS;
                            codCST = item.imposto.ICMS.ICMS00.CST;
                            valorICMSST = item.imposto.ICMS.ICMS00.vICMSST;
                            valorBCItem = item.imposto.ICMS.ICMS00.vBC;
                            aliquotaIcms = item.imposto.ICMS.ICMS00.pICMS;
                        }
                        else if (item.imposto.ICMS.ICMS10 != null)
                        {
                            Cfop = item.prod.CFOP;
                            valorICMS = item.imposto.ICMS.ICMS10.vICMS;
                            codCST = item.imposto.ICMS.ICMS10.CST;
                            valorICMSST = item.imposto.ICMS.ICMS10.vICMSST;
                            valorBCItem = item.imposto.ICMS.ICMS10.vBC;
                            aliquotaIcms = item.imposto.ICMS.ICMS10.pICMS;
                        }
                        else if (item.imposto.ICMS.ICMS40 != null)
                        {
                            Cfop = item.prod.CFOP;
                            codCST = item.imposto.ICMS.ICMS40.CST;
                            valorBCItem = item.imposto.ICMS.ICMS40.vBC;
                            aliquotaIcms = item.imposto.ICMS.ICMS40.pICMS;
                        }
                        else if (item.imposto.ICMS.ICMS60 != null)
                        {
                            Cfop = item.prod.CFOP;
                            codCST = item.imposto.ICMS.ICMS60.CST;
                            
                        }

                        NpgsqlConnection connect = new NpgsqlConnection();
                        string connection1 = $"Server=127.0.0.1; Port=5432; Database=testenfe; User Id=postgres; Password=postzeus2011";
                        connect.ConnectionString = connection1;
                        connect.Open();
                        string sql1 = $"INSERT INTO public.nfexml(numero, serie, modelo, chave, codproduto, ordem, descricaoitem, ncm, cst, valortotalprod, valoricms, valoricmsst) " +
                        $"VALUES({Numero}, {Serie}, {Modelo}, '{Chave}', '{CodProd}', {ordemID}, '{Descricao}', '{NCM}', {codCST}, REPLACE('{valorTotalItem.ToString()}',',','.')::numeric, REPLACE('{valorICMS.ToString()}',',','.')::numeric, REPLACE('{valorICMSST.ToString()}',',','.')::numeric);";
                        NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, connect);
                        cmd1.ExecuteNonQuery();
                        connect.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ExecutarNotas()
        {
            NpgsqlConnection connect = new NpgsqlConnection();
            string connection = $"Server=127.0.0.1; Port=5432; Database=testenfe; User Id=postgres; Password=postzeus2011";
            connect.ConnectionString = connection;
            connect.Open();
            string sql1 = $"SELECT DISTINCT ON (chave) numero, serie, modelo, chave FROM nfexml;";
            NpgsqlCommand cmd = new NpgsqlCommand(sql1, connect);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                XmlReaderTeste xmlReaderTeste = new XmlReaderTeste
                {
                    LNumero = reader.GetInt32(0),
                    LModelo = reader.GetInt32(1),
                    LSerie = reader.GetInt32(2),
                    LChave = reader.GetString(3)

                };
                xmlReaderTestes.Add(xmlReaderTeste);
                dataGridNotas.Rows.Add(xmlReaderTeste.LNumero, xmlReaderTeste.LModelo, xmlReaderTeste.LSerie, xmlReaderTeste.LChave);
            }
            reader.Close();
            connect.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ExecutarNotas();
        }
        private void dataGridNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Limpa o segundo DataGridView antes de adicionar os novos produtos
                dataGridProdXML.Rows.Clear();

                // Obtém a chave da linha clicada
                string chaveSelecionada = dataGridNotas.Rows[e.RowIndex].Cells["chaveDgv"].Value.ToString();

                NpgsqlConnection connect = new NpgsqlConnection();
                string connection = "Server=127.0.0.1; Port=5432; Database=testenfe; User Id=postgres; Password=postzeus2011";
                connect.ConnectionString = connection;
                connect.Open();

                // Use a chaveSelecionada na consulta SQL
                string sql = $"SELECT DISTINCT chave, ordem, codproduto, descricaoitem, ncm, cst, valoricms, valoricmsst FROM nfexml WHERE chave = '{chaveSelecionada}' ORDER BY ordem;";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                NpgsqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProdutosXML xmlReaderProd = new ProdutosXML
                    {
                        ChaveXML = reader.GetString(0),
                        Ordem = reader.GetInt32(1),
                        Codproduto = reader.GetString(2),
                        Descricaoitem = reader.GetString(3),
                        Ncm = reader.GetString(4),
                        Cst = reader.GetString(5),
                        Valoricms = reader.GetDecimal(6),
                        ValoricmsST = reader.GetDecimal(7)
                    };
                    xmlReaderProds.Add(xmlReaderProd);
                    dataGridProdXML.Rows.Add(xmlReaderProd.Codproduto, xmlReaderProd.Descricaoitem, xmlReaderProd.Ncm, xmlReaderProd.Cst, xmlReaderProd.Valoricms, xmlReaderProd.ValoricmsST);
                }

                reader.Close();
                connect.Close();
            }
        }
    }
}