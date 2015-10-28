using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            throw new NotImplementedException();
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            throw new NotImplementedException();
        }

        public void AddFirst(string value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (firstNode == null)
            {
                firstNode = newNode;
            }
            else
            {
                SinglyLinkedListNode currentNode = LastNode();
                currentNode.Next = newNode;
            }
        }

        private SinglyLinkedListNode LastNode()
        {
            SinglyLinkedListNode currentNode = firstNode;
            while (!currentNode.IsLast())
            {
                currentNode = currentNode.Next;
            }
            return currentNode;
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            SinglyLinkedListNode currentNode = firstNode;
            for (int i = 0; i <= index; i++)
            {
                if (currentNode == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (i == index)
                {
                    return currentNode.Value.ToString();
                }
                currentNode = currentNode.Next;
            }
            throw new ArgumentOutOfRangeException();
        }

        private SinglyLinkedListNode firstNode;
        public string First()
        {
            return firstNode == null ? null : firstNode.Value;
        }

        public int IndexOf(string value)
        {
            throw new NotImplementedException();
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            if (firstNode == null)
            {
                return null;
            }
            else
            {
                SinglyLinkedListNode currentNode = LastNode();
                return currentNode.Value.ToString();
            }
        }

        public void Remove(string value)
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string builtString = " ";
            if (firstNode != null)
            {
                SinglyLinkedListNode testNode = firstNode;
                while (!testNode.IsLast())
                {
                    builtString += "\"" + testNode.Value.ToString() + "\", ";
                    testNode = testNode.Next;
                }
                builtString += "\"" + testNode.Value.ToString() + "\" ";
            }
            return "{" + builtString + "}";
        }

        public string[] ToArray()
        {
            List<string> strung = new List<string> { };
            if (firstNode != null)
            {
                SinglyLinkedListNode testNode = firstNode;
                while (!testNode.IsLast())
                {
                    strung.Add(testNode.Value.ToString());
                    testNode = testNode.Next;
                }
                strung.Add(testNode.Value.ToString());
            }
            return strung.ToArray();
        }
    }
}
