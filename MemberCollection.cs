using System;
namespace ToolLibrarySystem
{
    //Hash table incorporation using chaining via Linked List

    public class MemberCollection
    {

        int hashTableSize;
        private LinkedList[] hashTable; // Declaration of Array of Linked list Nodes
        private LinkedList chain = new LinkedList();

        public MemberCollection()
        {
            hashTableSize = 10; //remains constant. Chaining adds to each index.
            hashTable = new LinkedList[hashTableSize]; //instance of Linked List Node array.

            for (int i = 0; i < hashTableSize; i++)
            {
                hashTable[i] = new LinkedList(); //Creates the linked list for the Hashtable index/chain.
            }
        }
        public int HashCode(int key)
        {
            return key % hashTableSize; //modulo operation
        }

        public void HashInsert(int element)
        {
            int i = HashCode(element);
            hashTable[i].SortedInsert(element);
        }
        //public void HashDelete(int element)
        //{
        //    int i = HashCode(element);
        //    Console.WriteLine(element);
        //}

        public bool TableCheck(int key)
        {
            int i = HashCode(key);
            return hashTable[i].Search(key) != -1; //this returns bool to user interface call
        }

        public void TableSearch(int key, string firstName, string lastName)
        {
            int i = HashCode(key);
            hashTable[i].DisplaySearchMember(firstName, lastName);
        }

        //DisplaySingle Member here
        //once searchtable returns true in the interface, call this method with the index

        public void DisplayMembers(string firstName, string lastName)
        {
            for (int i = 0; i < hashTableSize; i++)
            {
                Console.Write("Index: {0} ", i); //object properties display here
                hashTable[i].DisplayMembers(firstName, lastName);
            }
        }
        static void Main()
        {

            //MemberCollection Members = new MemberCollection();
            //Members.HashInsert(54);
            //Members.HashInsert(68);
            //Members.HashInsert(78);
            //Members.HashInsert(92);
            //Members.DisplayMembers();

            UserInterface menu = new UserInterface();
            menu.GetMainMenu();



        }

        /* Console.WriteLine("Five random integers between 0 and 100:");
         for (int ctr = 0; ctr <= 4; ctr++)
         Console.Write("{0,8:N0}", rand.Next(101));
         Console.WriteLine(); */
        //searching for a Hash value will return the member object with information about said member.

    }
    public class Node
    {

        public int element;
        public Node next;
        public Node(int e, Node n)
        {
            element = e;
            next = n;
        }
    }

    public class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public LinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public bool CheckEmpty()
        {
            return size == 0;
        }

        public void AddLast(int e)
        {
            Node newest = new Node(e, null);
            if (CheckEmpty())
                head = newest;
            else
                tail.next = newest;
            tail = newest;
            size++;
        }

        public void AddFirst(int e)
        {
            Node newest = new Node(e, null);

            if (CheckEmpty())
            {
                head = newest;
                tail = newest;
            }
            else
            {
                newest.next = head;
                head = newest;
            }
            size++;
        }

        //Add to the Chain
        public void Add(int e, int position)
        {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid Position");
                return;
            }
            Node newest = new Node(e, null);
            Node p = head;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i++;
            }
            newest.next = p.next;
            p.next = newest;
            size++;
        }

        //Insert element after sorting
        public void SortedInsert(int e)
        {
            Node newest = new Node(e, null);
            if (CheckEmpty())
                head = newest;
            else
            {
                Node p = head;
                Node q = head;
                while (p != null && p.element < e)
                {
                    q = p;
                    p = p.next;
                }
                if (p == head)
                {
                    newest.next = head;
                    head = newest;
                }
                else
                {
                    newest.next = q.next;
                    q.next = newest;
                }
            }
            size++;
        }

        public int RemoveFirst()
        {
            if (CheckEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            else
            {
                int e = head.element;
                head = head.next;
                size = size - 1;
                if (CheckEmpty())
                    tail = null;
                return e;
            }
        }

        public int RemoveLast()
        {
            if (CheckEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            Node p = head;
            int i = 1;
            while (i < size - 1)
            {
                p = p.next;
                i = i + 1;
            }
            tail = p;
            p = p.next;
            int e = p.element;
            tail.next = null;
            size = size - 1;
            return e;
        }

        //Display Members in the chains of S LList
        public void DisplayMembers(string firstName, string lastName)
        {
            Node p = head;
            while (p != null)
            {
                Console.Write("#"); //Hash represents the beginning of a new chain. For visual clarity.
                Console.Write(" Phone: " + p.element);
                Console.Write(" First Name: " + firstName + " |");
                Console.Write(" Last Name: " + lastName + " |");
                p = p.next;
            }
            Console.WriteLine();
        }

        public void DisplaySearchMember(string firstName, string lastName)
        {
            Node p = head;
            while (p != null)
            {
                Console.WriteLine("All Results and similar for Phone: {0} are listed below.\n", p.element);
                Console.WriteLine("First Name: " + firstName);
                Console.WriteLine("Last Name: " + lastName);
                p = p.next;
            }
            Console.WriteLine();
        }

        //Remove a Hash Element from the chain in the middle
        public int RemoveMember(int position)
        {
            if (position <= 0 || position >= size - 1)
            {
                Console.WriteLine("Invalid Position");
                return -1;
            }
            Node p = head;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i++;
            }
            int e = p.next.element;
            p.next = p.next.next;
            size++;
            return e;
        }

        //Search via int - Phone number.
        public int Search(int key)
        {
            Node p = head;
            int index = 0;

            while (p != null && index < 5)
            {
                if(p.element == key) //use index
                {
                    return index;
                }
                else
                    p = p.next;
                    index++;
            }
            return -1;
        }
        //return the S LList length:

        public int ListLength()
        {
            return size;
        }

    }
}





