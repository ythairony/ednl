﻿using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        Avl pinheiro = new Avl(10);
        
        // INSERÇÕES
        Node seis = pinheiro.Push(6);
        Node dois = pinheiro.Push(2);
        Node quatorze = pinheiro.Push(14);
        Node dezenove = pinheiro.Push(19);
        Node oito = pinheiro.Push(8);
        Node tres = pinheiro.Push(3);
        Node dezessete = pinheiro.Push(17);
        Node vinte_um = pinheiro.Push(21);
        // Node um = pinheiro.Push(1);
        Node quadro = pinheiro.Push(4);
        Node vinto = pinheiro.Push(20);
        Node dezoito = pinheiro.Push(18);
        Node sete = pinheiro.Push(7);
        
        // TESTE REMOVE
        // Console.WriteLine($"Removido o elemento -> {pinheiro.Remove(2)}");
        // pinheiro.NewRemove(19);
 
        // TESTE ELEMENTS()
        // Console.WriteLine();
        // Console.WriteLine("PRINT ELEMENTOS");
        // IEnumerator elementos = pinheiro.Elements();
        // int i = 1;
        // while (elementos.MoveNext()) {
        //     Console.WriteLine($"{i}º elemento da árvore -> {elementos.Current}");
        //     i++;
        // }


        // TESTE MOSTRAR
        pinheiro.ShowTree();
        }
    }