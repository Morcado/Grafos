using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    public partial class ConfigNodAri : Form{
        private Color colNodo;
        private Color colArista;
        private Color colBordeNodo;
        private Graphics g;
        private Rectangle r, r1, r2;
        private int borde;
        private int radio;
        private int anchoBordeNodo;
        private int anchoArista;
        private bool nombreArista;
        private bool pesoArista;
        private bool letra;

        public bool Letra {
            get { return letra; }
            set { letra = value; }
        }

        public bool PesoArista {
            get { return pesoArista; }
            set { pesoArista = value; }
        }

        public bool NombreArista {
            get { return nombreArista; }
            set { nombreArista = value; }
        }
     
	    public Color ColBordeNodo{
		    get { return colBordeNodo;}
		    set { colBordeNodo = value;}
	    }


        public int AnchoBordeNodo{
            get { return anchoBordeNodo; }
            set { anchoBordeNodo = value; }
        }

        public int AnchoArista {
            get { return anchoArista; }
            set { anchoArista = value; }
        }

        public int Radio {
            get { return radio; }
            set { radio = value; }
        }

        public Color ColArista {
            get { return colArista; }
            set { colArista = value; }
        }
        
        public Color ColNodo {
            get { return colNodo; }
            set { colNodo = value; }
        }

        private void ConfigNodAri_Load(object sender, EventArgs e) {
            
        }

        public ConfigNodAri(Graph graph){
            InitializeComponent();
            g = CreateGraphics();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            borde = 12; //separacion del rectangulo del area cliente
            r = r1 = r2 = this.ClientRectangle;

            r1.X += borde;
            r1.Width = r.Width / 2 - borde;
            r1.Y += 160;
            r1.Height = 100;

            r2.X = r.Width / 2;
            r2.Width = r.Width / 2 - borde;
            r2.Y = 160;
            r2.Height = 100;
           
            numericUpDown1.Maximum = 100;
            numericUpDown1.Minimum = 10;
            numericUpDown1.Increment = 10;

            numericUpDown2.Maximum = 10;
            numericUpDown2.Minimum = 1;
            numericUpDown2.Increment = 1;

            numericUpDown3.Maximum = 10;
            numericUpDown3.Minimum = 1;
            numericUpDown3.Increment = 1;

            numericUpDown3.Value = graph.EdgeWidth;
            numericUpDown2.Value = graph.NodeBorderWidth;
            numericUpDown1.Value = graph.NodeRadio;

            colBordeNodo = graph.NodeBorderColor;
            colNodo = graph.NodeColor;
            colArista = graph.EdgeColor;

            checkBox1.Checked = graph.EdgeNamesVisible;
            checkBox2.Checked = graph.EdgeWeightVisible;

            button3.BackColor = graph.NodeColor;
            if ((graph.NodeColor.R + graph.NodeColor.B + graph.NodeColor.G) / 3 < 100) {
                button3.ForeColor = Color.White;
            }
            else {
                button3.ForeColor = Color.Black;
            }
            button4.BackColor = graph.NodeBorderColor;
            if ((graph.NodeBorderColor.R + graph.NodeBorderColor.B + graph.NodeBorderColor.G) / 3 < 100) {
                button4.ForeColor = Color.White;
            }
            else {
                button4.ForeColor = Color.Black;
            }
            button5.BackColor = graph.EdgeColor;
            if ((graph.EdgeColor.R + graph.EdgeColor.B + graph.EdgeColor.G) / 3 < 100) {
                button5.ForeColor = Color.White;
            }
            else {
                button5.ForeColor = Color.Black;
            }
            button5.ForeColor = Color.White;
            Invalidate();
            
        }

        private void ConfigNodAri_Paint(object sender, PaintEventArgs e) {
            g.Clear(BackColor);
            g.DrawRectangle(new Pen(Color.LightGray), r1);
            g.DrawRectangle(new Pen(Color.LightGray), r2);
            g.FillEllipse(new SolidBrush(colNodo), (r1.X + r1.Width / 2) - radio / 2, (r1.Y + r1.Height / 2) - radio / 2, radio, radio);
            g.DrawEllipse(new Pen(colBordeNodo, anchoBordeNodo), (r1.X + r1.Width / 2) - radio / 2, (r1.Y + r1.Height / 2) - radio / 2, radio, radio);
            g.DrawLine(new Pen(colArista, anchoArista), r2.Left + 10, r2.Top + r2.Height / 2, r2.Right - 10, r2.Bottom - r2.Height / 2);
            g.DrawString("A", new Font("Bold", radio/4), Brushes.Black, (r1.X + r1.Width / 2) - radio/6, (r1.Y + r1.Height / 2) - radio/5);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e){ //tamaño del nodo
            radio = decimal.ToInt32(numericUpDown1.Value);
            Invalidate();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) { // ancho del bode del nodo
            anchoBordeNodo = decimal.ToInt32(numericUpDown2.Value);
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e) { //color nodo
            using(var c = new ColorDialog()){
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colNodo = c.Color;
                    button3.BackColor = c.Color;
                    if ((c.Color.R + c.Color.B + c.Color.G)/3 < 100) {
                        button3.ForeColor = Color.White;
                    }
                    else {
                        button3.ForeColor = Color.Black;
                    }
                }
            }
            Invalidate();
            
        }

        private void button4_Click(object sender, EventArgs e) { // color borde nodo
            using (var c = new ColorDialog()) {
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colBordeNodo = c.Color;
                    button4.BackColor = c.Color;
                    if ((c.Color.R + c.Color.B + c.Color.G) / 3 < 100) {
                        button4.ForeColor = Color.White;
                    }
                    else {
                        button4.ForeColor = Color.Black;
                    }
                }
            }
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e) { // OK
            this.DialogResult = DialogResult.OK;
            
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e) { // color aris|atara
            using (var c = new ColorDialog()) {
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colArista = c.Color;
                    button5.BackColor = c.Color;
                    if ((c.Color.R + c.Color.B + c.Color.G) / 3 < 100) {
                        button5.ForeColor = Color.White;
                    }
                    else {
                        button5.ForeColor = Color.Black;
                    }
                }
            }
            Invalidate();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) { // ancho de la arista
            anchoArista = decimal.ToInt32(numericUpDown3.Value);
            Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) { // nombre de arista
            nombreArista = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) { // peso de la arista
            pesoArista = checkBox2.Checked;
        }

        private void button6_Click(object sender, EventArgs e) { // por defecto
            numericUpDown1.Value = 30;
            radio = decimal.ToInt32(numericUpDown1.Value);
            numericUpDown2.Value = 1;
            anchoBordeNodo = decimal.ToInt32(numericUpDown2.Value);
            colNodo = Color.White;
            colBordeNodo = Color.Black;
            colArista = Color.Black;
            numericUpDown3.Value = 1;
            anchoArista = decimal.ToInt32(numericUpDown3.Value);
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.White;
            Invalidate();
        }
    }
}
