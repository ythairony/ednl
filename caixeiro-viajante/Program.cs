using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();

        Vertice v1 = grafo.InserirVertice("v1");
        Vertice v2 = grafo.InserirVertice("v2");
        Vertice v3 = grafo.InserirVertice("v3");
        Vertice v4 = grafo.InserirVertice("v4");
        Vertice v5 = grafo.InserirVertice("v5");
        Vertice v6 = grafo.InserirVertice("v6");


        Aresta a01 = grafo.InserirAresta(v1, v2, "v1v2", 7);
        Aresta a02 = grafo.InserirAresta(v1, v3, "v1v3", 5);
        Aresta a03 = grafo.InserirAresta(v1, v5, "v1v5", 7);
        Aresta a04 = grafo.InserirAresta(v1, v6, "v1v6", 8);
        Aresta a05 = grafo.InserirAresta(v2, v3, "v2v3", 5);
        Aresta a06 = grafo.InserirAresta(v2, v4, "v2v4", 2);
        Aresta a07 = grafo.InserirAresta(v2, v5, "v2v5", 4);
        Aresta a08 = grafo.InserirAresta(v2, v6, "v2v6", 2);
        Aresta a09 = grafo.InserirAresta(v3, v4, "v3v4", 3);
        Aresta a10 = grafo.InserirAresta(v3, v5, "v3v5", 3);
        Aresta a11 = grafo.InserirAresta(v3, v6, "v3v6", 6);
        Aresta a12 = grafo.InserirAresta(v4, v5, "v4v5", 2);
        Aresta a13 = grafo.InserirAresta(v4, v6, "v4v6", 4);
        Aresta a14 = grafo.InserirAresta(v5, v6, "v5v6", 3);

        // Console.WriteLine(grafo.RemoverVertice(v2));
        // Console.WriteLine(grafo.RemoverAresta(a2));
     

        Console.WriteLine(v1.ToString());
        Console.WriteLine(v2.ToString());
        Console.WriteLine(v3.ToString());
        Console.WriteLine(a01.ToString());
        Console.WriteLine(a02.ToString());
        Console.WriteLine(a03.ToString());

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Arestas incidentes em [v3]"); 
        foreach(Aresta a in grafo.ArestasIncidentes(v3)) {
            Console.WriteLine(a.GetAresta());
        }
    }
}
