﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Stretch Goals: Using Generics, which would include implementing GetType() http://msdn.microsoft.com/en-us/library/system.object.gettype(v=vs.110).aspx
namespace SinglyLinkedLists
{
    public class SinglyLinkedListNode : IComparable
    {
        // Used by the visualizer.  Do not change.
        public static List<SinglyLinkedListNode> allNodes = new List<SinglyLinkedListNode>();

        // READ: http://msdn.microsoft.com/en-us/library/aa287786(v=vs.71).aspx
        private SinglyLinkedListNode next;
        public SinglyLinkedListNode Next
        {
            get { return next; }
            set
            {
                if (ReferenceEquals(value, this)) throw new ArgumentException();
                next = value;
            }
        }

        private string value;
        public string Value 
        {
            get { return value; }
            set { this.value = value; }
        }

        public override bool Equals(object obj)
        {
            SinglyLinkedListNode sent = obj as SinglyLinkedListNode;
            return sent == null ? false : sent.Value == value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator <(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) < 0;
        }

        public static bool operator >(SinglyLinkedListNode node1, SinglyLinkedListNode node2)
        {
            // This implementation is provided for your convenience.
            return node1.CompareTo(node2) > 0;
        }

        public SinglyLinkedListNode(string value)
        {
            Value = value;
            // Used by the visualizer:
            allNodes.Add(this);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        // READ: http://msdn.microsoft.com/en-us/library/system.icomparable.compareto.aspx
        public int CompareTo(Object obj)
        {
            SinglyLinkedListNode testNode = obj as SinglyLinkedListNode;
            return testNode == null ? 1 : value.CompareTo(testNode.Value);
        }

        public bool IsLast()
        {
            return next == null;
        }
    }
}
