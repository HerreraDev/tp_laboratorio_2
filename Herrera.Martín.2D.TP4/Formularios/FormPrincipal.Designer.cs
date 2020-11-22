namespace Formularios
{
    partial class FormPrincipal
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
            this.dtgSoftware = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Refrescar = new System.Windows.Forms.Button();
            this.btn_CancelarRefresco = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgHardware = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Software = new System.Windows.Forms.Button();
            this.btn_Hardware = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSoftware)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHardware)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgSoftware
            // 
            this.dtgSoftware.AllowUserToAddRows = false;
            this.dtgSoftware.AllowUserToDeleteRows = false;
            this.dtgSoftware.AllowUserToResizeColumns = false;
            this.dtgSoftware.AllowUserToResizeRows = false;
            this.dtgSoftware.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgSoftware.BackgroundColor = System.Drawing.Color.Peru;
            this.dtgSoftware.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgSoftware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSoftware.GridColor = System.Drawing.Color.MistyRose;
            this.dtgSoftware.Location = new System.Drawing.Point(439, 90);
            this.dtgSoftware.Name = "dtgSoftware";
            this.dtgSoftware.ReadOnly = true;
            this.dtgSoftware.RowHeadersVisible = false;
            this.dtgSoftware.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSoftware.Size = new System.Drawing.Size(412, 135);
            this.dtgSoftware.TabIndex = 0;
            this.dtgSoftware.DoubleClick += new System.EventHandler(this.dtgProductos_DoubleClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(435, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Refrescar
            // 
            this.btn_Refrescar.Location = new System.Drawing.Point(439, 401);
            this.btn_Refrescar.Name = "btn_Refrescar";
            this.btn_Refrescar.Size = new System.Drawing.Size(75, 37);
            this.btn_Refrescar.TabIndex = 2;
            this.btn_Refrescar.Text = "Comenzar a refrescar";
            this.btn_Refrescar.UseVisualStyleBackColor = true;
            this.btn_Refrescar.Click += new System.EventHandler(this.btn_Refrescar_Click);
            // 
            // btn_CancelarRefresco
            // 
            this.btn_CancelarRefresco.Location = new System.Drawing.Point(520, 401);
            this.btn_CancelarRefresco.Name = "btn_CancelarRefresco";
            this.btn_CancelarRefresco.Size = new System.Drawing.Size(75, 37);
            this.btn_CancelarRefresco.TabIndex = 3;
            this.btn_CancelarRefresco.Text = "Parar de refrescar";
            this.btn_CancelarRefresco.UseVisualStyleBackColor = true;
            this.btn_CancelarRefresco.Click += new System.EventHandler(this.btn_CancelarRefresco_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Insertar un producto de:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgHardware
            // 
            this.dtgHardware.AllowUserToAddRows = false;
            this.dtgHardware.AllowUserToDeleteRows = false;
            this.dtgHardware.AllowUserToResizeColumns = false;
            this.dtgHardware.AllowUserToResizeRows = false;
            this.dtgHardware.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgHardware.BackgroundColor = System.Drawing.Color.Peru;
            this.dtgHardware.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgHardware.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHardware.GridColor = System.Drawing.Color.MistyRose;
            this.dtgHardware.Location = new System.Drawing.Point(439, 260);
            this.dtgHardware.Name = "dtgHardware";
            this.dtgHardware.ReadOnly = true;
            this.dtgHardware.RowHeadersVisible = false;
            this.dtgHardware.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgHardware.Size = new System.Drawing.Size(412, 135);
            this.dtgHardware.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(436, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Software:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 23);
            this.label8.TabIndex = 18;
            this.label8.Text = "Hardware";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Software
            // 
            this.btn_Software.Location = new System.Drawing.Point(63, 182);
            this.btn_Software.Name = "btn_Software";
            this.btn_Software.Size = new System.Drawing.Size(112, 75);
            this.btn_Software.TabIndex = 19;
            this.btn_Software.Text = "Software";
            this.btn_Software.UseVisualStyleBackColor = true;
            this.btn_Software.Click += new System.EventHandler(this.btn_Software_Click);
            // 
            // btn_Hardware
            // 
            this.btn_Hardware.Location = new System.Drawing.Point(195, 182);
            this.btn_Hardware.Name = "btn_Hardware";
            this.btn_Hardware.Size = new System.Drawing.Size(112, 75);
            this.btn_Hardware.TabIndex = 20;
            this.btn_Hardware.Text = "Hardware";
            this.btn_Hardware.UseVisualStyleBackColor = true;
            this.btn_Hardware.Click += new System.EventHandler(this.btn_Hardware_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(873, 450);
            this.Controls.Add(this.btn_Hardware);
            this.Controls.Add(this.btn_Software);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgHardware);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_CancelarRefresco);
            this.Controls.Add(this.btn_Refrescar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgSoftware);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "Insertar productos ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormularioProductos_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSoftware)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHardware)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgSoftware;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Refrescar;
        private System.Windows.Forms.Button btn_CancelarRefresco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgHardware;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Software;
        private System.Windows.Forms.Button btn_Hardware;
    }
}

