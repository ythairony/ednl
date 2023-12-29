using System;
using System.Collections;
using System.Collections.Generic;

public class Aresta {
    private Vertice verticeOrigem;
    private Vertice verticeDestino;
    private object aresta;
    private int value = 0;

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

    
    public void SetValue(int value) {
        this.value = value;
    }


    public override string ToString() {
        return $"A aresta [{aresta}] está conectada pelos vértices [{verticeOrigem.GetVertice()}] e [{verticeDestino.GetVertice()}]";
    }
}