namespace Nfe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listView1 = new ListView();
            numero = new ColumnHeader();
            serie = new ColumnHeader();
            modelo = new ColumnHeader();
            chave = new ColumnHeader();
            listView2 = new ListView();
            codprod = new ColumnHeader();
            descricao = new ColumnHeader();
            ncm = new ColumnHeader();
            vicms = new ColumnHeader();
            cst = new ColumnHeader();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(832, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Importar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { numero, serie, modelo, chave });
            listView1.Location = new Point(12, 60);
            listView1.Name = "listView1";
            listView1.Size = new Size(806, 188);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // numero
            // 
            numero.Text = "Número";
            numero.Width = 75;
            // 
            // serie
            // 
            serie.Text = "Serie";
            // 
            // modelo
            // 
            modelo.Text = "Modelo";
            // 
            // chave
            // 
            chave.Text = "Chave";
            chave.Width = 230;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { codprod, descricao, ncm, vicms, cst });
            listView2.Location = new Point(12, 254);
            listView2.Name = "listView2";
            listView2.Size = new Size(806, 188);
            listView2.TabIndex = 2;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // codprod
            // 
            codprod.Text = "Código";
            codprod.Width = 75;
            // 
            // descricao
            // 
            descricao.Text = "Descrição";
            descricao.Width = 150;
            // 
            // ncm
            // 
            ncm.Text = "NCM";
            // 
            // vicms
            // 
            vicms.Text = "Valor ICMS";
            vicms.Width = 90;
            // 
            // cst
            // 
            cst.Text = "CST";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 451);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListView listView1;
        private ColumnHeader numero;
        private ColumnHeader serie;
        private ColumnHeader modelo;
        private ColumnHeader chave;
        private ListView listView2;
        private ColumnHeader codprod;
        private ColumnHeader descricao;
        private ColumnHeader ncm;
        private ColumnHeader vicms;
        private ColumnHeader cst;
    }
}