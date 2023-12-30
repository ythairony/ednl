using System;
using System.IO;


public class Labirinto {
    private int[,] matriz;
    private Grafo grafo;
    private Vertice pontoPartida;
    private Vertice pontoSaida;


    public Labirinto(string caminhoArquivo) {
        LerLabirinto(caminhoArquivo);
        ConstruiGrafo();
    }


    private void LerLabirinto(string caminhoArquivo) {
        try {
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            int linhasLabirinto = linhas.Length;
            int colunasLabirinto = linhas[0].Length;

            matriz = new int[linhasLabirinto, colunasLabirinto];

            for (int i = 0; i < linhasLabirinto; i++) {
                for (int j = 0; j < colunasLabirinto; j++) {
                    matriz[i, j] = int.Parse(linhas[i][j].ToString());
                }
            }
        }

        catch (Exception e) {
            Console.WriteLine("ERRO ao ler o labirinto: ", e.Message);
        }
    }


    private void ConstruiGrafo() {
        grafo = new Grafo();

        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j <matriz.GetLength(1); j++) {
                if (matriz[i, j] == 0 || matriz[i, j] == 2 || matriz[i, j] == 3) {
                    Vertice vertice = grafo.InserirVertice(new Tuple<int, int>(i, j));

                    if (matriz[i, j] == 2) pontoPartida = vertice;

                    else if (matriz[i, j] == 3) pontoSaida = vertice;

                    if (i > 0 && (matriz[i - 1, j] == 0 || matriz[i - 1, j] == 2 || matriz[i - 1, j] == 3)) {
                        Vertice verticeOrigem = grafo.Vertices().Last(); // Pega o último vértice inserido

                        int indexVerticeDestino = grafo.Vertices().IndexOf(new Vertice(new Tuple<int, int>(i - 1, j)));
                        if (indexVerticeDestino != -1) {
                            Vertice verticeDestino = grafo.Vertices()[indexVerticeDestino];
                            grafo.InserirAresta(verticeOrigem, verticeDestino, null);
                        }
                    }

                    if (j > 0 && (matriz[i, j - 1] == 0 || matriz[i, j - 1] == 2 || matriz[i, j - 1] == 3)) {
                        Vertice verticeOrigem = grafo.Vertices().Last(); // Pega o último vértice inserido

                        int indexVerticeDestino = grafo.Vertices().IndexOf(new Vertice(new Tuple<int, int>(i, j - 1)));
                        if (indexVerticeDestino != -1) {
                            Vertice verticeDestino = grafo.Vertices()[indexVerticeDestino];
                            grafo.InserirAresta(verticeOrigem, verticeDestino, null);
                        }
                    }
                }
            }
        }
    }


    public List<Vertice> EncontrarMenorCaminho() {
        Dijkstra dijkstra = new Dijkstra();
        Dictionary<Vertice, int> distancias = dijkstra.Executar(grafo, pontoPartida);


        // Encontrar o vértice de saída com a menor distância 
        Vertice melhorSaida = pontoSaida;
        int menorDistancia = distancias[pontoSaida];

        foreach (Vertice saida in grafo.Vertices()) {
            if (matriz[((Tuple<int, int>)saida.GetVertice()).Item1, ((Tuple<int, int>)saida.GetVertice()).Item2] == 3) {
                int distancia = distancias[saida];
                if (distancia < menorDistancia) {
                    menorDistancia = distancia;
                    melhorSaida = saida;
                }
            }
        }

        // Reconstruir o caminho
        List<Vertice> caminho = new List<Vertice>();
        Vertice atual = melhorSaida;
        
        while (atual != null) {
            caminho.Insert(0, atual);
            atual = dijkstra.ObterAntecessor(atual);
        }


        return caminho;
    }


    public List<Vertice> EncontrarMenorCaminhoAEstrela() {
        AEstrela aEstrela = new AEstrela();
        Dictionary<Vertice, int> distancias = aEstrela.Executar(grafo, pontoPartida);

        // Reconstruir o caminho
        List<Vertice> caminho = new List<Vertice>();
        Vertice atual = pontoSaida;

        while (atual != null) {
            caminho.Insert(0, atual);
            atual = aEstrela.ObterAntecessor(atual);
        }

        return caminho;
    }


    public Grafo ObterGrafo() {
        return grafo;
    }


    public int[,] ObterMatriz() {
        return matriz;
    }


    public Vertice ObterPontoPartida() {
        return pontoPartida;
    }


    public Vertice ObterPontoSaida() {
        return pontoSaida;
    }
}