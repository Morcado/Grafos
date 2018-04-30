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

public class Graph:List<NodeP> {

    #region Variables
    private bool edgeNamesVisible;
    private bool edgeWeightVisible;
    private int nodeRadio;
    private int nodeBorderWidth;
    private int edgeWidth;
    private int[][] matriz;
    private Color edgeColor;
    private Color nodeColor;
    private Color nodeBorderColor;
    private List<Edge> edgesList;
    private bool letter;

    public bool Letter {
        get { return letter; }
        set { letter = value; }
    }

    public int EdgeWidth {
        get { return edgeWidth; }
        set { edgeWidth = value; }
    }

    public Color NodeBorderColor {
        get { return nodeBorderColor; }
        set { nodeBorderColor = value; }
    }

    public int NodeBorderWidth{
        get { return nodeBorderWidth; }
        set { nodeBorderWidth = value; }
    }

    public Color EdgeColor{ 
        get { return edgeColor; } 
        set { edgeColor = value; } 
    }

    public Color NodeColor {
        get { return nodeColor; }
        set { nodeColor = value; } 
    }
        
    public List<Edge> EdgesList { 
        get { return edgesList; } 
    }
        
    public int[][] Matriz{
        get { return matriz; } 
    }
        
    public int NodeRadio{
        get { return nodeRadio;} 
        set { nodeRadio = value; } 
    }
        
    public bool EdgeNamesVisible{
        get { return edgeNamesVisible; } 
        set { edgeNamesVisible = value; } 
    }
        
    public bool EdgeWeightVisible{
        get { return edgeWeightVisible; } 
        set { edgeWeightVisible = value; } 
    }

    #endregion

    #region constructores
    public Graph(){
        edgesList = new List<Edge>();
        edgeColor = Color.Black;
        letter = true;
        edgeNamesVisible = false;
        edgeWeightVisible = false;
        nodeColor = Color.White;
        nodeRadio = 30;
        nodeBorderWidth = 1;
        edgeWidth = 1;
        nodeBorderColor = Color.Black;
    }

    public Graph(Graph gr){

        edgesList = new List<Edge>();
        edgeColor = gr.EdgeColor;
        nodeColor = gr.nodeColor;
        NodeP aux1,aux2;
        nodeRadio = gr.NodeRadio;
        Edge k = new Edge();
        nodeBorderWidth = 1;
        edgeWidth = 1;
        nodeBorderColor = Color.Black;
        edgeNamesVisible = gr.EdgeNamesVisible;
        edgeWeightVisible = gr.EdgeWeightVisible;
        letter = gr.Letter;
            

        foreach (NodeP n in gr){
            this.Add(new NodeP(n));
        }

        foreach(NodeP n in gr){
            aux1 = Find(delegate(NodeP bu) { if (bu.Name == n.Name)return true; else return false; });
            foreach (NodeR rel in n.relations){
                aux2 = Find(delegate(NodeP je) { if (je.Name == rel.Up.Name)return true; else return false; });
                aux1.InsertRelation(aux2, EdgesList.Count);
            }
        }

        foreach (Edge ar in gr.edgesList){
            aux1 = Find(delegate(NodeP bu) { if (bu.Name == ar.Origin.Name)return true; else return false; });
            aux2 = Find(delegate(NodeP bu) { if (bu.Name == ar.Destiny.Name)return true; else return false; });
            k = new Edge(ar.Type, aux1, aux2, ar.Name);
            k.Weight = ar.Weight;
            AddEdge(k);
        }
    }

    #endregion
    #region operaciones

    public void AddNode(NodeP n){ 
        Add(n);
    }

    public void AddEdge(Edge A){
        edgesList.Add(A);
    }

    public void RemoveEdge(Edge ar){
        NodeR rel;
        rel = ar.Origin.relations.Find(delegate(NodeR np) { if (np.Up.Name==ar.Destiny.Name)return true; else return false; });
        if (rel != null){
            ar.Origin.relations.Remove(rel);
            ar.Origin.Degree--;
            ar.Destiny.Degree--;
            ar.Origin.DegreeEx--;
            ar.Destiny.DegreeIn--;
        }
        if (ar.Type == 2){
            rel = ar.Destiny.relations.Find(delegate(NodeR np) { if (np.Up.Name==ar.Origin.Name)return true; else return false; });
                
            if (rel != null){
                ar.Destiny.relations.Remove(rel);
                ar.Destiny.DegreeEx--;
                ar.Origin.DegreeIn--;
            }
        }
        edgesList.Remove(ar);
    }
    public void RemoveNode(NodeP rem){
        NodeR rel;
        List<Edge>remove;
        remove = new List<Edge>();
            
        foreach(NodeP a in this){
            rel = a.relations.Find(delegate(NodeR np) { if (np.Up.Name==rem.Name)return true; else return false; });
            if (rel != null){
                a.relations.Remove(rel);
                a.Degree--;
                a.DegreeEx--;
                if(edgesList[0].Type == 0 || edgesList[0].Type == 2){
                    a.DegreeIn--;
                }
            }
        }
        remove = edgesList.FindAll(delegate(Edge ar){if(ar.Origin.Name==rem.Name||ar.Destiny.Name==rem.Name)return true;else return false;});
        if(remove!=null)
            foreach(Edge re in remove){
                edgesList.Remove(re);
            }
        this.Remove(rem);
    }



    #endregion

    public void Deselect(){
        foreach (NodeP r in this){
            r.Selected = false;
        }
    }

    public bool Connected(NodeP a, NodeP b) { // regresa si dos nodos está conectados
        for (int i = 0; i < a.relations.Count; i++) {
            if (a.relations[i].Up == b) {
                return true;
            }
        }
        return false;
    }

