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
    public partial class Notas : Form {
        private Graph gra;
        private List<NodeP> listaCabezas;
        private List<string> nodos;
        private Editor editor;

        public Notas(Graph grafo, Editor editor) {
            InitializeComponent();
            this.editor = editor;
            this.gra = grafo;
            listaCabezas = new List<NodeP>();
            nodos = new List<string>();
            cargaNodos();
            encuentraFuentes();
            //GeneraNiveles();
        }

        public void cargaNodos() {
            foreach (NodeP np in gra) {
                comboBox1.Items.Add(np.Name);
            }
        }

        public void encuentraFuentes() {
            bool cabeza;
            for (int i = 0; i < gra.Count; i ++ ){
            //foreach (NodeP np in this.gra) {
                cabeza = true;
                gra[i].Visited = false;
                foreach (Edge a in gra.EdgesList) {

                    if (a.Destiny == gra[i]) {
                        cabeza = false;
                        break;
                    }
                }
                if (cabeza) {
                    listaCabezas.Add(gra[i]);

                }

            }
        }

        public void GeneraNiveles() {
            foreach (NodeP nodo in listaCabezas) {
                EncuentraSig(nodo);
            }
        }

        public void EncuentraSig(NodeP np){
            foreach (Edge ar in gra.EdgesList) {
                if (ar.Origin == np && !ar.Destiny.Visited) {
                    listView2.Items.Add(ar.Destiny.Name);
                    ar.Destiny.Visited = true;
                    
                    EncuentraSig(ar.Destiny);

                }
            }
        }

        private void Notas_Load(object sender, EventArgs e) {

        }

        public void eliminaNodo(NodeP np){
            foreach (NodeP no in gra) {
                no.Visited = false;
            }
            
            listView2.Items.Clear();
            comboBox1.Items.Remove(np.Name);
            listView1.Items.Add(np.Name);
                    
            EncuentraSig(np);

            gra.RemoveNode(np);
            editor.Invalidate();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) {

            
            //comboBox1.ValueMember = comboBox1.SelectedText;
            foreach (NodeP np in gra) {
                if (comboBox1.SelectedItem.ToString() == np.Name) {
                    
                    comboBox1.Items.Remove(np.Name);
                    listView1.Items.Add(np.Name);
                    
                    EncuentraSig(np);

                    gra.RemoveNode(np);
                    editor.Invalidate();
                    break;
                }
            }
            
        }

        private void Notas_FormClosing(object sender, FormClosingEventArgs e) {
            editor.Accion = 0; //regrasa la accion en 0
            editor.EnableMenus();
            this.Dispose();
        }

        public void actualiza(Graph grafo) {
            this.gra = grafo;
            cargaNodos();
        }

        private void Notas_MouseClick(object sender, MouseEventArgs e) {
            //editor.Accion = 99;
        }

        private void Notas_Activated(object sender, EventArgs e) {
            editor.Accion = 99;
        }

    }
}
