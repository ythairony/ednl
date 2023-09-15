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