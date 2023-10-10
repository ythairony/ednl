using System;

class Program {
    public static void Main() {
        RubroNegra rn = new RubroNegra(10);

        Node no1 = rn.Insert(13);
        Node no3 = rn.Insert(15);
        // Node no2 = rn.Insert(5);
        // Node no4 = rn.Insert(2);
        rn.ShowTree();
    }
}