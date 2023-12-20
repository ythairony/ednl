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

    public string FinalVertices(Aresta a) {
        return $"Os vértices da aresta {a.GetAresta()} são:\n{a.GetVerticeOrigem()}\n{a.GetVerticeDestino()}"; 
    }


    public object Oposto(Vertice vertice, Aresta aresta) { //OK mas precisa identificar a milacria do print
        // retorna ou outro vértice
        Vertice oposto = null;
        foreach(Aresta a in arestas) {
            if (a.GetVerticeOrigem().Equals(vertice) && a.GetAresta().Equals(aresta.GetAresta())) {
                oposto = new Vertice(a.GetVerticeDestino());
                break;
            } else if (a.GetVerticeDestino().Equals(vertice) && a.GetAresta().Equals(aresta.GetAresta())) {
                oposto = new Vertice(a.GetVerticeOrigem());
                break;
            }
        }

        if (oposto != null) {
            return oposto.ToString();
        } else {
            throw new InvalidOperationException("Não há vértice oposto"); 
        }
    }


    public bool EAdjacente (Vertice v, Vertice w) { //OK
        // retorna true ou false se eles são vizinhos
        foreach(Aresta a in arestas) {
            if (a.GetVerticeOrigem().Equals(v) && a.GetVerticeDestino().Equals(w)
             || a.GetVerticeOrigem().Equals(w) && a.GetVerticeDestino().Equals(v)
            ) {
                return true;
            }
        }
        return false;
    }


    // SUBSTITUIR
    public void SubstituirVertice(Vertice v, object new_v) { //OK
        // Substitui um vértice por um novo 
        v.SetVertice(new_v);
    }


    public void SubstituirAresta(Aresta a, object new_a) { //OK
        // Substitui um aresta por um novo
        a.SetAresta(new_a);
    }


    // INSERÇÃO 
    public Vertice InserirVertice(object v) { //OK
        Vertice vertice = new Vertice(v);
        vertices.Add(vertice);
        this.QntVertices++;
        return vertice;
    } 


    public Aresta InserirAresta(Vertice v, Vertice w, object a) { //OK
        // Insere e retorna uma nova aresta com os vertices v e w
        Aresta aresta = new Aresta(a, v, w);
        v.SetAresta(aresta);
        w.SetAresta(aresta);
        arestas.Add(aresta);
        this.QntArestas++;
        return aresta;
    }


    public object RemoverVertice(Vertice v) {
        // Remove e retorna o elemento do vértice
        vertices.Remove(v);

        foreach (Aresta a in arestas.ToList()) {
            if (a.GetVerticeOrigem().Equals(v) || a.GetVerticeDestino().Equals(v)) {
                arestas.Remove(a);
            } 
        }

        return v.GetVertice();
    }



    // RESOLVER ESSE PROBLEMA AQUI
    public void RemoverAresta(Aresta a) { // PARCIALMENTE FINALIZADO
        // remove a aresta e retorna o elemento
        arestas.Remove(a); 

        a.GetVerticeOrigem().RemoverAresta(a);
        a.GetVerticeDestino().RemoverAresta(a);
        // PRECISO REMOVER A ARESTA DOS VÉRTICES


        // return a.GetAresta(); 
    }


    public List<Aresta> ArestasIncidentes(Vertice v) { //OK
        // retorna um array com todas as arestas incidentes no vértice
        return v.GetArestas();
    }


    public List<Vertice> Vertices() { //OK 
        return vertices;
    }


    public List<Aresta> Arestas() { //OK
        return arestas;
    }


    //DIRIGIDO 
    // public bool EDirecionado(object a) {
    //     // testa se a aresta é direcionada
    // }


    public Aresta InserirArestaDirecionada(Vertice v_inicial, Vertice v_final, object a) {
        // Insere uma nova aresta dirigida com a origem em v_inicial e destino em v_final
        Aresta aresta = new Aresta(a, v_inicial, v_final);
        v_inicial.SetAresta(aresta);
        arestas.Add(aresta);
        this.QntArestas++;
        return aresta; 
    }
}


public class Vertice {
    private object vertice;
    private List<Aresta> arestas; 
    
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


    public void SetVertice(object v) {
        this.vertice = v;
    }

    
    public void SetAresta(Aresta a){
        arestas.Add(a);
    }


    public void RemoverAresta(Aresta a) {
        arestas.Remove(a);
    }

    public override string ToString() {
        return $"{vertice}";
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


    public object GetVerticeOrigem() {
        return verticeOrigem;
    }


    public object GetVerticeDestino() {
        return verticeDestino;
    }


    public void SetAresta(object a) {
        this.aresta = a;
    }


    public override string ToString() {
        return $"A aresta [{aresta}] está conectada pelos vértices [{verticeOrigem.GetVertice()}] e [{verticeDestino.GetVertice()}]";
    }
}