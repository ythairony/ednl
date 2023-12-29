using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();
        CarteiroChines perdido = new CarteiroChines(grafo);

        Vertice v1 = grafo.InserirVertice("v1");
        Vertice v2 = grafo.InserirVertice("v2");
        Vertice v3 = grafo.InserirVertice("v3");

        Aresta a1 = grafo.InserirAresta(v1, v2, "A1");
        Aresta a2 = grafo.InserirAresta(v2, v3, "A2");

        Console.WriteLine($"O carteiro achou o caminho conexo? {perdido.EConexo()}"); // True

        // Grafo euleriano = perdido.ConstruirGrafoEuleriano(grafo.Arestas());
    }
}
