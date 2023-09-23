﻿using System;
using System.Collections;


class Program {
    public static void Main(string[] args) {
        Avl pinheiro = new Avl(10);
        
        // teste push ok
        Node oito = pinheiro.Push(8);
        Node doze = pinheiro.Push(12);
        Node nove = pinheiro.Push(9);
        Node seis = pinheiro.Push(6);
        Node tres = pinheiro.Push(3);
        // Node quinze = pinheiro.Push(15);
        // Node dois = pinheiro.Push(2);

        // teste altura ok
        // Console.WriteLine("Altura");
        // Console.WriteLine(pinheiro.Height(pinheiro.Root())); // 2
        // Console.WriteLine(pinheiro.Height(oito)); // 1
        // Console.WriteLine(pinheiro.Height(sete)); // 0
        // Console.WriteLine(pinheiro.Height(doze)); // 0

        // // teste profundidade ok
        // Console.WriteLine();
        // Console.WriteLine("Profundidade");
        // Console.WriteLine(pinheiro.Depth(pinheiro.Root())); // 0
        // Console.WriteLine(pinheiro.Depth(oito)); // 1
        // Console.WriteLine(pinheiro.Depth(sete)); // 2
        // Console.WriteLine(pinheiro.Depth(doze)); // 1
        
        // // tamanho ok
        // Console.WriteLine();
        // Console.WriteLine($"Tamanho: {pinheiro.Length()}");

        // // teste remove ok
        // Console.WriteLine();
        // Console.WriteLine($"Removendo o {pinheiro.Remove(12)}");
        // Console.WriteLine($"Removendo o {pinheiro.Remove(8)}");
        // Console.WriteLine($"Tamanho: {pinheiro.Length()}");
        pinheiro.ShowTree();
        

        }
    }