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

public class Grafo:List<NodeP>{
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

    #region get's & set's

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

    public Grafo(){
        edgesList = new List<Edge>();
        edgeColor = Color.Black;
        edgeNamesVisible = false;
        edgeWeightVisible = false;
        nodeColor = Color.White;
        nodeRadio = 30;
        nodeBorderWidth = 1;
        edgeWidth = 1;
        nodeBorderColor = Color.Black;
    }

    public Grafo(Grafo gr){

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
        List<Edge>remover;
        remover=new List<Edge>();
            
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
        remover=edgesList.FindAll(delegate(Edge ar){if(ar.Origin.Name==rem.Name||ar.Destiny.Name==rem.Name)return true;else return false;});
        if(remover!=null)
            foreach(Edge re in remover){
                edgesList.Remove(re);
            }
        this.Remove(rem);
    }

    #endregion
    #region algoritmos

    public void CreateMatrix(){ //
        matriz = new int[Count][];
        int i = 0, j;
            
        for (int x = 0; x < Count; x++){
            matriz[x]=new int[Count];
        }
            
        this.Sort(delegate(NodeP a, NodeP b) { 
            return a.Name.CompareTo(b.Name); 
        });

        foreach(NodeP nod in this){
            j=0;
            foreach(NodeP nod2 in this){
                if (nod.relations.Find(delegate(NodeR r) {if(nod2.Name == r.Up.Name) return true; else return false; }) != null){
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
       
    public int Componentes2(NodeP nodito, List<NodeP> compo){
        if(nodito.relations.Find(delegate(NodeR r) { if (r.Visited!=true )return true; else return false; }) == null){
            return 1;
        }
        else{
            compo.Add(nodito);
            foreach (NodeR a in nodito.relations){
                if (a.Visited == false){
                    a.Visited = true;
                    compo.Add(a.Up);
                    Componentes2(a.Up, compo);
                }
            }
            return 0;
        }
    }

    public int Componentes(){
        bool enco = false;
        bool enco2=false;
        List<List<NodeP>> componentes = new List<List<NodeP>>();
        List<NodeP> nue = new List<NodeP>();
        Grafo aux = new Grafo(this);

        if(edgesList.Count != 0){
            foreach(NodeP nod in this){
                foreach(List<NodeP> n in componentes){
                    if(enco == false)
                        if(n.Find(delegate(NodeP f) { if (f.Name == nod.Name)return true; else return false; }) != null)
                            enco = true;
                }
                if(enco == false){
                    if(edgesList[0].Type == 1){
                        foreach(List<NodeP> n in componentes){
                            foreach(NodeP ee in n){
                                foreach(NodeR r in ee.relations){
                                    if(enco2 == false)
                                        if (n.Find(delegate(NodeP f) { if (f.Name == r.Up.Name)return true; else return false; }) != null)
                                            enco2 = true;
                                }
                            }
                        }
                        if(enco2 == false){
                            nue = new List<NodeP>();
                            this.Componentes2(nod, nue);
                            componentes.Add(nue);
                        }
                        enco2 = false;
                    }
                    else{
                        nue = new List<NodeP>();
                        this.Componentes2(nod, nue);
                        componentes.Add(nue);
                    }
                }
                enco = false;
            }
            foreach(NodeP re in this){
                foreach(NodeR rela in re.relations){
                    rela.Visited = false;
                }
            }
            return componentes.Count;
        }
        else{
            return this.Count;
        }
    }

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

    public Edge GiveEdge(NodeP a, NodeP b){ // regresa la arista entre dos nodos que si se sabe que tiene aristas
        for (int i = 0; i < edgesList.Count; i++) {
            if (edgesList[i].Origin == a && edgesList[i].Destiny == b) {
                return (edgesList[i]);
            }
            if (edgesList[i].Origin == b && edgesList[i].Destiny == a) {
                return (edgesList[i]);
            }
        }
        return(null);
    }

    public void Desel() {
        for (int k = 0; k < Count; k++) {
            this[k].Vis = false;
        }
    }

    public void Complement() { // saca el complemento del grafo
        Edge rel;
        int i, j;
        Desel();

            if (Count >= 2) {
                for (i = 0; i < Count; i++) { // recorre todo el grafo
                    for (j = 0; j < Count; j++) {
                        if (i != j && !this[j].Vis) { // si no apunta a si mismo y no esta visitado
                            if (Connected(this[i], this[j])) { // si esta conectados los nodos, remueve la arista
                                rel = GiveEdge(this[i], this[j]);
                                RemoveEdge(rel);
                                this[i].Vis = true;
                            }
                            else { // si los nodos no estan conectados
                                this[i].relations.Add(new NodeR(this[j], this[j].Name));
                                this[j].relations.Add(new NodeR(this[i], this[i].Name));
                                this.edgesList.Add(new Edge(0, this[i], this[j], "a"));
                                this[i].Degree++;
                                this[j].Degree++;
                                this[i].Vis = true;
                            }
                            
                        }
                    }
                }
            }

        /*
        if (nodoOriginal.relations.Count > 0){// si tiene alguna relacion el nodo original en el que esta

            for (j = 0; j < this.Count; j++) { // recorre todas las relaciones cada nodo del gafo principal

                relOriginal = nodoOriginal.relations.ElementAt<NodoRel>(j); // obtiene cada nodo de la lista de relaciones

                if (relOriginal.Name != nodName.ToString()) {
                    nodoNuevo.relations.Add(relOriginal);
                    inverse.Add(new Edge(0, nodoOriginal, relOriginal.Up, relOriginal.Name));
                }
                nodName++;
            }
        }
        else { // si no tiene ninguna relacion el nodo original
            for(j = 1; j < this.Count; j++){
                inverse.Add.(new Edge(0, nodoNuevo, ))
                npn.relations.Add()
            }
        }
        */
        //edgesList.Clear();
        //edgesList = inverse;
    }}
    #endregion
}

   