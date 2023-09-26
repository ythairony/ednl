﻿using System;
using System.Collections;


class Program {
    public static void Main(string[] args) {
        Avl avl = new Avl(10);
        
        // teste coleguinha
        // Node cinco = avl.Push(5);
        // Node quinze = avl.Push(15);
        // Node dois = avl.Push(2);
        // Node oito = avl.Push(8);
        // Node vintedois = avl.Push(22);
        // Node vintecinco = avl.Push(25);

        // teste duplo direita
        Node oito = avl.Push(8);
        // Node nove = avl.Push(9);


        // // tamanho ok
        // Console.WriteLine();
        // Console.WriteLine($"Tamanho: {avl.Length()}");

        // // teste remove ok
        // Console.WriteLine();
        // Console.WriteLine($"Removendo o {avl.Remove(12)}");
        // Console.WriteLine($"Removendo o {avl.Remove(8)}");
        // Console.WriteLine($"Tamanho: {avl.Length()}");
        avl.ShowTree();
        

        }
    }