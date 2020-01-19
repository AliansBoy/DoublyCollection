﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoblyCollection
{
    class CustomList<T> : IEnumerable<T>, ICustomList<T>
    {
        Node<T> Head; //link on first element
        Node<T> Tail; //link on Last element
        int count;
        public T this[int index]
        {
            get
            {
                Node<T> temp = Head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }
                return temp.Element;
            }
        }

        public virtual void Add(T value)
        {
            Node<T> NodeValue = new Node<T>(value);

            if (Head == null)
            {
                Head = NodeValue;
            }
            else
            {
                Tail.Next = NodeValue;
            }
            Tail = NodeValue;
            count++;
        }

        public virtual bool Delete(T data)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Element.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }
    }
}
