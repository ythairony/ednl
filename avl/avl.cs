using System.Collections;

public class Avl {
    private Node root;
    private int length = 0;
    private ArrayList showTree;


    // Construtor
    public Avl(object elem) {
        this.root = new Node(null, elem);
        this.length++;
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


    //Métodos de comparação
    private static bool IsLeft(Node node) {
        return node.GetLeftChild() == null;
    }
    

    private static bool IsRight(Node node) {
        return node.GetRightChild() == null;
    }


    //Método de pesquisa
    private Node SearchInt(Node node, object elem) {
        if ((int)elem < (int)node.GetElem()) {
            if (IsLeft(node)) {
                return node;
            } else {
                return SearchInt(node.GetLeftChild(), elem);
            }
        } else if((int)elem > (int)node.GetElem()) {
            if (IsRight(node)) {
                return node;
            } else {
                return SearchInt(node.GetRightChild(), elem);
            }
        } else {
            return node;
        }
    }

    //Método de inserção
    public Node Push(object elem) {
        Node dad = SearchInt(root, elem);
        Node newNode = new Node(dad, elem);

        if((int)elem < (int)dad.GetElem()) {
            dad.SetLeftChild(newNode);
        } else {
            dad.SetRightChild(newNode);
        }

        length++;
        return newNode;
    }


    //Método de remoção


    // Métodos de ordenação Sucessão, EmOrdem, PréOrdem e PosOrdem
    private static Node Sucessor(Node node) {
        Node sucessor = node.GetRightChild();
        while(sucessor.GetLeftChild() != null) {
            sucessor = sucessor.GetLeftChild();
        }

        return sucessor;
    }


    private void InOrder(Node node) {
        if(IsInternal(node)) {
            if(!IsLeft(node)) {
                InOrder(node.GetLeftChild());
            }
        } 

        showTree.Add(node.GetElem());

        if(IsInternal(node)) {
            if(!IsRight(node)) {
                InOrder(node.GetRightChild());
            }
        }
    }


    private void PreOrder(Node node) {
        showTree.Add(node.GetElem());

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

        showTree.Add(node.GetElem());
    }


    public IEnumerator Nodes() {
        showTree = new ArrayList();
        PreOrder(root);
        return showTree.GetEnumerator();
    }


    public IEnumerator Elements() {
        showTree = new ArrayList();
        InOrder(root);
        return showTree.GetEnumerator();
    }


    //Métodos de altura e profundidade


 }



public class Node {
    private Node dad;
    private Node leftChild = null;
    private Node rightChild = null;
    private object elem;


    public Node(Node dad, object elem) {
        this.dad = dad;
        this.elem = elem;
    }


    public object GetElem() {
        return elem;
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


    public void SetElem(object elem) {
        this.elem = elem;
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