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
        private Grafo graph;
        public Color colNodo;
        private Color colAristaDi;
        private Color colAristaNoDi;
        private int radio;
        private Graphics g;
        
        public Color ColAristaDi {
            get { return colAristaNoDi; }
            set { colAristaNoDi = value; }
        }

        public int Radio {
            get { return radio; }
            set { radio = value; }
        }

        public Color ColArista {
            get { return colAristaDi; }
            set { colAristaDi = value; }
        }
        
        public Color ColNodo {
            get { return colNodo; }
            set { colNodo = value; }
        }

        public ConfigNodAri(Grafo graph){
            InitializeComponent();
            g = CreateGraphics();
            this.graph = graph;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Increment = 10;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e){
            radio = decimal.ToInt32(numericUpDown1.Value);
            this.ConfigNodAri_Paint(this, null);
        }

        private void button2_Click(object sender, EventArgs e) {
            ColorDialog col = new ColorDialog();
           
            if (col.ShowDialog() == DialogResult.OK) {
                colNodo = col.Color;
            }
        }

        private void label2_Click(object sender, EventArgs e) {
            ColorDialog col = new ColorDialog();

            if (col.ShowDialog() == DialogResult.OK) {
                colAristaDi = colAristaNoDi = col.Color;
            }
        }

        private void ConfigNodAri_Paint(object sender, PaintEventArgs e) {
             g.Clear(BackColor);
            g.DrawEllipse(new Pen(colNodo), 200, 100, radio, radio);
        }
    }
}
