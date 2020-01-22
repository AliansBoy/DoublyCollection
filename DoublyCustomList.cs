using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoblyCollection
{
    class DoublyCustomList<T> : CustomList<T>
    {
        DoublyNode<T> Head; //link on first element
        DoublyNode<T> Tail; //link on Last element
        public override void Add(T value)
        {
            DoublyNode<T> NodeValue = new DoublyNode<T>(value);
            base.Add(value);
            if (Head == null)
                NodeValue.Previous = Tail;
            Tail = NodeValue;

        }

        protected override void GetNodeType(ref Node<T> node, T value)
        {
            node = new DoublyNode<T>(value);
        }

        public override bool Delete(T value)
        {
            DoublyNode<T> current = Head;

            while (current != null)
            {
                if (current.Element.Equals(value))
                {
                    break;
                }
                current = (DoublyNode<T>)current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    ((DoublyNode<T>)current.Next).Previous = current.Previous;
                }
                else
                {
                    Tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    Head = (DoublyNode<T>)current.Next;
                }
                count--;
                return true;
            }
            return false;

        }

        public IEnumerable<T> BackEnumerator()
        {
            DoublyNode<T> current = Tail;
            while (current != null)
            {
                yield return current.Element;
                current = current.Previous;
            }
        }
    }
}
