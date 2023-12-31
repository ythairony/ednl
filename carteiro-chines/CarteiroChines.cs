using System;
using System.Collections.Generic;
using System.Linq;


public class CarteiroChines {
    private Grafo grafo;


    public CarteiroChines(Grafo grafo) {
        this.grafo = grafo;
    }


    public List<Aresta> EncontrarCaminhoEuleriano() {
        List<Vertice> verticeImpar = EncontrarVerticeImpar();
        List<Aresta> menorCaminho = new List<Aresta>();

        while (verticeImpar.Count > 1) {
            Vertice vi = verticeImpar[0];

            Dictionary<Vertice, int> distancias = DijkstraExecutar(vi);

            // Encontrar vértice de menor distância (vj) em relação a vi
            Vertice vj = EncontrarVerticeMenorDistancia(distancias, verticeImpar);

            // Construir caminho entre vi e vj
            menorCaminho = ConstruirCaminhoEntreVertices(vi, vj);

            AdicionarCaminhoArtificial(menorCaminho);

            // Remover linhas e colunas correspondentes em D
            RemoverLinhasColunasD(vi, vj);

            // Atualizar a linha de vértices com grau ímpar
            verticeImpar = EncontrarVerticeImpar();
        }

        // Encontra caminho de Euler
        List<Aresta> caminhoEuleriano = Fleury(menorCaminho, verticeImpar[0]);

        return caminhoEuleriano;
    }


    public List<Vertice> EncontrarVerticeImpar() {
        List<Vertice> verticesImpar = new List<Vertice>();

        foreach (Vertice v in grafo.Vertices()) {
            if (grafo.Grau(v) % 2 != 0) {
                verticesImpar.Add(v);
            }
        }

        return verticesImpar;
    }


    private Vertice EncontrarVerticeMenorDistancia(Dictionary<Vertice, int> distancias, List<Vertice> vertices) {
        Vertice verticeMenorDistancia = null;
        int menorDistancia = int.MaxValue;

        foreach (Vertice v in vertices) {
            if (distancias[v] < menorDistancia) {
                verticeMenorDistancia = v;
                menorDistancia = distancias[v];
            }
        }

        return verticeMenorDistancia;
    }


    private void RemoverLinhasColunasD(Vertice vi, Vertice vj) {
        // Obtém a matriz de distâncias atual
        Dictionary<Vertice, int> distancias = DijkstraExecutar(vi);

        // Remove as linhas correspondentes ao vértice vi
        foreach (Vertice v in grafo.Vertices()) {
            if (v != vi) {
                distancias.Remove(v);
            }
        }

        // Remove as colunas correspondentes ao vértice vj
        foreach (Vertice v in grafo.Vertices()) {
            if (v != vj) {
                distancias.Remove(vj);
            }
        }
    }



    private void AdicionarCaminhoArtificial(List<Aresta> caminho) {
        foreach (Aresta aresta in caminho) {
            grafo.InserirAresta(aresta.GetVerticeOrigem(), aresta.GetVerticeDestino(), aresta.GetAresta(), aresta.GetPeso());
        }
    }


    private Dictionary<Vertice, int> DijkstraExecutar(Vertice origem) {
        Dijkstra dijkstra = new Dijkstra();
        return dijkstra.Executar(grafo, origem);
    }


    private List<Aresta> ConstruirCaminhoEntreVertices(Vertice origem, Vertice destino) {
        List<Aresta> caminho = new List<Aresta>();
        Vertice atual = destino;
        Dijkstra dijkstra = new Dijkstra();

        while (atual != origem) {
            Vertice antecessor = dijkstra.ObterAntecessor(atual);

            // Encontrar a aresta que conecta o antecessor ao vértice atual
            Aresta arestaCaminho = grafo.Arestas().FirstOrDefault(a =>
            (a.GetVerticeOrigem() == antecessor && a.GetVerticeDestino() == atual) ||
            (a.GetVerticeOrigem() == atual && a.GetVerticeDestino() == antecessor));

            if (arestaCaminho != null) {
                caminho.Insert(0, arestaCaminho);
                atual = antecessor;
            } else {
                throw new InvalidOperationException("Não foi possível encontrar a aresta no caminho.");
            }
        }

        return caminho;
    }


    public List<Aresta> Fleury(List<Aresta> arestasAGM, Vertice verticeInicio) {
        // Etapa 1: Inicialização
        List<Aresta> cicloEuleriano = new List<Aresta>();
        Grafo grafoDuplicado = CriarGrafoDuplicado(arestasAGM);

        // Etapa 2: Encontrar o ciclo Euleriano
        EncontrarCicloEuleriano(grafoDuplicado, verticeInicio, cicloEuleriano);

        // Etapa 3: Eliminar vértices duplicados
        RemoverVerticesDuplicados(cicloEuleriano);

        return cicloEuleriano;
    }

    private Grafo CriarGrafoDuplicado(List<Aresta> arestasAGM) {
        Grafo grafoDuplicado = new Grafo();

        foreach (Aresta a in arestasAGM) {
            // Duplicar cada aresta (cada aresta do AGM aparecerá duas vezes)
            grafoDuplicado.InserirAresta(a.GetVerticeOrigem(), a.GetVerticeDestino(), a.GetAresta(), a.GetPeso());
            grafoDuplicado.InserirAresta(a.GetVerticeDestino(), a.GetVerticeOrigem(), a.GetAresta(), a.GetPeso());
        }

        return grafoDuplicado;
    }


    private void EncontrarCicloEuleriano(Grafo grafo, Vertice atual, List<Aresta> ciclo) {
        if (atual == null) {
            throw new ArgumentNullException(nameof(atual), "O vértice atual não pode ser nulo.");
        }

        foreach (Aresta a in grafo.ArestasIncidentes(atual)) {
            Vertice proximo = a.GetVerticeDestino();

            if (!a.Visitada()) {
                a.Visitar(); // Marca a aresta como visitada
                EncontrarCicloEuleriano(grafo, proximo, ciclo);
            }
        }

        // Adiciona as arestas incidentes ao vértice atual ao ciclo
        ciclo.AddRange(grafo.ArestasIncidentes(atual).Where(a => !a.Visitada()));
    }


    private void RemoverVerticesDuplicados(List<Aresta> ciclo) {
        // Cria um conjunto para manter o controle das arestas já visitadas
        HashSet<Aresta> visitadas = new HashSet<Aresta>();
        List<Aresta> cicloSemDuplicatas = new List<Aresta>();

        foreach (Aresta aresta in ciclo) {
            if (!visitadas.Contains(aresta)) {
                cicloSemDuplicatas.Add(aresta);
                visitadas.Add(aresta);
            }
        }

        // Atualiza a lista de ciclo para conter arestas sem duplicatas
        ciclo.Clear();
        ciclo.AddRange(cicloSemDuplicatas);
    }

}