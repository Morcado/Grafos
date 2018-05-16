using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EditordeGrafos{
public partial class Editor : Form {
    private bool band;
    private char nombre;
    private int numero;
    private bool edgeIsDirected;
    private int timerOption;
    private Edge edge;
    private Bitmap bmp1;
    private Graphics graphics;
    private NodeP nu;
    private Pen fl;
    private Point pt1;
    private Point pt2;
    private Notas diag;
    private Graph graph;
    private int option;
    private int tmpCount;
    private int tmp2Count;
    private Timer timer1;
    private List<Edge> tmpEdges;
    private List<List<Edge>> tmp2Edges;
    private List<Color> listColors;
    
    

    public int Accion {
        get { return option; }
        set { option = value; }
    }

    #region Structure
    // Configuraciones iniciales al editor
    private void Form1_Load(object sender, EventArgs e){
        graphics = CreateGraphics();
        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        this.BackColor = Color.White;
        fl = new Pen(Brushes.Green);
        bmp1 = new Bitmap(800,600);
        
        numero = 0;
        
        band = false;
        option = 0;
        nombre = 'A';
        pt2 = new Point();
        graph = new Graph();

        MakeColors();
        DisableMenus();

        timerOption = 0;
        timer1 = new System.Windows.Forms.Timer();
        timer1.Interval = 700;
        timer1.Tick += new EventHandler(GraphTimer);
        tmpCount = 0;
        tmp2Count = 0;
    }

    public void MakeColors() {
        listColors = new List<Color>();
        listColors.Add(Color.FromArgb(135, 255, 95));

        listColors.Add(Color.FromArgb(0, 135, 0));
        listColors.Add(Color.FromArgb(95, 135, 175));
        listColors.Add(Color.FromArgb(175, 135, 135));
        listColors.Add(Color.FromArgb(175, 135, 255));
        listColors.Add(Color.FromArgb(215, 255, 255));
        listColors.Add(Color.FromArgb(215, 135, 95));
        listColors.Add(Color.FromArgb(135, 255, 175));
        listColors.Add(Color.FromArgb(95, 175, 135));
        listColors.Add(Color.FromArgb(135, 255, 215));
        listColors.Add(Color.FromArgb(255, 95, 95));
        listColors.Add(Color.FromArgb(0, 255, 0));
        listColors.Add(Color.FromArgb(0, 95, 175));
        listColors.Add(Color.FromArgb(128, 128, 128));
        listColors.Add(Color.FromArgb(175, 95, 0));
        listColors.Add(Color.FromArgb(215, 0, 255));
        listColors.Add(Color.FromArgb(95, 0, 135));
        listColors.Add(Color.FromArgb(95, 215, 135));
        listColors.Add(Color.FromArgb(215, 175, 255));
        listColors.Add(Color.FromArgb(98, 98, 98));
        listColors.Add(Color.FromArgb(215, 215, 215));
        listColors.Add(Color.FromArgb(95, 0, 215));
        listColors.Add(Color.FromArgb(175, 95, 255));
        listColors.Add(Color.FromArgb(0, 135, 95));
        listColors.Add(Color.FromArgb(215, 0, 0));
        listColors.Add(Color.FromArgb(255, 0, 255));
        listColors.Add(Color.FromArgb(175, 255, 175));
        listColors.Add(Color.FromArgb(135, 135, 175));
        listColors.Add(Color.FromArgb(178, 178, 178));
        listColors.Add(Color.FromArgb(135, 95, 215));
        listColors.Add(Color.FromArgb(255, 95, 175));
        listColors.Add(Color.FromArgb(135, 95, 135));
        listColors.Add(Color.FromArgb(215, 175, 135));
        listColors.Add(Color.FromArgb(215, 0, 215));
        listColors.Add(Color.FromArgb(135, 0, 255));
        listColors.Add(Color.FromArgb(215, 255, 0));
        listColors.Add(Color.FromArgb(255, 0, 175));
        
        listColors.Add(Color.FromArgb(215, 135, 175));
        listColors.Add(Color.FromArgb(135, 95, 175));
        listColors.Add(Color.FromArgb(38, 38, 38));
        listColors.Add(Color.FromArgb(128, 128, 0));
        listColors.Add(Color.FromArgb(95, 175, 95));
        listColors.Add(Color.FromArgb(95, 95, 255));
        listColors.Add(Color.FromArgb(135, 175, 0));
        listColors.Add(Color.FromArgb(95, 0, 95));
        listColors.Add(Color.FromArgb(108, 108, 108));
        listColors.Add(Color.FromArgb(255, 0, 255));
        listColors.Add(Color.FromArgb(215, 175, 215));
        listColors.Add(Color.FromArgb(135, 135, 0));
        listColors.Add(Color.FromArgb(215, 95, 135));
        listColors.Add(Color.FromArgb(215, 255, 135));
        listColors.Add(Color.FromArgb(255, 135, 135));
        listColors.Add(Color.FromArgb(215, 95, 215));
        listColors.Add(Color.FromArgb(135, 215, 135));
        listColors.Add(Color.FromArgb(0, 95, 135));
        listColors.Add(Color.FromArgb(255, 0, 0));
        listColors.Add(Color.FromArgb(255, 95, 0));
        listColors.Add(Color.FromArgb(135, 215, 95));
        listColors.Add(Color.FromArgb(128, 128, 128));
        listColors.Add(Color.FromArgb(175, 255, 255));
        listColors.Add(Color.FromArgb(175, 255, 95));
        listColors.Add(Color.FromArgb(135, 95, 0));
        listColors.Add(Color.FromArgb(255, 255, 0));
        listColors.Add(Color.FromArgb(28, 28, 28));
        listColors.Add(Color.FromArgb(175, 175, 175));
        listColors.Add(Color.FromArgb(95, 175, 175));
        listColors.Add(Color.FromArgb(138, 138, 138));
        listColors.Add(Color.FromArgb(0, 175, 255));
        listColors.Add(Color.FromArgb(215, 175, 95));
        listColors.Add(Color.FromArgb(95, 215, 0));
        listColors.Add(Color.FromArgb(0, 95, 95));
        listColors.Add(Color.FromArgb(168, 168, 168));
        listColors.Add(Color.FromArgb(0, 215, 175));
        listColors.Add(Color.FromArgb(175, 175, 255));
        listColors.Add(Color.FromArgb(8, 8, 8));
        listColors.Add(Color.FromArgb(0, 255, 175));
        listColors.Add(Color.FromArgb(135, 95, 255));
        listColors.Add(Color.FromArgb(175, 175, 95));
        listColors.Add(Color.FromArgb(175, 175, 135));
        listColors.Add(Color.FromArgb(135, 255, 255));
        listColors.Add(Color.FromArgb(215, 215, 175));
        listColors.Add(Color.FromArgb(95, 255, 175));
        listColors.Add(Color.FromArgb(0, 175, 0));
        listColors.Add(Color.FromArgb(135, 255, 0));
        listColors.Add(Color.FromArgb(228, 228, 228));
        listColors.Add(Color.FromArgb(95, 135, 255));
        listColors.Add(Color.FromArgb(255, 215, 175));
        listColors.Add(Color.FromArgb(135, 215, 215));
        listColors.Add(Color.FromArgb(0, 215, 0));
        listColors.Add(Color.FromArgb(188, 188, 188));
        listColors.Add(Color.FromArgb(135, 0, 135));
        listColors.Add(Color.FromArgb(95, 255, 0));
        listColors.Add(Color.FromArgb(238, 238, 238));
        listColors.Add(Color.FromArgb(148, 148, 148));
        listColors.Add(Color.FromArgb(215, 95, 95));
        listColors.Add(Color.FromArgb(0, 0, 95));

        listColors.Add(Color.FromArgb(215, 215, 255));
        listColors.Add(Color.FromArgb(135, 0, 95));
        listColors.Add(Color.FromArgb(95, 215, 175));
        listColors.Add(Color.FromArgb(255, 215, 0));
    }

    public Editor(){ 
        InitializeComponent();
    }

    // Maneja la redimencion del area cliente
    private void Resize_form(object sender, EventArgs e) {
        if (ClientSize.Width != 0 && ClientSize.Height != 0) {
            bmp1 = new Bitmap(ClientSize.Width, ClientSize.Height);
            graphics = CreateGraphics();
            graphics.DrawImage(bmp1, 0, 0);
        }
    }

    //Timer que permite hacer animaciones
    void GraphTimer(object sender, EventArgs e) {
        switch (timerOption) {
            // Dibujar lista de aristas
            case 1:
                if (tmpCount == tmpEdges.Count || tmpCount == listColors.Count) {
                    timer1.Stop();
                    tmpEdges.Clear();
                }
                else {
                    graphics.DrawLine(new Pen(new SolidBrush(listColors[0]), (float)6), tmpEdges[tmpCount].Origin.Position, tmpEdges[tmpCount].Destiny.Position);
                    tmpCount++;
                }
                break;
            // Dibujar lista de lista de aristas;
            case 2:
                if (tmpCount == tmp2Edges.Count || tmpCount == listColors.Count) {
                    timer1.Stop();
                    tmp2Edges.Clear();
                }
                else {
                    foreach (Edge eee in tmp2Edges[tmpCount]) {
                        graphics.DrawLine(new Pen(new SolidBrush(listColors[tmpCount]), (float)6), eee.Origin.Position, eee.Destiny.Position);
                    }
                    tmpCount++;
                }
                break;

        }
    }

    #endregion
    #region Mouse

    // Eventos cuando se hace click izquierdo o derecho con el mouse
    private void Form1_MouseDown(object sender, MouseEventArgs e){
        pt2 = e.Location;
        pt1 = pt2;
        Rectangle nRec;
        Rectangle mouseRec;
        int nX, nY; // coordenadas de los nodos iniciales o finalees
        int rad = graph.NodeRadio; // obtiene el radio del grafo;

        switch(e.Button.ToString()){
            case "Left":
                // Cuando es click izquierdo y esta activo la opcion de "Notas"
                if(diag != null && option == 99){
                    foreach (NodeP nod in graph) {
                        nX = nod.Position.X;
                        nY = nod.Position.Y;

                        mouseRec = new Rectangle(pt2.X, pt2.Y, 5, 5);
                        nRec = new Rectangle(nX - rad / 2, nY - rad / 2, rad, rad);
                        if (nRec.IntersectsWith(mouseRec)) {
                            diag.eliminaNodo(nod);
                            Invalidate();
                            break;
                        }
                    }
                }
                // Cuando es click en cualquier otra opción
                else {
                    if (option != 0 && option != 1) {
                        band = true;
                        Form1_Paint(this, null);
                        band = false;
                    }
                }

                break;
            // Click derecho para asignar peso a la arista
            case "Right":
                int totalEdges = graph.EdgesList.Count;
                    for(int i = 0; i < totalEdges; i++){
                        edge = graph.EdgesList[i];
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

    // Eventos cuando se mueve el mouse
    private void Form1_MouseMove(object sender, MouseEventArgs e){
        Rectangle mouseRec;
        Rectangle nRec;
        int nX, nY; // coordenadas de los nodos iniciales o finalees
        int rad = graph.NodeRadio; // obtiene el radio del grafo;


        // Mover el grafo
        if(option == 5){
            
            if (e.Button == MouseButtons.Left) {
                foreach(NodeP nod in graph){         
                    nX = nod.Position.X;
                    nY = nod.Position.Y;

                    mouseRec = new Rectangle(pt2.X, pt2.Y, 5, 5);
                    nRec = new Rectangle(nX - rad / 2, nY - rad / 2, rad, rad);
 
                    if ((nRec.IntersectsWith(mouseRec))) {
                        pt2 = e.Location;
                        Form1_Paint(this, null);
                    }
                }
            }
        }
        else{
            if (e.Button == MouseButtons.Left) {
                pt2 = e.Location;
                band = false;
                Form1_Paint(this, null);

            }
        }
    }

    // Eventos cuando se levanta el mouse
    private void Form1_MouseUp(object sender, MouseEventArgs e){
        Edge ed = new Edge();
        NodeP des;
        Graphics au;
        au = Graphics.FromImage(bmp1);
        au.Clear(BackColor);
        switch(option){
            // Agregar nodo
            case 1:
                pt1 = pt2;
                pt2 = e.Location;
                band = true;
                Form1_Paint(this, null);
                band = false;    
                break;
            // Mover nodo
            case 2:
                nu = null; 
                break;
            // Arista dirigida y no dirigida
            case 3:
                des = (NodeP)graph.Find(delegate(NodeP a) { if (e.Location.X > a.Position.X - (graph.NodeRadio / 2) && e.Location.X < a.Position.X + (graph.NodeRadio) && e.Location.Y > a.Position.Y - (graph.NodeRadio / 2) && e.Location.Y < a.Position.Y + (graph.NodeRadio ))return true; else return false; });
                if(des != null && nu != null){
                    nu.InsertRelation(des, graph.EdgesList.Count, edgeIsDirected);
                    ed = new Edge(nu, des, "e" + graph.EdgesList.Count.ToString());
                    graph.AddEdge(ed);

                    if(!edgeIsDirected && ed.Destiny.Name != ed.Origin.Name){
                        des.InsertRelation(nu, graph.EdgesList.Count - 1, edgeIsDirected);
                    }
                    pinta(au);
                    band = false;
                    nu = null;                       
                }
                else{
                    pinta(au);
                }
                pt1 = pt2;
                if (graph.EdgesList.Count > 0) {
                    tT_removeEdge.Enabled = m_deleteEdge.Enabled = true;
                }
                EnableMenus();
                graphics.DrawImage(bmp1, 0, 0);
                break;
            // Eliminar nodo
            case 4:
                nu = (NodeP)graph.Find(delegate(NodeP a) { if (e.Location.X > a.Position.X - graph.NodeRadio / 2 && e.Location.X < a.Position.X + graph.NodeRadio && e.Location.Y > a.Position.Y - graph.NodeRadio / 2&& e.Location.Y < a.Position.Y + graph.NodeRadio)return true; else return false; });
                if (nu != null){
                    graph.RemoveNode(nu);
                    if (graph.Count < 2) {          
                        m_undirectedEdge.Enabled = m_directedEdge.Enabled = false;
                        tT_undirectedEdge.Enabled = tT_directedEdge.Enabled = false;
                    }
                    else {
                        if (graph.EdgesList.Count == 0) {
                            m_undirectedEdge.Enabled = m_directedEdge.Enabled = true;
                            tT_undirectedEdge.Enabled = tT_directedEdge.Enabled = true;
                        }

                    }
                    if (graph.Count == 0){
                        nombre = 'A';
                        DisableMenus();
                        UncheckMenus();
                    }
                    Form1_Paint(this, null);
                    band = false;
                }
                break;
            // Mover grafo
            case 5:
                pt2 = pt1;
                break;

        }
    }

    #endregion
    #region TopToolbar

    // Abrir un grafo
    private void mOpenGraph(object sender, EventArgs e) {
        OpenFileDialog OpenFile = new OpenFileDialog();
        OpenFile.InitialDirectory = Application.StartupPath + "\\ProyectosGrafo";
        OpenFile.DefaultExt = ".grafo";
        string namefile;
        OpenFile.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
        if (OpenFile.ShowDialog() == DialogResult.OK) {
            namefile = OpenFile.FileName;

            try {
                using (Stream stream = File.Open(namefile, FileMode.Open)) {
                    BinaryFormatter bin = new BinaryFormatter();
                    graph = (Graph)bin.Deserialize(stream);
                    pinta(graphics);
                }
            }
            catch (IOException exe) {
                MessageBox.Show(exe.ToString());
            }

            EnableMenus();

            // Verifica dirigido o no dirigido
            if (graph.EdgesList != null && graph.EdgesList.Count > 0 && edgeIsDirected) {
                m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
                m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;
            }
            else {
                m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
                m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
            }

            option = 0;
            graph.UnselectAllNodes();   
            nombre = graph[graph.Count - 1].Name[0];
        }
    }

    // Guarda un grafo
    private void mSaveGraph(object sender, EventArgs e) {
        SaveFileDialog sav = new SaveFileDialog();
        sav.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
        sav.InitialDirectory = Application.StartupPath + "\\ProyectosGrafo";
        String nombr;
        if (sav.ShowDialog() == DialogResult.OK) {
            nombr = sav.FileName;

            try {
                using (Stream stream = File.Open(nombr, FileMode.Create)) {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, graph);
                }
            }
            catch (IOException exe) {
                MessageBox.Show(exe.ToString());
            }
        }
    }

    // Elimina grafo y mantiene la configuracion
    private void mEraseGraph(object sender, EventArgs e) {
        DisableMenus();
        UncheckMenus();
        graph.Clear();
        graph = new Graph();
        graphics.Clear(BackColor);
        nombre = 'A';

    }

    // Borra grafo y restablece la configuración
    private void mDeleteGraph(object sender, EventArgs e) {
        int r = graph.NodeRadio;
        Color nc = graph.NodeColor;
        Color ec = graph.EdgeColor;
        Color nbc = graph.NodeBorderColor;
        int bw = graph.NodeBorderWidth;
        int ew = graph.EdgeWidth;
        bool env = graph.EdgeNamesVisible;
        bool ewv = graph.EdgeWeightVisible;
        graph = new Graph();
        graphics.Clear(BackColor);
        nombre = 'A';
        graph.NodeRadio = r;
        graph.NodeColor = nc;
        graph.EdgeColor = ec;
        graph.NodeBorderColor = nbc;
        graph.NodeBorderWidth = bw;
        graph.EdgeWidth = ew;
        graph.EdgeNamesVisible = env;
        graph.EdgeWeightVisible = ewv;
    }

    // Evento salir
    private void mExit(object sender, EventArgs e) {
        if (MessageBox.Show("¿Salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK) {
            System.Windows.Forms.Application.Exit();
        }
    }

    // Evento agrega nodo
    private void mAddNode(object sender, EventArgs e) {
        UncheckMenus();
        pt2 = new Point();
        tT_addNode.Checked = true;
        option = 1;
    }
    // Evento mueve nodo
    private void mMoveNode(object sender, EventArgs e) {
        UncheckMenus();
        band = true;
        option = 2;
        tT_moveNode.Checked = true;
    }
    // Evento mueve grafo
    private void mMoveGraph(object sender, EventArgs e) {
        
        UncheckMenus();
        option = 5;
        tT_moveGraph.Checked = true;
    }

    // Evento elimina nodo
    private void mDeleteNode(object sender, EventArgs e) {
        UncheckMenus();
        tT_deleteNode.Checked = true;
        option = 4;
    }
    // Evento elimina arista
    private void mDeleteEdge(object sender, EventArgs e) {
        UncheckMenus();
        option = 6;
        tT_removeEdge.Checked = true;
    }

    // Evento arista dirigida
    private void mDirectedEdge(object sender, EventArgs e) {
        option = 3;
        band = true;

        UncheckMenus();
        tT_directedEdge.Checked = true;

        fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        fl.StartCap = LineCap.RoundAnchor;
        fl.Width = 4;
        edgeIsDirected = true;
    }

    // Evento arista no digirida
    private void mUndirectedEdge(object sender, EventArgs e) {
        option = 3;
        band = true;
        UncheckMenus();
        tT_undirectedEdge.Checked = true;

        fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
        fl.StartCap = LineCap.NoAnchor;
        fl.Width = 4;
        edgeIsDirected = false;
    }

    // Intercambia las letras por numeros en las aristas
    private void mExchange() {
        int cont = 0;
        char name = 'A';
        bool num = graph.Letter;

        if (num == true) {
            foreach (NodeP cambio in graph) {
                cambio.Name = name.ToString();
                name++;
            }
            name = 'A';
            for (int i = 0; i < graph.Count; i++) {
                name++;
            }
        }
        else {
            numero = graph.Count;
            foreach (NodeP cambio in graph) {
                cambio.Name = cont.ToString();
                cont++;
            }
        }
        Form1_Paint(this, null);
    }

    // Abre la configuración del nodo y arista
    private void mConfiguration(object sender, EventArgs e) {
        using (var f2 = new ConfigNodAri(graph)) {
            var result = f2.ShowDialog();
            if (result == DialogResult.OK) {
                foreach (NodeP colNodo in graph) {
                    colNodo.Color = f2.ColNodo;
                }
                graph.Letter = f2.Letra;
                mExchange();
                graph.NodeRadio = f2.Radio;
                graph.NodeColor = f2.ColNodo;
                graph.EdgeColor = f2.ColArista;
                graph.NodeBorderColor = f2.ColBordeNodo;
                graph.NodeBorderWidth = f2.AnchoBordeNodo;
                graph.EdgeWidth = f2.AnchoArista;
                graph.EdgeNamesVisible = f2.NombreArista;
                graph.EdgeWeightVisible = f2.PesoArista;
            }
        }
        Form1_Paint(this, null);
    }
    // Evento view
    private void mView(object sender, ToolStripItemClickedEventArgs e) {
        switch (e.ClickedItem.Name) {
            case "NombreAristas":
                graph.EdgeNamesVisible = !graph.EdgeNamesVisible;
                break;
            case "PesoAristas":
                graph.EdgeWeightVisible = !graph.EdgeWeightVisible;
                break;
        }
        pinta(graphics);
    }

    #endregion
    #region Paint

    private void Form1_Paint(object sender, PaintEventArgs e){
        Graphics au = Graphics.FromImage(bmp1);
        au.Clear(BackColor);
        if (option == 5) {
            Cursor.Current = Cursors.Hand;
        }
        switch(option){
            // Agrega nodo
            case 1:
                if (band) {
                    bool num = false;
                    int iaux;
                    if (graph.Count > 0) {
                        if ((int.TryParse(graph[0].Name.ToString(), out iaux)) == true) {
                            num = true;
                        }
                    }
                    nu = new NodeP(pt2, nombre);
                    if (num == false) {
                        nombre++;
                    }
                    else {
                        nu.Name = numero.ToString();
                        numero++;
                    }

                    if (graph.Count > 1) {
                        nu.Color = graph[0].Color;
                    }
                    EnableMenus();
                    graph.AddNode(nu);
                }
                break;
            // Mueve nodo
            case 2:
                if (band) {
                    nu = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - (graph.NodeRadio / 2) && pt2.X < a.Position.X + (graph.NodeRadio) && pt2.Y > a.Position.Y - (graph.NodeRadio / 2) && pt2.Y < a.Position.Y + (graph.NodeRadio))return true; else return false; });
                }
                else {

                    if (nu != null) {
                        nu.Position = pt2;
                        au.Clear(BackColor);
                    }
                    pt2 = pt1;
                }
                break;
            // Arista dirigida y no dirigida
            case 3:
                if (band) {
                    nu = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - (graph.NodeRadio / 2) && pt2.X < a.Position.X + (graph.NodeRadio) && pt2.Y > a.Position.Y - (graph.NodeRadio / 2) && pt2.Y < a.Position.Y + (graph.NodeRadio))return true; else return false; });
                    pt1 = pt2;
                }
                else {
                    au.Clear(BackColor);
                    if (nu != null) {
                        au.DrawLine(fl, pt1, pt2);
                    }
                }
                break;
            // Mover grafo
            case 5:
                Point po = new Point(pt2.X - pt1.X, pt2.Y - pt1.Y);
                foreach (NodeP n in graph) {
                    Point nue = new Point(n.Position.X + po.X, n.Position.Y + po.Y);
                    n.Position = nue;
                }
                pt1 = pt2;
                au.Clear(BackColor);
                break;
            // Elimina arista
            case 6:
                if (band) {
                    Rectangle mouseRec, niRec, nfRec;
                    Point ini, fin;

                    foreach (Edge ed in graph.EdgesList) { 
                    //for (int i = 0; i < graph.EdgesList.Count; i++) {
                        if (ed.toca(pt2)) {

                            ini = ed.Origin.Position;
                            fin = ed.Destiny.Position;
                            mouseRec = new Rectangle(pt2.X, pt2.Y, 3, 3);
                            niRec = new Rectangle(ini.X - graph.NodeRadio / 2, ini.Y - graph.NodeRadio / 2, graph.NodeRadio, graph.NodeRadio);
                            nfRec = new Rectangle(ini.X - graph.NodeRadio / 2, ini.Y - graph.NodeRadio / 2, graph.NodeRadio, graph.NodeRadio);

                            if (!(nfRec.IntersectsWith(mouseRec))) {
                                graph.RemoveEdge(ed);
                                break;
                            }
                            
                        }
                    }
                    if (graph.EdgesList.Count == 0) {
                        tT_removeEdge.Enabled = m_deleteEdge.Enabled = false;
                    }
                }
                break;                   
        }
        pinta(au);
        graphics.DrawImage(bmp1, 0, 0);
        
    }

    private void pinta(Graphics g) {
        Pen pendi = new Pen(graph.EdgeColor, graph.EdgeWidth);
        Pen penNdi = new Pen(graph.EdgeColor, graph.EdgeWidth);
        Pen pen = new Pen(graph.NodeBorderColor, graph.NodeBorderWidth);

        AdjustableArrowCap end = new AdjustableArrowCap(6, 6);
        SolidBrush nod;
        pendi.CustomEndCap = end;
        Size s = new Size(graph.NodeRadio, graph.NodeRadio);
        double p3x, p3y, p4x, p4y;
        double ang;
        PointF A, B;
        A = new PointF();
        double d;
        double r;
        double an;
        double dy, dx;
        dy = dx = 0;
        List<Edge> repetidas = new List<Edge>();
        if (graph.EdgesList != null && graph.EdgesList.Count > 0) {
            foreach (Edge a in graph.EdgesList) {
                if (!edgeIsDirected) {
                    if (a.Origin.Name == a.Destiny.Name) {
                        g.DrawBezier(penNdi, new Point(a.Origin.Position.X + ((a.Destiny.Position.X - a.Origin.Position.X) / 2) - 10, a.Origin.Position.Y + ((a.Destiny.Position.Y - a.Origin.Position.Y) / 2) - 5), new Point(a.Origin.Position.X + ((a.Destiny.Position.X - a.Origin.Position.X) / 2) - 40, a.Origin.Position.Y - ((a.Destiny.Position.Y - a.Origin.Position.Y) / 2) - 60), new Point(a.Origin.Position.X + 40, a.Destiny.Position.Y - 60), new Point(a.Destiny.Position.X + 10, a.Destiny.Position.Y - 5));
                    }
                    else {
                        g.DrawLine(penNdi, a.Origin.Position.X, a.Origin.Position.Y, a.Destiny.Position.X, a.Destiny.Position.Y);
                    }

                    repetidas = graph.EdgesList.FindAll(delegate(Edge repe) { if (repe.Origin.Name == a.Origin.Name && repe.Destiny.Name == a.Destiny.Name || (a.Origin.Name == repe.Destiny.Name && a.Destiny.Name == repe.Origin.Name))return true; else return false; });

                    if (repetidas.Count > 1 && a.Painted == false) {
                        if ((a.Destiny.Position.Y - a.Origin.Position.Y) != 0) {
                            g.DrawString(repetidas.Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Origin.Position.X + ((a.Destiny.Position.X - a.Origin.Position.X) / 2) + 4, a.Origin.Position.Y + ((a.Destiny.Position.Y - a.Origin.Position.Y) / 2) + 4); foreach (Edge re in repetidas)
                                re.Painted = true;
                        }
                    }
                }
                else {
                    if (a.Origin.Name == a.Destiny.Name) {
                        g.DrawBezier(pendi, new Point(a.Origin.Position.X - 10, a.Origin.Position.Y - 5), new Point(a.Origin.Position.X - 40, a.Origin.Position.Y - 60), new Point(a.Origin.Position.X + 40, a.Destiny.Position.Y - 60), new Point(a.Destiny.Position.X + 10, a.Destiny.Position.Y - 10));
                    }
                    else {
                        if (graph.EdgesList.Find(delegate(Edge bus) { if (bus.Origin.Name == a.Destiny.Name && bus.Destiny.Name == a.Origin.Name)return true; else return false; }) == null) {
                            double teta1 = Math.Atan2((double)(a.Destiny.Position.Y - a.Origin.Position.Y), (double)(a.Destiny.Position.X - a.Origin.Position.X));
                            float x1 = a.Origin.Position.X + (float)((Math.Cos(teta1)) * (s.Height / 2));
                            float y1 = a.Origin.Position.Y + (float)((Math.Sin(teta1)) * (s.Height / 2));

                            double teta2 = Math.Atan2(a.Origin.Position.Y - a.Destiny.Position.Y, a.Origin.Position.X - a.Destiny.Position.X);
                            float x2 = a.Destiny.Position.X + (float)((Math.Cos(teta2)) * (s.Height / 2));
                            float y2 = a.Destiny.Position.Y + (float)((Math.Sin(teta2)) * (s.Height / 2));
                            g.DrawLine(pendi, x1, y1, x2, y2);

                            if (graph.EdgesList.FindAll(delegate(Edge repe) { if (repe.Origin.Name == a.Origin.Name && repe.Destiny.Name == a.Destiny.Name)return true; else return false; }).Count > 1) {
                                if ((a.Destiny.Position.Y - a.Origin.Position.Y) != 0) {
                                    g.DrawString(graph.EdgesList.FindAll(delegate(Edge repe) { if (repe.Origin.Name == a.Origin.Name && repe.Destiny.Name == a.Destiny.Name)return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Origin.Position.X + ((a.Destiny.Position.X - a.Origin.Position.X) / 2) + 4, a.Origin.Position.Y + ((a.Destiny.Position.Y - a.Origin.Position.Y) / 2) + 4);
                                }
                            }

                        }
                        else {
                            if (a.Painted == false) {
                                dy = a.Destiny.Position.Y - a.Origin.Position.Y;
                                dx = a.Destiny.Position.X - a.Origin.Position.X;

                                p3x = (dx * 1 / 3) + a.Origin.Position.X;
                                p3y = (dy * 1 / 3) + a.Origin.Position.Y;
                                p4x = (dx * 2 / 3) + a.Origin.Position.X;
                                p4y = (dy * 2 / 3) + a.Origin.Position.Y;

                                d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
                                r = .35 * d;

                                if (a.Destiny.Position.X != a.Origin.Position.X) {
                                    ang = Math.Atan((double)((double)dy / (double)dx));
                                }
                                else {
                                    ang = 90;
                                }

                                if (a.Destiny.Position.X > a.Origin.Position.X) {
                                    an = ang + 89.8;
                                }
                                else {
                                    an = ang - 89.8;
                                }

                                B = new PointF((float)((r * Math.Cos(an)) + p4x), (float)((r * Math.Sin(an)) + p4y /*+ 15 * (an / Math.Abs(an))*/));
                                A = new PointF((float)((r * Math.Cos(an)) + p3x), (float)((r * Math.Sin(an)) + p3y /*+ 15 * (an / Math.Abs(an))*/));

                                if (a.Destiny.Position.X > a.Origin.Position.X) {
                                    an = ang + 89.56;
                                }
                                else {
                                    an = ang - 89.56;
                                }

                                g.DrawBezier(pendi, new PointF(a.Origin.Position.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Origin.Position.Y + (float)((Math.Sin(an)) * (s.Height / 2))), A, B, new PointF(a.Destiny.Position.X + (float)((Math.Cos(an)) * (s.Height / 2)), a.Destiny.Position.Y + (float)((Math.Sin(an)) * (s.Height / 2))));
                                a.Painted = true;
                            }
                        }
                        if (graph.EdgesList.FindAll(delegate(Edge repe) { if (repe.Origin.Name == a.Origin.Name && repe.Destiny.Name == a.Destiny.Name)return true; else return false; }).Count > 1) {
                            if ((a.Destiny.Position.Y - a.Origin.Position.Y) != 0) {
                                g.DrawString(graph.EdgesList.FindAll(delegate(Edge repe) { if (repe.Origin.Name == a.Origin.Name && repe.Destiny.Name == a.Destiny.Name)return true; else return false; }).Count.ToString(), new Font("Arial", 10), Brushes.Black, a.Destiny.Position.X, A.Y - 10);
                            }
                        }
                    }
                }

                if (graph.EdgeNamesVisible) {
                    g.DrawString(a.Name, new Font("Bold", 10), Brushes.Blue, a.Origin.Position.X + ((a.Destiny.Position.X - a.Origin.Position.X) / 3) + 4, a.Origin.Position.Y + ((a.Destiny.Position.Y - a.Origin.Position.Y) / 2) + 1);
                }
                if (graph.EdgeWeightVisible) {
                    if (graph.EdgesList.Find(delegate(Edge bus) { if (bus.Origin.Name == a.Destiny.Name && bus.Destiny.Name == a.Origin.Name)return true; else return false; }) == null) {
                        g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Origin.Position.X + ((a.Destiny.Position.X - a.Origin.Position.X) / 2) + 4, a.Origin.Position.Y + ((a.Destiny.Position.Y - a.Origin.Position.Y) / 2) + 4);
                    }
                    else {
                        g.DrawString(a.Weight.ToString(), new Font("Bold", 10), Brushes.Blue, a.Destiny.Position.X, A.Y - 10);
                    }
                }

            }
        }
        if (graph.EdgesList != null) {
            foreach (Edge des in graph.EdgesList) {
                des.Painted = false;
            }
        }
        if (graph.Count > 0 && graph.NodeRadio != 0) {
            foreach (NodeP n in graph) {
                pendi.Width = 3;
                if (n.Selected == false) {
                    nod = new SolidBrush(n.Color);
                }
                else {
                    nod = new SolidBrush(Color.Red);
                }

                Rectangle re = new Rectangle(n.Position.X - (s.Height / 2), n.Position.Y - (s.Height / 2), s.Width, s.Height);
                g.FillEllipse(nod, re);
                g.DrawEllipse(pen, re);
                g.DrawString(n.Name.ToString(), new Font("Bold", graph.NodeRadio / 4), new SolidBrush(graph.NodeBorderColor), (n.Position.X - graph.NodeRadio / 4 + graph.NodeRadio / 12), (n.Position.Y - graph.NodeRadio / 4 + graph.NodeRadio / 12));
            }
        }
        pendi.Dispose();
        penNdi.Dispose();
        pen.Dispose();
    }

    #endregion
    #region Interface

    private void MenuArista_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
        if (toolStripTextBox1.Text.Length > 0) {
            edge.Weight = int.Parse(toolStripTextBox1.Text);
            edge = null;
            toolStripTextBox1.Text = "";
        }
    }

    // Método que activa todos los menús de toolstrip y del menu, cuando hay algo en el editor.
    public void EnableMenus() {
        tT_saveGraph.Enabled  = m_saveGraph.Enabled = true;
        tT_deleteNode.Enabled = m_deleteNode.Enabled = true;
        tT_moveNode.Enabled = m_moveNode.Enabled = true;
        tT_addNode.Enabled = m_addNode.Enabled = true;
        // Si hay mas de un nodo
        if (graph.Count >= 1) {
            lT_complement.Enabled = m_complement.Enabled = true;
            lT_nPartite.Enabled = m_npartite.Enabled = true;
            // Si no hay aristas
            if (graph.EdgesList.Count == 0) {
                m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
                m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
            }
            else {
                // Si hay aristas dirigidas
                if (edgeIsDirected) {
                    
                    m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
                    m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;
                   
                }
                    // Si hay aristas no dirigidas
                else {
                    lT_coloredEdges.Enabled = m_coloredEdges.Enabled = true;
                    m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
                    m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
                    lT_prim.Enabled = m_prim.Enabled = true;
                }
            }
        }

        // Si hay mas de una arista
        if (graph.EdgesList.Count > 0) {
            m_deleteEdge.Enabled = tT_removeEdge.Enabled = true;
            lT_euler.Enabled = m_euler.Enabled = true;

        }

        m_moveGraph.Enabled = tT_moveGraph.Enabled = true;
        m_deleteGraph.Enabled = tT_deleteGraph.Enabled = true;
        m_eraseGraph.Enabled = tT_eraseGraph.Enabled = true;
        m_exchange.Enabled = true;

        
    }

    // Descativa la mayoría de los botones y reinicializa el grafo
    private void DisableMenus() {
        m_addNode.Enabled = tT_addNode.Enabled = true;
        m_moveNode.Enabled = tT_moveNode.Enabled = false;
        m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
        m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;
        m_deleteNode.Enabled = tT_deleteNode.Enabled = false;
        m_moveGraph.Enabled = tT_moveGraph.Enabled = false;
        m_deleteEdge.Enabled = tT_removeEdge.Enabled = false;
        m_deleteGraph.Enabled = tT_deleteGraph.Enabled = false;
        m_saveGraph.Enabled = tT_saveGraph.Enabled = false;
        m_nombreAristas.Enabled = m_pesoAristas.Enabled = false;
        m_eraseGraph.Enabled = tT_eraseGraph.Enabled = false;
        m_exchange.Enabled = false;
        m_addEdge.Enabled = false;
        lT_complement.Enabled = m_complement.Enabled = false;
        lT_euler.Enabled = m_euler.Enabled = false;
        lT_nPartite.Enabled = m_npartite.Enabled = false;
        lT_prim.Enabled = m_prim.Enabled = false;
        lT_coloredEdges.Enabled = m_coloredEdges.Enabled = false;
    }

    public void UncheckMenus() {
        tT_addNode.Checked = false;
        tT_moveNode.Checked = false;
        tT_deleteNode.Checked = false;
        tT_directedEdge.Checked = false;
        tT_undirectedEdge.Checked = false;
        tT_removeEdge.Checked = false;
        tT_moveGraph.Checked = false;
        tT_eraseGraph.Checked = false;
        tT_deleteGraph.Checked = false;
    }

    #endregion

    private void EdgeWeigth(object sender, EventArgs e) {
        Weights w = new Weights();
        w.ShowDialog();
    }

    private void mSpecialGraph(object sender, EventArgs e) {

        SpecialGraph sg = new SpecialGraph();
        sg.ShowDialog();
        if (sg.DialogResult == DialogResult.OK) {
            switch (sg.Type) {
                case 1:
                    OpenSpecialGraph(Application.StartupPath + "/ProyectosGrafo/especiales/petersen.grafo");
                    break;
                case 2:
                    OpenSpecialGraph(Application.StartupPath + "/ProyectosGrafo/especiales/dodecahedro.grafo");
                    break;
                case 3:
                    OpenSpecialGraph(Application.StartupPath + "/ProyectosGrafo/especiales/cimitarra.grafo");
                    break;
                case 4:
                    OpenSpecialGraph(Application.StartupPath + "/ProyectosGrafo/especiales/k33.grafo");
                    break;
            }
        }
    }

    private void OpenSpecialGraph(string name) {

        try {
            using (Stream stream = File.Open(name, FileMode.Open)) {
                BinaryFormatter bin = new BinaryFormatter();
                graph = (Graph)bin.Deserialize(stream);
                pinta(graphics);
            }
        }
        catch (IOException exe) {
            MessageBox.Show(exe.ToString());
        }

        EnableMenus();

        if (graph.EdgesList != null && graph.EdgesList.Count > 0 && edgeIsDirected) {
            m_directedEdge.Enabled = tT_directedEdge.Enabled = true;
            m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = false;
        }
        else {
            m_undirectedEdge.Enabled = tT_undirectedEdge.Enabled = true;
            m_directedEdge.Enabled = tT_directedEdge.Enabled = false;
        }

        option = 0;
        graph.UnselectAllNodes();
        nombre = 'A';
        // avanza el nombre hasta el ultimo que habia
        for (int i = 0; i < graph.Count; i++) {
            nombre++;
        }

    }

    private void mInsertaKn(object sender, EventArgs e) {
        Plantilla p = new Plantilla("Insertar grafo Kn");
        p.ShowDialog();
        if (p.DialogResult == DialogResult.OK) {
            InsertaKn(p.N);
            EnableMenus();
        }
    }

    private void mInsertaWn(object sender, EventArgs e) {
        Plantilla p = new Plantilla("Insertar grafo Wn");
        p.ShowDialog();
        if (p.DialogResult == DialogResult.OK) {
            InsertaWn(p.N);
            EnableMenus();
        }
    }

    private void mInsertaCn(object sender, EventArgs e) {
        Plantilla p = new Plantilla("Insertar grafo Cn");
        p.ShowDialog();
        if (p.DialogResult == DialogResult.OK) {
            InsertaCn(p.N);
            EnableMenus();
        }
    }

    private void mNPartita(object sender, EventArgs e) {
        List<List<NodeP>> grupos = genPartita();
        MessageBox.Show("El grafo es " + grupos.Count.ToString() + "-partita");
        string conjuntos = "";
        for (int i = 0; i < grupos.Count; i++) {
            conjuntos += "Grupo " + (i + 1).ToString() + ":\n";
            for (int j = 0; j < grupos[i].Count; j++) {
                conjuntos += grupos[i][j].Name.ToString() + ", ";
            }
            conjuntos = conjuntos.Remove(conjuntos.Length - 2);
            conjuntos += "\n";
        }
        MessageBox.Show(conjuntos);
    }

    private void mKuratowsky(object sender, EventArgs e){
        Kuratowsky();
    }

    private void mComplement(object sender, EventArgs e) {
        if (!edgeIsDirected) {
            Complement();
        }
        else {
            UndirComplement();
            graph.UnselectAllNodes();
        }
    }

    private void mEuler(object sender, EventArgs e) {
        tmpEdges = EulerCycle();
        if (tmpEdges != null) {
            string camino = tmpEdges[0].Origin.Name;
            foreach (Edge ed in tmpEdges) {
                camino += " → ";
                camino += ed.Destiny.Name;
                
            }
            
            timerOption = 1;
            tmpCount = 0;
            timer1.Start();
            MessageBox.Show(camino);
        }
    }

    private void mPrim(object sender, EventArgs e) {
        tmpEdges = Prim();
        if (tmpEdges != null) {
            string prm = "Arbol de costo minimo\n";
            foreach (Edge ed in tmpEdges) {
                prm += ed.Name + ", ";
            }
            prm = prm.Remove(prm.Length - 2);
            
            timerOption = 1;
            tmpCount = 0;
            timer1.Start();
            MessageBox.Show(prm);
        }
    }

    private void mDijkstra(object sender, EventArgs e) {

    }

    private void mColoredEdges(object sender, EventArgs e) {
        tmp2Edges = ColoredEdges();
        timer1.Start();
        if (tmp2Edges != null) {
            string colored = "";
                //tmp2Edges[0].Origin.Name;
            for (int i = 0; i < tmp2Edges.Count; i++){
                colored += "Grupo " + (i+1).ToString() + ":\n"; 
                for (int j = 0; j < tmp2Edges[i].Count; j++) {
                    colored += tmp2Edges[i][j].Name + ", ";
                }
                colored = colored.Remove(colored.Length - 2);
                colored += "\n";

			}

            
            timerOption = 2;
            tmpCount = 0;
            tmp2Count = 0;
            timer1.Start();
            MessageBox.Show(colored);
        }
    }

}
}
