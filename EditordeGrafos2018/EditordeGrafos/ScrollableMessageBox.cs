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
    public partial class ScrollableMessageBox : Form {
        public ScrollableMessageBox(string title, string[] message) {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            Text = title;
            textBox1.Lines = message;
            
        }

        private void ScrollableMessageBox_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
