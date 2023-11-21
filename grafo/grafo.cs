using System;
using System.Collections;
using System.Collections.Generic;

public class Grafo {
    private List<Vertice> vertices;
    private List<Aresta> arestas;
    private int QntVertices = 0;
    private int QntArestas = 0;


    public Grafo() {
        vertices = new List<Vertice>();
        arestas = new List<Aresta>();
    }

    public List<Vertice> FinalVertices(object a) {
        // retorna um array com os vértices de cada lá
        return vertices; 
    }


    public Vertice Oposto(Vertice v, object a) {
        // retorna ou outro vértice
        return v; // é outro vertice 
    }


    public bool EAdjacente (Vertice v, Vertice w) {
        // retorna true ou false se eles são vizinhos
        return true;
    }


    // SUBSTITUIR
    public void SubstituirVertice(Vertice v, Vertice new_v) {
        // Substitui um vértice por um novo 
    }


    public void SubstituirAresta(object a, object new_a) {
        // Substitui um aresta por um novo
    }


    // INSERÇÃO 
    public Vertice InserirVertice(object v) { //OK
        Vertice vertice = new Vertice(v);
        vertices.Add(vertice);
        this.QntVertices++;
        return vertice;
    } 


    public void InserirAresta(Vertice v, Vertice w, object a) { //OK
        // Insere e retorna uma nova aresta com os vertices v e w
        Aresta aresta = new Aresta(a, v, w);
        v.SetAresta(aresta);
        w.SetAresta(aresta);
        arestas.Add(aresta);
        this.QntArestas++;
    }


    public object RemoverVertice(Vertice v) {
        // Remove e retorna o elemento do vértice
        return v.GetVertice();
    }


    public object RemoverAresta(object a) {
        // remove a aresta e retorna o elemento
        return a; 
    }


    public object ArestasIncidentes(Vertice v) {
        // retorna um array com todas as arestas incidentes no vértice
        return v.GetVertice();
    }


    public List<Vertice> Vertices() { //OK 
        return vertices;
    }


    public List<Aresta> Arestas() {
        return arestas;
    }


    //DIRIGIDO 
    // public bool EDirecionado(object a) {
    //     // testa se a aresta é direcionada
    // }


    // public Vertice InserirArestaDirecionada(Vertice v_inicial, Vertice v_final, object a) {
    //     // Insere uma nova aresta dirigida com a origem em v_inicial e destino em v_final 
    // }
}


public class Vertice {
    private object vertice;
    private List<Aresta> arestas; // Decidir na hora da implementação 
    
    public Vertice(object vertice) {
        this.vertice = vertice;
        this.arestas = new List<Aresta>();
    }


    public object GetVertice() {
        return vertice;
    }

    
    public List<Aresta> GetArestas() {
        return arestas;
    }

    
    public void SetAresta(Aresta a){
        arestas.Add(a);
    }
}


public class Aresta {
    private Vertice verticeOrigem;
    private Vertice verticeDestino;
    private object aresta;

    public Aresta(object aresta, Vertice vOrigem, Vertice vDestino) {
        this.aresta = aresta;
        this.verticeOrigem = vOrigem;
        this.verticeDestino = vDestino;
    }


    public object GetAresta() {
        return aresta;
    }


    public object GetVerticeSaida() {
        return verticeOrigem;
    }


    public object GetverticeDestino() {
        return verticeDestino;
    }


    public override string ToString() {
        return $"A aresta [{aresta}] está conectada pelos vértices [{verticeOrigem.GetVertice()}] e [{verticeDestino.GetVertice()}]";
    }
}