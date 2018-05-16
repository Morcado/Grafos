using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditordeGrafos {
public partial class Editor : Form {
    #region Examen 1
    private void examen_Click(object sender, EventArgs e) {
        tT_deleteNode.Enabled = m_deleteNode.Enabled = false;
        tT_addNode.Enabled = m_addNode.Enabled = false;
        m_directedEdge.Enabled = m_undirectedEdge.Enabled = false;
        tT_directedEdge.Enabled = tT_undirectedEdge.Enabled = false;
        option = 99;
        diag = new Notas(graph, this);
        diag.Location = new Point(this.ClientSize.Width + this.Left, this.Top);
        diag.TopMost = true;
        diag.Show();

        Form1_Paint(this, null);
    }
    #endregion
    #region RegularGraphs

    private void InsertaWn(int n) {
        InsertaCn(n);
        graph.AddNode(new NodeP(new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2 + 30), nombre++));
        for (int i = 0; i < graph.Count - 1; i++) {
            graph[graph.Count - 1].InsertRelation(graph[i], i, edgeIsDirected);
            graph[i].InsertRelation(graph[graph.Count - 1], i, edgeIsDirected);
            graph.EdgesList.Add(new Edge(graph[graph.Count - 1], graph[i], "e" + i.ToString()));
        }
    }

    private void InsertaCn(int n) {
        double x, y;
        float deg = 0, ang = 0, dist = this.ClientRectangle.Height / 2 - 50;
        nombre = 'A';

        // El dialogo recoge el número de nodos para dibujar el KN

        ang = (float)(360.0 / n);
        this.mEraseGraph(this, null);
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
            graph[i].InsertRelation(graph[i + 1], i + 1, edgeIsDirected);
            graph[graph.Count - 1 - i].InsertRelation(graph[graph.Count - 2 - i], graph.Count - 2 - i, edgeIsDirected);
            graph.EdgesList.Add(new Edge(graph[i], graph[i + 1], "e" + i.ToString()));

            //graph[i].relations.Add(new NodeR(graph[i + 1], graph[i + 1].Name));
            //graph.EdgesList.Add(new Edge(0, graph[i], graph[i + 1], "e" + i.ToString()));
        }
        graph[graph.Count - 1].InsertRelation(graph[0], 0, edgeIsDirected);
        graph[0].InsertRelation(graph[graph.Count - 1], graph.Count - 1, edgeIsDirected);
        graph.EdgesList.Add(new Edge(graph[graph.Count - 1], graph[0], "e" + (graph.Count - 1).ToString()));
    }

    // Método que inserta un grafo KN, el usuario ingresa el numero de nodos a dibujar
    private void InsertaKn(int n) {

        double x, y;
        int deg = 0, ang = 0, dist = this.ClientRectangle.Height / 2 - 50;
        nombre = 'A';

        // El dialogo recoge el número de nodos para dibujar el KN

        ang = 360 / n;
        this.mEraseGraph(this, null);
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
        Complement();
    }

    #endregion
    #region Complement

    public void UndirComplement() {
        Edge edg;
        NodeR rAB, rBA;
        int i, j;
        graph.UnselectAllNodes();
        int cuenta = 0;
        for (i = 0; i < graph.Count; i++) { // recorre todo el grafo
            for (j = 0; j < graph.Count; j++) {
                if (graph[i].Name != graph[j].Name && !graph[j].Visited) {
                    rAB = graph.Connected(graph[i], graph[j]);
                    rBA = graph.Connected(graph[j], graph[i]);
                    // Si los dos estan conectados
                    if (rAB != null && rBA != null) {
                        graph[i].RemoveRelation(rAB, edgeIsDirected);
                        graph[j].RemoveRelation(rBA, edgeIsDirected);
                        edg = graph.GetEdge(graph[i], graph[j]);
                        if (edg != null) {
                            graph.RemoveEdge(edg);
                        }
                        edg = graph.GetEdge(graph[j], graph[i]);
                        if (edg != null) {
                            graph.RemoveEdge(edg);
                        }
                        cuenta--;
                    }
                    else {
                        // Si esta conectado de A a B, pero de B a A no
                        if (rAB != null && rBA == null) {
                            edg = graph.GetEdge(graph[i], graph[j]);
                            if (edg != null) {
                                graph.RemoveEdge(edg);
                            }
                            edg = graph.GetEdge(graph[j], graph[i]);
                            if (edg != null) {
                                graph.RemoveEdge(edg);
                            }
                            graph[j].InsertRelation(graph[i], cuenta, edgeIsDirected);
                            graph.AddEdge(new Edge(graph[j], graph[i], "e" + cuenta++.ToString()));
                        }
                        else {
                            // Si esta conectado de B a A
                            if (rAB == null && rBA != null) {
                                edg = graph.GetEdge(graph[i], graph[j]);
                                if (edg != null) {
                                    graph.RemoveEdge(edg);
                                }
                                edg = graph.GetEdge(graph[j], graph[i]);
                                if (edg != null) {
                                    graph.RemoveEdge(edg);
                                }
                                graph[i].InsertRelation(graph[j], cuenta, edgeIsDirected);
                                graph.AddEdge(new Edge(graph[i], graph[j], "e" + cuenta++.ToString()));
                            }
                        }
                    }
                }
            }
            graph[i].Visited = true;
        }
    }

    public void Complement() { // saca el complemento del grafo
        Edge edg;
        NodeR rel;
        int i, j;
        graph.UnselectAllNodes();
        int cuenta = 0;
        for (i = 0; i < graph.Count; i++) { // recorre todo el grafo
            for (j = 0; j < graph.Count; j++) {
                if (i != j && !graph[j].Visited) { // si no apunta a si mismo y no esta visitado
                    rel = graph.Connected(graph[i], graph[j]);
                    if (rel != null) {
                        // si esta conectados los nodos, remueve la arista
                        graph[i].RemoveRelation(rel, edgeIsDirected);
                        graph[j].RemoveRelation(rel, edgeIsDirected);
                        edg = graph.GetEdge(graph[i], graph[j]);
                        graph.RemoveEdge(edg);
                        cuenta--;
                    }
                    else {
                        // si los nodos no estan conectados
                        graph[i].InsertRelation(graph[j], graph.EdgesList.Count, edgeIsDirected);
                        graph[j].InsertRelation(graph[i], graph.EdgesList.Count, edgeIsDirected);
                        graph.AddEdge(new Edge(graph[i], graph[j], "e" + cuenta++.ToString()));
                    }
                }
            }
            graph[i].Visited = true;
        }
    }
    #endregion
    #region NPartita
    // Función que encuentra en el grafo los grupos de nodos partitas

    private List<List<NodeP>> genPartita() {
        List<NodeP> grupo = new List<NodeP>();
        List<List<NodeP>> grupos = new List<List<NodeP>>();
        Random ra = new Random();
        int k = 0;
        graph.UnselectAllNodes();

        if (graph.Count > 0) {
            grupo.Add(graph[0]);
            // añade el primer nodo al grupo por defecto
            graph[0].Visited = true;

            // checa todos los nodos para saber cuáles no se relacionan con el grafo y los agrega al grupo actual
            for (int i = 0; i < graph.Count; i++) {
                for (int j = 0; j < graph.Count; j++){
                    if (!graph[j].Visited && !nodoDentroGrupo(grupo, graph[j]) && !aristaDentroGrupo(grupo, graph[j])) {
                        grupo.Add(graph[j]);
                        graph[j].Visited = true;
                    }   
                }
                if (grupo.Count == 0) {
                    break;
                }
                else {
                    grupos.Add(grupo);
                }

                // Colorea los nodos de colores aleatorios

                foreach (NodeP np in grupo) {
                    np.Color = listColors[k];
                }
                k++;
                grupo = new List<NodeP>();

            }
            EnableMenus();
        }
        return grupos;
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
                if ((ed.Origin.Name == nn.Name && ed.Destiny.Name == ng.Name) || 
                    (ed.Origin.Name == ng.Name && ed.Destiny.Name == nn.Name)) {
                    return true;
                }
            }
        }
        return false;
    }

    #endregion
    #region Kuratowski

    private void Kuratowsky() {
        if (graph.Count >= 3) {
            int regiones = graph.EdgesList.Count - graph.Count + 2;
            int c = 3 * graph.Count - 6, a, b = 0;
            String aaaaaaa = "Corolario 1\n";
            aaaaaaa += "2E <= 3V - 6\n";
            aaaaaaa += graph.EdgesList.Count.ToString() + " <= " + c.ToString() + "\n";
            //aaaaaaa += "2E = ∑deg(r) >= 3r\n";
            //a = 2 * graph.EdgesList.Count;
            //foreach (NodeP np in graph) {
            //    b += 
            //}
            //c = 3 * regiones;
            //aaaaaaa += a.ToString() + " = " + b.ToString() + " <= " + c.ToString();
            if (graph.EdgesList.Count <= c) {
                aaaaaaa += "El grafo es plano\n";
            }
            else {
                aaaaaaa += "El grafo no es plano\n";
            }

            aaaaaaa += "\nCorolario 2: \n";
            aaaaaaa += "E <= 2V - 4\n";
            c = 2 * graph.Count - 4;
            aaaaaaa += graph.EdgesList.Count.ToString() + " <= " + c.ToString() + "\n";

            bool sihay = false;
            foreach (NodeP np in graph) {
                if (verifCircuito3(np)) {
                    sihay = true;
                }

            }
            if (sihay) {
                aaaaaaa += "Tiene circuito 3\nEl grafo no es plano\n";
            }
            else {
                aaaaaaa += "No tiene circuito 3\nEl grafo es plano\n";
            }

            aaaaaaa += "\nK5: \n";
            if (homeomorficok5()) {
                aaaaaaa += "Es homeomórfico a K5\n";
            }
            else {
                aaaaaaa += "No es homeomórfico a K5\n";
            }
            aaaaaaa += "\nK3,3: \n";
            if (homeomorficok33()) {
                aaaaaaa += "Es homeomórfico a K3,3\n";
            }
            else {
                aaaaaaa += "No es homeomórfico a K3,3\n";
            }


            MessageBox.Show(aaaaaaa, "Resultado");
        }
    }

    private bool verifCircuito3(NodeP n) {
        foreach (NodeR r2 in n.relations) {
            NodeP n2 = r2.Up;
            if (n2.Name != n.Name) {
                foreach (NodeR r3 in n2.relations) {
                    if (r3.Name != n.Name) {
                        NodeP n3 = r3.Up;
                        foreach (NodeR r4 in n3.relations)
                            if (r4.Up == n) {
                                return true;
                            }
                    }
                }
            }
        }
        return false;
    }

    private bool homeomorficok5() {

        if (graph.Count < 5) { //si tiene menos que 5 nodos
            return false;
        }
        else {
            if (graph.isRegular()) { //si es regular o tiene solo 5 nodos
                return true;
            }
            else {
                if (graph.Count == 5) {
                    return false;
                }
                else {
                    //si tiene mas de 5 nodos entonces se procede a ver si se pueden quitar nodos o agregar aristas
                    List<NodeP> ln = new List<NodeP>();
                    Graph gra = new Graph(graph);

                    foreach (Edge a in graph.EdgesList) {
                        gra.EdgesList.Add(new Edge(a.Origin, a.Destiny, "e" + gra.EdgesList.Count));
                    }
                    for (int i = 0; i < gra.Count; i++) {
                        switch (gra[i].Degree) {
                            case 2:
                                ln.Add(gra[i]);
                                break;
                            default:
                                return false;
                        }
                    }
                    foreach (NodeP nodo in ln) {
                        creapuente2nodos(gra, nodo);
                        gra.RemoveNode(nodo);
                    }
                }
            }

        }

        return true;
    }

    private bool homeomorficok33() {
        //Grafo gra = graf;
        Graph gra = new Graph(graph);
        foreach (Edge a in graph.EdgesList) {
            gra.EdgesList.Add(new Edge(a.Origin, a.Destiny, "e" + gra.EdgesList.Count));
        }
        List<NodeP> ln = new List<NodeP>();
        if (gra.Count < 5) {
            return false;
        }
        else {
            foreach (NodeP n in gra) {
                n.Visited = false;
            }

            for (int i = 0; i < gra.Count; i++) {
                switch (gra[i].Degree) {
                    case 3:
                        break;
                    case 2:
                        //creapuente2nodos(gra, gra[i]);
                        ln.Add(gra[i]);
                        break;
                    default:
                        return false;

                }
            }
            foreach (NodeP nodo in ln) {
                creapuente2nodos(gra, nodo);
                gra.RemoveNode(nodo);
            }

            if (genPartita().Count != 2) {
                return false;
            }
        }
        return true;
    }

    private void creapuente2nodos(Graph gra, NodeP nodo) {
        List<Edge> aux = new List<Edge>();
        foreach (Edge a in gra.EdgesList) {
            if (a.Origin == nodo || a.Destiny == nodo) {
                aux.Add(a);
            }
        }
        if (aux[0].Origin == nodo && aux[1].Origin == nodo) {
            gra.AddEdge(new Edge(aux[0].Destiny, aux[1].Destiny, "e" + gra.EdgesList.Count));
        }
        else if (aux[0].Destiny == nodo && aux[1].Origin == nodo) {
            gra.AddEdge(new Edge(aux[0].Origin, aux[1].Destiny, "e" + gra.EdgesList.Count));
        }
        else if (aux[0].Origin == nodo && aux[1].Destiny == nodo) {
            gra.AddEdge(new Edge(aux[0].Destiny, aux[1].Origin, "e" + gra.EdgesList.Count));
        }
        else if (aux[0].Destiny == nodo && aux[1].Destiny == nodo) {
            gra.AddEdge(new Edge(aux[0].Origin, aux[1].Origin, "e" + gra.EdgesList.Count));
        }
    }

    #endregion
    #region Prim

    private List<Edge> Prim() {
        if (graph.IsConnectedU()) {
            List<Edge> minTree = new List<Edge>();
            graph.UnselectAllNodes();
            graph.UnselectAllEdges();
            // toma como minima la primera arista, aunque no necesariamente lo es
            int minValue = 9999999;
            Edge minEdge = graph.EdgesList[0];

            //encuentra la primera arista de costo minimo para empezar de aqui
            foreach (Edge ed in graph.EdgesList) {
                if (ed.Weight < minValue) {
                    minValue = ed.Weight;
                    minEdge = ed;
                }
            }
            minTree.Add(minEdge);
            minEdge.Visited = true;
            minEdge.Origin.Visited = minEdge.Destiny.Visited = true;
            // mientras todos los nodos no estén visitados
            while (!graph.AllNodesVisited()) {
                //recorre todas las aristas
                minValue = 999999;
                foreach (Edge ed in graph.EdgesList) {
                    //si estan conectadas a el grupo de nodos de costo minimo
                    if (((ed.Destiny.Visited == true && ed.Origin.Visited == false) || (ed.Destiny.Visited == false && ed.Origin.Visited == true)) && !ed.Visited) {
                        if (ed.Weight < minValue) {
                            minValue = ed.Weight;
                            minEdge = ed;
                        }
                    }
                }

                minEdge.Origin.Visited = minEdge.Destiny.Visited = true;
                minEdge.Visited = true;
                minTree.Add(minEdge);

            }
            graph.UnselectAllNodes();
            graph.UnselectAllEdges();
            return minTree;
        }
        return null;
    }

    #endregion
    #region Euler

    private List<Edge> EulerCycle() {
        List<Edge> euler = new List<Edge>();
        int pendingNodes = HasEulerPath();
        Edge start = graph.EdgesList[0];

        // Si tiene circuito entonces muestra circuito
        if (HasEulerCycle()) {
            MessageBox.Show("El grafo tiene circuito y camino euler");
            graph.UnselectAllEdges();
            FindEulerCycleRoad(graph.EdgesList[0], graph.EdgesList[0].Origin, graph.EdgesList[0].Destiny, euler);
            return euler;
        }
        else {
            // Si no tiene entonces busca un camino
            if (pendingNodes == 0) {
                MessageBox.Show("El grafo tiene camino euler");
                graph.UnselectAllEdges();
                FindEulerCycleRoad(start, start.Origin, start.Destiny, euler);
                return euler;
            }
            else {
                if (pendingNodes < 3) {
                    foreach (NodeP np in graph) {
                        if (np.Degree == 1) {
                            foreach (Edge ed in graph.EdgesList) {
                                if (ed.Origin.Name == np.Name || ed.Destiny.Name == np.Name) {
                                    start = ed;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    MessageBox.Show("El grafo tiene camino euler");
                    graph.UnselectAllEdges();
                    FindEulerCycleRoad(start, start.Origin, start.Destiny, euler);
                    return euler;
                }
                else {
                    MessageBox.Show("El grafo no tiene circuito ni camino euler");
                    return null;
                }
            }
        }
    }

    private void FindEulerCycleRoad(Edge e, NodeP orig, NodeP dest, List<Edge> euler) {

        e.Visited = true;
        euler.Add(e);
 
        //busca la siguiente arista conectada al nodo actual en la lista de aristas
        bool resp = graph.AllEdgesVisited();

        if (!resp) {
            foreach (Edge currEd in graph.EdgesList) {
                if (!currEd.Visited && currEd.Destiny.Name == dest.Name) {
                    FindEulerCycleRoad(currEd, currEd.Destiny, currEd.Origin, euler);
                }
                if (!currEd.Visited && currEd.Origin.Name == dest.Name) {
                    FindEulerCycleRoad(currEd, currEd.Origin, currEd.Destiny, euler);
                }
            }
        }

    }

    //checa si tiene un camino de euler
    private int HasEulerPath() {
        int evenNodes = 0;
        int pending = 0;
        foreach (NodeP np in graph) {
            //si encuentra un nodo pendiente, entonces se le resta al numero
            //de nodos pares porque es como si se eliminara el nodo pendiente
            if (np.Degree == 1) {
                pending++;
                evenNodes--;
            }
            else {
                //si no ha encontrado mas de 3 nodos pendientes
                if (pending < 3) {
                    //si el nodo es de grado impar
                    if (np.Degree % 3 == 0) {
                        evenNodes++;
                    }
                }
                //si tiene mas de 3 pendientes entonces no tiene camino
                else {
                    return 3;
                }
            }
        }

        //si tiene 0 o 2 nodos pares entonces si tiene camino
        if (pending < 3 && (evenNodes <= 0 || evenNodes == 2)) {
            return pending;
        }
        return 3;
    }

    //Método que regresa si un grafo tiene circuito
    private bool HasEulerCycle() {
        foreach (NodeP np in graph) {
            if (np.Degree > 1) {
                //si todos los nodos tienen grado impar
                if (np.Degree % 2 != 0) {
                    return false;
                }
            }
            else {
                return false;
            }
        }
        return true;
    }

    #endregion
    #region ColoredEdges

    private List<List<Edge>> ColoredEdges() {
        List<List<Edge>> colorGroups = new List<List<Edge>>();
        List<Edge> gColor = new List<Edge>();
        graph.UnselectAllEdges();
        graph.UnselectAllNodes();

        gColor.Add(graph.EdgesList[0]);
        graph.EdgesList[0].Visited = true;

        for (int i = 0; i < graph.EdgesList.Count; i++) {
            for (int j = 0; j < graph.EdgesList.Count; j++) {
                if (!graph.EdgesList[j].Visited && !edgeInsideGroup(gColor, graph.EdgesList[j]) && !nodesInsideGroup(gColor, graph.EdgesList[j].Origin, graph.EdgesList[j].Destiny)) {
                    gColor.Add(graph.EdgesList[j]);
                    graph.EdgesList[j].Visited = true;  
                }
            }
            if (gColor.Count == 0) {
                break;
            }
            else {
                colorGroups.Add(gColor);
            }
            gColor = new List<Edge>();

        }
        
        return colorGroups;
    }
    private bool edgeInsideGroup(List<Edge> liEd, Edge currEdg) {
        foreach (Edge ed in liEd) {
            if (currEdg == ed) {
                return true;
            }
        }
        return false;
    }

    private bool nodesInsideGroup(List<Edge> liEd, NodeP a, NodeP b) {
        foreach (Edge ed in liEd) {
            if ((a.Name == ed.Origin.Name || a.Name == ed.Destiny.Name) || (b.Name == ed.Origin.Name || b.Name == ed.Destiny.Name)) {
                return true;
            }
        }
        return false;
    }

    #endregion
}
}
