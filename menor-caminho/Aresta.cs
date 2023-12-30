using System;
using System.Collections;
using System.Collections.Generic;

public class Aresta {
    private Vertice verticeOrigem;
    private Vertice verticeDestino;
    private object aresta;
    private bool visitada;

    public Aresta(object aresta, Vertice vOrigem, Vertice vDestino) {
        // Verificação se alguns dos vértices são nulos
        if (vOrigem == null || vDestino == null) {
            throw new ArgumentNullException("Os vértices de origem e destino não podem ser nulos.");
        }

        this.aresta = aresta;
        this.verticeOrigem = vOrigem;
        this.verticeDestino = vDestino;
        this.visitada = false;
    }


    public bool Visitada() {
        return this.visitada;
    }


    public void Visitar() {
        this.visitada = true;
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


    public void SetAresta(object a) {
        this.aresta = a;
    }


    public override string ToString() {
        return $"A aresta [{aresta}] está conectada pelos vértices [{verticeOrigem.GetVertice()}] e [{verticeDestino.GetVertice()}]";
    }
}