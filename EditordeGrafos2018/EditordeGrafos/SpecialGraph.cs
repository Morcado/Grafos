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
    public partial class SpecialGraph : Form {
        private int type;

        public int Type {
            get { return type; }
            set { type = value; }
        }

        public SpecialGraph() {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            type = 0;
        }

        private void petersen(object sender, EventArgs e) {
            type = 1;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void dodecahedro(object sender, EventArgs e) {
            type = 2;
            Close();
            this.DialogResult = DialogResult.OK;
        }

        private void cimitarra(object sender, EventArgs e) {
            type = 3;
            Close();
            this.DialogResult = DialogResult.OK;
        }

        private void k33(object sender, EventArgs e) {
            type = 4;
            Close();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void SpecialGraph_Load(object sender, EventArgs e) {

        }

    }
}
