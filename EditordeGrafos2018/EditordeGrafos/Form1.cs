using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EditordeGrafos{
    public partial class Form1 : Form{
        //bool gactivo;
        private bool band;
        private bool b_cam;
        private bool b_coloreando;
        private bool b_mov;
        private bool b_tck;
        private char nombre;
        private int icam;
        private int numero;
        private int tipoarista;
        private Edge ed;
        private Edge edge;
        private BinaryFormatter file;
        private Bitmap bmp1; 
        private Color resp;
        private Grafo graph, graph2;

        private Graphics graphics;
        private List<NodoP> CCE;
        private NodoP nu;
        private NodoP origin, destin;
        private Pen fl;
        private Point pt1;
        private Point pt2;
        private int accion;
        private Timer time;

        private void Form1_Load(object sender, EventArgs e){
            this.BackColor = Color.White;
            b_cam = false;
            icam = 0;
            numero = 0;
            b_tck = false;
            CCE = new List<NodoP>();
            b_coloreando = false;
            resp = Color.White;
            graph2 = new Grafo();
            ed = new Edge();
            fl = new Pen(Brushes.Green);
            bmp1 = new Bitmap(800,600);
            graphics = CreateGraphics();
            file = new BinaryFormatter();
            graph = new Grafo();

            AgregaNodo.Enabled = AgregaNod.Enabled = true; 
            MueveNodo.Enabled = MueveNod.Enabled = false;
            AgregaRelacion.Enabled = Dirigida.Enabled = NoDirigida.Enabled = false;
            EliminaNodo.Enabled = EliminaNod.Enabled = false;
            MueveGrafo.Enabled = MueveGraf.Enabled = false;
            EliminaArista.Enabled = EliminaArist.Enabled = false;

            PropiedadesGraf.Enabled = false;
            band = false;
            Intercambio.Enabled = true;
            accion = 0;
            //gactivo = false;
            pt2 = new Point();
            nombre = 'A';
            b_mov = false;
            time = new Timer();
            Intercambio.Enabled = false;
            time.Tick += time_Tick;
        }       

        public Form1(){ 
            InitializeComponent();
        }

        #region mouse
        private void Form1_MouseDown(object sender, MouseEventArgs e){
            pt2 = e.Location;
            pt1 = pt2;

            switch(e.Button.ToString()){
                case "Left":
                    if(accion != 0 && accion !=1){ 
                        band = true;
                        Form1_Paint(this, null);
                        band = false;          
                    }
                    break;   
                case "Right":   
                    int totalEdges = graph.Aristas.Count;
                        for(int i = 0; i < totalEdges; i++){
                            edge = graph.Aristas[i];
                            if(edge.toca(pt2)){
                                MenuArista.Enabled = true;
                                MenuArista.ClientSize = new Size(50, 50);
                                MenuArista.Visible = true;
                                MenuArista.Show(Cursor.Position);
                                break;
                            }
                        }
                    break;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left){
                pt2 = e.Location;
                band = false;
                Form1_Paint(this, null);
            }           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e){
            NodoP des;
            Graphics au;

            au = Graphics.FromImage(bmp1);
            au.Clear(BackColor);
            switch(accion){
                case 1:
                    pt1 = pt2;
                    pt2 = e.Location;
                    band = true;
                    Form1_Paint(this, null);
                    band = false;    
                    break;
                case 2:
                    nu = null; 
                    break;
                case 3:
                    des = (NodoP)graph.Find(delegate(NodoP a) { if (e.Location.X > a.Position.X - (graph.Radio / 2) && e.Location.X < a.Position.X + (graph.Radio) && e.Location.Y > a.Position.Y - (graph.Radio / 2) && e.Location.Y < a.Position.Y + (graph.Radio ))return true; else return false; });
                    if(des != null && nu != null){
                        if(nu.insertaRelacion(des,graph.Aristas.Count)){
                            ed = new Edge(tipoarista, nu, des, "e" + graph.Aristas.Count.ToString());
                            graph.AgregaArista(ed);
                            nu.Degree++;
                            des.Degree++;
                            nu.DegreeEx++;
                            des.DegreeIn++;
                        }
                        if(tipoarista == 2 && ed.Destiny.Name!=ed.Origin.Name){
                            des.insertaRelacion(nu, graph.Aristas.Count-1);
                            des.DegreeEx++;
                            nu.DegreeIn++; 
                        }
                        if(b_coloreando == true){
                            graph.colorear();
                        }

                        graph.pinta(au);
                        band = false;
                        nu = null;                       
                    }
                    else{
                        graph.pinta(au);
                    }
                    graphics.DrawImage(bmp1, 0, 0);
                    break;
                case 4:
                    nu = (NodoP)graph.Find(delegate(NodoP a) { if (e.Location.X > a.Position.X - 15 && e.Location.X < a.Position.X + 30 && e.Location.Y > a.Position.Y - 15 && e.Location.Y < a.Position.Y + 30)return true; else return false; });
                    if (nu != null){
                        graph.RemueveNodo(nu);
                        band = true;
                        if (graph.Count == 0){
                            nombre = 'A';
                            //gactivo = false;
                        }
                        Form1_Paint(this, null);
                        band = false;
                    }
                    break;
                case 7:
                    break;
                case 9:
                    break;
                case 8:
                    SeleccionaNodos();
                    break;
            }
        }

        #endregion
        #region menus

        private void Archivo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ArchivoToolStripMenuItem.HideDropDown();
            switch(e.ClickedItem.Name){
                case "Nuevo":
                    band = false;
                    Intercambio.Enabled = false;
                    b_mov = false;

                    BackColor = Color.White;
                    graphics.Clear(BackColor);
                    AgregaNod.Enabled = true;
                    MueveNodo.Enabled = MueveNod.Enabled = false;
                    AgregaRelacion.Enabled = Dirigida.Enabled = NoDirigida.Enabled = false;
                    EliminaNodo.Enabled = EliminaNod.Enabled = false;
                    MueveGrafo.Enabled = MueveGraf.Enabled = false;
                    AristaNoDirigida.Enabled = true;
                    AristaDirigida.Enabled= true;
                    EliminaArista.Enabled = EliminaArist.Enabled = false;
                    graph2 = new Grafo();
                    PropiedadesGraf.Enabled=false;
                    graph = new Grafo();
                    nombre = 'A';
                    //gactivo = false;
                    break;

                case "Abrir":      
                    OpenFileDialog filed = new OpenFileDialog();
                    filed.InitialDirectory = Application.StartupPath+"\\Ejemplos";
                    filed.DefaultExt = ".grafo";                    
                    string namefile;
                    filed.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
                    if (filed.ShowDialog() == DialogResult.OK){
                        namefile = filed.FileName;
                        
                        try{
                            using (Stream stream = File.Open(namefile, FileMode.Open)){
                               BinaryFormatter bin = new BinaryFormatter();
                               graph = (Grafo)bin.Deserialize(stream);
                               graph.pinta(graphics);
                            }
                        }
                        catch (IOException exe){
                            MessageBox.Show(exe.ToString());
                        }

                        graph2 = new Grafo();
                        AgregaRelacion.Enabled = Dirigida.Enabled=NoDirigida.Enabled = true;
                        AgregaNod.Enabled = true;
                        Intercambio.Enabled = true;

                        
                        if (graph.Aristas.Count > 0 && graph.Aristas[0].Type == 1) {
                            AristaDirigida.Enabled = Dirigida.Enabled = true;
                            AristaNoDirigida.Enabled = NoDirigida.Enabled =  false;
                        }
                        else {
                            AristaNoDirigida.Enabled = NoDirigida.Enabled = true;
                            AristaDirigida.Enabled = Dirigida.Enabled = false;
                        }
                        

                        MueveGrafo.Enabled = MueveGraf.Enabled = true;
                        MueveNodo.Enabled = MueveNod.Enabled = true;
                        EliminaNodo.Enabled = EliminaNod.Enabled = true;
                        EliminaArista.Enabled = EliminaArist.Enabled = true;
                        
                        accion = 1;
                        AgregaNod.Checked = AgregaNodo.Checked = true;
                        MueveNod.Checked = MueveNodo.Checked = false;
                        MueveGrafo.Checked = MueveGraf.Checked = false;
                        EliminaNodo.Checked = EliminaNod.Checked = false;
                        EliminaArista.Checked = EliminaArist.Checked = false;
                        PropiedadesGraf.Enabled = true;
                        graph.desseleccionar();
                        nombre = 'A';

                        for (int nn = 0; nn < graph.Count; nn++){
                            nombre++;
                        }
                    }
                    break;
                case "Guardar":
                    SaveFileDialog sav = new SaveFileDialog();
                    sav.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
                    sav.InitialDirectory = Application.StartupPath + "\\ProyectosGrafo";
                    String nombr;
                    if(sav.ShowDialog() == DialogResult.OK){
                        nombr=sav.FileName;

                        try{
                            using (Stream stream = File.Open(nombr, FileMode.Create)){
                                BinaryFormatter bin = new BinaryFormatter();
                                bin.Serialize(stream,graph);
                            }
                        }
                        catch (IOException exe){
                            MessageBox.Show(exe.ToString());
                        }
                    }
                    break;
                case "BorraGrafo":
                    graph = new Grafo();
                    graphics.Clear(BackColor);
                    graph2 = new Grafo();
                    nombre = 'A';
                    break;

                case "Salir":
                    System.Windows.Forms.Application.Exit();
                    break;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e){
            switch(e.ClickedItem.Name){
                case "AgregaNod":
                case "AgregaNodo":
                    pt2 = new Point();
                    accion = 1;
                    AgregaNod.Checked=AgregaNodo.Checked = true;
                    MueveNod.Checked = MueveNodo.Checked = false;
                    MueveGrafo.Checked = MueveGraf.Checked = false;
                    EliminaNodo.Checked = EliminaNod.Checked = false;
                    EliminaArista.Checked=EliminaArist.Checked = false;
                    
                    graph.desseleccionar();
                    break;
                case "MueveNodo":
                case "MueveNod":
                    band = true;
                    accion = 2;
                    MueveNod.Checked = MueveNodo.Checked = true;
                    AgregaNod.Checked=AgregaNodo.Checked = false;
                    EliminaNodo.Checked = EliminaNod.Checked = false;
                    MueveGrafo.Checked = MueveGraf.Checked = false;
                    EliminaArista.Checked=EliminaArist.Checked = false;
                    graph.desseleccionar();
                    break;
                case "EliminaNodo":
                case "EliminaNod":
                    accion = 4;
                    EliminaNodo.Checked = EliminaNod.Checked = true;
                    MueveNod.Checked = MueveNodo.Checked = false;
                    AgregaNod.Checked=AgregaNodo.Checked = false;       
                    MueveGrafo.Checked = MueveGraf.Checked = false;
                    EliminaArista.Checked = EliminaArist.Checked = false;
                    graph.desseleccionar();
                    break;
                case "MueveGrafo":
                case "MueveGraf":
                    MueveGrafo.Checked = MueveGraf.Checked = true;
                    EliminaNodo.Checked = EliminaNod.Checked = false;
                    MueveNod.Checked = MueveNodo.Checked = false;
                    AgregaNod.Checked=AgregaNodo.Checked = false;
                    EliminaArista.Checked = EliminaArist.Checked = false;
                    accion = 5;
                    graph.desseleccionar();
                    break;
                case "EliminaArista":
                case "EliminaArist":
                    accion = 6;
                    EliminaArista.Checked = EliminaArist.Checked = true;
                    MueveGrafo.Checked = MueveGraf.Checked = false;
                    EliminaNodo.Checked = EliminaNod.Checked = false;
                    MueveNod.Checked = MueveNodo.Checked = false;
                    AgregaNod.Checked=AgregaNodo.Checked = false;
                    graph.desseleccionar();
                    break;
                case "PropiedadesGrafo":
                case "PropiedadesGraf":
                     Form f;
                     if(AristaDirigida.Enabled==false)
                        f = new PropiedadesGrafo(graph,2);
                     else
                        f = new PropiedadesGrafo(graph,1);
                     f.Activate();
                     f.Show();
                     graph.desseleccionar();
                    break;
                case "Intercambio":
                    int cont=0;
                    char name='A';
                    bool num;
                    int aux;
                    if((int.TryParse(graph[0].Name.ToString(),out aux))==true){
                        num=true;
                    }
                    else{
                        num=false;
                    }

                    if(num == true){
                        foreach (NodoP cambio in graph){
                            cambio.Name = name.ToString();
                            name++;
                        }
                        nombre = 'A';
                        for (int i = 0; i < graph.Count; i++){
                            nombre++;
                        }
                    }
                    else{
                        numero = graph.Count;
                        foreach (NodoP cambio in graph){
                            cambio.Name = cont.ToString();
                            cont++;
                        }
                    }
                    break;
                case "Dirigida":
                    accion = 3;
                    band = true;

                    MueveNod.Checked = MueveNodo.Checked = false;
                    Intercambio.Enabled = true;
                    AgregaNod.Checked = AgregaNodo.Checked = false;
                    EliminaNodo.Checked = EliminaNod.Checked = false;
                    MueveGrafo.Checked = MueveGraf.Checked = false;
                    EliminaArista.Checked = EliminaArist.Checked = false;
                    AgregaRelacion.Checked = true;

                    fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    fl.StartCap = LineCap.RoundAnchor;
                    fl.Width = 4;
                    tipoarista = 1;
                    AristaNoDirigida.Enabled=NoDirigida.Enabled = false;
                    Dirigida.Checked=AristaDirigida.Checked = true;
                    
                    graph.desseleccionar();
                    break;
                case "NoDirigida":
                    accion = 3;
                    band = true;
                    MueveNod.Checked = MueveNodo.Checked = false;
                    Intercambio.Enabled = true;
                    AgregaNod.Checked = AgregaNodo.Checked = false;
                    EliminaNodo.Checked = EliminaNod.Checked = false;
                    MueveGrafo.Checked = MueveGraf.Checked = false;
                    EliminaArista.Checked = EliminaArist.Checked = false;
                    AgregaRelacion.Checked = true;
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    fl.StartCap = LineCap.NoAnchor;
                    fl.Width = 4;
                    tipoarista = 2;
                    graph.desseleccionar();
                    AristaDirigida.Enabled=Dirigida.Enabled = false;
                    NoDirigida.Checked = AristaNoDirigida.Checked = false;

                    break;

            }
        }

        private void RelacionClicked(object sender, ToolStripItemClickedEventArgs e){
            accion = 3;
            band = true;
            MueveNod.Checked = MueveNodo.Checked = false;
            Intercambio.Enabled = true;
            AgregaNod.Checked = AgregaNodo.Checked = false;
            EliminaNodo.Checked = EliminaNod.Checked = false;
            MueveGrafo.Checked = MueveGraf.Checked = false;
            EliminaArista.Checked = EliminaArist.Checked = false;
            AgregaRelacion.Checked = true;

            switch(e.ClickedItem.Name){
                case "Dirigida":
                case "AristaDirigida":
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    fl.StartCap = LineCap.RoundAnchor;
                    fl.Width = 4;
                    tipoarista = 1;
                    AristaNoDirigida.Enabled=NoDirigida.Enabled = false;
                    Dirigida.Checked=AristaDirigida.Checked = true;

                    graph.desseleccionar();

                    break;
                case "NoDirigida":
                case "AristaNoDirigida":
                    fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
                    fl.StartCap = LineCap.NoAnchor;
                    fl.Width = 4;
                    tipoarista = 2;
                    graph.desseleccionar();
                    AristaDirigida.Enabled=Dirigida.Enabled = false;
                    NoDirigida.Checked = AristaNoDirigida.Checked = false;
                    
                    break;
            }
        }

        private void Ver_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e){
            switch (e.ClickedItem.Name){
                case "NombreAristas":
                    graph.NombreAristasVisible = !graph.NombreAristasVisible;                
                    break;
                case "PesoAristas":
                    graph.PesoAristasVisible = !graph.PesoAristasVisible;
                    break;
            }
            graph.pinta(graphics);
        }

        private void Configuracion_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e){
            switch (e.ClickedItem.Name){
                case "PropiedadesGrafo":
                    using (var f = new PropiedadesGrafo(graph, AristaDirigida.Enabled ? 1 : 2)) {
                        var result = f.ShowDialog();
                        graph.desseleccionar();
                    }
                    break;
                case "ConfigurarNodAri":
                    using (var f2 = new ConfigNodAri(graph)) {
                        var result = f2.ShowDialog();
                        if (result == DialogResult.OK) {
                            foreach (NodoP colNodo in graph) {
                                
                                colNodo.Color = f2.ColNodo;
                            }
                            graph.Radio = f2.Radio;
                            graph.ColorNodo = f2.ColNodo;
                            graph.ColorArista = f2.ColArista;
                        }
                    }
                    break;
                case "Intercamb":
                    int cont=0;
                    char name='A';
                    bool num;
                    int aux;
                    if((int.TryParse(graph[0].Name.ToString(),out aux))==true){
                        num=true;
                    }
                    else{
                        num=false;
                    }

                    if(num == true){
                        foreach (NodoP cambio in graph){
                            cambio.Name = name.ToString();
                            name++;
                        }
                        nombre = 'A';
                        for (int i = 0; i < graph.Count; i++){
                            nombre++;
                        }
                    }
                    else{
                        numero = graph.Count;
                        foreach (NodoP cambio in graph){
                            cambio.Name = cont.ToString();
                            cont++;
                        }
                    }
                    break;
            }
            Form1_Paint(this, null);
        }

        private void MenuArista_Closing(object sender, ToolStripDropDownClosingEventArgs e){
            if (toolStripTextBox1.Text.Length > 0){
                edge.Weight = int.Parse(toolStripTextBox1.Text);
                edge = null;
                toolStripTextBox1.Text = "";
            }
        }

        #endregion 
        #region paint

        private void Form1_Paint(object sender, PaintEventArgs e){
            Graphics au;
            au = Graphics.FromImage(bmp1);
            au.Clear(BackColor);
            if(band){
                //au.Clear(BackColor);
                switch(accion){                   
                    case 1:
                        bool num;
                        int iaux;
                        if(graph.Count > 0){
                            if((int.TryParse(graph[0].Name.ToString(), out iaux)) == true){
                                num = true;
                            }
                            else{
                                num = false;
                            }
                        }
                        else{
                            num = false;
                        }
                        if(num == false){
                            nu = new NodoP(pt2, nombre);
                            nombre++;
                        }
                        else{
                            nu = new NodoP(pt2,nombre );
                            nu.Name = numero.ToString();
                            numero++;
                        }
                        if(graph.Count == 0){
                            Dirigida.Enabled = NoDirigida.Enabled = true;
                        }
                        if(graph.Count > 1){
                            nu.Color = graph[0].Color;
                        }
                        graph.AgregaNodo(nu);
                        Intercambio.Enabled = true;
                        PropiedadesGraf.Enabled = true;
                        AgregaRelacion.Enabled= true;
                       
                        MueveGrafo.Enabled = MueveGraf.Enabled = true;
                        MueveNodo.Enabled=MueveNod.Enabled = true;
                        EliminaNodo.Enabled=EliminaNod.Enabled = true;
                        EliminaArista.Enabled = EliminaArist.Enabled = true;
                        //gactivo = true;
                        nu = null;          
                        break;
                    case 2:
                        nu = (NodoP)graph.Find(delegate(NodoP a) { if (pt2.X > a.Position.X - (graph.Radio / 2) && pt2.X < a.Position.X + (graph.Radio) && pt2.Y > a.Position.Y - (graph.Radio / 2) && pt2.Y < a.Position.Y + (graph.Radio ))return true; else return false; });
                        break;
                    case 3:
                        nu = (NodoP)graph.Find(delegate(NodoP a) { if (pt2.X > a.Position.X - (graph.Radio / 2) && pt2.X < a.Position.X + (graph.Radio) && pt2.Y > a.Position.Y - (graph.Radio / 2) && pt2.Y < a.Position.Y + (graph.Radio))return true; else return false; });
                        pt1 = pt2;                        
                        break;
                    case 5:
                        Grafo aux=new Grafo();
                        aux = graph;
                        aux.Sort(delegate(NodoP a, NodoP b) { return a.Position.X.CompareTo(b.Position.X); });
                        if(pt2.X > aux.ToArray()[0].Position.X && pt2.X < aux.ToArray()[aux.Count - 1].Position.X){
                            aux.Sort(delegate(NodoP a, NodoP b) { return a.Position.Y.CompareTo(b.Position.Y); });
                            if(pt2.Y > aux.ToArray()[0].Position.Y && pt2.Y < aux.ToArray()[aux.Count - 1].Position.Y){
                                b_mov = true;             
                            }
                            else{
                                b_mov = false;
                            }
                        }
                        else{
                            b_mov = false;
                        }
                        break;
                    case 6:
                        Edge arista;

                        int total = graph.Aristas.Count;
                        for(int i = 0; i < total; i++){
                            arista = graph.Aristas[i];
                            if (arista.toca(pt2)){
                                graph.RemueveArista(arista);
                                if(b_coloreando==true)
                                graph.colorear();
                                break;
                            }
                        }
                        break;
                    case 14:  
                        Edge ari;
                        NodoP o, d;

                        o=d=null;
                        if(b_cam == true){
                            ari = new Edge(); ;
                            graph = new Grafo(graph2);
                            graph.Aristas.Clear();
                            foreach (NodoP rel in graph)
                            {
                                rel.relations.Clear();
                            }
                            b_cam = false;
                            au.Clear(BackColor);
                        }
                        if(b_tck == true){
                            accion = 0;
                            b_tck = false;
                            if(icam > 0){
                                graph.Find(delegate(NodoP dx) { if (dx.Name == CCE[icam].Name)return true; else return false; }).insertaRelacion(graph.Find(delegate(NodoP ox) { if (ox.Name == CCE[icam - 1].Name)return true; else return false; }), graph.Aristas.Count);
                                d=graph.Find(delegate(NodoP dx) { if (dx.Name == CCE[icam].Name)return true; else return false; });
                                o=graph.Find(delegate(NodoP ox) { if (ox.Name == CCE[icam - 1].Name)return true; else return false; });
                                d.Color = Color.Blue;
                                o.Color = Color.Blue;
                                Pen penn = new Pen(Brushes.Red);
                                penn.Width = 4;
                                graphics.DrawEllipse(penn,new Rectangle(d.Position.X - 16, d.Position.Y - 16,30, 30));
                                ari = new Edge(1, d, o, "e" + (CCE.Count - icam).ToString());                                          
                                graph.AgregaArista(ari);
                            }
                            graph.pinta(graphics);                                  
                        }
                        break;                    
                }
                graph.pinta(au);
                graphics.DrawImage(bmp1, 0, 0);
            }
            else{
                switch(accion){
                    case 1:
                    break;
                    case 2:
                        if(nu != null){
                            nu.Position = pt2;
                            au.Clear(BackColor);
                        }
                        break;
                    case 3:
                        au.Clear(BackColor);
                        if(nu!=null){
                            au.DrawLine(fl, pt1,pt2);                       
                        }
                        break;
                    case 5:
                    if(b_mov){
                        Point po = new Point(pt2.X - pt1.X, pt2.Y - pt1.Y);
                        foreach(NodoP n in graph){
                            Point nue = new Point(n.Position.X + po.X, n.Position.Y + po.Y);
                            n.Position = nue;
                        }                        
                        pt1 = pt2;
                        au.Clear(BackColor);
                    }
                        break;                    
                }
                graph.pinta(au);
                graphics.DrawImage(bmp1, 0, 0);
            }
        }   

        #endregion
        #region otrosEventos
        
        private void Resize_form(object sender, EventArgs e){
            if (ClientSize.Width != 0 && ClientSize.Height != 0){
                bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
                graphics = CreateGraphics();
                graphics.DrawImage(bmp1, 0, 0);
            }
        }

        public void SeleccionaNodos(){
            if(origin == null || destin == null){
                if(origin == null){
                    origin = (NodoP)graph.Find(delegate(NodoP a) { if (pt2.X > a.Position.X - 15 && pt2.X < a.Position.X + 30 && pt2.Y > a.Position.Y - 15 && pt2.Y < a.Position.Y + 30)return true; else return false; });
                    if(origin != null){
                        origin.Selected = true;
                    }
                }
                else{
                    if(destin == null){
                        destin = (NodoP)graph.Find(delegate(NodoP a) { if (pt2.X > a.Position.X - 15 && pt2.X < a.Position.X + 30 && pt2.Y > a.Position.Y - 15 && pt2.Y < a.Position.Y + 30)return true; else return false; });
                        if(destin != null)
                            destin.Selected = true;
                    }
                }
            }
            else{
                nu = (NodoP)graph.Find(delegate(NodoP a) { if (pt2.X > a.Position.X - 15 && pt2.X < a.Position.X + 30 && pt2.Y > a.Position.Y - 15 && pt2.Y < a.Position.Y + 30)return true; else return false; });
                if(nu != null){
                    nu.Selected = false;
                    if(nu == origin){
                        origin = null;
                    }
                    if(nu == destin){
                        destin = null;
                    }
                    nu = null;
                }
            }
            graph.pinta(graphics);
        }

        void time_Tick(object sender, EventArgs e){
            b_tck = true;
            accion = 14;
            if (icam < 0){
                icam = CCE.Count - 1;
                b_cam = true;
            }
            else{
                icam--;
            }

            this.Form1_Paint(this, null);
        }

        public int componentes(){
            List<List<NodoP>> componentes = new List<List<NodoP>>();
            List<NodoP> nue = new List<NodoP>();
            Grafo aux = new Grafo(graph);
            bool enco = false;

            foreach(NodoP nod in graph){
                foreach(List<NodoP> n in componentes){
                    if(enco == false){
                        if(n.Find(delegate(NodoP f) { if (f.Name == nod.Name)return true; else return false; }) != null){
                            enco = true;
                        }
                    }
                }
                if(enco == false){
                    nue = new List<NodoP>();
                    graph.Componentes2(nod, nue);
                    componentes.Add(nue);
                }
                enco = false;
            }
            foreach(NodoP re in graph){
                foreach(NodoRel rela in re.relations){
                    rela.Visited = false;
                }
            }
            return componentes.Count;
        }

        #endregion

        /*private void TamNodo_ValueChange(object sender, EventArgs e){

            int res = graph.RADIO;
            if(tamañoToolStripMenuItem.Text != null){
                graph.RADIO = int.Parse(Conf_TamNodo.Text);
            }
            else{
                graph.RADIO = res;
                Conf_TamNodo.Text = res.ToString();
            }
        }
         * */


    }
}
