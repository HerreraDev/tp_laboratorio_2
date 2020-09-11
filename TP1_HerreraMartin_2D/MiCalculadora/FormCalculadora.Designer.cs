namespace MiCalculadora
{
    partial class FormCalculadora
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
            this.txt_Num1 = new System.Windows.Forms.TextBox();
            this.txt_Num2 = new System.Windows.Forms.TextBox();
            this.cmbOperadores = new System.Windows.Forms.ComboBox();
            this.btn_Operar = new System.Windows.Forms.Button();
            this.btn_Limpiar = new System.Windows.Forms.Button();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.btn_DecToBin = new System.Windows.Forms.Button();
            this.btn_BinToDec = new System.Windows.Forms.Button();
            this.lbl_Resultado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Num1
            // 
            this.txt_Num1.Location = new System.Drawing.Point(24, 36);
            this.txt_Num1.Name = "txt_Num1";
            this.txt_Num1.Size = new System.Drawing.Size(119, 20);
            this.txt_Num1.TabIndex = 0;
            // 
            // txt_Num2
            // 
            this.txt_Num2.Location = new System.Drawing.Point(262, 37);
            this.txt_Num2.Name = "txt_Num2";
            this.txt_Num2.Size = new System.Drawing.Size(100, 20);
            this.txt_Num2.TabIndex = 2;
            // 
            // cmbOperadores
            // 
            this.cmbOperadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperadores.FormattingEnabled = true;
            this.cmbOperadores.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.cmbOperadores.Location = new System.Drawing.Point(177, 36);
            this.cmbOperadores.Name = "cmbOperadores";
            this.cmbOperadores.Size = new System.Drawing.Size(52, 21);
            this.cmbOperadores.TabIndex = 1;
            // 
            // btn_Operar
            // 
            this.btn_Operar.Location = new System.Drawing.Point(24, 83);
            this.btn_Operar.Name = "btn_Operar";
            this.btn_Operar.Size = new System.Drawing.Size(119, 23);
            this.btn_Operar.TabIndex = 3;
            this.btn_Operar.Text = "Operar";
            this.btn_Operar.UseVisualStyleBackColor = true;
            // 
            // btn_Limpiar
            // 
            this.btn_Limpiar.Location = new System.Drawing.Point(149, 83);
            this.btn_Limpiar.Name = "btn_Limpiar";
            this.btn_Limpiar.Size = new System.Drawing.Size(107, 23);
            this.btn_Limpiar.TabIndex = 4;
            this.btn_Limpiar.Text = "Limpiar";
            this.btn_Limpiar.UseVisualStyleBackColor = true;
            this.btn_Limpiar.Click += new System.EventHandler(this.btn_Limpiar_Click);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.Location = new System.Drawing.Point(262, 83);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(100, 23);
            this.btn_Cerrar.TabIndex = 5;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.UseVisualStyleBackColor = true;
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // btn_DecToBin
            // 
            this.btn_DecToBin.Location = new System.Drawing.Point(24, 132);
            this.btn_DecToBin.Name = "btn_DecToBin";
            this.btn_DecToBin.Size = new System.Drawing.Size(178, 34);
            this.btn_DecToBin.TabIndex = 6;
            this.btn_DecToBin.Text = "Convertir a Binario";
            this.btn_DecToBin.UseVisualStyleBackColor = true;
            // 
            // btn_BinToDec
            // 
            this.btn_BinToDec.Location = new System.Drawing.Point(208, 132);
            this.btn_BinToDec.Name = "btn_BinToDec";
            this.btn_BinToDec.Size = new System.Drawing.Size(154, 34);
            this.btn_BinToDec.TabIndex = 7;
            this.btn_BinToDec.Text = "Convertir a Decimal";
            this.btn_BinToDec.UseVisualStyleBackColor = true;
            // 
            // lbl_Resultado
            // 
            this.lbl_Resultado.AutoSize = true;
            this.lbl_Resultado.Location = new System.Drawing.Point(327, 6);
            this.lbl_Resultado.Name = "lbl_Resultado";
            this.lbl_Resultado.Size = new System.Drawing.Size(35, 13);
            this.lbl_Resultado.TabIndex = 8;
            this.lbl_Resultado.Text = "label1";
            // 
            // FormCalculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 197);
            this.Controls.Add(this.lbl_Resultado);
            this.Controls.Add(this.btn_BinToDec);
            this.Controls.Add(this.btn_DecToBin);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.btn_Limpiar);
            this.Controls.Add(this.btn_Operar);
            this.Controls.Add(this.cmbOperadores);
            this.Controls.Add(this.txt_Num2);
            this.Controls.Add(this.txt_Num1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCalculadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Martín Herrera del curso 2ºD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Num1;
        private System.Windows.Forms.TextBox txt_Num2;
        private System.Windows.Forms.ComboBox cmbOperadores;
        private System.Windows.Forms.Button btn_Operar;
        private System.Windows.Forms.Button btn_Limpiar;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Button btn_DecToBin;
        private System.Windows.Forms.Button btn_BinToDec;
        private System.Windows.Forms.Label lbl_Resultado;
    }
}

