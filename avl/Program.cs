﻿using System;
using System.Collections;


class Program {
    public static void Main(string[] args) {
        Avl avl = new Avl(10);
        
        // teste coleguinha
        avl.Insert(5);
        avl.Insert(15);
        avl.Insert(2);
        avl.Insert(8);
        avl.Insert(22);
        avl.Insert(25);
        
        // Teste de inserções dinâmicas
        // while (true) {
        //     Console.Write("Insira um valor [0 para parar]: ");
        //     int x = int.Parse(Console.ReadLine());
        //     avl.Insert(x);
        //     if (x == 0) break;
        //     avl.ShowTree();
        // }

        // // teste simples esqueda
        // avl.Insert(14);
        // avl.Insert(20);

        // teste simples direita
        // avl.Insert(6);
        // avl.Insert(4);

        // teste duplo direita
        // Node oito = avl.Insert(8);
        // Node nove = avl.Insert(9);

        // teste duplo a esquerda
        // avl.Insert(16);
        // avl.Insert(11);


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