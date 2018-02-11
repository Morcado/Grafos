using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    [Serializable()]
    public class Edge{
        
        private bool painted;
        private bool visited;
        private int type;
        private int weight;
        private NodoP origin;
        private NodoP destiny;
        private string name;

        public NodoP Origin{
            get { return origin; }
            set { origin=value; }
        }

        public NodoP Destiny{ 
            get { return destiny; } 
            set { destiny = value; } 
        }
        
        public int Type{ 
            get { return type; } 
        }

        public string Name{
            get { return name; }
            set { name=value; }
        }

        public int Weight{ 
            get { return weight; } 
            set { weight = value; } 
        }
        
        public bool Painted{ 
            get { return painted; } 
            set { painted = value; } 
        }
        
        public bool Visited{ 
            get { return visited; } 
            set { visited = value; } 
        }

        public Edge(){
           
        }

        public Edge(int type, NodoP origin, NodoP destiny, string name){
            this.type = type;
            this.origin = origin;
            this.destiny = destiny;
            this.name = name;
            this.weight = 0;
            this.visited = false;
        }

        public Edge(Edge ed){
            type = ed.type;
            origin = ed.origin;
            destiny = ed.destiny;
            weight = ed.Weight;
            visited = ed.Visited;
        }
        
        //calculate center
        private PointF Punto(double angulo,int tip){
            double dy, dx;
            double an, ang, d, r;
            double p3x, p3y, p4x, p4y;
            PointF A, B;
            dy = dx = 0;

            if(tip == 1){
                PointF pF = new PointF();
                float x1 = Origin.Position.X + (float)((Math.Cos(angulo * Math.PI / 180)) * (15));
                float y1 = Origin.Position.Y + (float)((Math.Sin(angulo * Math.PI / 180)) * (15));
                pF.X = x1;
                pF.Y = y1;
                return pF;
            }
            else{
                dy = Destiny.Position.Y - Origin.Position.Y;
                dx = Destiny.Position.X - Origin.Position.X;
                p3x = (dx * 1 / 3) + Origin.Position.X;
                p3y = (dy * 1 / 3) + Origin.Position.Y;
                p4x = (dx * 2 / 3) + Origin.Position.X;
                p4y = (dy * 2 / 3) + Origin.Position.Y;
                d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                r = .35 * d;

                if(Destiny.Position.X != Origin.Position.X){
                    ang = Math.Atan((double)((double)dy / (double)dx));
                }
                else{
                    ang = 90;
                }

                if(Destiny.Position.X > Origin.Position.X){
                    an = ang + 90;
                }
                else{
                    an = ang - 90;
                }

                B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));                

                if (tip == 2){
                    return A;
                }
                else{
                    return B;
                }
            }
        }

        public bool toca(Point pos){
            Rectangle mouse = new Rectangle(pos.X, pos.Y, 3, 3);
            Rectangle pix = new Rectangle(Origin.Position.X, Origin.Position.Y, 3, 3);

            PointF p1 = Punto(-50,1);
            PointF p2 = Punto(-140,1);
            

            int x0 = Origin.Position.X;
            int y0 = Origin.Position.Y;
            int x1 = Destiny.Position.X;
            int y1 = Destiny.Position.Y;

            int dx = Destiny.Position.X - Origin.Position.X;
            int dy = Destiny.Position.Y - Origin.Position.Y;

            if (Math.Abs(dx) > Math.Abs(dy)){
                float m = (float)dy / (float)dx;
                float b = y0 - m * x0;
                if (dx < 0){
                    dx = -1;
                }
                else{
                    dx = 1;
                }

                while (x0 != x1){
                    x0 += dx;
                    y0 = (int)Math.Round(m * x0 + b);
                    pix.X = x0;
                    pix.Y = y0;

                    if(mouse.IntersectsWith(pix)){
                        return true;
                    }
                }
            }
            else{
                if (dy != 0){
                    float m = (float)dx / (float)dy;      
                    float b = x0 - m * y0;
                    if(dy < 0){
                        dy = -1;
                    }
                    else{
                        dy = 1;
                    }

                    while (y0 != y1){
                        y0 += dy;
                        x0 = (int)Math.Round(m * y0 + b);
                        pix.X = x0;
                        pix.Y = y0;

                        if(mouse.IntersectsWith(pix)){
                            return true;
                        }
                    }
                }
            }

            if(Destiny == Origin){
                List<double> ptList = new List<double>();
                Bezier bc = new Bezier();

                ptList.Add(p1.X);
                ptList.Add(p1.Y);
                ptList.Add(p1.X + 20);
                ptList.Add(p1.Y - 50);
                ptList.Add(p1.X - 50);
                ptList.Add(p1.Y - 50);
                ptList.Add(p2.X);
                ptList.Add(p2.Y);

                const int Puntos = 200;
                double[] ptind = new double[ptList.Count];
                double[] p = new double[Puntos];
                ptList.CopyTo(ptind, 0);
                bc.Bezier2D(ptind, (Puntos) / 2, p);

                for(int i = 1; i != Puntos - 1; i += 2)                {
                    if(mouse.IntersectsWith(new Rectangle((int)p[i + 1], (int)p[i], 10, 10))){
                        return true;
                    }
                }
            }
            else{
                p1 = Punto(1, 2);
                p2 = Punto(1, 3);
                List<double> ptList = new List<double>();
                Bezier bc = new Bezier();

                ptList.Add(Origin.Position.X);
                ptList.Add(Origin.Position.Y);
                ptList.Add(p1.X);
                ptList.Add(p1.Y);
                ptList.Add(p2.X);
                ptList.Add(p2.Y);
                ptList.Add(destiny.Position.X);
                ptList.Add(destiny.Position.Y);
               
                const int Puntos = 200;
                double[] ptind = new double[ptList.Count];
                double[] p = new double[Puntos];
                ptList.CopyTo(ptind, 0);
                bc.Bezier2D(ptind, (Puntos) / 2, p);

                for(int i = 1; i != Puntos - 1; i += 2){
                    if(mouse.IntersectsWith(new Rectangle((int)p[i + 1], (int)p[i], 10, 10))){
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
