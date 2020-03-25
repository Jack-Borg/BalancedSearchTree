using System;

namespace BalamcedSearchTree
{
    public class RedBlack
    {
        public Node Root;

        public void Insert(int value)
        {
            Root = Insert(Root, value);
            Root.Color = Color.Black;
        }
        
        private Node Insert(Node newNode, int val)
        {
            if(newNode == null)
                return new Node(val);

            if (val < newNode.Value)
                newNode.Left = Insert(newNode.Left, val);
            else if (val >= newNode.Value)
                newNode.Right = Insert(newNode.Right, val);

            if(Node.IsRed(newNode) && !Node.IsRed(newNode.Left)) 
                newNode = Node.RotateLeft(newNode);
            
            if(Node.IsRed(newNode.Left) && Node.IsRed(newNode.Left.Left))
                newNode = Node.RotateRight(newNode);
            
            if(Node.IsRed(newNode.Left) && Node.IsRed(newNode.Right)) 
                Node.SwitchColors(newNode);
            
            //val.NodesInSubtree = Size(val.Left) + Size(val.Right) + 1;
            return newNode;
        }

        public void Print()
        {
            Print(Root);
        }

        private void Print(Node n)
        {
            if (n != null)
            {
                Print(n.Left);
                Console.WriteLine(n.Value);
                Print(n.Right);
            }
        }
        
        public enum Color
        {
            Red,
            Black
        }

        public class Node
        {
            public int Value;
            public Node Left;
            public Node Right;
            public Color Color;

            public Node(int value, Color color = Color.Red)
            {
                Value = value;
                Color = color;
            }
            
            public static bool IsRed(Node n)
            {
                if (n == null)
                    return false;
                
                return n.Color == Color.Red;
            }

            public static Node RotateLeft(Node parent)
            {
                Node newNode = parent.Right;
                parent.Right = newNode.Left;
                newNode.Left = parent;
                newNode.Color = parent.Color;
                parent.Color = Color.Red;
                //newNode.NodesInSubtree = Parent.NodesInSubtree;
                //Parent.NodesInSubtree = 1 + Size(Parent.Left) + Size(Parent.Right);
                return newNode;
            }

            public static Node RotateRight(Node parent)
            {
                Node newNode = parent.Left;
                parent.Left = newNode.Right;
                newNode.Right = parent;
                newNode.Color = parent.Color;
                parent.Color = Color.Red;
                //newNode.NodesInSubtree = Parent.NodesInSubtree;
                //Parent.NodesInSubtree = 1 + Size(Parent.Left) + Size(Parent.Right);
                return newNode;
            }

            public static void SwitchColors(Node parent)
            {
                parent.Color = Color.Red;
                parent.Left.Color = Color.Black;
                parent.Right.Color = Color.Black;
            }
        }
    }
}