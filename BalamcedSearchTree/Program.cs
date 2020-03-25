using System;
using System.Linq;

namespace BalamcedSearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            RedBlack tree = new RedBlack();
            
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            
            tree.Print();
        }
    }
}