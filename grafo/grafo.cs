public class Grafo {
    private ArrayList vertices;
    private ArrayList arestas;


    public Vertice FinalVertices(object a) {
        // retorna um array com os vértices de cada lá 
    }


    public Vertice Oposto(Vertice v, object a) {
        // retorna ou outro vértice 
    }


    public bool EAdjacente (Vertice v, Vertice w) {
        // retorna true ou false se eles são vizinhos
    }


    // SUBSTITUIR
    public void SubstituirVertice(Vertice v, Vertice new_v) {
        // Substitui um vértice por um novo 
    }


    public void SubstituirAresta(object a, object new_a) {
        // Substitui um aresta por um novo
    }


    // INSERÇÃO 
    public object InserirVertice(object a) {
        // Insere e retorna o elemento armazenando o valor de a
    } 


    public Vertice InserirAresta(Vertice v, Vertice w, object a) {
        // Insere e retorna uma nova aresta com os vertices v e w
    }


    public object RemoverVertice(Vertice v) {
        // Remove e retorna o elemento do vértice
    }


    public object RemoverAresta(object a) {
        // remove a aresta e retorna o elemento 
    }


    public object ArestasIncidentes(Vertice v) {
        // retorna um array com todas as arestas incidentes no vértice
    }


    public Vertice Vertices() {
        // retorna todos os vértices no grafo.
    }


    public object Arestas() {
        // retorna todas as arestas no grafo
    }


    //DIRIGIDO 
    public bool EDirecionado(object a) {
        // testa se a aresta é direcionada
    }


    public Vertice InserirArestaDirecionada(Vertice v_inicial, Vertice v_final, object a) {
        // Insere uma nova aresta dirigida com a origem em v_inicial e destino em v_final 
    }
}


public class Vertice {
    private object vertice;
    private ArrayList arestas; // Decidir na hora da implementação 
    
    public Vertice(object vertice, object aresta) {
        this.vertice = vertice;
        this.aresta = aresta;
    }


    public object GetVertice() {
        return vertice;
    }

    
    public object GetAresta() {
        return aresta;
    }
}


public class Aresta {
    private object vertice_saida;
    private object vertice_destino;
    private object aresta;

    public Aresta(object aresta, object v_saida, object v_destino) {
        this.aresta = aresta;
        this.vertice_saida = v_saida;
        this.vertice_destino = v_destino;
    }


    public object GetAresta() {
        return aresta;
    }


    public object GetVerticeSaida() {
        return vertice_saida;
    }


    public object GetVerticeDestino() {
        return vertice_destino;
    }
}