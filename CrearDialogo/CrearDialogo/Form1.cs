using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Este proyecto es una idea de como hacer la Configuración
//Para los que no lo han implementado espero les sirva.
//Los que lo hicieron pues muy bien!!! 
//Por ahi de repente aparece un fantasma haber si lo pueden quitar.
//Si no les sale es que mi máquina es muy lenta!!!

namespace CrearDialogo
{
    public partial class Form1 : Form
    {
        int TamañoNodo; //var del tamaño para actualizar en el grafo dibujado.
        Graphics g;
        Point pt;
        bool band, bandConf;
        CConfiguracion cc;//Declaración del objeto Configuración.

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            TamañoNodo = 30;        //atributos por Default.
            band = false;
            bandConf = false;          
        }

        //Manejador de la opción del Menu Configuración-Configurar Opciones... cambienlo a
        //Configurar Atributos... o algo asi.
        private void Configuracion_Clicked(object sender, EventArgs e)
        {
            cc = new CConfiguracion(TamañoNodo); //Crea el objeto de la Configuración y le pasa los
                                                //atributos por default. Aqui solo el ancho del nodo.
            cc.Visible = true;                      
            bandConf = true;
        }

        //Dibuja el nodo por default o el  modificado en Configuración. 
        //Yo lo dibujo de sopetón sin ninguna opción de crea_nodo.
        //Como práctica de funcionamiento de este proyecto de muestra, uds pueden
        //dibujar el nodo de entrada y llamar a Configuración y volver a dibujar 
        //para que vean la actualización del tamaño.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = CreateGraphics();
            if(band)
                g.DrawEllipse(new Pen(Color.Red), pt.X, pt.Y, TamañoNodo, TamañoNodo);            
        }

        //Click en el área cliente para dibujar el nodo "ipso facto" o sea de sopetón.
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                pt = e.Location;
                if (bandConf == true && cc.cambios == true) //Si Configuración se creo y hubo modificaciones
                    TamañoNodo = cc.anchoN;
                band = true;
                Form1_Paint(this, null);
            }
        }
    }
}
