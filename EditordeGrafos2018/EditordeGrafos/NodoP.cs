using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    [Serializable()]

    public class NodoP{
        private bool visited;
        private bool selected;
        private int degree;
        private int degreeIn;
        private int degreeEx;
        private string name;
        private Point position;
        private Color color;
        public List<NodoRel> relations;
        
        public Point Position { 
            get { return position; } 
            set { position = value; } 
        }

        public string Name {
            get { return name; } 
            set { name = value; } 
        }
        public int Degree {
            get { return degree; } 
            set { degree = value; } 
        }

        public Color Color{
            get { return color; } 
            set { color=value; }
        }

        public int DegreeIn {
            get { return degreeIn; } 
            set { degreeIn = value; } 
        }
        public int DegreeEx {
            get { return degreeEx; } 
            set { degreeEx = value; } 
        }
        public bool Selected{
            get { return selected; }
            set { selected=value; }
        }
        public bool Visited { 
            get { return visited; } 
            set { visited = value; } 
        }

        #region constructores

        public NodoP(){

        }

        public NodoP(NodoP co){
            position = co.Position;
            name = co.Name;
            relations = new List<NodoRel>();
            degree = co.Degree;
            degreeEx = co.DegreeEx;
            degreeIn = co.DegreeIn;
            color = co.Color;
            selected = false;
        }

        public NodoP(Point p, char n){
            position = p;
            name = n.ToString();
            relations = new List<NodoRel>();
            degree = 0;
            color = Color.White;
            selected = false;
        }

        #endregion
        #region operaciones

        public bool InsertRelation(NodoP newRel, int num){
            NodoRel n;
            n = new NodoRel(newRel, "e" + num.ToString());
           
            relations.Add(n);
            return true;
        }
        #endregion
    }
}
