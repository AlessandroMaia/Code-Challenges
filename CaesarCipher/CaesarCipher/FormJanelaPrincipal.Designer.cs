namespace CaesarCipher
{
    partial class FormJanelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnRequisitarJson = new System.Windows.Forms.Button();
            this.txtJsonOriginal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDescriptografar = new System.Windows.Forms.Button();
            this.txtJsonDescriptografado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnEnviarArquivo = new System.Windows.Forms.Button();
            this.btnResumoCriptografico = new System.Windows.Forms.Button();
            this.txtJsonFinalizado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(382, 254);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnRequisitarJson);
            this.tabPage1.Controls.Add(this.txtJsonOriginal);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(374, 228);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Etapa 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRequisitarJson
            // 
            this.btnRequisitarJson.Location = new System.Drawing.Point(6, 198);
            this.btnRequisitarJson.Name = "btnRequisitarJson";
            this.btnRequisitarJson.Size = new System.Drawing.Size(363, 23);
            this.btnRequisitarJson.TabIndex = 2;
            this.btnRequisitarJson.Text = "Requisitar e Salvar Arquivo";
            this.btnRequisitarJson.UseVisualStyleBackColor = true;
            this.btnRequisitarJson.Click += new System.EventHandler(this.btnRequisitarJson_Click);
            // 
            // txtJsonOriginal
            // 
            this.txtJsonOriginal.Location = new System.Drawing.Point(6, 23);
            this.txtJsonOriginal.Multiline = true;
            this.txtJsonOriginal.Name = "txtJsonOriginal";
            this.txtJsonOriginal.ReadOnly = true;
            this.txtJsonOriginal.Size = new System.Drawing.Size(363, 169);
            this.txtJsonOriginal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "JSON original";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDescriptografar);
            this.tabPage2.Controls.Add(this.txtJsonDescriptografado);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(374, 228);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Etapa 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDescriptografar
            // 
            this.btnDescriptografar.Location = new System.Drawing.Point(6, 198);
            this.btnDescriptografar.Name = "btnDescriptografar";
            this.btnDescriptografar.Size = new System.Drawing.Size(363, 23);
            this.btnDescriptografar.TabIndex = 3;
            this.btnDescriptografar.Text = "Descriptografar e Salvar Arquivo";
            this.btnDescriptografar.UseVisualStyleBackColor = true;
            this.btnDescriptografar.Click += new System.EventHandler(this.btnDescriptografar_Click);
            // 
            // txtJsonDescriptografado
            // 
            this.txtJsonDescriptografado.Location = new System.Drawing.Point(6, 23);
            this.txtJsonDescriptografado.Multiline = true;
            this.txtJsonDescriptografado.Name = "txtJsonDescriptografado";
            this.txtJsonDescriptografado.ReadOnly = true;
            this.txtJsonDescriptografado.Size = new System.Drawing.Size(363, 169);
            this.txtJsonDescriptografado.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "JSON descriptografado";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnEnviarArquivo);
            this.tabPage3.Controls.Add(this.btnResumoCriptografico);
            this.tabPage3.Controls.Add(this.txtJsonFinalizado);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(374, 228);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Etapa 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnEnviarArquivo
            // 
            this.btnEnviarArquivo.Location = new System.Drawing.Point(249, 198);
            this.btnEnviarArquivo.Name = "btnEnviarArquivo";
            this.btnEnviarArquivo.Size = new System.Drawing.Size(117, 23);
            this.btnEnviarArquivo.TabIndex = 8;
            this.btnEnviarArquivo.Text = "Enviar";
            this.btnEnviarArquivo.UseVisualStyleBackColor = true;
            this.btnEnviarArquivo.Click += new System.EventHandler(this.btnEnviarArquivo_Click);
            // 
            // btnResumoCriptografico
            // 
            this.btnResumoCriptografico.Location = new System.Drawing.Point(6, 198);
            this.btnResumoCriptografico.Name = "btnResumoCriptografico";
            this.btnResumoCriptografico.Size = new System.Drawing.Size(237, 23);
            this.btnResumoCriptografico.TabIndex = 6;
            this.btnResumoCriptografico.Text = "Aplicar resumo criptográfico e Salvar Arquivo";
            this.btnResumoCriptografico.UseVisualStyleBackColor = true;
            this.btnResumoCriptografico.Click += new System.EventHandler(this.btnResumoCriptografico_Click);
            // 
            // txtJsonFinalizado
            // 
            this.txtJsonFinalizado.Location = new System.Drawing.Point(6, 23);
            this.txtJsonFinalizado.Multiline = true;
            this.txtJsonFinalizado.Name = "txtJsonFinalizado";
            this.txtJsonFinalizado.ReadOnly = true;
            this.txtJsonFinalizado.Size = new System.Drawing.Size(363, 169);
            this.txtJsonFinalizado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "JSON com resumo criptografico";
            // 
            // FormJanelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormJanelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criptografia Codenation";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnRequisitarJson;
        private System.Windows.Forms.TextBox txtJsonOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDescriptografar;
        private System.Windows.Forms.TextBox txtJsonDescriptografado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnResumoCriptografico;
        private System.Windows.Forms.TextBox txtJsonFinalizado;
        private System.Windows.Forms.Button btnEnviarArquivo;
    }
}