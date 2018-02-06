using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos{
    [Serializable()]

    public class NodoRel{
        private bool visitada;
        private string nombre;
        private NodoP arriba;
        //int peso;

        public string NOMBRE{ 
            get {return nombre;} 
            set {nombre = value;} 
        }
        public NodoP ARRIBA{
            get {return arriba;}
        }
        public bool VISITADA{ 
            get { return visitada; } 
            set { visitada = value; } 
        }
        
        public NodoRel(NodoP np,string nam){
            arriba = np;
            visitada = false;
            nombre = nam;
        }
    }
}
