using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos {
    public partial class Plantilla : Form {
        private int n;
        private string tipo;

        public string Tipo {
            get { return tipo; }
            set { tipo = value; }
        }

        public int N {
            get { return n; }
            set { n = value; }
        }
        
        public Plantilla() {
            InitializeComponent();
            n = 3;
            KeyPreview = true;
        }

        private void Plantilla_Load(object sender, EventArgs e) {
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            n = decimal.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            tipo = comboBox1.Text;
            Close();
        }

        private void Plantilla_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                button1_Click(this, null);
            }
        }

    }
}
