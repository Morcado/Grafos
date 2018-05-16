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
    public partial class Weights : Form {
        public Weights() {
            InitializeComponent();
        }

        private void Weights_Load(object sender, EventArgs e) {
            tabControl1.TabPages.Add("ohola");
        }
    }
}