    public Edge GetEdge(NodeP a, NodeP b){ // regresa la arista entre dos nodos que si se sabe que tiene aristas
        for (int i = 0; i < edgesList.Count; i++) {
            if (edgesList[i].Origin == a && edgesList[i].Destiny == b || edgesList[i].Origin == b && edgesList[i].Destiny == a) {
                return (edgesList[i]);
            }
        }
        return(null);
    }

    public void UnselectAllNodes() {
        for (int k = 0; k < Count; k++) {
            this[k].Visited = false;
        }
    }

    public void Complement() { // saca el complemento del grafo
        Edge rel;
        int i, j;
        UnselectAllNodes();

            if (Count >= 2) {
                for (i = 0; i < Count; i++) { // recorre todo el grafo
                    for (j = 0; j < Count; j++) {
                        if (i != j && !this[j].Visited) { // si no apunta a si mismo y no esta visitado
                            if (Connected(this[i], this[j])) { 
                                // si esta conectados los nodos, remueve la arista
                                rel = GetEdge(this[i], this[j]);
                                RemoveEdge(rel);
                            }
                            else { 
                                // si los nodos no estan conectados
                                this[i].InsertRelation(this[j], edgesList.Count);
                                this[j].InsertRelation(this[i], edgesList.Count);
                                //this[i].relations.Add(new NodeR(this[j], this[j].Name));
                                //this[j].relations.Add(new NodeR(this[i], this[i].Name));
                                this.AddEdge(new Edge(2, this[i], this[j], "e" + i.ToString()));
                                this[i].Degree++;
                                this[j].Degree++;
                                this[i].DegreeEx++;
                                this[j].DegreeIn++;
                                this[i].DegreeEx++;
                                this[j].DegreeIn++;
                          
                            }
                            
                        }
                    }
                    this[i].Visited = true;
                }
            }
    }

    public bool isRegular() {
        foreach (NodeP np in this) {
            if (np.Degree < Count - 1) {
                return false;
            }
        }
        return true;
    }   

    public List<List<NodeP>> colorear(){
        bool found = false;
        int re = 0, g = 0, b = 255;            
        Color co = Color.FromArgb(re, g, b);
        List<List<NodeP>> listas=new List<List<NodeP>>();
        List<NodeP> au = new List<NodeP>();
        
        foreach(NodeP nodin in this){
            foreach(List<NodeP> c in listas){
                if(found == false)
                    if (c.Find(delegate(NodeP a) { if (a.relations.Find(delegate(NodeR r) { if (r.Up.Name == nodin.Name)return true; else return false; }) != null || nodin.relations.Find(delegate(NodeR rela){if(rela.Up.Name==a.Name)return true;else return false;})!=null)return true; else return false; }) == null)
                    {
                        c.Add(nodin);
                        found = true;
                    }
            }
            if (found == false){
                au = new List<NodeP>();
                au.Add(nodin);
                listas.Add(au);
            }
            found = false;
        }
        foreach (List<NodeP> a in listas) {
            foreach (NodeP n in a) {
                n.Color = co;
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
            co = Color.FromArgb(co.R - co.R + re, co.G - co.G + g, co.B - co.B + b);      
        }
        return(listas);
    }

    //metodo que regresa si el grafo esta conectado(un solo componente)
    public bool IsConnectedU() {
        foreach (NodeP np in this) {
            if (np.Degree == 0) {
                return false;
            }
        }
        return true;
    }

    //hace que todas las aristas no estén visitadas
    public void UnselectAllEdges() {
        foreach (Edge ed in edgesList) {
            ed.Visited = false;
        }
    }

    //verifica que todas las aristas estén visitadas
    public bool AllEdgesVisited() {
        foreach (Edge ed in edgesList) {
            if (ed.Visited == false) {
                return false;
            }
        }
        return true;
    }

    public bool AllNodesVisited() {
        foreach(NodeP np in this){
            if (np.Visited == false) {
                return false;
            }
        }
        return true;
    }

    //checa si tiene un camino de euler
    public int HasEulerPath() {
        int evenNodes = 0;
        int pending = 0;
        foreach (NodeP np in this) {
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
                    if (np.Degree%3 == 0) {
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
    public bool HasEulerCycle () {
        foreach (NodeP np in this) {
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

    //regresa una lista de aristas que representa un camino o un circuito de euler
    public void FindEulerCycleRoad(Edge e, NodeP orig, NodeP dest,  List<Edge> euler) {
        Console.Write(e.Name + " ");
        //marca como visitada
        e.Visited = true;

        //busca la siguiente arista conectada al nodo actual en la lista de aristas
        //for(int i = 0; i < edgesList.Count; i++){
        foreach (Edge currEd in edgesList) {
            if (!currEd.Visited && currEd.Destiny.Name == dest.Name) {
                //orig = currEd.Destiny;
                //dest = currEd.Origin;
                if (!AllEdgesVisited()) {
                    FindEulerCycleRoad(currEd, currEd.Destiny, currEd.Origin, euler);
                }
                break;
            }
            if (!currEd.Visited && currEd.Origin.Name == dest.Name) {
                //orig = dest;
                //orig = currEd.Origin;
                //dest = currEd.Destiny;
                if (!AllEdgesVisited()) {
                    FindEulerCycleRoad(currEd, currEd.Origin, currEd.Destiny, euler);
                }

                break;
            }

        }
        //obtiene la arista siguiente
        //Edge ne = GetEdge(orig, dest);
        //si todas las aristas no son visitadas entonces repite
        //if(!AllEdgesVisited()){
        //    FindEulerCycleRoad(ne, orig, dest, euler);
        //}
        //agrega la lista
        euler.Add(e);
    }

}
}


   