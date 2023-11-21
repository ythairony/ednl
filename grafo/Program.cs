using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();

        Vertice v1 = grafo.InserirVertice("v1");
        Vertice v2 = grafo.InserirVertice("v2");

        grafo.InserirAresta(v1, v2, "A1");
        
        
        // Printando os vértices
        Console.WriteLine("Lista de Vértices");
        foreach(Vertice v in grafo.Vertices()) {
            Console.WriteLine(v.GetVertice());
        }


        Console.WriteLine();
        Console.WriteLine();
        // Pritando as arestas
        Console.WriteLine("Lista de Arestas");
        foreach(Aresta a in grafo.Arestas()) {
            Console.WriteLine(a.ToString());
        }
    }
}
