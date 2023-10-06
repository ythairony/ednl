using System.Collections;

public class RubroNegra {
    private Node root;
    private int length = 0;
    private ArrayList showTree;


    // Construtor
    public RubroNegra(object key) {
        this.root = new Node(null, key);
        this.length++;
        this.color = "black";
    }


    //Métodos básicos de verificação
    public int Length() {
        return length;
    }


    public bool IsEmpty() {
        return root == null;   
    }


    public Node Root() {
        return root;
    }


    public bool IsRoot(Node node) {
        return root == node;
    }


    public static bool IsInternal(Node node) {
        return node.GetLeftChild() != null || node.GetRightChild() != null;
    }


    public static bool IsExternal(Node node) {
        return node.GetLeftChild() == null && node.GetRightChild() == null;
    }


    public static bool IsLeftChild(Node node) {
        return node == node.GetDad().GetLeftChild();
    }


    public static bool IsRightChild(Node node) {
        return node == node.GetDad().GetRightChild();
    }


    //Métodos de comparação
    private static bool IsLeft(Node node) {
        return node.GetLeftChild() == null;
    }
    

    private static bool IsRight(Node node) {
        return node.GetRightChild() == null;
    }


    //Método de pesquisa
    private Node SearchInt(Node node, object key) {
        if ((int)key < (int)node.Getkey()) {
            if (IsLeft(node)) {
                return node;
            } else {
                return SearchInt(node.GetLeftChild(), key);
            }
        } else if((int)key > (int)node.Getkey()) {
            if (IsRight(node)) {
                return node;
            } else {
                return SearchInt(node.GetRightChild(), key);
            }
        } else {
            return node;
        }
    }


    //Método de inserção
    public Node Insert(object key) {
        Node dad = SearchInt(root, key);
        Node newNode = new Node(dad, key);

        if((int)key < (int)dad.Getkey()) {
            dad.SetLeftChild(newNode);
        } else {
            dad.SetRightChild(newNode);
        }

        this.length++;
        return newNode;
    }


    //Método de remoção
    public object Remove(object key) {
        Node node = SearchInt(root, key);

        if (IsExternal(node)) {                                     // removendo o no da árvore
            if (node.GetDad().GetLeftChild().Equals(node)) {
                node.GetDad().SetLeftChild(null);
            } else if (node.GetDad().GetRightChild().Equals(node)) {
                node.GetDad().SetRightChild(null);
            }
        } else if (node.GetLeftChild() != null && node.GetRightChild() == null) {
            node.GetDad().SetLeftChild(node.GetLeftChild());        // subindo o filho esquerdo do nó pro lugar dele
            node.GetLeftChild().SetDad(node.GetDad());              // settando o pai do nó que subiu
        } else if (node.GetRightChild() != null && node.GetLeftChild() == null) {
            node.GetDad().SetRightChild(node.GetRightChild());
            node.GetRightChild().SetDad(node.GetDad());
        } else if (node.GetLeftChild() != null && node.GetRightChild() != null) {
            Node nextNode = NextNode(node);
            nextNode.SetDad(node.GetDad());
            nextNode.SetLeftChild(node.GetLeftChild());
            node.GetLeftChild().SetDad(nextNode);
            if (IsRightChild(node)) {
                node.GetDad().SetRightChild(nextNode);
            } else {
                node.GetDad().SetLeftChild(nextNode);
            }
        }

        this.length--;
        return key;
    }


    //Método mostrar árvore 
    public void ShowTree() {
        object[,] matriz = new object[Height(root)+1, length];
        showTree = new ArrayList();
        ShowTreeConstruction(root);

        for (int i = 0; i < length; i++) {
            object obj = ((Node)showTree[i]).Getkey();
            matriz[Depth((Node)showTree[i]), i] = obj;
        }

        for (int i = 0; i < Height(root)+1; i++) {
            for (int j = 0; j < length; j++) {
                if (matriz[i, j] == null) {
                    Console.Write(" ");
                } else {
                    Console.Write(matriz[i,j]);
                }

                if (j == length - 1) {
                    Console.WriteLine();
                }
            }
        }
    }


    private void ShowTreeConstruction(Node node) { // Ordena da esquerda pra direita
        if(IsInternal(node)) {
            if(node.GetLeftChild() != null) {
                ShowTreeConstruction(node.GetLeftChild());
            }
        }
        showTree.Add(node);
        if(IsInternal(node)) {
            if(node.GetRightChild() != null) {
                ShowTreeConstruction(node.GetRightChild());
            }
        }
    }


    // Métodos de ordenação Sucessão, EmOrdem, PréOrdem e PosOrdem
    private static Node NextNode(Node node) {
        Node nextNode = node.GetRightChild();

        while(nextNode.GetLeftChild() != null) {
            nextNode = nextNode.GetLeftChild();
        }

        return nextNode;
    }


    private void InOrder(Node node) {
        if(IsInternal(node)) {
            if(!IsLeft(node)) {
                InOrder(node.GetLeftChild());
            }
        } 

        showTree.Add(node.Getkey());

        if(IsInternal(node)) {
            if(!IsRight(node)) {
                InOrder(node.GetRightChild());
            }
        }
    }


    private void PreOrder(Node node) {
        showTree.Add(node.Getkey());

        if(IsInternal(node)) {
            if(!IsLeft(node)) {
                InOrder(node.GetLeftChild());
            }
        } 

        if(IsInternal(node)) {
            if(!IsRight(node)) {
                InOrder(node.GetRightChild());
            }
        }
    }


    private void PosOrder(Node node) {
        if(IsInternal(node)) {
            if(!IsLeft(node)) {
                InOrder(node.GetLeftChild());
            }
        } 

        if(IsInternal(node)) {
            if(!IsRight(node)) {
                InOrder(node.GetRightChild());
            }
        }

        showTree.Add(node.Getkey());
    }


    public IEnumerator Nodes() {
        showTree = new ArrayList();
        PreOrder(root);
        return showTree.GetEnumerator();
    }


    public IEnumerator keyents() {
        showTree = new ArrayList();
        InOrder(root);
        return showTree.GetEnumerator();
    }


    //Métodos de altura e profundidade
    public int Height(Node node) {
        if (IsExternal(node)) {
            return 0;
        } else {
            int height = 0;
            int childHeight;
            if (node.GetLeftChild() != null) {
                childHeight = Height(node.GetLeftChild());
                height = Math.Max(height, childHeight);
            } 
            
            if(node.GetRightChild() != null) {
                childHeight = Height(node.GetRightChild());
                height = Math.Max(height, childHeight);
            }

            return height + 1;
        }
    }


    public int Depth(Node node) {
        int depth = this.Deep(node);
        return depth;
    }


    private int Deep(Node node) {
        if (node == root) {
            return 0;
        } else {
            return (1 + this.Deep(node.GetDad()));
        }
    }

 }

 public class Node {
    private Node dad;
    private Node leftChild = null;
    private Node rightChild = null;
    private object key;
    private string color = "red";


    public Node(Node dad, object key) {
        this.dad = dad;
        this.key = key;
    }


    public object Getkey() {
        return key;
    }


    public Node GetDad(){
        return dad;
    }


    public Node GetLeftChild() {
        return leftChild;
    } 


    public Node GetRightChild() {
        return rightChild;
    }


    public void Setkey(object key) {
        this.key = key;
    } 


    public void SetDad(Node dad) {
        this.dad = dad;
    }


    public void SetLeftChild(Node lc) {
        this.leftChild = lc;
    }


    public void SetRightChild(Node rc) {
        this.rightChild = rc;
    }

}
