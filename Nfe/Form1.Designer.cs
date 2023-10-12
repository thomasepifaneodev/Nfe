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
            button2 = new Button();
            dataGridNotas = new DataGridView();
            numeroDgv = new DataGridViewTextBoxColumn();
            serieDgv = new DataGridViewTextBoxColumn();
            modeloDgv = new DataGridViewTextBoxColumn();
            chaveDgv = new DataGridViewTextBoxColumn();
            dataGridProdXML = new DataGridView();
            codigoDgvXML = new DataGridViewTextBoxColumn();
            descricaoDgvXML = new DataGridViewTextBoxColumn();
            ncmDgvXML = new DataGridViewTextBoxColumn();
            cstDgvXML = new DataGridViewTextBoxColumn();
            vlIcmsDgvXML = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridNotas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProdXML).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1087, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Importar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1087, 419);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Checar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridNotas
            // 
            dataGridNotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridNotas.Columns.AddRange(new DataGridViewColumn[] { numeroDgv, serieDgv, modeloDgv, chaveDgv });
            dataGridNotas.Location = new Point(12, 12);
            dataGridNotas.Name = "dataGridNotas";
            dataGridNotas.ReadOnly = true;
            dataGridNotas.RowTemplate.Height = 25;
            dataGridNotas.Size = new Size(598, 225);
            dataGridNotas.TabIndex = 4;
            dataGridNotas.CellClick += dataGridNotas_CellClick;
            // 
            // numeroDgv
            // 
            numeroDgv.HeaderText = "Número";
            numeroDgv.Name = "numeroDgv";
            numeroDgv.ReadOnly = true;
            numeroDgv.Width = 95;
            // 
            // serieDgv
            // 
            serieDgv.HeaderText = "Serie";
            serieDgv.Name = "serieDgv";
            serieDgv.ReadOnly = true;
            // 
            // modeloDgv
            // 
            modeloDgv.HeaderText = "Modelo";
            modeloDgv.Name = "modeloDgv";
            modeloDgv.ReadOnly = true;
            // 
            // chaveDgv
            // 
            chaveDgv.HeaderText = "Chave";
            chaveDgv.Name = "chaveDgv";
            chaveDgv.ReadOnly = true;
            chaveDgv.Width = 260;
            // 
            // dataGridProdXML
            // 
            dataGridProdXML.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProdXML.Columns.AddRange(new DataGridViewColumn[] { codigoDgvXML, descricaoDgvXML, ncmDgvXML, cstDgvXML, vlIcmsDgvXML });
            dataGridProdXML.Location = new Point(12, 256);
            dataGridProdXML.Name = "dataGridProdXML";
            dataGridProdXML.ReadOnly = true;
            dataGridProdXML.RowTemplate.Height = 25;
            dataGridProdXML.Size = new Size(598, 264);
            dataGridProdXML.TabIndex = 5;
            // 
            // codigoDgvXML
            // 
            codigoDgvXML.HeaderText = "Código";
            codigoDgvXML.Name = "codigoDgvXML";
            codigoDgvXML.ReadOnly = true;
            codigoDgvXML.Width = 70;
            // 
            // descricaoDgvXML
            // 
            descricaoDgvXML.HeaderText = "Descrição";
            descricaoDgvXML.Name = "descricaoDgvXML";
            descricaoDgvXML.ReadOnly = true;
            descricaoDgvXML.Width = 185;
            // 
            // ncmDgvXML
            // 
            ncmDgvXML.HeaderText = "NCM";
            ncmDgvXML.Name = "ncmDgvXML";
            ncmDgvXML.ReadOnly = true;
            // 
            // cstDgvXML
            // 
            cstDgvXML.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cstDgvXML.HeaderText = "CST";
            cstDgvXML.Name = "cstDgvXML";
            cstDgvXML.ReadOnly = true;
            // 
            // vlIcmsDgvXML
            // 
            vlIcmsDgvXML.HeaderText = "Valor ICMS";
            vlIcmsDgvXML.Name = "vlIcmsDgvXML";
            vlIcmsDgvXML.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 532);
            Controls.Add(dataGridProdXML);
            Controls.Add(dataGridNotas);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridNotas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProdXML).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dataGridNotas;
        private DataGridView dataGridProdXML;
        private DataGridViewTextBoxColumn codigoDgvXML;
        private DataGridViewTextBoxColumn descricaoDgvXML;
        private DataGridViewTextBoxColumn ncmDgvXML;
        private DataGridViewTextBoxColumn cstDgvXML;
        private DataGridViewTextBoxColumn vlIcmsDgvXML;
        private DataGridViewTextBoxColumn numeroDgv;
        private DataGridViewTextBoxColumn serieDgv;
        private DataGridViewTextBoxColumn modeloDgv;
        private DataGridViewTextBoxColumn chaveDgv;
    }
}