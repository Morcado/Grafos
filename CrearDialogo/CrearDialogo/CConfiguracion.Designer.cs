namespace CrearDialogo
{
    partial class CConfiguracion
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
            this.NodoNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NodoNum)).BeginInit();
            this.SuspendLayout();
            // 
            // NodoNum
            // 
            this.NodoNum.Location = new System.Drawing.Point(12, 54);
            this.NodoNum.Name = "NodoNum";
            this.NodoNum.Size = new System.Drawing.Size(100, 20);
            this.NodoNum.TabIndex = 0;
            this.NodoNum.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NodoNum.ValueChanged += new System.EventHandler(this.AnchoNodo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tamaño Nodo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 58);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // CConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NodoNum);
            this.Location = new System.Drawing.Point(300, 300);
            this.Name = "CConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CConfiguracion_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.NodoNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NodoNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}