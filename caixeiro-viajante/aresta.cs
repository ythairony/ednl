using System;
using System.Collections;
using System.Collections.Generic;

public class Aresta {
    private Vertice verticeOrigem;
    private Vertice verticeDestino;
    private object aresta;
    private int peso;

    public Aresta(object aresta, Vertice vOrigem, Vertice vDestino, int peso) {
        // Verificação se alguns dos vértices são nulos
        if (vOrigem == null || vDestino == null) {
            throw new ArgumentNullException("Os vértices de origem e destino não podem ser nulos.");
        }

        this.aresta = aresta;
        this.verticeOrigem = vOrigem;
        this.verticeDestino = vDestino;
        this.peso = peso;
    }


    public object GetAresta() {
        return aresta;
    }


    public Vertice GetVerticeOrigem() {
        return verticeOrigem;
    }


    public Vertice GetVerticeDestino() {
        return verticeDestino;
    }


    public int GetPeso() {
        return peso;
    }


    public void SetAresta(object a) {
        this.aresta = a;
    }

    
    public void SetPeso(int peso) {
        this.peso = peso;
    }


    public override string ToString() {
        return $"A aresta [{aresta}] está conectada pelos vértices [{verticeOrigem.GetVertice()}] e [{verticeDestino.GetVertice()}] e o peso é {peso}";
    }
}