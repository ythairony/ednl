using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();

        Vertice v1 = grafo.InserirVertice("v1");
        Vertice v2 = grafo.InserirVertice("v2");
        Vertice v3 = grafo.InserirVertice("v3");

        Aresta a1 = grafo.InserirAresta(v1, v2, "A1");
        Aresta a2 = grafo.InserirAresta(v2, v3, "A2");
        Aresta a3 = grafo.InserirAresta(v1, v3, "A3");

        Console.WriteLine(grafo.RemoverVertice(v2));
        // Console.WriteLine(grafo.RemoverAresta(a2));
     

        Console.WriteLine(v1.ToString());
        Console.WriteLine(v2.ToString());
        Console.WriteLine(v3.ToString());
        Console.WriteLine(a1.ToString());
        Console.WriteLine(a2.ToString());
        Console.WriteLine(a3.ToString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Arestas incidentes em [v3]"); 
        foreach(Aresta a in grafo.ArestasIncidentes(v3)) {
            Console.WriteLine(a.GetAresta());
        }
    }
}
