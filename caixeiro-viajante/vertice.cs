using System;
using System.Collections;
using System.Collections.Generic;

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