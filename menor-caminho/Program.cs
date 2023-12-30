using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program {
    static void Main() {
        string caminhoArquivo = "labirinto.dat";
        Labirinto labirinto = new Labirinto(caminhoArquivo);

        Grafo grafo = labirinto.ObterGrafo();
        Vertice pontoPartida = labirinto.ObterPontoPartida();
        Vertice pontoSaida = labirinto.ObterPontoSaida();

        Console.WriteLine("Labirinto:");
        ImprimirMatriz(labirinto);

        // Executar e medir o tempo de execução do algoritmo de Dijkstra
        Stopwatch stopwatchDijkstra = new Stopwatch();
        stopwatchDijkstra.Start();
        Console.WriteLine("\nMenor Caminho - Dijkstra:");
        List<Vertice> menorCaminhoDijkstra = labirinto.EncontrarMenorCaminho();
        stopwatchDijkstra.Stop();
        ImprimirCaminho(menorCaminhoDijkstra);
        Console.WriteLine($"Tempo de execução (Dijkstra): {stopwatchDijkstra.ElapsedMilliseconds*1000}");

        // Executar e medir o tempo de execução do algoritmo A*
        Stopwatch stopwatchAStar = new Stopwatch();
        stopwatchAStar.Start();
        Console.WriteLine("\nMenor Caminho - A*:");
        List<Vertice> menorCaminhoAStar = labirinto.EncontrarMenorCaminhoAEstrela();
        stopwatchAStar.Stop();
        ImprimirCaminho(menorCaminhoAStar);
        Console.WriteLine($"Tempo de execução (A*): {stopwatchAStar.ElapsedMilliseconds*1000}");
    }

    static void ImprimirMatriz(Labirinto labirinto) {
        int[,] matriz = labirinto.ObterMatriz();

        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j < matriz.GetLength(1); j++) {
                Console.Write(matriz[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void ImprimirCaminho(List<Vertice> caminho) {
        foreach (Vertice vertice in caminho) {
            Tuple<int, int> coordenadas = (Tuple<int, int>)vertice.GetVertice();
            Console.WriteLine($"({coordenadas.Item1}, {coordenadas.Item2})");
        }
    }
}
