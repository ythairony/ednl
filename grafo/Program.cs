using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();

        Vertice v1 = grafo.InserirVertice("v1");
        Vertice v2 = grafo.InserirVertice("v2");
        Vertice v3 = grafo.InserirVertice("v3");
        grafo.SubstituirVertice(v1, "Novo v1");

        Aresta a1 = grafo.InserirAresta(v1, v2, "A1");
        Aresta a2 = grafo.InserirAresta(v2, v3, "A2");
        grafo.SubstituirAresta(a1, "Novo A1");
        
        
        // Printando os vértices
        // Console.WriteLine("Lista de Vértices");
        // foreach(Vertice v in grafo.Vertices()) {
        //     Console.WriteLine(v.GetVertice());
        // }


        // Console.WriteLine();
        // Console.WriteLine();
        // // Pritando as arestas
        // Console.WriteLine("Lista de Arestas");
        // foreach(Aresta a in grafo.Arestas()) {
        //     Console.WriteLine(a.ToString());
        // }

        // Console.WriteLine(grafo.Oposto(v1, a1));
        // Console.WriteLine(grafo.EAdjacente(v1, v3));

        // Printando Arestas Incidentes
        Console.WriteLine("Arestas incidentes em [v2]"); 
        foreach(Aresta a in grafo.ArestasIncidentes(v2)) {
            Console.WriteLine(a.GetAresta());
        }
    }
}
