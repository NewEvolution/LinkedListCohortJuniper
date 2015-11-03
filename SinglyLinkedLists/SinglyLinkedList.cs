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
            foreach (object nodeValue in values) AddLast(nodeValue as string);
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            // Only because nodes can only contain a single string, more complex nodes would require replacement.
            set { NodeAt(i).Value = value; }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode testNode = firstNode;
            while (true)
            {
                if (testNode == null) throw new ArgumentException("The specified value was not found in the list.");
                else if (testNode.Value == existingValue)
                {
                    SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                    newNode.Next = testNode.Next;
                    testNode.Next = newNode;
                    break;
                }
                testNode = testNode.Next;
            }
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            newNode.Next = firstNode;
            firstNode = newNode;
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (firstNode == null) firstNode = newNode;
            else LastNode().Next = newNode;
        }

        private SinglyLinkedListNode LastNode()
        {
            SinglyLinkedListNode currentNode = firstNode;
            while (!currentNode.IsLast()) currentNode = currentNode.Next;
            return currentNode;
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            int count = 0;
            SinglyLinkedListNode currentNode = firstNode;
            if (currentNode == null) return count;
            else
            {
                while (currentNode != null)
                {
                    currentNode = currentNode.Next;
                    count++;
                }
            }
            return count;
        }

        public string ElementAt(int index)
        {
            if (index < 0)
            {
                index = index + Count();
                if (index < 0) throw new ArgumentOutOfRangeException();
            }
            return NodeAt(index).ToString();
        }

        private SinglyLinkedListNode NodeAt(int index)
        {
            if (index + 1 > Count()) throw new ArgumentOutOfRangeException();
            SinglyLinkedListNode currentNode = firstNode;
            for (int i = 0; i <= index; i++)
            {
                if (i == index) return currentNode;
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
            int position = -1;
            if (firstNode != null)
            {
                position++;
                SinglyLinkedListNode testNode = firstNode;
                while (position < Count())
                {
                    if (testNode.Value == value) return position;
                    testNode = testNode.Next;
                    position++;
                }
                position = -1;
            }
            return position;
        }

        public bool IsSorted()
        {
            bool sorted = true;
            if (firstNode == null || firstNode.Next == null) { }
            else
            {
                SinglyLinkedListNode testNode = firstNode;
                while (!testNode.IsLast())
                {
                    if (testNode > testNode.Next) sorted = false;
                    testNode = testNode.Next;
                }
            }
            return sorted;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            return firstNode == null ? null : LastNode().ToString();
        }

        public void Remove(string value)
        {
            int toRemoveIndex = IndexOf(value);
            if (toRemoveIndex >= 0)
            {
                SinglyLinkedListNode toRemove = NodeAt(toRemoveIndex);
                if (toRemoveIndex == 0) firstNode = toRemove.Next;
                else
                {
                    SinglyLinkedListNode previousNode = NodeAt(toRemoveIndex - 1);
                    previousNode.Next = toRemove.Next;
                }
            }
        }

        public void Sort()
        {
            if (firstNode != null)
            {
                SinglyLinkedListNode testNode = firstNode;
                while (!IsSorted())
                {
                    if (testNode.CompareTo(testNode.Next) > 0)
                    {
                        string testValue = testNode.ToString();
                        testNode.Value = testNode.Next.Value;
                        testNode.Next.Value = testValue;
                        testNode = testNode.Next;
                    }
                    else testNode = testNode.Next;
                    if (testNode.IsLast()) testNode = firstNode;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder builtString = new StringBuilder("{ ");
            if (firstNode != null)
            {
                SinglyLinkedListNode testNode = firstNode;
                while (!testNode.IsLast())
                {
                    builtString.Append("\"").Append(testNode.ToString()).Append("\", ");
                    testNode = testNode.Next;
                }
                builtString.Append("\"").Append(testNode.ToString()).Append("\" ");
            }
            builtString.Append("}");
            return builtString.ToString();
        }

        public string[] ToArray()
        {
            string builtString = ToString();
            string[] delimiters = new string[] { "{ \"", "\", \"", "\" }", "{ }" };
            return builtString.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
