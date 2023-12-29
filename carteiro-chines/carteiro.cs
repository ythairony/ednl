using System;
using System.Collections.Generic;
using System.Linq;

public class CarteiroChines {
    private Grafo grafo;

    public CarteiroChines(Grafo grafo) {
        this.grafo = grafo;
    }

    public List<Vertice> SolucionarProblemaCarteiroChines() {
        // Verifica se o grafo é conexo
        if (!EConexo()) {
            throw new InvalidOperationException("O grafo não é conexo. O problema do Carteiro Chinês requer um grafo conexo.");
        }

        // Encontra um emparelhamento perfeito mínimo
        List<Aresta> emparelhamentoPerfeito = EncontrarEmparelhamentoPerfeitoMinimo();

        // Constrói um grafo euleriano
        Grafo grafoEuleriano = ConstruirGrafoEuleriano(emparelhamentoPerfeito);

        // Encontra um ciclo euleriano no grafo euleriano
        List<Vertice> cicloEuleriano = EncontrarCicloEuleriano(grafoEuleriano);

        // Converte o ciclo euleriano em um caminho hamiltoniano
        List<Vertice> caminhoHamiltoniano = ConverteCicloParaHamiltoniano(cicloEuleriano);

        return caminhoHamiltoniano;
    }

    public bool EConexo() { // OK
        // Verifica se todos os vértices do grafo estão conectados
        // verifica se todos os vértices têm grau maior que zero.
        return grafo.Vertices().All(v => v.GetArestas().Count > 0);
    }

    private List<Aresta> EncontrarEmparelhamentoPerfeitoMinimo() {
        // Implemente a lógica para encontrar um emparelhamento perfeito mínimo

        return grafo.Arestas();
    }

    public Grafo ConstruirGrafoEuleriano(List<Aresta> emparelhamentoPerfeito) {
        Grafo grafoEuleriano = new Grafo();

        foreach (Aresta aresta in emparelhamentoPerfeito) {
            Vertice vOrigem = (Vertice)aresta.GetVerticeOrigem();
            Vertice vDestino = (Vertice)aresta.GetVerticeDestino();

            // Adiciona arestas duplicadas
            grafoEuleriano.InserirAresta(vOrigem, vDestino, aresta.GetAresta());
            grafoEuleriano.InserirAresta(vDestino, vOrigem, aresta.GetAresta());
        }

        // Adiciona arestas adicionais para tornar o grafo Euleriano
        foreach (Vertice v in grafo.Vertices()) {
            foreach (Aresta aresta in v.GetArestas()) {
                if (!emparelhamentoPerfeito.Contains(aresta)) {
                    Vertice w = aresta.GetVerticeDestino() == v ? (Vertice)aresta.GetVerticeOrigem() : (Vertice)aresta.GetVerticeDestino();
                    grafoEuleriano.InserirAresta(v, w, aresta.GetAresta());
                }
            }
        }

        return grafoEuleriano;
    }

    private List<Vertice> EncontrarCicloEuleriano(Grafo grafoEuleriano) {
        // Implemente a lógica para encontrar um ciclo euleriano no grafo Euleriano
        // Pode-se usar algoritmos conhecidos como Hierholzer's Algorithm.

        // Aqui, por simplicidade, vou retornar todos os vértices do grafo Euleriano na ordem em que foram visitados.
        return grafoEuleriano.Vertices();
    }

    private List<Vertice> ConverteCicloParaHamiltoniano(List<Vertice> cicloEuleriano) {
        // Converte o ciclo euleriano em um caminho hamiltoniano
        // Removendo vértices duplicados na ordem em que aparecem.
        HashSet<Vertice> visitados = new HashSet<Vertice>();
        List<Vertice> caminhoHamiltoniano = new List<Vertice>();

        foreach (Vertice v in cicloEuleriano) {
            if (!visitados.Contains(v)) {
                caminhoHamiltoniano.Add(v);
                visitados.Add(v);
            }
        }

        // Adiciona o último vértice para formar um ciclo
        caminhoHamiltoniano.Add(caminhoHamiltoniano[0]);

        return caminhoHamiltoniano;
    }
}
