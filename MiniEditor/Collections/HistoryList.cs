using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniEditor.Collections
{
        public class HistoryList<T>
        {
            private class Node
            {
                public T Value { get; }
                public Node? Prev { get; set; }
                public Node? Next { get; set; }
                public Node(T value)
                {
                    Value = value;
                    Prev = null;
                    Next = null;
                }
            }

            private Node? head;     
            private Node? tail;      
            private Node? current;   
            private int capacity;

            public int Count { get; private set; }
            public int Capacity
            {
                get => capacity;
                set
                {
                    if (value < 1) throw new ArgumentOutOfRangeException(nameof(value));
                    capacity = value;
                    EnsureCapacity();
                }
            }

            public HistoryList(int capacity = 100)
            {
                if (capacity < 1) throw new ArgumentOutOfRangeException(nameof(capacity));
                this.capacity = capacity;
                Count = 0;
                head = tail = current = null;
            }

            
            public bool CanUndo => current != null && current.Prev != null;

           
            public bool CanRedo => current != null && current.Next != null;

            
            public void Push(T value)
            {
                var node = new Node(value);

                if (current == null)
                {
                    
                    head = tail = current = node;
                    Count = 1;
                    EnsureCapacity();
                    return;
                }

                if (current.Next != null)
                {
                    var toRemove = current.Next;
                    current.Next = null;
                    tail = current;
             
                    RecountFromHead();
                }

                node.Prev = current;
                current.Next = node;
                tail = node;
                current = node;
                Count++;
                EnsureCapacity();
            }

            public T UndoOrDefault(T defaultValue)
            {
                if (!CanUndo || current == null || current.Prev == null) return defaultValue;
                current = current.Prev;
                return current.Value;
            }
            public T RedoOrDefault(T defaultValue)
            {
                if (!CanRedo || current == null || current.Next == null) return defaultValue;
                current = current.Next;
                return current.Value;
            }
            public T CurrentOrDefault(T defaultValue)
            {
                return current != null ? current.Value : defaultValue;
            }

            private void EnsureCapacity()
            {
                while (Count > Capacity)
                {
                    if (head == null) break;
                    head = head.Next;
                    if (head != null) head.Prev = null;
                    Count--;
                }
                if (head == null)
                {
                    tail = current = null;
                    Count = 0;
                }
                if (current != null && head != null)
                {

                }
            }
            private void RecountFromHead()
            {
                int c = 0;
                Node? n = head;
                Node? last = null;
                while (n != null)
                {
                    c++;
                    last = n;
                    n = n.Next;
                }
                Count = c;
                tail = last ?? tail;

                if (current != null)
                {
                    bool found = false;
                    n = head;
                    while (n != null)
                    {
                        if (Object.ReferenceEquals(n, current)) { found = true; break; }
                        n = n.Next;
                    }
                    if (!found)
                    {
                        if (tail != null)
                        {
                            current = tail;
                        }
                        else
                        {
                            current = null;
                        }
                    }
                }
            }
        }
    }

