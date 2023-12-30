using System;
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

        Console.WriteLine("\nMenor Caminho:");
        List<Vertice> menorCaminho = labirinto.EncontrarMenorCaminho();
        ImprimirCaminho(menorCaminho);
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
