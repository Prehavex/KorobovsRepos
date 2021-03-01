using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HW2
{
    public class OwnNode<Type>
    {
        public OwnNode(Type value)
        {
            Value = value;
        }
        public Type Value { get; set; }
        public OwnNode<Type> Previous { get; set; }
        public OwnNode<Type> Next { get; set; }
    }

    public class OwnList<Type> : IEnumerable<Type>, IEnumerator<Type>
    {

        OwnNode<Type> head;
        OwnNode<Type> tail;
        int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        OwnNode<Type> currentItem;

        Type IEnumerator<Type>.Current { get { return currentItem.Value; } }
        public object Current { get { return currentItem.Value; }}

        public void Add(Type data)
        {
            OwnNode<Type> node = new OwnNode<Type>(data);

            if (IsEmpty)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        public void Remove(Type data)
        {
            if (IsEmpty)
            {
                Console.WriteLine("List is empty");
                return;
            }
            else
            {
                currentItem = head;
                while (currentItem != null)
                {
                    if (currentItem.Value.Equals(data))
                    {
                        break;
                    }
                    currentItem = currentItem.Next;
                }
                if (currentItem != null)
                {
                    if (currentItem.Next != null)
                    {
                        currentItem.Next.Previous = currentItem.Previous;
                    }
                    else
                    {
                        tail = currentItem.Previous;
                    }
                    if (currentItem.Previous != null)
                    {
                        currentItem.Previous.Next = currentItem.Next;
                    }
                    else
                    {
                        head = currentItem.Next;
                    }
                    count--;
                    currentItem = null;
                }
            }
        }

        void IDisposable.Dispose()
        {
            currentItem = null;
        }

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            return this;
        }
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        bool IEnumerator.MoveNext()
        {
            if (IsEmpty)
            {
                return false;
            }
            else
            {
                if (currentItem == null)
                {
                    currentItem = head;
                    return true;
                }
                else if(currentItem.Next == null)
                {
                    return false;
                }
                else
                {
                    currentItem = currentItem.Next;
                    return true;
                }
            }
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
    }
}

   
