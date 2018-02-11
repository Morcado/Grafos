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
        private int radio;
        private Graphics g;
        private Rectangle r, r1, r2;
        private int borde;

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

        public ConfigNodAri(Grafo graph){
            InitializeComponent();
            g = CreateGraphics(); 
            borde = 20; //separacion del rectangulo del area cliente
            r = r1 = r2 = this.ClientRectangle;

            r1.X += borde;
            r1.Width = r.Width / 2 - borde;
            r1.Y += 100;
            r1.Height = 100;

            r2.X = r.Width / 2;
            r2.Width = r.Width / 2 - borde;
            r2.Y = 100;
            r2.Height = 100;
           
            numericUpDown1.Maximum = 100;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Increment = 10;
            numericUpDown1.Value = graph.Radio;
            colNodo = graph.ColorNodo;
            colArista = graph.ColorArista;
            this.ConfigNodAri_Load(this, null);
            //g.DrawEllipse(new Pen(graph.ColorNodo), 20, 100, graph.Radio, graph.Radio);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e){
            radio = decimal.ToInt32(numericUpDown1.Value);
            this.ConfigNodAri_Paint(this, null);
        }

        private void button2_Click(object sender, EventArgs e) { //color nodo
            using(var c = new ColorDialog()){
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colNodo = c.Color;
                }
            }
            this.ConfigNodAri_Paint(this, null);
        }

        private void ConfigNodAri_Paint(object sender, PaintEventArgs e) {
            g.Clear(BackColor);
            g.DrawRectangle(new Pen(Color.LightGray), r1);
            g.DrawRectangle(new Pen(Color.LightGray), r2);
            g.FillEllipse(new SolidBrush(colNodo), (r1.X + r1.Width/2) - radio/2, (r1.Y + r1.Height/2) - radio/2, radio, radio);
            g.DrawEllipse(new Pen(Color.Black), (r1.X + r1.Width / 2) - radio / 2, (r1.Y + r1.Height / 2) - radio / 2, radio, radio);
            g.DrawLine(new Pen(colArista), r2.Left + 10, r2.Top + r2.Height/2, r2.Right - 10, r2.Bottom - r2.Height/2);
        }

        private void button1_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ConfigNodAri_Load(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) { // color arisatara
            using (var c = new ColorDialog()) {
                var result = c.ShowDialog();
                if (result == DialogResult.OK) {
                    colArista = c.Color;
                }
            }
            this.ConfigNodAri_Paint(this, null);
        }
    }
}
