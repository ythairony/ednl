using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();

        object v1 = grafo.InserirVertice("v1");
        object v2 = grafo.InserirVertice("v2");

        // grafo.InserirAresta(v1, v2, "Primeira ARESTA");
        
        
        // Printando os vértices
        Console.WriteLine("Lista de Vértices");
        foreach(Vertice v in grafo.Vertices()) {
            Console.WriteLine(v.GetVertice());
        }
    }
}
