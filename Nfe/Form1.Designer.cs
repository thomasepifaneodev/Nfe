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
            cfopDgv = new DataGridViewTextBoxColumn();
            cstDgvXML = new DataGridViewTextBoxColumn();
            vlTotalProd = new DataGridViewTextBoxColumn();
            aliquotaDgv = new DataGridViewTextBoxColumn();
            vlIcmsDgvXML = new DataGridViewTextBoxColumn();
            vlIcmsstDgvXML = new DataGridViewTextBoxColumn();
            cestCodigo = new DataGridViewTextBoxColumn();
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridNotas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProdXML).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1138, 659);
            button1.Name = "button1";
            button1.Size = new Size(90, 23);
            button1.TabIndex = 0;
            button1.Text = "Importar XML";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1234, 659);
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
            dataGridNotas.Location = new Point(12, 14);
            dataGridNotas.Name = "dataGridNotas";
            dataGridNotas.ReadOnly = true;
            dataGridNotas.RowTemplate.Height = 25;
            dataGridNotas.Size = new Size(1099, 190);
            dataGridNotas.TabIndex = 4;
            dataGridNotas.CellClick += dataGridNotas_CellClick;
            // 
            // numeroDgv
            // 
            numeroDgv.HeaderText = "Número";
            numeroDgv.Name = "numeroDgv";
            numeroDgv.ReadOnly = true;
            numeroDgv.Width = 75;
            // 
            // serieDgv
            // 
            serieDgv.HeaderText = "Serie";
            serieDgv.Name = "serieDgv";
            serieDgv.ReadOnly = true;
            serieDgv.Width = 60;
            // 
            // modeloDgv
            // 
            modeloDgv.HeaderText = "Modelo";
            modeloDgv.Name = "modeloDgv";
            modeloDgv.ReadOnly = true;
            modeloDgv.Width = 75;
            // 
            // chaveDgv
            // 
            chaveDgv.HeaderText = "Chave";
            chaveDgv.Name = "chaveDgv";
            chaveDgv.ReadOnly = true;
            chaveDgv.Width = 300;
            // 
            // dataGridProdXML
            // 
            dataGridProdXML.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProdXML.Columns.AddRange(new DataGridViewColumn[] { codigoDgvXML, descricaoDgvXML, ncmDgvXML, cfopDgv, cstDgvXML, vlTotalProd, aliquotaDgv, vlIcmsDgvXML, vlIcmsstDgvXML, cestCodigo });
            dataGridProdXML.Location = new Point(12, 210);
            dataGridProdXML.Name = "dataGridProdXML";
            dataGridProdXML.ReadOnly = true;
            dataGridProdXML.RowTemplate.Height = 25;
            dataGridProdXML.Size = new Size(1099, 233);
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
            // cfopDgv
            // 
            cfopDgv.HeaderText = "CFOP";
            cfopDgv.Name = "cfopDgv";
            cfopDgv.ReadOnly = true;
            // 
            // cstDgvXML
            // 
            cstDgvXML.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            cstDgvXML.HeaderText = "CST";
            cstDgvXML.Name = "cstDgvXML";
            cstDgvXML.ReadOnly = true;
            // 
            // vlTotalProd
            // 
            vlTotalProd.HeaderText = "Valor Total";
            vlTotalProd.Name = "vlTotalProd";
            vlTotalProd.ReadOnly = true;
            // 
            // aliquotaDgv
            // 
            aliquotaDgv.HeaderText = "Alíquota";
            aliquotaDgv.Name = "aliquotaDgv";
            aliquotaDgv.ReadOnly = true;
            // 
            // vlIcmsDgvXML
            // 
            vlIcmsDgvXML.HeaderText = "Valor ICMS";
            vlIcmsDgvXML.Name = "vlIcmsDgvXML";
            vlIcmsDgvXML.ReadOnly = true;
            // 
            // vlIcmsstDgvXML
            // 
            vlIcmsstDgvXML.HeaderText = "Valor ICMS ST";
            vlIcmsstDgvXML.Name = "vlIcmsstDgvXML";
            vlIcmsstDgvXML.ReadOnly = true;
            // 
            // cestCodigo
            // 
            cestCodigo.HeaderText = "CEST";
            cestCodigo.Name = "cestCodigo";
            cestCodigo.ReadOnly = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridView1.Location = new Point(12, 449);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1099, 233);
            dataGridView1.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 185;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "NCM";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewTextBoxColumn4.HeaderText = "CST";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Valor ICMS";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1350, 729);
            Controls.Add(dataGridView1);
            Controls.Add(dataGridProdXML);
            Controls.Add(dataGridNotas);
            Controls.Add(button2);
            Controls.Add(button1);
            MinimumSize = new Size(720, 480);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridNotas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProdXML).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dataGridNotas;
        private DataGridView dataGridProdXML;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn numeroDgv;
        private DataGridViewTextBoxColumn serieDgv;
        private DataGridViewTextBoxColumn modeloDgv;
        private DataGridViewTextBoxColumn chaveDgv;
        private DataGridViewTextBoxColumn codigoDgvXML;
        private DataGridViewTextBoxColumn descricaoDgvXML;
        private DataGridViewTextBoxColumn ncmDgvXML;
        private DataGridViewTextBoxColumn cfopDgv;
        private DataGridViewTextBoxColumn cstDgvXML;
        private DataGridViewTextBoxColumn vlTotalProd;
        private DataGridViewTextBoxColumn aliquotaDgv;
        private DataGridViewTextBoxColumn vlIcmsDgvXML;
        private DataGridViewTextBoxColumn vlIcmsstDgvXML;
        private DataGridViewTextBoxColumn cestCodigo;
    }
}