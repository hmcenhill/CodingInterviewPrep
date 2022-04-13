using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPrep.Trees
{
    public class BinarySearchTree<T> where T : IComparable
    {
        public BinarySearchTree()
        {
            this.Root = null;
        }

        public Node<T> Root;

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
            }
            else
            {
                Root.AddChild(value);
            }
        }

        public Node<T> Lookup(T value) => Root?.Lookup(value);

        public bool Contains(T value) => Lookup(value) != null;

        public bool Remove(T value)
        {
            Node<T> parent = null;
            var current = Root;
            while (current != null)
            {
                var compare = value.CompareTo(current.Value);
                if (compare < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (compare > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else // ==0 MATCH
                {
                    if (current.Right == null)
                    {
                        if (parent == null)
                        {
                            Root = current.Left;
                        }
                        else
                        {
                            if (current.Value.CompareTo(parent.Value) < 0)
                            {
                                parent.Left = current.Left;
                            }
                            else
                            {
                                parent.Right = current.Left;
                            }
                        }
                    }
                    else if (current.Right.Left == null)
                    {
                        if (parent == null)
                        {
                            Root = current.Left;
                        }
                        else
                        {
                            current.Right.Left = current.Left;
                            if (current.Value.CompareTo(parent.Value) < 0)
                            {
                                parent.Left = current.Left;
                            }
                            else
                            {
                                parent.Right = current.Left;
                            }
                        }
                    }
                    else
                    {
                        var leftMost = current.Right.Left;
                        var leftMostParent = current.Right;
                        while (leftMost.Left != null)
                        {
                            leftMostParent = leftMost;
                            leftMost = leftMost.Left;
                        }

                        leftMostParent.Left = leftMost.Right;
                        leftMost.Left = current.Left;
                        leftMost.Right = current.Right;

                        if (parent == null)
                        {
                            Root = leftMost;
                        }
                        else
                        {
                            if (current.Value.CompareTo(parent.Value) < 0)
                            {
                                parent.Left = leftMost;
                            }
                            else
                            {
                                parent.Right = leftMost;
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public void Print()
        {
            Console.Write($"\nContent: [");
            Root.Print();
            Console.Write("]\n");
        }
    }

    public class Node<T> where T : IComparable
    {
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public T Value;
        public Node<T> Left;
        public Node<T> Right;

        public void AddChild(T value)
        {
            var check = value.CompareTo(Value);

            if (check < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(value);
                }
                else
                {
                    Left.AddChild(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(value);
                }
                else
                {
                    Right.AddChild(value);
                }
            }

        }

        public Node<T> Lookup(T value)
        {
            var compare = value.CompareTo(Value);
            if (compare < 0)
            {
                return Left?.Lookup(value);
            }
            else if (compare == 0)
            {
                return this;
            }
            else
            {
                return Right?.Lookup(value);
            }
        }

        public void Remove(T value) { }

        public void Print()
        {
            Left?.Print();
            Console.Write($"{this.Value}, ");
            Right?.Print();
        }
    }
}
