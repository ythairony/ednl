using System;
using System.Collections.Generic;
using System.Linq;

public class Dijkstra {
    private Dictionary<Vertice, Vertice> antecessor;

    public Dictionary<Vertice, int> Executar(Grafo grafo, Vertice origem) {
        Dictionary<Vertice, int> distancia = new Dictionary<Vertice, int>();
        List<Vertice> naoVisitados = new List<Vertice>();
        antecessor = new Dictionary<Vertice, Vertice>();

        foreach (Vertice v in grafo.Vertices()) {
            distancia[v] = int.MaxValue;
            antecessor[v] = null;
            naoVisitados.Add(v);
        }

        distancia[origem] = 0;

        while (naoVisitados.Count > 0) {
            Vertice u = ObterVerticeMenorDistancia(distancia, naoVisitados);
            naoVisitados.Remove(u);

            foreach (Aresta a in grafo.ArestasIncidentes(u)) {
                Vertice v = grafo.Oposto(u, a);
                int distanciaAtualizada = distancia[u] + 1;

                if (distanciaAtualizada < distancia[v]) {
                    distancia[v] = distanciaAtualizada;
                    antecessor[v] = u;
                }
            }
        }
    

    return distancia;
    }


    private static Vertice ObterVerticeMenorDistancia(Dictionary<Vertice, int> distancia, List<Vertice> naoVisitados) {
        return naoVisitados.OrderBy(v => distancia[v]).First();
    }


    public Vertice ObterAntecessor(Vertice v) {
        return antecessor[v];
    }

}