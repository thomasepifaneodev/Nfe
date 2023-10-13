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
                MessageBox.Show("Erro na importa��o do XML: " + ex.Message);
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
                    string Descricao = item.prod.xProd; // Acessar a descri��o do produto (exemplo)
                    decimal valorTotal = item.prod.vProd; // Acessar o valor total do item (exemplo)
                    string NCM = item.prod.NCM;
                    string Chave = nota.protNFe.infProt.chNFe.ToString();
                    int Numero = nota.NFe.infNFe.ide.nNF;
                    int Serie = nota.NFe.infNFe.ide.serie;
                    int Modelo = nota.NFe.infNFe.ide.mod;
                    // Vari�veis para armazenar os valores de ICMS
                    decimal valorICMS = 0;
                    decimal valorICMSST = 0;
                    int codCST = 90;
                    int ordemID = item.nItem;
                    string CodProd = item.prod.cProd;
                    // Verificar se o ICMS est� presente e acessar o valor
                    if (item.imposto.ICMS != null)
                    {
                        if (item.imposto.ICMS.ICMS00 != null)
                        {
                            valorICMS = item.imposto.ICMS.ICMS00.vICMS;
                            codCST = item.imposto.ICMS.ICMS00.CST;
                            valorICMSST = item.imposto.ICMS.ICMS00.vICMSST;
                        }
                        else if (item.imposto.ICMS.ICMS10 != null)
                        {
                            valorICMS = item.imposto.ICMS.ICMS10.vICMS;
                            codCST = item.imposto.ICMS.ICMS10.CST;
                            valorICMSST = item.imposto.ICMS.ICMS10.vICMSST;
                        }
                        else if (item.imposto.ICMS.ICMS40 != null)
                        {
                            codCST = item.imposto.ICMS.ICMS40.CST;
                        }
                        else if (item.imposto.ICMS.ICMS60 != null)
                        {
                            codCST = item.imposto.ICMS.ICMS60.CST;
                        }
                        NpgsqlConnection connect = new NpgsqlConnection();
                        string connection1 = $"Server=127.0.0.1; Port=5432; Database=testenfe; User Id=postgres; Password=postzeus2011";
                        connect.ConnectionString = connection1;
                        connect.Open();
                        string sql1 = $"INSERT INTO public.nfexml(numero, serie, modelo, chave, codproduto, ordem, descricaoitem, ncm, cst, valortotal, valoricms, valoricmsst) " +
                            $"VALUES({Numero}, {Serie}, {Modelo}, '{Chave}', '{CodProd}', {ordemID}, '{Descricao}', '{NCM}', {codCST}, REPLACE('{valorTotal.ToString()}',',','.')::numeric, REPLACE('{valorICMS.ToString()}',',','.')::numeric, REPLACE('{valorICMSST.ToString()}',',','.')::numeric);";
                        NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, connect);
                        cmd1.ExecuteNonQuery();
                        connect.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na desserializa��o do XML: " + ex.Message);
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

                // Obt�m a chave da linha clicada
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
                        Cst = reader.GetInt32(5).ToString(),
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