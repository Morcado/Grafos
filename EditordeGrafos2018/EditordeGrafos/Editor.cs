using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EditordeGrafos{
public partial class Editor : Form{

    private bool band;
    private bool b_cam;
    private bool b_tck;
    private bool b_coloreando;
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
        b_coloreando = false;
        this.BackColor = Color.White;
        b_cam = false;
        icam = 0;
        numero = 0;
        b_tck = false;
        CCE = new List<NodeP>();
        resp = Color.White;
        graph2 = new Grafo();
        ed = new Edge();
        fl = new Pen(Brushes.Green);
        bmp1 = new Bitmap(800,600);
        graphics = CreateGraphics();
        file = new BinaryFormatter();
        graph = new Grafo();

        DesactivaMenus();

        band = false;
        accion = 0;

        pt2 = new Point();
        nombre = 'A';


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
                    pinta(au);
                    band = false;
                    nu = null;                       
                }
                else{
                    pinta(au);
                }
                pt1 = pt2;
                if (graph.EdgesList.Count > 0) {
                    EliminaArist.Enabled = EliminaArista.Enabled = true;
                }
                ActivaMenus();
                graphics.DrawImage(bmp1, 0, 0);
                break;
            case 4:
                nu = (NodeP)graph.Find(delegate(NodeP a) { if (e.Location.X > a.Position.X - graph.NodeRadio / 2 && e.Location.X < a.Position.X + graph.NodeRadio && e.Location.Y > a.Position.Y - graph.NodeRadio / 2&& e.Location.Y < a.Position.Y + graph.NodeRadio)return true; else return false; });
                if (nu != null){
                    graph.RemoveNode(nu);
                    if (graph.Count < 2) {          
                        AristaNoDirigida.Enabled = AristaDirigida.Enabled = false;
                        AristaNoDirigid.Enabled = AristaDirigid.Enabled = false;
                    }
                    else {
                        if (graph.EdgesList.Count == 0) {
                            AristaNoDirigida.Enabled = AristaDirigida.Enabled = true;
                            AristaNoDirigid.Enabled = AristaDirigid.Enabled = true;
                        }

                    }
                    if (graph.Count == 0){
                        nombre = 'A';
                        DesactivaMenus();
                        Uncheck();
                    }
                    Form1_Paint(this, null);
                    band = false;
                }
                break;
            case 5:
                pt2 = pt1;
                break;
            case 8:
                SeleccionaNodos();
                break;
        }
    }

    #endregion
    #region menus

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
                    pinta(graphics);
                }
            }
            catch (IOException exe) {
                MessageBox.Show(exe.ToString());
            }

            graph2 = new Grafo();
            ActivaMenus();

            if (graph.EdgesList != null && graph.EdgesList.Count > 0 && graph.EdgesList[0].Type == 1) {
                AristaDirigida.Enabled = AristaDirigid.Enabled = true;
                AristaNoDirigida.Enabled = AristaNoDirigid.Enabled = false;
            }
            else {
                AristaNoDirigida.Enabled = AristaNoDirigid.Enabled = true;
                AristaDirigida.Enabled = AristaDirigid.Enabled = false;
            }

            accion = 0;
            graph.Deselect();
            nombre = 'A';
            // avanza el nombre hasta el ultimo que habia
            for (int i = 0; i < graph.Count; i++) {
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

    private void mnuAgregaNod_Click(object sender, EventArgs e) {
        pt2 = new Point();
        Uncheck();
        AgregaNod.Checked = true;
        accion = 1;
        graph.Deselect();
    }

    private void mnuMueveNodo_Click(object sender, EventArgs e) {
        band = true;
        accion = 2;
        Uncheck();
        MueveNod.Checked = true;
        
        graph.Deselect();
    }

    private void mnuMueveGrafo_Click(object sender, EventArgs e) {
        accion = 5;
        Uncheck();
        MueveGraf.Checked = true;
        graph.Deselect();
    }

    private void mnuEliminaNodo_Click(object sender, EventArgs e) {
        Uncheck();
        EliminaNod.Checked = true;
        accion = 4;
        graph.Deselect();
    }

    private void mnuEliminaArista_Click(object sender, EventArgs e) {
        accion = 6;
        Uncheck();
        EliminaArist.Checked = true;
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

        Uncheck();
        AristaDirigid.Checked = true;

        fl.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        fl.StartCap = LineCap.RoundAnchor;
        fl.Width = 4;
        tipoarista = 1;

        graph.Deselect();
    }

    private void mnuAristaNoDir_Click(object sender, EventArgs e) {
        accion = 3;
        band = true;
        Uncheck();
        AristaNoDirigid.Checked = true;

        fl.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
        fl.StartCap = LineCap.NoAnchor;
        fl.Width = 4;
        tipoarista = 2;
        graph.Deselect();

    }

    private void mnuComplemento(object sender, EventArgs e) {
        graph.Complement();
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
        pinta(graphics);
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

                    if(graph.Count > 1){
                        nu.Color = graph[0].Color;
                    }
                    ActivaMenus();
                    graph.AddNode(nu);

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
                                if (!(nfRec.IntersectsWith(mouseRec))) {
                                    graph.RemoveEdge(arista);
                                    if (b_coloreando == true) {
                                        graph.colorear();
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    if (graph.EdgesList.Count == 0) {
                        EliminaArist.Enabled = EliminaArista.Enabled = false;
                    }
                    break;
                case 14:
                    Edge ari;
                    NodeP o, d;

                    o = d = null;
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
                        pinta(graphics);                                  
                    }
                    break;                    
            }
            pinta(au);
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
            pinta(au);
            graphics.DrawImage(bmp1, 0, 0);
        }
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
        //int multi;
        double dy, dx;
        dy = dx = 0;
        List<Edge> repetidas = new List<Edge>();
        if (graph.EdgesList != null && graph.EdgesList.Count > 0) {
            foreach (Edge a in graph.EdgesList) {
                if (a.Type != 1) {
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
        pinta(graphics);
    }

    /*void time_Tick(object sender, EventArgs e){
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
     */

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

    // Método que activa todos los menús de toolstrip y del menu, cuando hay algo en el editor.
    public void ActivaMenus() {
        Guard.Enabled = Guardar.Enabled = true;
        EliminaNod.Enabled = EliminaNodo.Enabled = true;
        MueveNod.Enabled = MueveNodo.Enabled = true;
        AgregaNod.Enabled = AgregaNodo.Enabled = true;
        if (graph.Count >= 1) {
            if (graph.EdgesList.Count == 0) {
                AristaNoDirigida.Enabled = AristaDirigida.Enabled = true;
                AristaNoDirigid.Enabled = AristaDirigid.Enabled = true;
            }
            else {
                if (graph.EdgesList[0].Type == 1) {
                    AristaDirigida.Enabled = AristaDirigid.Enabled = true;
                    AristaNoDirigida.Enabled = AristaNoDirigid.Enabled = false;
                }
                else {
                    AristaNoDirigida.Enabled = AristaNoDirigid.Enabled = true;
                    AristaDirigida.Enabled = AristaDirigid.Enabled = false;
                }
            }
        }

        if (graph.EdgesList.Count > 0) {
            EliminaArista.Enabled = EliminaArist.Enabled = true;
        }

        MueveGraf.Enabled = MueveGrafo.Enabled = true;
        EliminaGrafo.Enabled = EliminaGraf.Enabled = true;
        BorraGrafo.Enabled = BorraGraf.Enabled = true;
        Intercamb.Enabled = Intercambio.Enabled = true;
        Complemento.Enabled = true;
    }

    // descativa la mayoría de los botones y reinicializa el grafo
    private void DesactivaMenus() {
        AgregaNodo.Enabled = AgregaNod.Enabled = true;
        MueveNodo.Enabled = MueveNod.Enabled = false;
        AgregaRelacion.Enabled = AristaDirigid.Enabled = AristaNoDirigid.Enabled = false;
        EliminaNodo.Enabled = EliminaNod.Enabled = false;
        MueveGrafo.Enabled = MueveGraf.Enabled = false;
        EliminaArista.Enabled = EliminaArist.Enabled = false;
        EliminaGraf.Enabled = EliminaGrafo.Enabled = false;
        Guardar.Enabled = Guard.Enabled = false;
        NombreAristas.Enabled = PesoAristas.Enabled = false;
        BorraGraf.Enabled = BorraGrafo.Enabled = false;
        Intercambio.Enabled = Intercamb.Enabled = false;
        Complemento.Enabled = false;
        AristaNoDirigid.Enabled = AristaDirigid.Enabled = false;
    }

    public void Uncheck() {
        AgregaNod.Checked = false;
        MueveNod.Checked = false;
        EliminaNod.Checked = false;
        AristaDirigid.Checked = false;
        AristaNoDirigid.Checked = false;
        EliminaArist.Checked = false;
        MueveGraf.Checked = false;
        BorraGraf.Checked = false;
        EliminaGraf.Checked = false;
    }

    // metodo del primer examen parcial
    private void examen_Click(object sender, EventArgs e) {
        EliminaNod.Enabled = EliminaNodo.Enabled = false;
        AgregaNod.Enabled = AgregaNodo.Enabled = false;
        AristaDirigida.Enabled = AristaNoDirigida.Enabled = false;
        AristaDirigid.Enabled = AristaNoDirigid.Enabled = false;
        accion = 99;
        diag = new Notas(graph, this);
        diag.Location = new Point(this.ClientSize.Width + this.Left, this.Top);
        diag.TopMost = true;
        diag.Show();

        Form1_Paint(this, null);
    }


    private void InsertaPlantilla(object sender, EventArgs e) {
        Plantilla p = new Plantilla();   
        p.ShowDialog();
        if (p.DialogResult == DialogResult.OK) {
            switch(p.Tipo){
                case "Kn":
                    InsertaKn(p.N);
                    break;
                case "Cn":
                    InsertaCn(p.N);
                    break;
                case "Wn":
                    InsertaWn(p.N);
                    break;
            }
        }
        ActivaMenus();
    }

    private void InsertaWn(int n) {
        InsertaCn(n);
        graph.AddNode(new NodeP(new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2 + 30), nombre++));
        for (int i = 0; i < graph.Count - 1; i++) {
            graph[graph.Count - 1].relations.Add(new NodeR(graph[i], graph[i].Name));
            graph.EdgesList.Add(new Edge(0, graph[graph.Count - 1], graph[i], "e" + i.ToString()));
        }
    }

    private void InsertaCn(int n) {
        double x, y;
        float deg = 0, ang = 0, dist = this.ClientRectangle.Height / 2 - 50;
        nombre = 'A';

        // El dialogo recoge el número de nodos para dibujar el KN

        ang = (float)(360.0 / n);
        this.mnuBorraGrafo_Click(this, null);
        /* Este ciclo va aumentando las coordenadas de x y y usando trigonometria para la nueva posicion del siguiente nodo
        Va agregando los nodos en sentido horario o antihorario */
        for (int i = 0; i < n; i++) {
            x = dist * Math.Cos(Math.PI * deg / 180);
            y = dist * Math.Sin(Math.PI * deg / 180);
            int xx = Convert.ToInt32(x);
            int yy = Convert.ToInt32(y);
            graph.AddNode(new NodeP(new Point(xx + this.ClientRectangle.Width / 2, yy + this.ClientRectangle.Height / 2 + 30), nombre++));
            deg += ang;
        }
        for (int i = 0; i < graph.Count - 1; i++) {
            graph[i].relations.Add(new NodeR(graph[i + 1], graph[i + 1].Name));
            graph.EdgesList.Add(new Edge(0, graph[i], graph[i + 1], "e" + i.ToString()));
        }
        graph[graph.Count -1].relations.Add(new NodeR(graph[0], graph[0].Name));
        graph.EdgesList.Add(new Edge(0, graph[graph.Count -1], graph[0], "e" + (graph.Count-1).ToString()));
    }

    // Método que inserta un grafo KN, el usuario ingresa el numero de nodos a dibujar
    private void InsertaKn(int n) {

        double x, y;
        int deg = 0, ang = 0, dist = this.ClientRectangle.Height / 2 - 50;
        nombre = 'A';

        // El dialogo recoge el número de nodos para dibujar el KN

        ang = 360 / n;
        this.mnuBorraGrafo_Click(this, null);
        /* Este ciclo va aumentando las coordenadas de x y y usando trigonometria para la nueva posicion del siguiente nodo
        Va agregando los nodos en sentido horario o antihorario */
        for (int i = 0; i < n; i++) {
            x = dist * Math.Cos(Math.PI * deg / 180);
            y = dist * Math.Sin(Math.PI * deg / 180);
            int xx = Convert.ToInt32(x);
            int yy = Convert.ToInt32(y);
            graph.AddNode(new NodeP(new Point(xx + this.ClientRectangle.Width / 2, yy + this.ClientRectangle.Height / 2 + 30), nombre++));
            deg += ang;
        }
        graph.Complement();
    }


    // funcion que divide el grafo en n partitas
    private void NPartita(object sender, EventArgs e) {
        List<NodeP> grupo = new List<NodeP>();
        List<List<NodeP>> grupos = new List<List<NodeP>>();
        Random ra = new Random();
        int r = 30, g = 30, b = 30, c = 0, ant = 0;
        graph.Desel();

        if(graph.Count > 0) {
            grupo.Add(graph[0]);
            // añade el primer nodo al grupo por defecto
            graph[0].Vis = true;

            // checa todos los nodos para saber cuáles no se relacionan con el grafo y los agrega al grupo actual
            foreach (NodeP n1 in graph) {
                foreach (NodeP n2 in graph) {
                    if (n1 != n2 && !n2.Vis && !nodoDentroGrupo(grupo, n2) && !aristaDentroGrupo(grupo, n2)){
                        //Console.WriteLine("Se agrega " + n2.Name + " al grupo " + grupos.Count);
                        grupo.Add(n2);
                        n2.Vis = true;
                    }
                }
                grupos.Add(grupo); 

                // Colorea los nodos de colores aleatorios

                while (ant == c) {
                    c = ra.Next(3);
                }
                if (c == 0) {
                    r += 90;
                    if (Math.Abs(r - b) < 20 || Math.Abs(r - g) < 20) {
                        r += 50;
                    }
                }
                else {
                    if (c == 1) {
                        g += 90;
                        if (Math.Abs(g - b) < 20 || Math.Abs(g - r) < 20) {
                            g += 50;
                        }
                    }
                    else {
                        if (c == 2) {
                            b += 90;
                            if (Math.Abs(b - r) < 20 || Math.Abs(b - g) < 20) {
                                b += 50;
                            }
                        }
                    }
                }
                ant = c;

                Color col = Color.FromArgb((r >= 255) ? (r -= 255) : (r), (g >= 255) ? (g -= 255) : (g), (b >= 255) ? (b -= 255) : (b));

                for (int i = 0; i < grupo.Count; i++) {
                    foreach (NodeP np in graph) {
                        if (grupo[i] == np) {
                            np.Color = col;
                        }
                    }
                }
                    
                grupo.Clear();
                
            }
            ActivaMenus();
        }
      
       
    }

    // regresa true si hay un nodo que pertenece a un grupo de nodos, pertenece al metodo n partita
    private bool nodoDentroGrupo(List<NodeP> g1, NodeP nn) {
        foreach (NodeP ng in g1) {
            if (ng.Name == nn.Name) {
                return true;
            }
        }
        return false;
    }

    // Regresa true si hay una arista que pertenece a un grupo de nodos, pertenece al metodo n partita
    private bool aristaDentroGrupo(List<NodeP> g1, NodeP nn) {
        foreach (NodeP ng in g1) {
            foreach (Edge ed in graph.EdgesList) {
                if ((ed.Origin.Name == nn.Name && ed.Destiny.Name == ng.Name) || (ed.Origin.Name == ng.Name && ed.Destiny.Name == nn.Name)) {
                    return true;
                }
            }
        }
        return false;
    }

    private void mnuBorraGrafo(object sender, EventArgs e) {
        DesactivaMenus();
        Uncheck();
        graph = new Grafo();
        graphics.Clear(BackColor);
        graph2 = new Grafo();
        nombre = 'A';
    }

}
}
