namespace DemoINPE {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.txtBuscaLocal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscaLocal = new System.Windows.Forms.Button();
            this.lbxResultadoLocalidade = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbxPrevisao = new System.Windows.Forms.GroupBox();
            this.txtResultadoPrevisao = new System.Windows.Forms.TextBox();
            this.btnObterPrevisao = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodLocalidade = new System.Windows.Forms.TextBox();
            this.txtCidadeSelecionada = new System.Windows.Forms.TextBox();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.lblTituloPrev = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbxPrevisao.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscaLocal
            // 
            this.txtBuscaLocal.Location = new System.Drawing.Point(140, 28);
            this.txtBuscaLocal.Name = "txtBuscaLocal";
            this.txtBuscaLocal.Size = new System.Drawing.Size(264, 20);
            this.txtBuscaLocal.TabIndex = 0;
            this.txtBuscaLocal.TextChanged += new System.EventHandler(this.txtBuscaLocal_TextChanged);
            this.txtBuscaLocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaLocal_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Digite o nome da cidade:";
            // 
            // btnBuscaLocal
            // 
            this.btnBuscaLocal.Enabled = false;
            this.btnBuscaLocal.Location = new System.Drawing.Point(419, 26);
            this.btnBuscaLocal.Name = "btnBuscaLocal";
            this.btnBuscaLocal.Size = new System.Drawing.Size(107, 23);
            this.btnBuscaLocal.TabIndex = 2;
            this.btnBuscaLocal.Text = "Buscar Localidade";
            this.btnBuscaLocal.UseVisualStyleBackColor = true;
            this.btnBuscaLocal.Click += new System.EventHandler(this.btnBuscaLocal_Click);
            // 
            // lbxResultadoLocalidade
            // 
            this.lbxResultadoLocalidade.FormattingEnabled = true;
            this.lbxResultadoLocalidade.Location = new System.Drawing.Point(12, 64);
            this.lbxResultadoLocalidade.Name = "lbxResultadoLocalidade";
            this.lbxResultadoLocalidade.Size = new System.Drawing.Size(514, 147);
            this.lbxResultadoLocalidade.TabIndex = 3;
            this.lbxResultadoLocalidade.SelectedIndexChanged += new System.EventHandler(this.lbxResultadoLocalidade_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxResultadoLocalidade);
            this.groupBox1.Controls.Add(this.txtBuscaLocal);
            this.groupBox1.Controls.Add(this.btnBuscaLocal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 226);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Localidade";
            // 
            // gbxPrevisao
            // 
            this.gbxPrevisao.Controls.Add(this.lblTituloPrev);
            this.gbxPrevisao.Controls.Add(this.txtResultadoPrevisao);
            this.gbxPrevisao.Controls.Add(this.btnObterPrevisao);
            this.gbxPrevisao.Controls.Add(this.label3);
            this.gbxPrevisao.Controls.Add(this.label2);
            this.gbxPrevisao.Controls.Add(this.txtCodLocalidade);
            this.gbxPrevisao.Controls.Add(this.txtCidadeSelecionada);
            this.gbxPrevisao.Controls.Add(this.cmbPeriodo);
            this.gbxPrevisao.Location = new System.Drawing.Point(12, 244);
            this.gbxPrevisao.Name = "gbxPrevisao";
            this.gbxPrevisao.Size = new System.Drawing.Size(536, 271);
            this.gbxPrevisao.TabIndex = 5;
            this.gbxPrevisao.TabStop = false;
            this.gbxPrevisao.Text = "Previsão do Tempo";
            this.gbxPrevisao.Visible = false;
            this.gbxPrevisao.VisibleChanged += new System.EventHandler(this.gbxPrevisao_VisibleChanged);
            // 
            // txtResultadoPrevisao
            // 
            this.txtResultadoPrevisao.Location = new System.Drawing.Point(12, 117);
            this.txtResultadoPrevisao.Multiline = true;
            this.txtResultadoPrevisao.Name = "txtResultadoPrevisao";
            this.txtResultadoPrevisao.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultadoPrevisao.Size = new System.Drawing.Size(514, 135);
            this.txtResultadoPrevisao.TabIndex = 8;
            // 
            // btnObterPrevisao
            // 
            this.btnObterPrevisao.Enabled = false;
            this.btnObterPrevisao.Location = new System.Drawing.Point(286, 69);
            this.btnObterPrevisao.Name = "btnObterPrevisao";
            this.btnObterPrevisao.Size = new System.Drawing.Size(156, 23);
            this.btnObterPrevisao.TabIndex = 7;
            this.btnObterPrevisao.Text = "Obter Previsao do Tempo";
            this.btnObterPrevisao.UseVisualStyleBackColor = true;
            this.btnObterPrevisao.Click += new System.EventHandler(this.btnObterPrevisao_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cidade selecionada:";
            // 
            // txtCodLocalidade
            // 
            this.txtCodLocalidade.Location = new System.Drawing.Point(426, 32);
            this.txtCodLocalidade.Name = "txtCodLocalidade";
            this.txtCodLocalidade.Size = new System.Drawing.Size(100, 20);
            this.txtCodLocalidade.TabIndex = 2;
            // 
            // txtCidadeSelecionada
            // 
            this.txtCidadeSelecionada.Location = new System.Drawing.Point(109, 32);
            this.txtCidadeSelecionada.Name = "txtCidadeSelecionada";
            this.txtCidadeSelecionada.Size = new System.Drawing.Size(242, 20);
            this.txtCidadeSelecionada.TabIndex = 1;
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Items.AddRange(new object[] {
            "Previsão para 4 dias",
            "Previsão para 7 dias",
            "Previsão estendida (semana posterior a previsão para 7 dias)"});
            this.cmbPeriodo.Location = new System.Drawing.Point(12, 69);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(268, 21);
            this.cmbPeriodo.TabIndex = 0;
            this.cmbPeriodo.Text = "Selecione o período de previsão para a tempo...";
            this.cmbPeriodo.SelectionChangeCommitted += new System.EventHandler(this.cmbPeriodo_SelectionChangeCommitted);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.Location = new System.Drawing.Point(10, 298);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(537, 94);
            this.lblAviso.TabIndex = 9;
            this.lblAviso.Text = "PESQUISE A LOCALIDADE PARA \r\nOBTER A PREVISÃO DO TEMPO";
            this.lblAviso.VisibleChanged += new System.EventHandler(this.lblAviso_VisibleChanged);
            // 
            // lblTituloPrev
            // 
            this.lblTituloPrev.AutoSize = true;
            this.lblTituloPrev.Location = new System.Drawing.Point(9, 101);
            this.lblTituloPrev.Name = "lblTituloPrev";
            this.lblTituloPrev.Size = new System.Drawing.Size(0, 13);
            this.lblTituloPrev.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 527);
            this.Controls.Add(this.gbxPrevisao);
            this.Controls.Add(this.lblAviso);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxPrevisao.ResumeLayout(false);
            this.gbxPrevisao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscaLocal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscaLocal;
        private System.Windows.Forms.ListBox lbxResultadoLocalidade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbxPrevisao;
        private System.Windows.Forms.TextBox txtResultadoPrevisao;
        private System.Windows.Forms.Button btnObterPrevisao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodLocalidade;
        private System.Windows.Forms.TextBox txtCidadeSelecionada;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label lblTituloPrev;
    }
}

