using System.Xml.Serialization;
using System.Xml;
using Npgsql;


namespace Nfe
{
    public partial class Form1 : Form
    {
        List<XmlReaderTeste> xmlReaderTestes = new List<XmlReaderTeste>();
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
                }
                MessageBox.Show("Dados inseridos com sucesso!");
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
                    string Descricao = item.prod.xProd; // Acessar a descrição do produto (exemplo)
                    decimal valorTotal = item.prod.vProd; // Acessar o valor total do item (exemplo)
                    string NCM = item.prod.NCM;
                    string Chave = nota.protNFe.infProt.chNFe.ToString();
                    int Numero = nota.NFe.infNFe.ide.nNF;
                    int Serie = nota.NFe.infNFe.ide.serie;
                    int Modelo = nota.NFe.infNFe.ide.mod;
                    // Variáveis para armazenar os valores de ICMS
                    decimal valorICMS = 0;
                    int codCST = 90;
                    int ordemID = item.nItem;
                    string CodProd = item.prod.cProd;
                    // Verificar se o ICMS está presente e acessar o valor
                    if (item.imposto.ICMS != null)
                    {
                        if (item.imposto.ICMS.ICMS00 != null)
                        {
                            valorICMS = item.imposto.ICMS.ICMS00.vICMS;
                            codCST = item.imposto.ICMS.ICMS00.CST;
                        }
                        else if (item.imposto.ICMS.ICMS10 != null)
                        {
                            valorICMS = item.imposto.ICMS.ICMS10.vICMS;
                            codCST = item.imposto.ICMS.ICMS10.CST;
                        }
                        else if (item.imposto.ICMS.ICMS40 != null)
                        {
                            codCST = item.imposto.ICMS.ICMS40.CST;
                        }
                        else if (item.imposto.ICMS.ICMS60 != null)
                        {
                            codCST = item.imposto.ICMS.ICMS60.CST;
                        }
                        // Adicione mais condições conforme necessário para outros tipos de ICMS
                        //}

                        listView1.Items.Add(new ListViewItem(new[] { Numero.ToString(), Serie.ToString(), Modelo.ToString(), Chave }));


                        // Montar uma string com as informações do item e dos impostos
                        string itemInfo = $"Item: {ordemID} - Chave {Chave} - {Descricao} - NCM: {NCM} - Total: R${valorTotal} - CST {codCST} - ICMS: R${valorICMS}";
                        // Adicionar a string à ListBox                                        
                        NpgsqlConnection connect = new NpgsqlConnection();
                        string connection1 = $"Server=127.0.0.1; Port=5432; Database=testenfe; User Id=postgres; Password=postzeus2011";
                        connect.ConnectionString = connection1;
                        connect.Open();
                        string sql1 = $"INSERT INTO public.nfexml(numero, serie, modelo, chave, codproduto, ordem, descricaoitem, ncm, cst, valortotal, valoricms) " +
                            $"VALUES({Numero}, {Serie}, {Modelo}, '{Chave}', '{CodProd}', {ordemID}, '{Descricao}', '{NCM}', {codCST}, REPLACE('{valorTotal.ToString()}',',','.')::numeric, REPLACE('{valorICMS.ToString()}',',','.')::numeric);";
                        NpgsqlCommand cmd1 = new NpgsqlCommand(sql1, connect);
                        cmd1.ExecuteNonQuery();
                        connect.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na desserialização do XML: " + ex.Message);
            }
        }
    }
}