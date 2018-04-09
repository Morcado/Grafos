using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EditordeGrafos{
public partial class Editor : Form{
    //bool gactivo;
    private bool band;
    private bool b_cam;
    private bool b_coloreando;
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
    private Grafo graph2;
    private Rectangle nRec;

    private Graphics graphics;
    private List<NodeP> CCE;
    private NodeP nu;
    private NodeP origin, destin;
    private Pen fl;
    private Point pt1;
    private Point pt2;
    private Timer time;
    private Notas diag;
    private Grafo graph;
    private int accion;

    public int Accion {
        get { return accion; }
        set { accion = value; }
    }
    

    private void Form1_Load(object sender, EventArgs e){

        this.BackColor = Color.White;
        b_cam = false;
        
        icam = 0;
        numero = 0;
        b_tck = false;
        CCE = new List<NodeP>();
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
        EliminaGrafo.Enabled = EliminaGraf.Enabled = false;
        Guardar.Enabled = Guard.Enabled = false;
        NombreAristas.Enabled = PesoAristas.Enabled = false;
        BorraGrafo.Enabled = BorraGraf.Enabled = false;
        Intercambio.Enabled = Intercamb.Enabled = false;
        Complemento.Enabled = false;
        //Complemento.Enabled = false;
        //PropiedadesGraf.Enabled = false;
        band = false;
        //Intercambio.Enabled = true;
        accion = 0;
        //gactivo = false;
        pt2 = new Point();
        nombre = 'A';
        time = new Timer();
        //Intercambio.Enabled = false;
        time.Tick += time_Tick;
    }       

    public Editor(){ 
        InitializeComponent();
    }

    #region mouse
    private void Form1_MouseDown(object sender, MouseEventArgs e){
        pt2 = e.Location;
        pt1 = pt2;
        Rectangle mouseRec;
        int nX, nY; // coordenadas de los nodos iniciales o finalees
        int rad = graph.NodeRadio; // obtiene el radio del grafo;

        switch(e.Button.ToString()){
            case "Left":

                if(diag != null && accion == 99){
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
                else {
                    if (accion != 0 && accion != 1) {
                        band = true;
                        Form1_Paint(this, null);
                        band = false;
                    }
                }

                break;
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

    private void Form1_MouseMove(object sender, MouseEventArgs e){
        Rectangle mouseRec;
        int nX, nY; // coordenadas de los nodos iniciales o finalees
        int rad = graph.NodeRadio; // obtiene el radio del grafo;

        if(accion == 5){
            if (e.Button == MouseButtons.Left) {
                foreach(NodeP nod in graph){         
                    nX = nod.Position.X;
                    nY = nod.Position.Y;

                    mouseRec = new Rectangle(pt2.X, pt2.Y, 5, 5);
                    nRec = new Rectangle(nX - rad / 2, nY - rad / 2, rad, rad);
 
                    if ((nRec.IntersectsWith(mouseRec))) {
                        pt2 = e.Location;
                        band = false;
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

    private void Form1_MouseUp(object sender, MouseEventArgs e){
        NodeP des;
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
                des = (NodeP)graph.Find(delegate(NodeP a) { if (e.Location.X > a.Position.X - (graph.NodeRadio / 2) && e.Location.X < a.Position.X + (graph.NodeRadio) && e.Location.Y > a.Position.Y - (graph.NodeRadio / 2) && e.Location.Y < a.Position.Y + (graph.NodeRadio ))return true; else return false; });
                if(des != null && nu != null){
                    if (nu.InsertRelation(des, graph.EdgesList.Count)) {
                        ed = new Edge(tipoarista, nu, des, "e" + graph.EdgesList.Count.ToString());
                        graph.AddEdge(ed);
                        nu.Degree++;
                        des.Degree++;
                        nu.DegreeEx++;
                        des.DegreeIn++;
                    }
                    if(tipoarista == 2 && ed.Destiny.Name!=ed.Origin.Name){
                        des.InsertRelation(nu, graph.EdgesList.Count - 1);
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
                pt1 = pt2;
                graphics.DrawImage(bmp1, 0, 0);
                break;
            case 4:
                nu = (NodeP)graph.Find(delegate(NodeP a) { if (e.Location.X > a.Position.X - graph.NodeRadio / 2 && e.Location.X < a.Position.X + graph.NodeRadio && e.Location.Y > a.Position.Y - graph.NodeRadio / 2&& e.Location.Y < a.Position.Y + graph.NodeRadio)return true; else return false; });
                if (nu != null){
                    graph.RemoveNode(nu);
                    band = true;
                    if (graph.Count == 0){
                        nombre = 'A';
                        //gactivo = false;
                    }
                    Form1_Paint(this, null);
                    band = false;
                }
                break;
            case 5:
                pt2 = pt1;
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

    private void mnuNuevo_Click(object sender, EventArgs e) {
        band = false;
        //Intercambio.Enabled = false;
  

        BackColor = Color.White;
        graphics.Clear(BackColor);
        AgregaNod.Enabled = true;
        MueveNodo.Enabled = MueveNod.Enabled = false;
        AgregaRelacion.Enabled = Dirigida.Enabled = NoDirigida.Enabled = false;
        EliminaNodo.Enabled = EliminaNod.Enabled = false;
        MueveGrafo.Enabled = MueveGraf.Enabled = false;
        AristaNoDirigida.Enabled = true;
        AristaDirigida.Enabled = true;
        EliminaArista.Enabled = EliminaArist.Enabled = false;
        graph2 = new Grafo();
        //PropiedadesGraf.Enabled = false;
        graph = new Grafo();
        nombre = 'A';
    }

    private void mnuAbrir_Click(object sender, EventArgs e) {

        OpenFileDialog filed = new OpenFileDialog();
        filed.InitialDirectory = Application.StartupPath + "\\Ejemplos";
        filed.DefaultExt = ".grafo";
        string namefile;
        filed.Filter = "Grafo Files (*.grafo)|*.grafo|All files (*.*)|*.*";
        if (filed.ShowDialog() == DialogResult.OK) {
            namefile = filed.FileName;

            try {
                using (Stream stream = File.Open(namefile, FileMode.Open)) {
                    BinaryFormatter bin = new BinaryFormatter();
                    graph = (Grafo)bin.Deserialize(stream);
                    graph.pinta(graphics);
                }
            }
            catch (IOException exe) {
                MessageBox.Show(exe.ToString());
            }

            graph2 = new Grafo();
            AgregaRelacion.Enabled = Dirigida.Enabled = NoDirigida.Enabled = true;
            AgregaNod.Enabled = true;
            //Intercambio.Enabled = true;

            if (graph.EdgesList != null && graph.EdgesList.Count > 0 && graph.EdgesList[0].Type == 1) {
                AristaDirigida.Enabled = Dirigida.Enabled = true;
                AristaNoDirigida.Enabled = NoDirigida.Enabled = false;
            }
            else {
                AristaNoDirigida.Enabled = NoDirigida.Enabled = true;
                AristaDirigida.Enabled = Dirigida.Enabled = false;
            }

            MueveGrafo.Enabled = MueveGraf.Enabled = true;
            MueveNodo.Enabled = MueveNod.Enabled = true;
            EliminaNodo.Enabled = EliminaNod.Enabled = true;
            EliminaArista.Enabled = EliminaArist.Enabled = true;

            accion = 0;
            AgregaNod.Checked = AgregaNodo.Checked = true;
            MueveNod.Checked = MueveNodo.Checked = false;
            MueveGrafo.Checked = MueveGraf.Checked = false;
            EliminaNodo.Checked = EliminaNod.Checked = false;
            EliminaArista.Checked = EliminaArist.Checked = false;
            //PropiedadesGraf.Enabled = true;
            graph.Deselect();
            nombre = 'A';

            for (int nn = 0; nn < graph.Count; nn++) {
                nombre++;
            }
        }
    }

    private void mnuGuardar_Click(object sender, EventArgs e) {
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

    private void mnuBorraGrafo_Click(object sender, EventArgs e) {
        int r = graph.NodeRadio;
        Color nc = graph.NodeColor;
        Color ec = graph.EdgeColor;
        Color nbc = graph.NodeBorderColor;
        int bw = graph.NodeBorderWidth;
        int ew = graph.EdgeWidth;
        bool env = graph.EdgeNamesVisible;
        bool ewv = graph.EdgeWeightVisible;
        graph = new Grafo();
        graphics.Clear(BackColor);
        graph2 = new Grafo();
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

    private void mnuSalir_Click(object sender, EventArgs e) {
        if (MessageBox.Show("¿Salir?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK) {
            System.Windows.Forms.Application.Exit();
        }
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
        switch (e.ClickedItem.Name) {
                
            case "Salir":
                System.Windows.Forms.Application.Exit();
                break;
        }
    }

    private void mnuAgregaNod_Click(object sender, EventArgs e) {
        pt2 = new Point();
        accion = 1;
        AgregaNod.Checked = AgregaNodo.Checked = true;
        MueveNod.Checked = MueveNodo.Checked = false;
        MueveGrafo.Checked = MueveGraf.Checked = false;
        EliminaNodo.Checked = EliminaNod.Checked = false;
        EliminaArista.Checked = EliminaArist.Checked = false;

        graph.Deselect();
    }

    private void mnuMueveNodo_Click(object sender, EventArgs e) {
        band = true;
        accion = 2;
        MueveNod.Checked = MueveNodo.Checked = true;
        AgregaNod.Checked = AgregaNodo.Checked = false;
        EliminaNodo.Checked = EliminaNod.Checked = false;
        MueveGrafo.Checked = MueveGraf.Checked = false;
        EliminaArista.Checked = EliminaArist.Checked = false;
        graph.Deselect();
    }

    private void mnuMueveGrafo_Click(object sender, EventArgs e) {
        MueveGrafo.Checked = MueveGraf.Checked = true;
        EliminaNodo.Checked = EliminaNod.Checked = false;
        MueveNod.Checked = MueveNodo.Checked = false;
        AgregaNod.Checked = AgregaNodo.Checked = false;
        EliminaArista.Checked = EliminaArist.Checked = false;
        accion = 5;
        graph.Deselect();
    }

    private void mnuEliminaNodo_Click(object sender, EventArgs e) {
        accion = 4;
        EliminaNodo.Checked = EliminaNod.Checked = true;
        MueveNod.Checked = MueveNodo.Checked = false;
        AgregaNod.Checked=AgregaNodo.Checked = false;       
        MueveGrafo.Checked = MueveGraf.Checked = false;
        EliminaArista.Checked = EliminaArist.Checked = false;
        graph.Deselect();
    }

    private void mnuEliminaArista_Click(object sender, EventArgs e) {
        accion = 6;
        EliminaArista.Checked = EliminaArist.Checked = true;
        MueveGrafo.Checked = MueveGraf.Checked = false;
        EliminaNodo.Checked = EliminaNod.Checked = false;
        MueveNod.Checked = MueveNodo.Checked = false;
        AgregaNod.Checked = AgregaNodo.Checked = false;
        graph.Deselect();
    }

    private void mnuPropGrafo_Click(object sender, EventArgs e) {
        using (var f = new GraphProperties(graph, AristaDirigida.Enabled ? 1 : 2)) {
            var result = f.ShowDialog();
            graph.Deselect();
        }
        Form1_Paint(this, null);
    }

    private void mnuIntercamb_Click(object sender, EventArgs e) {
        int cont = 0;
        char name = 'A';
        bool num;
        int aux;
        if ((int.TryParse(graph[0].Name.ToString(), out aux)) == true) {
            num = true;
        }
        else {
            num = false;
        }

        if (num == true) {
            foreach (NodeP cambio in graph) {
                cambio.Name = name.ToString();
                name++;
            }
            nombre = 'A';
            for (int i = 0; i < graph.Count; i++) {
                nombre++;
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

    private void mnuAristaDir_Click(object sender, EventArgs e) {
        accion = 3;
        band = true;
            
        MueveNod.Checked = MueveNodo.Checked = false;
        //Intercambio.Enabled = true;
        AgregaNod.Checked = AgregaNodo.Checked = false;
        EliminaNodo.Checked = EliminaNod.Checked = false;
        MueveGrafo.Checked = MueveGraf.Checked = false;
        EliminaArista.Checked = EliminaArist.Checked = false;
        AgregaRelacion.Checked = true;
           

        fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        fl.StartCap = LineCap.RoundAnchor;
        fl.Width = 4;
        tipoarista = 1;
        AristaNoDirigida.Enabled = NoDirigida.Enabled = false;
        Dirigida.Checked = AristaDirigida.Checked = true;

        graph.Deselect();
    }

    private void mnuAristaNoDir_Click(object sender, EventArgs e) {
        accion = 3;
        band = true;
        MueveNod.Checked = MueveNodo.Checked = false;
        AgregaNod.Checked = AgregaNodo.Checked = false;
        EliminaNodo.Checked = EliminaNod.Checked = false;
        MueveGrafo.Checked = MueveGraf.Checked = false;
        EliminaArista.Checked = EliminaArist.Checked = false;
        AgregaRelacion.Checked = true;
        Complemento.Checked = true;
        AristaDirigida.Enabled = Dirigida.Enabled = false;
        NoDirigida.Checked = AristaNoDirigida.Checked = false;

        fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
        fl.StartCap = LineCap.NoAnchor;
        fl.Width = 4;
        tipoarista = 2;
        graph.Deselect();

    }

    private void mnuComplemento(object sender, EventArgs e) {
        graph.Complemento();
        Invalidate();
    }

    private void mnuConfigNodAri_Click(object sender, EventArgs e) {
        using (var f2 = new ConfigNodAri(graph)) {
            var result = f2.ShowDialog();
            if (result == DialogResult.OK) {
                foreach (NodeP colNodo in graph) {
                    colNodo.Color = f2.ColNodo;
                }
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

    private void Ver_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e){
        switch (e.ClickedItem.Name){
            case "NombreAristas":
                graph.EdgeNamesVisible = !graph.EdgeNamesVisible;                
                break;
            case "PesoAristas":
                graph.EdgeWeightVisible = !graph.EdgeWeightVisible;
                break;
        }
        graph.pinta(graphics);
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
                        nu = new NodeP(pt2, nombre);
                        nombre++;
                    }
                    else{
                        nu = new NodeP(pt2,nombre );
                        nu.Name = numero.ToString();
                        numero++;
                    }
                    if(graph.Count == 0){
                        Dirigida.Enabled = NoDirigida.Enabled = true;
                    }
                    if(graph.Count > 1){
                        nu.Color = graph[0].Color;
                    }
                    graph.AddNode(nu);
                    AgregaRelacion.Enabled= true;
                       
                    MueveGrafo.Enabled = MueveGraf.Enabled = true;
                    MueveNodo.Enabled=MueveNod.Enabled = true;
                    EliminaNodo.Enabled=EliminaNod.Enabled = true;
                    EliminaArista.Enabled = EliminaArist.Enabled = true;
                    EliminaGrafo.Enabled = EliminaGraf.Enabled = true;
                    Guardar.Enabled = Guard.Enabled = true;
                    NombreAristas.Enabled = PesoAristas.Enabled = true;
                    BorraGrafo.Enabled = BorraGraf.Enabled = true;
                    Intercambio.Enabled = Intercamb.Enabled = true;
                    Complemento.Enabled = true;
                    //gactivo = true;
                    nu = null;          
                    break;
                case 2:
                    nu = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - (graph.NodeRadio / 2) && pt2.X < a.Position.X + (graph.NodeRadio) && pt2.Y > a.Position.Y - (graph.NodeRadio / 2) && pt2.Y < a.Position.Y + (graph.NodeRadio ))return true; else return false; });
                    break;
                case 3:
                    nu = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - (graph.NodeRadio / 2) && pt2.X < a.Position.X + (graph.NodeRadio) && pt2.Y > a.Position.Y - (graph.NodeRadio / 2) && pt2.Y < a.Position.Y + (graph.NodeRadio))return true; else return false; });
                    pt1 = pt2;                        
                    break;
                case 5:
                    Grafo aux = new Grafo();
                    aux = graph;
                    break;
                case 6: // elimina arista
                    Edge arista;
                    Rectangle mouseRec, niRec, nfRec;
                    int niX, niY, nfX, nfY; // coordenadas de los nodos iniciales o finalees
                    int rad = graph.NodeRadio; // obtiene el radio del grafo,
                    int total = graph.EdgesList.Count;

                    for(int i = 0; i < total; i++){
                        arista = graph.EdgesList[i];
                        if (arista.toca(pt2)){

                            niX = arista.Origin.Position.X;
                            niY = arista.Origin.Position.Y;
                            nfX = arista.Destiny.Position.X;
                            nfY = arista.Destiny.Position.Y;

                            mouseRec = new Rectangle(pt2.X, pt2.Y, 3, 3);
                            niRec = new Rectangle(niX - rad/2, niY - rad/2, rad, rad);
                            nfRec = new Rectangle(nfX - rad/2, nfY - rad/2, rad, rad);

                            if (!(niRec.IntersectsWith(mouseRec))) {
                                if (!(nfRec.IntersectsWith(mouseRec))){
                                    graph.RemoveEdge(arista);
                                    if (b_coloreando == true) {
                                        graph.colorear();
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case 14:  
                    Edge ari;
                    NodeP o, d;

                    o=d=null;
                    if(b_cam == true){
                        ari = new Edge(); ;
                        graph = new Grafo(graph2);
                        graph.EdgesList.Clear();
                        foreach (NodeP rel in graph)
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
                            graph.Find(delegate(NodeP dx) { if (dx.Name == CCE[icam].Name)return true; else return false; }).InsertRelation(graph.Find(delegate(NodeP ox) { if (ox.Name == CCE[icam - 1].Name)return true; else return false; }), graph.EdgesList.Count);
                            d=graph.Find(delegate(NodeP dx) { if (dx.Name == CCE[icam].Name)return true; else return false; });
                            o=graph.Find(delegate(NodeP ox) { if (ox.Name == CCE[icam - 1].Name)return true; else return false; });
                            d.Color = Color.Blue;
                            o.Color = Color.Blue;
                            Pen penn = new Pen(Brushes.Red);
                            penn.Width = 4;
                            graphics.DrawEllipse(penn,new Rectangle(d.Position.X - 16, d.Position.Y - 16,30, 30));
                            ari = new Edge(1, d, o, "e" + (CCE.Count - icam).ToString());                                          
                            graph.AddEdge(ari);
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
                    pt2 = pt1;
                    break;
                case 3:
                    au.Clear(BackColor);
                    if(nu!=null){
                        au.DrawLine(fl, pt1,pt2);                       
                    }
                   
                    break;
                case 5:
                    Point po = new Point(pt2.X - pt1.X, pt2.Y - pt1.Y);
                    foreach(NodeP n in graph){
                        Point nue = new Point(n.Position.X + po.X, n.Position.Y + po.Y);
                        n.Position = nue;
                    }                        
                    pt1 = pt2;
                    au.Clear(BackColor);
                    
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
                origin = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - 15 && pt2.X < a.Position.X + 30 && pt2.Y > a.Position.Y - 15 && pt2.Y < a.Position.Y + 30)return true; else return false; });
                if(origin != null){
                    origin.Selected = true;
                }
            }
            else{
                if(destin == null){
                    destin = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - 15 && pt2.X < a.Position.X + 30 && pt2.Y > a.Position.Y - 15 && pt2.Y < a.Position.Y + 30)return true; else return false; });
                    if(destin != null)
                        destin.Selected = true;
                }
            }
        }
        else{
            nu = (NodeP)graph.Find(delegate(NodeP a) { if (pt2.X > a.Position.X - 15 && pt2.X < a.Position.X + 30 && pt2.Y > a.Position.Y - 15 && pt2.Y < a.Position.Y + 30)return true; else return false; });
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
        List<List<NodeP>> componentes = new List<List<NodeP>>();
        List<NodeP> nue = new List<NodeP>();
        Grafo aux = new Grafo(graph);
        bool enco = false;

        foreach(NodeP nod in graph){
            foreach(List<NodeP> n in componentes){
                if(enco == false){
                    if(n.Find(delegate(NodeP f) { if (f.Name == nod.Name)return true; else return false; }) != null){
                        enco = true;
                    }
                }
            }
            if(enco == false){
                nue = new List<NodeP>();
                graph.Componentes2(nod, nue);
                componentes.Add(nue);
            }
            enco = false;
        }
        foreach(NodeP re in graph){
            foreach(NodeR rela in re.relations){
                rela.Visited = false;
            }
        }
        return componentes.Count;
    }

    #endregion

    private void borraTodoToolStripMenuItem_Click(object sender, EventArgs e) {
        AgregaNodo.Enabled = AgregaNod.Enabled = true;
        MueveNodo.Enabled = MueveNod.Enabled = false;
        AgregaRelacion.Enabled = Dirigida.Enabled = NoDirigida.Enabled = false;
        EliminaNodo.Enabled = EliminaNod.Enabled = false;
        MueveGrafo.Enabled = MueveGraf.Enabled = false;
        EliminaArista.Enabled = EliminaArist.Enabled = false;
        EliminaGrafo.Enabled = EliminaGraf.Enabled = false;
        Guardar.Enabled = Guard.Enabled = false;
        NombreAristas.Enabled = PesoAristas.Enabled = false;
        BorraGrafo.Enabled = BorraGraf.Enabled = false;
        Intercambio.Enabled = Intercamb.Enabled = false;
        Complemento.Enabled = false;
        graph = new Grafo();
        graphics.Clear(BackColor);
        graph2 = new Grafo();
        nombre = 'A';
    }

    private void examen_Click(object sender, EventArgs e) {
        EliminaNod.Enabled = EliminaNodo.Enabled = false;
        AgregaNod.Enabled = AgregaNodo.Enabled = false;
        AristaDirigida.Enabled = AristaNoDirigida.Enabled = false;
        Dirigida.Enabled = NoDirigida.Enabled = false;
        accion = 99;
        diag = new Notas(graph, this);
        diag.Location = new Point(this.ClientSize.Width + this.Left, this.Top);
        diag.TopMost = true;
        diag.Show();
            
        
        Form1_Paint(this, null);
    }

    public void ActivaMenus() {
        EliminaNod.Enabled = EliminaNodo.Enabled = true;
        AgregaNod.Enabled = AgregaNodo.Enabled = true;
        AristaNoDirigida.Enabled = AristaDirigida.Enabled = true;
        Dirigida.Enabled = NoDirigida.Enabled = true;
    }

}
}
