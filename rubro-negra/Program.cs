using System;

class Program {
    public static void Main() {
        RubroNegra rn = new RubroNegra(10);

        // Node no1 = rn.Insert(13);
        // Node no2 = rn.Insert(5);
        // Node no3 = rn.Insert(15);
        // Node no3 = rn.Insert(11);
        // Node no4 = rn.Insert(2);
        // Node no4 = rn.Insert(8);
        

        // Testes dinâmicos
        Console.WriteLine($"O raiz é {rn.Root().GetKey()}");
        int n;
        while (true) { 
            Console.Write("Insira um valor: ");
            n = int.Parse(Console.ReadLine());
            if (n == 0) { break; }
            rn.Insert(n);
            rn.ShowTree();
            Console.WriteLine();
        }

        rn.ShowTree();
    }
}