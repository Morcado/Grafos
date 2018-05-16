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
        public int N {
            get { return n; }
            set { n = value; }
        }
        
        public Plantilla(string name) {
            
            InitializeComponent();
            n = 3;
            this.Text = name;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Plantilla_Load(object sender, EventArgs e) {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            n = decimal.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
