using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrearDialogo
{
    public partial class CConfiguracion : Form
    {
        private int AnchoN;
        public int anchoN{get{return AnchoN;}set{AnchoN = value;}}
        private Graphics g;
        private bool Cambios;
        public bool cambios { get { return Cambios; } set { Cambios = value; } }


        public CConfiguracion()
        {
            InitializeComponent();    
            
        }

        public CConfiguracion(int ancho)//Se le pasan los atributos de Default desde la forma_1
        {
            InitializeComponent(); 
            g = CreateGraphics();
            cambios = new bool();
            anchoN = ancho;
            cambios = false;
            NodoNum.Value = ancho;
            CConfiguracion_Paint(this, null);
        }

        //Cada Click aumenta el tamaño del Nodo y lo dibuja.
        private void AnchoNodo(object sender, EventArgs e)
        {
           anchoN = (int) NodoNum.Value;    //Captura el valor del atributo modificado en el control
                                            //y asi cada uno. Porque? Porque se va a dibujar en el 
                                            //momento.
           if(anchoN != 30)
                 cambios = true; 
           CConfiguracion_Paint(this, null);//Invocada para dibujar la modificación.
        }
        
        //Hay que poner el dibujo en un control o mínimo un recuadro. Yo solo lo dibuje al aventón.
        private void CConfiguracion_Paint(object sender, PaintEventArgs e)//Pen(new  SolidBrush(Color.Red) , anchoN)
        {
            g.Clear(BackColor);
            g.DrawEllipse(new Pen(Color.Red), 200, 100, anchoN, anchoN);
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {             
            //Aquí pueden llamar a una función que pase todas la actualizaciones para llamarla de la Form1
            //o allá en la Form1 hacerla y trasferir asignar uno a uno. Como yo lo hice.     
            this.Close();
        }

        //Se puede agregar o no
        private void Cancelar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
