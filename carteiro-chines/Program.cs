using System;
using System.Collections.Generic;

public class Program {
    public static void Main() {
        Grafo grafo = new Grafo();

        // Criação dos vértices de exemplo
        Vertice v1 = grafo.InserirVertice("v1");
        Vertice v2 = grafo.InserirVertice("v2");
        Vertice v3 = grafo.InserirVertice("v3");
        Vertice v4 = grafo.InserirVertice("v4");

        // Criação das arestas de exemplo
        Aresta a01 = grafo.InserirAresta(v1, v2, "v1v2", 5);
        Aresta a02 = grafo.InserirAresta(v1, v3, "v1v3", 1);
        Aresta a03 = grafo.InserirAresta(v2, v3, "v2v3", 1);
        Aresta a04 = grafo.InserirAresta(v2, v4, "v2v4", 2);
        Aresta a05 = grafo.InserirAresta(v3, v4, "v3v4", 3);

        // Criar uma instância de CarteiroChines
        CarteiroChines carteiroChines = new CarteiroChines(grafo);

        // Encontrar o caminho Euleriano
        List<Aresta> caminhoEuleriano = carteiroChines.EncontrarCaminhoEuleriano();

        // Exibir ou inspecionar o resultado
        Console.WriteLine("Caminho Euleriano:");
        foreach (Aresta aresta in caminhoEuleriano) {
            Console.WriteLine(aresta);
        }
    }
}
