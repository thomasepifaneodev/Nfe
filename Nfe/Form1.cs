using System.Xml.Serialization;
using System.Xml;
using Npgsql;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Nfe
{
    public class XmlReaderTeste
    {
        public int Numero { get; set; }
        public int Serie { get; set; }
        public int Modelo { get; set; }
        public string? Chave { get; set; }
        public string? Codproduto { get; set; }
        public int Ordem { get; set; }
        public string? Descricaoitem { get; set; }
        public string? Ncm { get; set; }
        public int Cst { get; set; }
        public decimal Valortotal { get; set; }
        public decimal Valoricms { get; set; }
    }
    public partial class Form1 : Form
    {
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
                    }

                    // Montar uma string com as informações do item e dos impostos
                    string itemInfo = $"Item: {ordemID} - Chave {Chave} - {Descricao} - NCM: {NCM} - Total: R${valorTotal} - CST {codCST} - ICMS: R${valorICMS}";

                    // Adicionar a string à ListBox
                    listBox1.Items.Add(itemInfo);
                    //InsertXML(Numero, Serie, Modelo, Chave, CodProd, ordemID, Descricao, NCM, codCST, valorTotal, valorICMS);
                    NpgsqlConnection connect = new NpgsqlConnection();
                    string connection = $"Server=127.0.0.1; Port=5432; Database=testenfe; User Id=postgres; Password=postzeus2011";
                    connect.ConnectionString = connection;
                    connect.Open();
                    string sql = $"INSERT INTO public.nfexml(numero, serie, modelo, chave, codproduto, ordem, descricaoitem, ncm, cst, valortotal, valoricms) " +
                        $"VALUES({Numero}, {Serie}, {Modelo}, '{Chave}', '{CodProd}', {ordemID}, '{Descricao}', '{NCM}', {codCST}, REPLACE('{valorTotal.ToString()}',',','.')::numeric, REPLACE('{valorICMS.ToString()}',',','.')::numeric);";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na desserialização do XML: " + ex.Message);
            }
        }
    }
}