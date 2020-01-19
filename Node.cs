using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoblyCollection
{
    class Node<T>
    {
        public Node(T element)
        {
            Element = element;
        }
        public T Element { get; set; }
        public Node<T> Next { get; set; }
    }

    class DoublyNode<T>: Node<T>
    {
        public DoublyNode(T element): base(element)
        {
        }
        public DoublyNode<T> Previous { get; set; }
    }
}
