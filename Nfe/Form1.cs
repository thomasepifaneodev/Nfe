using System.Xml.Serialization;
using System.Xml;

namespace Nfe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string arquivoXML in openFileDialog.FileNames)
                {
                    // Chame uma função para processar o arquivo XML selecionado
                    ProcessarArquivoXML(arquivoXML);
                }
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
                    string descricao = item.prod.xProd; // Acessar a descrição do produto (exemplo)
                    decimal valorTotal = item.prod.vProd; // Acessar o valor total do item (exemplo)
                    uint NCM = item.prod.NCM;
                    string Chave = nota.protNFe.infProt.chNFe.ToString();

                    // Variáveis para armazenar os valores de ICMS
                    decimal valorICMS = 0;
                    int codCST = 90;

                    // Verificar se o ICMS está presente e acessar o valor
                    if (item.imposto.ICMS != null)
                    {
                        if (item.imposto.ICMS.ICMS00 != null)
                        {
                            valorICMS = item.imposto.ICMS.ICMS00.vICMS;
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
                    }

                    // Montar uma string com as informações do item e dos impostos
                    string itemInfo = $"Chave {Chave} - {descricao} - NCM: {NCM} - Total: R${valorTotal}, ICMS: R${valorICMS}";

                    // Adicionar a string à ListBox
                    listBox1.Items.Add(itemInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na desserialização do XML: " + ex.Message);
            }
        }
    }
}