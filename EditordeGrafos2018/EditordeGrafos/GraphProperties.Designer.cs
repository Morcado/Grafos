namespace EditordeGrafos
{
    partial class GraphProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Vertices = new System.Windows.Forms.Label();
            this.Aristas = new System.Windows.Forms.Label();
            this.Grado = new System.Windows.Forms.Label();
            this.Componentes = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Interno = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Externo = new System.Windows.Forms.ComboBox();
            this.LabInterno = new System.Windows.Forms.Label();
            this.LabExterno = new System.Windows.Forms.Label();
            this.Relaciones = new System.Windows.Forms.RadioButton();
            this.Incidencia = new System.Windows.Forms.RadioButton();
            this.Adyacencia = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grado del grafo: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Componentes conexas: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Número de vertices";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Número de aristas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 274);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(504, 251);
            this.dataGridView1.TabIndex = 1;
            // 
            // Vertices
            // 
            this.Vertices.AutoSize = true;
            this.Vertices.Location = new System.Drawing.Point(229, 31);
            this.Vertices.Name = "Vertices";
            this.Vertices.Size = new System.Drawing.Size(0, 13);
            this.Vertices.TabIndex = 2;
            // 
            // Aristas
            // 
            this.Aristas.AutoSize = true;
            this.Aristas.Location = new System.Drawing.Point(229, 57);
            this.Aristas.Name = "Aristas";
            this.Aristas.Size = new System.Drawing.Size(0, 13);
            this.Aristas.TabIndex = 2;
            // 
            // Grado
            // 
            this.Grado.AutoSize = true;
            this.Grado.Location = new System.Drawing.Point(229, 85);
            this.Grado.Name = "Grado";
            this.Grado.Size = new System.Drawing.Size(0, 13);
            this.Grado.TabIndex = 2;
            // 
            // Componentes
            // 
            this.Componentes.AutoSize = true;
            this.Componentes.Location = new System.Drawing.Point(229, 107);
            this.Componentes.Name = "Componentes";
            this.Componentes.Size = new System.Drawing.Size(0, 13);
            this.Componentes.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Grado Interno:";
            // 
            // Interno
            // 
            this.Interno.FormattingEnabled = true;
            this.Interno.Location = new System.Drawing.Point(15, 154);
            this.Interno.Name = "Interno";
            this.Interno.Size = new System.Drawing.Size(121, 21);
            this.Interno.TabIndex = 5;
            this.Interno.TextChanged += new System.EventHandler(this.Interno_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Grado Externo:";
            // 
            // Externo
            // 
            this.Externo.FormattingEnabled = true;
            this.Externo.Location = new System.Drawing.Point(15, 209);
            this.Externo.Name = "Externo";
            this.Externo.Size = new System.Drawing.Size(121, 21);
            this.Externo.TabIndex = 5;
            this.Externo.TextChanged += new System.EventHandler(this.Externo_TextChanged);
            // 
            // LabInterno
            // 
            this.LabInterno.AutoSize = true;
            this.LabInterno.Location = new System.Drawing.Point(229, 154);
            this.LabInterno.Name = "LabInterno";
            this.LabInterno.Size = new System.Drawing.Size(0, 13);
            this.LabInterno.TabIndex = 7;
            // 
            // LabExterno
            // 
            this.LabExterno.AutoSize = true;
            this.LabExterno.Location = new System.Drawing.Point(229, 209);
            this.LabExterno.Name = "LabExterno";
            this.LabExterno.Size = new System.Drawing.Size(0, 13);
            this.LabExterno.TabIndex = 7;
            // 
            // Relaciones
            // 
            this.Relaciones.AutoSize = true;
            this.Relaciones.Location = new System.Drawing.Point(19, 251);
            this.Relaciones.Name = "Relaciones";
            this.Relaciones.Size = new System.Drawing.Size(130, 17);
            this.Relaciones.TabIndex = 9;
            this.Relaciones.TabStop = true;
            this.Relaciones.Text = "Matriz de Relaciones: ";
            this.Relaciones.UseVisualStyleBackColor = true;
            this.Relaciones.CheckedChanged += new System.EventHandler(this.Relaciones_CheckedChanged);
            // 
            // Incidencia
            // 
            this.Incidencia.AutoSize = true;
            this.Incidencia.Location = new System.Drawing.Point(155, 251);
            this.Incidencia.Name = "Incidencia";
            this.Incidencia.Size = new System.Drawing.Size(120, 17);
            this.Incidencia.TabIndex = 9;
            this.Incidencia.TabStop = true;
            this.Incidencia.Text = "Matriz de Incidencia";
            this.Incidencia.UseVisualStyleBackColor = true;
            this.Incidencia.CheckedChanged += new System.EventHandler(this.Incidencia_CheckedChanged);
            // 
            // Adyacencia
            // 
            this.Adyacencia.AutoSize = true;
            this.Adyacencia.Location = new System.Drawing.Point(306, 251);
            this.Adyacencia.Name = "Adyacencia";
            this.Adyacencia.Size = new System.Drawing.Size(121, 17);
            this.Adyacencia.TabIndex = 9;
            this.Adyacencia.TabStop = true;
            this.Adyacencia.Text = "Lista de Adyacencia";
            this.Adyacencia.UseVisualStyleBackColor = true;
            this.Adyacencia.CheckedChanged += new System.EventHandler(this.Adyacencia_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 537);
            this.Controls.Add(this.Adyacencia);
            this.Controls.Add(this.Incidencia);
            this.Controls.Add(this.Relaciones);
            this.Controls.Add(this.LabExterno);
            this.Controls.Add(this.LabInterno);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Externo);
            this.Controls.Add(this.Interno);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Componentes);
            this.Controls.Add(this.Grado);
            this.Controls.Add(this.Aristas);
            this.Controls.Add(this.Vertices);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Grafo - Propiedades";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form3_Paint);
            this.Resize += new System.EventHandler(this.Form3_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Vertices;
        private System.Windows.Forms.Label Aristas;
        private System.Windows.Forms.Label Grado;
        private System.Windows.Forms.Label Componentes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Interno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Externo;
        private System.Windows.Forms.Label LabInterno;
        private System.Windows.Forms.Label LabExterno;
        private System.Windows.Forms.RadioButton Relaciones;
        private System.Windows.Forms.RadioButton Incidencia;
        private System.Windows.Forms.RadioButton Adyacencia;
    }
}