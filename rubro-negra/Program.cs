using System;

class Program {
    public static void Main() {
        RubroNegra rn = new RubroNegra(10);

        rn.Insert(13);
        rn.Insert(11);
        rn.Remove(13);
        rn.ShowTree();
    }
}