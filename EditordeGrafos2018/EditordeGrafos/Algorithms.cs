using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos {
public partial class Editor {

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
        double deg = 0, ang = 0, dist = this.ClientRectangle.Height / 2 - 50;
        nombre = 'A';

        // El dialogo recoge el número de nodos para dibujar el KN

        ang = (float)(360.0 / n);
        this.mEraseGraph(this, null);
        /* Este ciclo va aumentando las coordenadas de x y y usando trigonometria para la nueva posicion del siguiente nodo
        Va agregando los nodos en sentido horario o antihorario */
        for (int i = 0; i < n; i++) {
            x = dist * Math.Cos(Math.PI * deg / 180.0);
            y = dist * Math.Sin(Math.PI * deg / 180.0);
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
        double deg = 0, ang = 0, dist = this.ClientRectangle.Height / 2 - 50;
        nombre = 'A';

        // El dialogo recoge el número de nodos para dibujar el KN

        ang = 360.0 / n;
        this.mEraseGraph(this, null);
        /* Este ciclo va aumentando las coordenadas de x y y usando trigonometria para la nueva posicion del siguiente nodo
        Va agregando los nodos en sentido horario o antihorario */
        for (int i = 0; i < n; i++) {
            x = dist * Math.Cos(Math.PI * deg / 180.0);
            y = dist * Math.Sin(Math.PI * deg / 180.0);
            int xx = Convert.ToInt32(x);
            int yy = Convert.ToInt32(y);
            graph.AddNode(new NodeP(new Point(xx + this.ClientRectangle.Width / 2, yy + this.ClientRectangle.Height / 2 + 30), nombre++));
            deg += ang;
        }
        Complement();
    }

    #endregion
    #region Complement

    public void invertDirectedEdges() {
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
            graph[i].Visited = true;
            }
            
        }


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
        if (graph.EdgesList.Count > 0) {
            tT_removeEdge.Enabled = m_deleteEdge.Enabled = true;
        }
        else {
            tT_removeEdge.Enabled = m_deleteEdge.Enabled = false;
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
        if (graph.EdgesList.Count > 0) {
            tT_removeEdge.Enabled = m_deleteEdge.Enabled = true;
            lT_prim.Enabled = m_prim.Enabled = true;
            lT_euler.Enabled = m_euler.Enabled = true;
            lT_coloredEdges.Enabled = m_coloredEdges.Enabled = true;
        }
        else {
            tT_removeEdge.Enabled = m_deleteEdge.Enabled = false;
            lT_prim.Enabled = m_prim.Enabled = false;
            lT_euler.Enabled = m_euler.Enabled = false;
            lT_coloredEdges.Enabled = m_coloredEdges.Enabled = false;
        }
    }
    #endregion
    #region NPartita
    // Función que encuentra en el grafo los grupos de nodos partitas

    private List<List<NodeP>> genPartita(Graph g2) {
        List<NodeP> grupo = new List<NodeP>();
        List<List<NodeP>> grupos = new List<List<NodeP>>();
        int k = 0;
        g2.UnselectAllNodes();

        if (g2.Count > 0) {
            grupo.Add(g2[0]);
            // añade el primer nodo al grupo por defecto
            g2[0].Visited = true;

            // checa todos los nodos para saber cuáles no se relacionan con el grafo y los agrega al grupo actual
            for (int i = 0; i < g2.Count; i++) {
                for (int j = 0; j < g2.Count; j++) {
                    if (!g2[j].Visited && !nodoDentroGrupo(grupo, g2[j]) && !aristaDentroGrupo(grupo, g2[j])) {
                        grupo.Add(g2[j]);
                        g2[j].Visited = true;
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

    public string Kuratowsky(List<NodeP> noditos, List<Edge> aristitas) {
        string message = "";
        List<Edge> edgs = new List<Edge>();
        Edge badEdg;
        Graph g2 = new Graph(graph);
        foreach (NodeP np in graph) {
            np.Color = Color.White;
        }
        foreach (NodeP n in g2) {
            n.Degree = n.Degree / 2;
        }

        
        g2.UnselectAllNodes();
        // quitar nodos grado dos
        removeBridges(g2);
        // Checa que es homeomórfico a K5
        if (checkHomeomorphicK5(g2)) {
            // Intenta quitar los nodos para checar homeomócrfico
            tryEveryNodeK5(g2, noditos);

            if (noditos.Count > 0) {
                message = "Grafo no plano homeomorfico a k5\n\nk5 mostrado en color azul\nLos nodos eliminados mostrados en naranja\nLos nodos agregados mostrados en verde :v";
            }
            else {
                //marcar el k5 como visitado
                int count = 0;
                foreach (NodeP np in g2) {
                    
                    if (np.Degree >= 4 && count != 5) {
                        np.Visited = true;
                        count++;
                    }
                }
                for (int i = g2.Count -  1; i >= 0; i--){
                    if (g2[i].Degree > 4) {
                       // busca todas las aristas que se pueden eliminar
                       tryNodesDegree5(g2, g2[i], aristitas);
                    }
                }
                // quita todas esas aristas y despues hace lo de arriba para sacar el homeomorfico
                for (int i = 0; i < aristitas.Count; i++) {
                    g2.RemoveEdge(aristitas[i]);
                }
         
                tryEveryNodeK5(g2, noditos);
                if (noditos.Count > 0) {
                    message = "Grafo no plano homeomorfico a k5\n\nk5 mostrado en color azul\nLos nodos eliminados mostrados en naranja\nLos nodos agregados mostrados en verde\nAristas que se deberian eliminar mostradas en naranja";
                }
                else {
                    message = "El grafo es plano, se fue por k5";    
                }
            }
        }
        else {
            if (checkHomeomorphicK33(g2)) {
                tryEveryNodeK33(g2, noditos);
                if (noditos.Count > 0) {
                    message = "Grafo no plano homeomorfico a k33\n\nk33 mostrado en color azul\nLos nodos eliminados mostrados en naranja\nLos nodos agregados mostrados en verde";
                }
                else {
                    message = "El grafo es plano, se fue por k33";
                }
                
            }
            else {
                message = "El grafo es plano, se fue por k33";
            }
        }
        return message;
    }

    private void tryNodesDegree5(Graph g2, NodeP np,  List<Edge> arist) {
        // Hace la prueba para cada arista del nodo 
        for (int i = 0; i < np.relations.Count; i++) {
            Edge ed = g2.GetEdge(np, np.relations[i].Up);

            g2.RemoveEdge(ed);


            if (checkHomeomorphicK5(g2)) {
                if (np == ed.Origin) {
                    if (ed.Destiny.Visited) {
                        if (ed.Destiny.Degree >= 4 && !ed.Origin.Visited) {
                            arist.Add(ed);
                        }
                    }
                    else {
                        arist.Add(ed);
                    }
                }
                else {
                    if (np == ed.Destiny) {
                        if (ed.Origin.Visited) {
                            if (ed.Origin.Degree >= 4 && !ed.Destiny.Visited) {
                                arist.Add(ed);
                            }
                        }
                        else {
                            arist.Add(ed);
                        }
                    }
                }

            }

            // la vuelve a agregar
                
            g2.EdgesList.Insert(i, ed);
            if (np == ed.Origin) {
                np.Degree++;
                ed.Destiny.Degree++;
                np.relations.Insert(i, new NodeR(ed.Destiny, "e" + i.ToString()));
                ed.Destiny.relations.Add(new NodeR(np, "e" + i.ToString()));

            }
            else {
                np.Degree++;
                ed.Origin.Degree++;
                np.relations.Insert(i, new NodeR(ed.Origin, "e" + i.ToString()));
                ed.Origin.relations.Add(new NodeR(np, "e" + i.ToString()));
            }
            
        }
    }

    private bool checkHomeomorphicK33(Graph g2) {
        int numNodos = 0;
        foreach (NodeP np in g2) {
            if (np.Degree >= 3) {
                numNodos++;
            }
        }

        if (numNodos >= 6) {
            return true;
        }
        return false; 

    }

    private List<List<NodeP>> equalToK33(Graph g2) {
        List<List<NodeP>> grupos;
        int numNodos = g2.Count;
        int numEdges = g2.EdgesList.Count;
        int numRelGrupos = 0;
        grupos = genPartita(g2);


        for (int i = 0; i < grupos.Count; i++) {
            if (grupos[i].Count <= 2) {
                if (grupos[i][0].Degree <= 3) {
                    grupos.Remove(grupos[i--]);
                }
               
            }
        }

        foreach (List<NodeP> grupo in grupos) {
            numRelGrupos += grupo.Count;
        }

        if (grupos.Count == 2 && numRelGrupos == 6) {
            return grupos;
        }
        return null;

    }

    private void tryEveryNodeK33(Graph g2, List<NodeP> nods) {
        List<NodeP> tempRel;
        List<List<NodeP>> grupos = null;
        NodeP tempNode;
        if (checkHomeomorphicK33(g2)) {
            grupos = equalToK33(g2);
            if (grupos != null && nods.Count == 0) {
                foreach (List<NodeP> lnp in grupos) {
                    foreach (NodeP np in lnp) {
                        nods.Add(np);
                    }
                }
            }
            else {
                for (int i = 0; i < g2.Count; i++) {

                    tempRel = getSurroundNodes(g2[i]);
                    tempNode = new NodeP(g2[i]);
                    g2.RemoveNode(g2[i]);

                    // llamada recursiva
                    tryEveryNodeK33(g2, nods);
                    // unir nodos otra vez
                    tempNode.Degree = 0;
                    g2.Insert(i, tempNode);
                    //g2.Add(tempNode);
                    for (int j = 0; j < tempRel.Count; j++) {
                        tempRel[j].InsertRelation(tempNode, j, false);
                        tempNode.InsertRelation(tempRel[j], j, false);
                        g2.EdgesList.Add(new Edge(tempNode, tempRel[j], "e" + j.ToString()));
                    }

                }
            }
        }
    }

    private void tryEveryNodeK5(Graph g2, List<NodeP> nods) {
        List<NodeP> tempRel;
        NodeP tempNode;
        if (checkHomeomorphicK5(g2)) {
            if (equalToK5(g2) && nods.Count == 0) {
                foreach (NodeP np in g2) {
                    if (np.Degree > 2) {
                        nods.Add(np);
                    }
                    
                }
            }
            else {
                for (int i = 0; i < g2.Count; i++) {

                    tempRel = getSurroundNodes(g2[i]);
                    tempNode = new NodeP(g2[i]);
                    g2.RemoveNode(g2[i]);
                        
                    // llamada recursiva
                    tryEveryNodeK5(g2, nods);
                    // unir nodos otra vez
                    tempNode.Degree = 0;
                    g2.Insert(i, tempNode);
                    //g2.Add(tempNode);
                    for (int j = 0; j < tempRel.Count; j++) {
                        tempRel[j].InsertRelation(tempNode, j, false);
                        tempNode.InsertRelation(tempRel[j], j, false);
                        g2.EdgesList.Add(new Edge(tempNode, tempRel[j], "e" + j.ToString()));
                    }
                }
            }
        }
    }

    private bool checkHomeomorphicK5(Graph g2) {
        int numNodos = 0;
        foreach (NodeP np in g2) {
            if (np.Degree >= 4) {
                numNodos++;
            }
        }

        if (numNodos >= 5) {
            return true;
        }
        return false; 
    }

    public bool equalToK5(Graph g2) {
        int numNodos = g2.Count;
        int numEdges = g2.EdgesList.Count;
        foreach (NodeP np in g2) {
            if (np.Degree == 2) {
                numNodos--;
                numEdges--;
            }
        }
        if (numNodos == 5 && numEdges == 10) {
            return true;
        }
        return false;
    }

    private List<NodeP> getSurroundNodes(NodeP nod) {
        List<NodeP> tempRel = new List<NodeP>();
        foreach (NodeR rel in nod.relations) {
            tempRel.Add(rel.Up);
        }
        return tempRel;
    }

    private void removeBridges(Graph g2) {
        for (int i = 0; i < g2.Count; i++) {
            if (g2[i].Degree == 2) {
                //creapuente2nodos(g2[i]);
                NodeP a = g2[i].relations[0].Up;
                NodeP b = g2[i].relations[1].Up;
                Edge ed = new Edge(a, b, "p");
                bool esta = false;
                foreach (Edge eee in g2.EdgesList) {
                    //si ya esta
                    if ((ed.Origin.Name == eee.Origin.Name && ed.Destiny.Name == eee.Destiny.Name) || (ed.Origin.Name == eee.Destiny.Name && ed.Destiny.Name == eee.Origin.Name)) {
                        esta = true;
                    }
                }
                if (!esta) {
                    g2.EdgesList.Add(ed);
                    a.InsertRelation(b, 1, false);
                    b.InsertRelation(a, 1, false);
                }
                g2.RemoveNode(g2[i--]);
            }
        }
    }


    private bool verifCircuito3(NodeP n) {
        foreach (NodeR r2 in n.relations) {
            NodeP n2 = r2.Up;
            if (n2.Name != n.Name) {
                foreach (NodeR r3 in n2.relations) {
                    if (r3.Name != n.Name) {
                        NodeP n3 = r3.Up;
                        foreach (NodeR r4 in n3.relations) {
                            if (r4.Up == n) {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
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

    private bool EulerCircuit(NodeP actual, NodeP origin) {
        bool resp = false;
        actual.Visited = true;
        if (actual.Name == origin.Name && actual.Visited && graph.AllEdgesVisited()) {
            tmpNodes.Add(actual);
            return true;
        }

        foreach (NodeR nrel in actual.relations) {
            Edge a = graph.GetEdge(nrel.Up, actual);

            if (a != null && !a.Visited) {
                a.Visited = true;
                resp |= EulerCircuit(nrel.Up, origin);
                if (!resp) {
                    a.Visited = false;
                }
                else {
                    actual.Visited = true;
                    tmpNodes.Add(actual);
                    break;
                }
            }
        }
        return resp;
    }

    public bool EulerRoad(NodeP actual, NodeP origin) {
        bool resp = false;
        if (graph.AllEdgesVisited()) {
            tmpNodes.Add(actual);
            return true;
        }

        foreach (NodeR nrel in actual.relations) {
            Edge a = graph.GetEdge(nrel.Up, actual);

            if (a != null && !a.Visited) {
                a.Visited = true;
                resp |= EulerRoad(nrel.Up, origin);
                if (!resp) {
                    a.Visited = false;
                }
                else {
                    actual.Visited = true;
                    tmpNodes.Add(actual);
                    break;
                }

            }

        }
        return resp;
    }

    private List<Edge> EulerCycle() {
        List<Edge> euler = new List<Edge>();
        int pendingNodes = HasEulerPath();
        Edge start = graph.EdgesList[0];
        // Si tiene circuito entonces muestra circuito
        if (HasEulerCycle()) {
            graph.UnselectAllEdges();
            FindEulerCycleRoad(graph.EdgesList[0], graph.EdgesList[0].Origin, graph.EdgesList[0].Destiny, euler);
            return euler;
        }
        else {
            // Si no tiene entonces busca un camino
            if (pendingNodes == 0) {
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
                    graph.UnselectAllEdges();
                    FindEulerCycleRoad(start, start.Origin, start.Destiny, euler);
                    return euler;
                }
                else {
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
                if (!graph.EdgesList[j].Visited && !nodesInsideGroup(gColor, graph.EdgesList[j].Origin, graph.EdgesList[j].Destiny)) {
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

    private bool nodesInsideGroup(List<Edge> liEd, NodeP a, NodeP b) {
        foreach (Edge ed in liEd) {
            if ((a.Name == ed.Origin.Name || a.Name == ed.Destiny.Name) || 
                (b.Name == ed.Origin.Name || b.Name == ed.Destiny.Name)) {
                return true;
            }
        }
        return false;
    }

    #endregion
    #region Topological

    public void topoprueba(NodeP actual) {
        actual.Visited = true;
        foreach (NodeR rel in actual.relations) {
            if (rel.Up.Visited == false) {
                topoprueba(rel.Up);
            }
        }
        tmpNodes.Add(actual);
    }

    public void recorretopo() {
        graph.UnselectAllNodes();
        foreach (NodeP n in graph) {
            if (n.DegreeIn == 0) {
                topoprueba(n);
            }
        }
        tmpNodes.Reverse();

    }

    public List<NodeP> Topological(NodeP nod) {
        graph.UnselectAllNodes();
 
        List<NodeP> clasificacion = new List<NodeP>();
        foreach (NodeP nodo in graph) {
            if (nodo.Visited != true) {
                clasificacionTopologica(nodo, clasificacion);
            }
            else {

                
            }
        }
        return clasificacion;

    }


    private void clasificacionTopologica(NodeP v, List<NodeP> g) {
        v.Visited = true;
        foreach (NodeR rel in v.relations) {
            if (rel.Up.Visited != true) {
                clasificacionTopologica(rel.Up, g);
            }
        }
        NodeP nuevo = new NodeP(v);
        g.Add(nuevo);
    }

    #endregion
    #region Hamilton

    public bool makeHamilton(NodeP origen, NodeP actual) {


        bool resp = false;
        actual.Visited = true;
        if (graph.AllNodesVisited()) {
            tmpNodes.Add(actual);
            return true;
        }

        foreach (NodeR nrel in actual.relations) {
            Edge a = graph.GetEdge(nrel.Up, actual);
            if (!a.Visited) {
                a.Visited = true;
                if (actual == a.Origin && !a.Destiny.Visited) {
                    resp |= makeHamilton(origen, a.Destiny);
                    if (!resp) {
                        a.Destiny.Visited = false;
                    }
                    else {
                        tmpNodes.Add(a.Origin);
                        break;
                    }
                }
                else if (actual == a.Destiny && !a.Origin.Visited) {
                    resp |= makeHamilton(origen, a.Origin);
                    if (!resp) {
                        a.Origin.Visited = false;
                    }
                    else {
                        tmpNodes.Add(a.Destiny);
                        break;
                    }
                }
            }
            if (!resp)
                a.Visited = false;
        }
        return resp;
    }

    public int retHamil() {
        tmpNodes = new List<NodeP>();
        bool finded = false;
        bool circuito = false;
        bool camino = false;
        foreach (NodeP n in graph) {
            tmpNodes.Clear();
            graph.UnselectAllNodes();
            graph.UnselectAllEdges();
            finded = makeHamilton(n, n);

            if (finded && graph.GetEdge(tmpNodes[0], tmpNodes[tmpNodes.Count - 1]) != null) {
                circuito = true;
                break;
            }

        }
        if (circuito) {
            return 1;
        }
        foreach (NodeP n in graph) {
            tmpNodes.Clear();
            graph.UnselectAllNodes();
            graph.UnselectAllEdges();
            finded = makeHamilton(n, n);

            if (finded) {
                camino = true;
                break;
            }

        }

        if (camino) {
            return 2;
        }
        return 0;
    }
    

    #endregion
}
}
