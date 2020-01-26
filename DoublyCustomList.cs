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
            //var DoublyNodeValue = new DoublyNode<T>(value);
            base.Add(value);
            if (Head == null)
            {
                Head = (DoublyNode<T>)base.Head;
                
            }
            //else
            //{
            //    DoublyNodeValue.Previous = Tail;
            //}
            Tail = (DoublyNode<T>)base.Tail;

        }

        protected override Node<T> GetNodeType(T value)
        {
            DoublyNode<T> node = new DoublyNode<T>(value);
            return node;
        }

        protected override void GetTail(Node<T> NodeValue, Node<T> Tail)
        {
            base.GetTail(NodeValue, Tail);
            ((DoublyNode<T>)NodeValue).Previous = (DoublyNode<T>)Tail;
        }

        public override bool Delete(T value)
        {
            DoublyNode<T> current = Head;
            DoublyNode<T> currentHead = Head;
            DoublyNode<T> currentTail = Tail;


            while (current != null)
            {
                if (current.Element.Equals(value))
                {
                    break;
                }
                if (currentHead.Element.Equals(value))
                {
                    current = currentHead;
                }
                if (currentTail.Element.Equals(value))
                {
                    current = currentHead;
                }
                currentHead = (DoublyNode<T>)currentHead.Next;
                currentTail = (DoublyNode<T>)currentTail.Previous;

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
