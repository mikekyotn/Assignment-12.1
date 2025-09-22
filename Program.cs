namespace Assignment_12._1
{
    //Assignment 1: Complete.
    //Assignment 2: Complete.
    internal class Program
    {
        static void Main(string[] args)
        {
            bool test1 = CanCreateNote("d", "c");
            bool test2 = CanCreateNote("aa", "ab");
            bool test3 = CanCreateNote("aab", "ab");

            Console.WriteLine("magazine: d, note: c > " + test1);
            Console.WriteLine("magazine: aa, note ab > " + test2);
            Console.WriteLine("magazine: aab, note ab > " + test3);

            Node head = new Node(1);
            Node currentNode = head;
            currentNode = AddNode(currentNode, 2);
            currentNode = AddNode(currentNode, 2);
            currentNode = AddNode(currentNode, 1);
            PrintLL(head);                
            Console.WriteLine($" Palindrome test: {isLLPalindrome(head)}");

            head = new Node(1);
            currentNode = head;
            currentNode = AddNode(currentNode, 2);
            PrintLL(head);
            Console.WriteLine($" Palindrome test: {isLLPalindrome(head)}");

            head = new Node();
            PrintLL(head);
            Console.WriteLine($" Palindrome test: {isLLPalindrome(head)}");
            Console.ReadKey();  
        }

        //Assignment 1: Given two strings ransomNote and magazine,
        //return true if ransomNote can be constructed by using the letters
        //from magazine and false otherwise.
        //Time Complexity: O(n) n=magazine length; for filling the dictionary
        static bool CanCreateNote(string magazine, string ransomNote)
        {
            //put magazine into a counting dictionary
            //check each letter in ransomNote if in dictionary, if so subtract count
            //if not immediately return false, if get to end of ransomeNote return true
            
            //First check magazine size with rN since each letter can only be used once
            if (magazine.Length < ransomNote.Length) 
            {
                return false;
            }
            //create and fill dictionary with magazine chars
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    { charCount[c] = 1; }
                }
            }
            bool containsLetter = false;
            int val;
            foreach(char d in ransomNote)
            {
                containsLetter = charCount.TryGetValue(d, out val);
                if (containsLetter && val > 0)
                {
                    charCount[d]--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        } // end of Assignment 1

        //Assignment 2: Given the head of a singly linked list,
        //return true if it is a palindrome or false otherwise
        //Time Complexity = O(n) for iterating through string
        public class Node
        {
            public int data;
            public Node next;
            public Node(int val = 0, Node nextNode = null)
            {
                data = val;
                next = nextNode;
            }
        }
        static bool isLLPalindrome(Node head)
        {
                //first get length of LL then divide by 2 to get first half
                //start at head push val on stack till get to halfway point
                //if length is odd skip next node;
                //compare node with stack peek and pop if equal return false if not
                //when stack is empty return true
            Node temp = head;
                int listLength = 0;
            while (temp != null)
            {
                listLength++;
                temp = temp.next;
            }
                if (listLength == 0) 
                { 
                    return true; 
                }
                int halfLength = listLength / 2;
                Stack<int> halfStack = new Stack<int>();
                temp = head;
                while (halfLength > 0)
                {
                    halfStack.Push(temp.data);
                    halfLength--;
                    temp = temp.next;
                }
                if (listLength%2 != 0)
                    temp=temp.next;
                while (temp != null)
                {
                    if (temp.data == halfStack.Peek())
                    {
                        halfStack.Pop();
                        temp = temp.next;
                    }
                    else 
                    { return false; }
                }

                if (halfStack.Count > 0)
                {
                    return false;
                }
                else
                    return true;
        }
        static Node AddNode(Node current, int val)
        {
            current.next = new Node(val, null);
            return current.next;
        }
        static void PrintLL(Node startNode)
        {
            Node printNode = startNode;
            while(printNode != null)
            {
                Console.Write(printNode.data);
                printNode = printNode.next;
            }
        }
    }
}
