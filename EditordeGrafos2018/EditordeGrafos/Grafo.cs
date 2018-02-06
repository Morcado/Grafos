using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos{
    [Serializable()]

    public class Grafo:List<NodoP>{
        private bool nombreAristasVisible;
        private bool pesoAristasVisible;
        private int radio;
        private int[][] matriz;
        private Color aristaDi;
        private Color aristaNoDi;
        private Color colorNodo;
        private List<Edge> aristas;
        //private int[][] MatrizCostos;
        //private NodoP[][] P;

        #region get's & set's
        
        public Color ColorAristaDi{ 
            get { return aristaDi; } 
            set { aristaDi = value; } 
        }

        public Color ColorAristaNoDi{ 
            get { return aristaNoDi; } 
            set { aristaNoDi = value; }
        }

        public Color ColorNodo {
            get { return colorNodo; }
            set { colorNodo = value; } 
        }
        
        public List<Edge> Aristas { 
            get { return aristas; } 
        }
        
        public int[][] Matriz{
            get { return matriz; } 
        }
        
        public int Radio{
            get { return radio;} 
            set { radio = value; } 
        }
        
        public bool NombreAristasVisible{
            get { return nombreAristasVisible; } 
            set { nombreAristasVisible = value; } 
        }
        
        public bool PesoAristasVisible{
            get { return pesoAristasVisible; } 
            set { pesoAristasVisible = value; } 
        }

        #endregion
        #region constructores

        public Grafo(){
            aristas = new List<Edge>();
            aristaDi = Color.Black;
            aristaNoDi = Color.Black;
            nombreAristasVisible = false;
            pesoAristasVisible = false;
            colorNodo = Color.White;
            radio = 30;
        }

        public Grafo(Grafo gr){
            aristas = new List<Edge>();
            aristaDi = gr.ColorAristaDi;
            aristaNoDi = gr.ColorAristaNoDi;
            colorNodo = gr.colorNodo;
            NodoP aux1,aux2;
            radio = gr.Radio;
            Edge k = new Edge();
            nombreAristasVisible = gr.NombreAristasVisible;
            pesoAristasVisible = gr.PesoAristasVisible;
            
            foreach (NodoP n in gr){
                this.Add(new NodoP(n));
            }

            foreach(NodoP n in gr){
                aux1 = Find(delegate(NodoP bu) { if (bu.NOMBRE == n.NOMBRE)return true; else return false; });
                foreach (NodoRel rel in n.relaciones){
                    aux2 = Find(delegate(NodoP je) { if (je.NOMBRE == rel.ARRIBA.NOMBRE)return true; else return false; });
                    aux1.insertaRelacion(aux2, Aristas.Count);
                }
            }

            foreach (Edge ar in gr.aristas){
                aux1 = Find(delegate(NodoP bu) { if (bu.NOMBRE == ar.Origin.NOMBRE)return true; else return false; });
                aux2 = Find(delegate(NodoP bu) { if (bu.NOMBRE == ar.Destiny.NOMBRE)return true; else return false; });
                k = new Edge(ar.Type, aux1, aux2, ar.Name);
                k.Weight = ar.Weight;
                AgregaArista(k);
            }
        }

        #endregion
        #region operaciones

        public void AgregaNodo(NodoP n){ 
            Add(n);
        }

        public void AgregaArista(Edge A){
            aristas.Add(A);
        }

        public void RemueveArista(Edge ar){
            NodoRel rel;
            
            rel = ar.Origin.relaciones.Find(delegate(NodoRel np) { if (np.ARRIBA.NOMBRE==ar.Destiny.NOMBRE)return true; else return false; });
            if (rel != null){
                ar.Origin.relaciones.Remove(rel);
                ar.Origin.GRADO--;
                ar.Destiny.GRADO--;
                ar.Origin.GradoExterno--;
                ar.Destiny.GradoInterno--;
            }
            if (ar.Type == 2){
                rel = ar.Destiny.relaciones.Find(delegate(NodoRel np) { if (np.ARRIBA.NOMBRE==ar.Origin.NOMBRE)return true; else return false; });
                
                if (rel != null){
                    ar.Destiny.relaciones.Remove(rel);
                    ar.Destiny.GradoExterno--;
                    ar.Origin.GradoInterno--;
                }
            }
            aristas.Remove(ar);
        }
        public void RemueveNodo(NodoP rem){
            NodoRel rel;
            List<Edge>remover;
            remover=new List<Edge>();
            
            foreach(NodoP a in this){
                rel = a.relaciones.Find(delegate(NodoRel np) { if (np.ARRIBA.NOMBRE==rem.NOMBRE)return true; else return false; });
                if (rel != null){
                    a.relaciones.Remove(rel);
                    a.GRADO--;
                    a.GradoExterno--;
                    if(aristas[0].Type == 0 || aristas[0].Type == 2){
                        a.GradoInterno--;
                    }
                }
            }
            remover=aristas.FindAll(delegate(Edge ar){if(ar.Origin.NOMBRE==rem.NOMBRE||ar.Destiny.NOMBRE==rem.NOMBRE)return true;else return false;});
            if(remover!=null)
                foreach(Edge re in remover){
                    aristas.Remove(re);
                }
            this.Remove(rem);
        }

        #endregion
        #region paint

        public void pinta(Graphics g)
        {
            Pen pendi = new Pen(aristaDi);
            Pen penNdi = new Pen(aristaNoDi);
            Pen pen = new Pen(Color.Black);
            AdjustableArrowCap end=new AdjustableArrowCap(6,6);
            SolidBrush nod;
            pen.Width = 1;
            penNdi.Width = 1;
            pendi.CustomEndCap = end;
            pendi.Width =1;
            Size s = new Size(radio, radio);
            double p3x,p3y, p4x,p4y;
            double ang;
            PointF A, B;
            A = new PointF();
            double d;
            double r;
            double an;
            //int multi;
            double dy,dx;
            dy = dx=0;
            List<Edge> repetidas=new List<Edge>();
            if(aristas.Count > 0){
                foreach (Edge a in aristas){
                    if(a.Type != 1){
                        if(a.Origin.NOMBRE == a.Destiny.NOMBRE){
                            g.DrawBezier(penNdi, new Point(a.Origin.POS.X + ((a.Destiny.POS.X - a.Origin.POS.X) / 2) - 10, a.Origin.POS.Y + ((a.Destiny.POS.Y - a.Origin.POS.Y) / 2) - 5), new Point(a.Origin.POS.X + ((a.Destiny.POS.X - a.Origin.POS.X) / 2) - 40, a.Origin.POS.Y - ((a.Destiny.POS.Y - a.Origin.POS.Y) / 2) - 60), new Point(a.Origin.POS.X + 40, a.Destiny.POS.Y - 60), new Point(a.Destiny.POS.X + 10, a.Destiny.POS.Y - 5));
                        }
                        else{
                            g.DrawLine(penNdi, a.Origin.POS.X, a.Origin.POS.Y, a.Destiny.POS.X, a.Destiny.POS.Y);
                        }

                        repetidas = aristas.FindAll(delegate(Edge repe) { if (repe.Origin.NOMBRE == a.Origin.NOMBRE && repe.Destiny.NOMBRE == a.Destiny.NOMBRE || (a.Origin.NOMBRE == repe.Destiny.NOMBRE && a.Destiny.NOMBRE == repe.Origin.NOMBRE))return true;else return false; });
                        
                        if(repetidas.Count > 1 && a.Painted==false){
                            if((a.Destiny.POS.Y - a.Origin.POS.Y) != 0 ){
                                g.DrawString(repetidas.Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Origin.POS.X + ((a.Destiny.POS.X - a.Origin.POS.X) / 2) + 4, a.Origin.POS.Y + ((a.Destiny.POS.Y - a.Origin.POS.Y) / 2) + 4);                                foreach (Edge re in repetidas)
                                re.Painted = true;
                            }
                        }
                    }
                    else{
                        if(a.Origin.NOMBRE == a.Destiny.NOMBRE){
                            g.DrawBezier(pendi, new Point(a.Origin.POS.X - 10, a.Origin.POS.Y - 5), new Point(a.Origin.POS.X - 40, a.Origin.POS.Y - 60), new Point(a.Origin.POS.X + 40, a.Destiny.POS.Y - 60), new Point(a.Destiny.POS.X + 10, a.Destiny.POS.Y - 10));
                        }
                        else{
                            if(aristas.Find(delegate(Edge bus) { if (bus.Origin.NOMBRE == a.Destiny.NOMBRE && bus.Destiny.NOMBRE == a.Origin.NOMBRE)return true; else return false; }) == null){
                                double teta1 = Math.Atan2((double)(a.Destiny.POS.Y - a.Origin.POS.Y),(double)( a.Destiny.POS.X - a.Origin.POS.X));
                                float x1 = a.Origin.POS.X + (float)((Math.Cos(teta1)) * (s.Height/2));
                                float y1 = a.Origin.POS.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

                                double teta2 = Math.Atan2(a.Origin.POS.Y - a.Destiny.POS.Y, a.Origin.POS.X - a.Destiny.POS.X);
                                float x2 = a.Destiny.POS.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
                                float y2 = a.Destiny.POS.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
                                g.DrawLine(pendi, x1, y1, x2, y2);

                                if(aristas.FindAll(delegate(Edge repe) { if (repe.Origin.NOMBRE == a.Origin.NOMBRE && repe.Destiny.NOMBRE == a.Destiny.NOMBRE)return true; else return false; }).Count > 1){
                                    if((a.Destiny.POS.Y - a.Origin.POS.Y) != 0){
                                        g.DrawString(aristas.FindAll(delegate(Edge repe) { if (repe.Origin.NOMBRE == a.Origin.NOMBRE && repe.Destiny.NOMBRE == a.Destiny.NOMBRE)return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Origin.POS.X + ((a.Destiny.POS.X - a.Origin.POS.X) / 2) + 4, a.Origin.POS.Y + ((a.Destiny.POS.Y - a.Origin.POS.Y) / 2) + 4);
                                    }
                                }

                            }
                            else{
                                if(a.Painted == false){
                                    dy = a.Destiny.POS.Y - a.Origin.POS.Y;
                                    dx = a.Destiny.POS.X - a.Origin.POS.X;

                                    p3x = (dx * 1 / 3) + a.Origin.POS.X;
                                    p3y = (dy * 1 / 3) + a.Origin.POS.Y;
                                    p4x = (dx * 2 / 3) + a.Origin.POS.X;
                                    p4y = (dy * 2 / 3) + a.Origin.POS.Y;

                                    d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                                    r = .35 * d;

                                    if(a.Destiny.POS.X != a.Origin.POS.X){
                                        ang = Math.Atan((double)((double)dy / (double)dx));
                                    }
                                    else{
                                        ang = 90;
                                    }

                                    if(a.Destiny.POS.X > a.Origin.POS.X){
                                        an = ang + 89.8;
                                    }
                                    else{
                                        an = ang - 89.8;
                                    }
                                    
                                    B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                                    A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));
                                    
                                    if(a.Destiny.POS.X > a.Origin.POS.X){
                                        an = ang + 89.56;
                                    }
                                    else{
                                        an = ang - 89.56;
                                    }

                                    g.DrawBezier(pendi, new PointF(a.Origin.POS.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Origin.POS.Y + (float)((Math.Sin(an)) * (s.Height / 2))), A, B, new PointF(a.Destiny.POS.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Destiny.POS.Y + (float)((Math.Sin(an)) * (s.Height / 2))));
                                    a.Painted = true;                   
                                }
                            }
                            if(aristas.FindAll(delegate(Edge repe) { if (repe.Origin.NOMBRE == a.Origin.NOMBRE && repe.Destiny.NOMBRE == a.Destiny.NOMBRE)return true; else return false; }).Count > 1){
                                if((a.Destiny.POS.Y - a.Origin.POS.Y)!=0){
                                    g.DrawString(aristas.FindAll(delegate(Edge repe) { if (repe.Origin.NOMBRE == a.Origin.NOMBRE && repe.Destiny.NOMBRE == a.Destiny.NOMBRE)return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Destiny.POS.X,A.Y-10);
                                }
                            }
                        }
                    }
                   
                    if (nombreAristasVisible){
                        g.DrawString(a.Name, new Font("Bold", 10), Brushes.Blue, a.Origin.POS.X + ((a.Destiny.POS.X - a.Origin.POS.X) / 3) + 4, a.Origin.POS.Y + ((a.Destiny.POS.Y - a.Origin.POS.Y) / 2) + 1);
                    }
                    if (pesoAristasVisible){
                        if (aristas.Find(delegate(Edge bus) { if (bus.Origin.NOMBRE == a.Destiny.NOMBRE && bus.Destiny.NOMBRE == a.Origin.NOMBRE)return true; else return false; }) == null){
                            g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Origin.POS.X + ((a.Destiny.POS.X - a.Origin.POS.X) / 2) + 4, a.Origin.POS.Y + ((a.Destiny.POS.Y - a.Origin.POS.Y) / 2) + 4);
                        }
                        else{
                            g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Destiny.POS.X, A.Y - 10);
                        }
                    }
                    
                }
            }
            foreach (Edge des in aristas){
                des.Painted = false;
            }
            foreach (NodoP n in this){
                pendi.Width = 3;
                if(n.SELECCIONADO==false){
                    nod = new SolidBrush(n.COLOR);
                }
                else{
                    nod = new SolidBrush(Color.Red);
                }

                Rectangle re = new Rectangle(n.POS.X - (s.Height / 2), n.POS.Y - (s.Height / 2), s.Width, s.Height);
                g.FillEllipse(nod, re);
                g.DrawEllipse(pen, re);
                //g.DrawString(n.NOMBRE.ToString(), new Font("Bold", 10), Brushes.Black, n.POS.X -5, n.POS.Y -7);
                if(radio<25){
                    g.DrawString(n.NOMBRE.ToString(), new Font("Bold", 6), Brushes.Black, (n.POS.X -3), (n.POS.Y-5 )  );
                }
                else{
                    g.DrawString(n.NOMBRE.ToString(), new Font("Bold", 10), Brushes.Black, (n.POS.X -5), (n.POS.Y-7 )  );
                }
            }
            pendi.Dispose();
            penNdi.Dispose();
            pen.Dispose();
           
        }

        #endregion
        #region algoritmos

        public void CreaMatriz(){
            matriz = new int[Count][];
            int i = 0, j;
            
            for (int x = 0; x < Count; x++){
                matriz[x]=new int[Count];
            }
            
            this.Sort(delegate(NodoP a, NodoP b) { 
                return a.NOMBRE.CompareTo(b.NOMBRE); 
            });

            foreach(NodoP nod in this){
                j=0;
                foreach(NodoP nod2 in this){
                    if (nod.relaciones.Find(delegate(NodoRel r) { if (nod2.NOMBRE == r.ARRIBA.NOMBRE )return true; else return false; }) != null){
                        matriz[i][j] = 1;

                    }
                    else{
                        matriz[i][j] = 0;    
                    }
                    j++;
                }
                i++;
            }
        }
       
        public int Componentes2(NodoP nodito,List<NodoP> compo){
            if(nodito.relaciones.Find(delegate(NodoRel r) { if (r.VISITADA!=true )return true; else return false; }) == null){
                return 1;
            }
            else{
                compo.Add(nodito);
                foreach (NodoRel a in nodito.relaciones){
                    if (a.VISITADA == false){
                        a.VISITADA = true;
                        compo.Add(a.ARRIBA);
                        Componentes2(a.ARRIBA, compo);
                    }
                }
                return 0;
            }
        }

        public int Componentes(){
            bool enco = false;
            bool enco2=false;
            List<List<NodoP>> componentes = new List<List<NodoP>>();
            List<NodoP> nue = new List<NodoP>();
            Grafo aux = new Grafo(this);

            if(aristas.Count != 0){
                foreach(NodoP nod in this){
                    foreach(List<NodoP> n in componentes){
                        if(enco == false)
                            if(n.Find(delegate(NodoP f) { if (f.NOMBRE == nod.NOMBRE)return true; else return false; }) != null)
                                enco = true;
                    }
                    if(enco == false){
                        if(aristas[0].Type == 1){
                            foreach(List<NodoP> n in componentes){
                                foreach(NodoP ee in n){
                                    foreach(NodoRel r in ee.relaciones){
                                        if(enco2 == false)
                                            if (n.Find(delegate(NodoP f) { if (f.NOMBRE == r.ARRIBA.NOMBRE)return true; else return false; }) != null)
                                                enco2 = true;
                                    }
                                }
                            }
                            if(enco2 == false){
                                nue = new List<NodoP>();
                                this.Componentes2(nod, nue);
                                componentes.Add(nue);
                            }
                            enco2 = false;
                        }
                        else{
                            nue = new List<NodoP>();
                            this.Componentes2(nod, nue);
                            componentes.Add(nue);
                        }
                    }
                    enco = false;
                }
                foreach(NodoP re in this){
                    foreach(NodoRel rela in re.relaciones){
                        rela.VISITADA = false;
                    }
                }
                return componentes.Count;
            }
            else{
                return this.Count;
            }
        }

        public void desseleccionar(){
            foreach (NodoP r in this){
                r.SELECCIONADO = false;
            }
        }

        public List<List<NodoP>> colorear(){
            
            bool found = false;
            int re = 0, g = 0, b = 255;            
            Color co = Color.FromArgb(re, g, b);
            List<List<NodoP>> listas=new List<List<NodoP>>();
            List<NodoP> au = new List<NodoP>();
            
            foreach(NodoP nodin in this){
                foreach(List<NodoP> c in listas){
                    if(found == false)
                        if (c.Find(delegate(NodoP a) { if (a.relaciones.Find(delegate(NodoRel r) { if (r.ARRIBA.NOMBRE == nodin.NOMBRE)return true; else return false; }) != null || nodin.relaciones.Find(delegate(NodoRel rela){if(rela.ARRIBA.NOMBRE==a.NOMBRE)return true;else return false;})!=null)return true; else return false; }) == null)
                        {
                            c.Add(nodin);
                            found = true;
                        }
                }
                if (found == false){
                    au = new List<NodoP>();
                    au.Add(nodin);
                    listas.Add(au);
                }
                found = false;
            }
            foreach(List<NodoP> a in listas){
                foreach (NodoP n in a){
                    n.COLOR = co;
                }
                if (re + 100 >= 255){
                    re = 0;
                    if (g + 100 >= 255){
                        g = 0;
                        if (b + 150 >= 255){
                            b = 0;
                        }
                        else{
                            b += 150;
                        }
                    }
                    else{
                        g += 100;
                    }
                }
                else{
                    re += 100;
                    b = 180;
                }
                co = Color.FromArgb(co.R-co.R+re, co.G-co.G+g, co.B-co.B+b );      
            }
            return listas;

        }

        #endregion
    }
}
   