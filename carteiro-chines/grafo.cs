using System;
using System.Collections;
using System.Collections.Generic;

public class Grafo {
    private List<Vertice> vertices;
    private List<Aresta> arestas;
    private int QntVertices = 0;
    private int QntArestas = 0;


    public Grafo() {
        vertices = new List<Vertice>();
        arestas = new List<Aresta>();
    }


    public int Grau(Vertice v) {
        int grau = 0;

        foreach (Aresta a in arestas) {
            if(a.GetVerticeOrigem().Equals(v) || a.GetVerticeDestino().Equals(v)) {
                grau++;
            }
        }

        return grau;
    }

    public string FinalVertices(Aresta a) {
        return $"Os vértices da aresta {a.GetAresta()} são:\n{a.GetVerticeOrigem()}\n{a.GetVerticeDestino()}"; 
    }


    public object Oposto(Vertice vertice, Aresta aresta) { //OK mas precisa identificar a milacria do print
        // retorna ou outro vértice
        Vertice oposto = null;
        foreach(Aresta a in arestas) {
            if (a.GetVerticeOrigem().Equals(vertice) && a.GetAresta().Equals(aresta.GetAresta())) {
                oposto = new Vertice(a.GetVerticeDestino());
                break;
            } else if (a.GetVerticeDestino().Equals(vertice) && a.GetAresta().Equals(aresta.GetAresta())) {
                oposto = new Vertice(a.GetVerticeOrigem());
                break;
            }
        }

        if (oposto != null) {
            return oposto.ToString();
        } else {
            throw new InvalidOperationException("Não há vértice oposto"); 
        }
    }


    public bool EAdjacente (Vertice v, Vertice w) { //OK
        // retorna true ou false se eles são vizinhos
        foreach(Aresta a in arestas) {
            if (a.GetVerticeOrigem().Equals(v) && a.GetVerticeDestino().Equals(w)
             || a.GetVerticeOrigem().Equals(w) && a.GetVerticeDestino().Equals(v)
            ) {
                return true;
            }
        }
        return false;
    }


    // SUBSTITUIR
    public void SubstituirVertice(Vertice v, object new_v) { //OK
        // Substitui um vértice por um novo 
        v.SetVertice(new_v);
    }


    public void SubstituirAresta(Aresta a, object new_a) { //OK
        // Substitui um aresta por um novo
        a.SetAresta(new_a);
    }


    // INSERÇÃO 
    public Vertice InserirVertice(object v) { //OK
        Vertice vertice = new Vertice(v);
        vertices.Add(vertice);
        this.QntVertices++;
        return vertice;
    } 


    public Aresta InserirAresta(Vertice v, Vertice w, object a, int p) { //OK
        // Insere e retorna uma nova aresta com os vertices v e w
        Aresta aresta = new Aresta(a, v, w, p);
        v.SetAresta(aresta);
        w.SetAresta(aresta);
        arestas.Add(aresta);
        this.QntArestas++;
        return aresta;
    }


    public object RemoverVertice(Vertice v) { // Finalmente resolvido
        // Remove e retorna o elemento do vértice
        vertices.Remove(v);

        List<Aresta> arestasARemover = new List<Aresta>();

        foreach (Aresta a in v.GetArestas()) {
            arestasARemover.Add(a);

            Vertice verticeOposto = (v == a.GetVerticeOrigem()) ? a.GetVerticeDestino() : a.GetVerticeOrigem();
            verticeOposto.RemoverAresta(a);
        }

        foreach (Aresta aRemover in arestasARemover) {
            arestas.Remove(aRemover);
        }

        return v.GetVertice();
    }




    public object RemoverAresta(Aresta a) { // OK
        if (a == null) {
            throw new ArgumentNullException("Aresta não pode ser nula.");
        }
        // remove a aresta e retorna o elemento
        arestas.Remove(a); 

        Vertice vOrigem = (Vertice)a.GetVerticeOrigem();
        Vertice vDestino = (Vertice)a.GetVerticeDestino();

        vOrigem.GetArestas().Remove(a);
        vDestino.GetArestas().Remove(a);

        

        return a.GetAresta(); 
    }



    public List<Aresta> ArestasIncidentes(Vertice v) { //OK
        // retorna um array com todas as arestas incidentes no vértice
        return v.GetArestas();
    }


    public List<Vertice> Vertices() { //OK 
        return vertices;
    }


    public List<Aresta> Arestas() { //OK
        return arestas;
    }


    // Fleury
    public List<Vertice> Fleury(List<Aresta> arestasAGM, Vertice verticeInicio) {
        // Etapa 1: Inicialização
        List<Vertice> cicloEuleriano = new List<Vertice>();
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

    // private Vertice EncontrarVerticeComGrauImpar(Grafo grafo) {
    //     foreach (Vertice v in grafo.Vertices()) {
    //         if (grafo.Grau(v) % 2 != 0) {
    //             return v;
    //         }
    //     }
    //     return null; // Isso não deveria acontecer em um grafo Euleriano
    // }

    private void EncontrarCicloEuleriano(Grafo grafo, Vertice atual, List<Vertice> ciclo) {
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

        // Adiciona o vértice atual ao ciclo
        ciclo.Add(atual);
    }

    private void RemoverVerticesDuplicados(List<Vertice> ciclo) {
        // Cria um conjunto para manter o controle dos vértices já visitados
        HashSet<Vertice> visitados = new HashSet<Vertice>();
        List<Vertice> cicloSemDuplicatas = new List<Vertice>();

        foreach (Vertice v in ciclo) {
            if (!visitados.Contains(v)) {
                cicloSemDuplicatas.Add(v);
                visitados.Add(v);
            }
        }

        // Atualiza a lista de ciclo para conter vértices sem duplicatas
        ciclo.Clear();
        ciclo.AddRange(cicloSemDuplicatas);
    }

}