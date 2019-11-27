using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BST
{
    class BinarySearchTree
    {
        //int[] inputNumbers;
        int[] treeNumbers;

        int[] input;
        int inputCount=0;
        public BinarySearchTree(int[] input)
        {
            
            treeNumbers = new int[2097152];
            //Console.WriteLine("length " + l);
            for(int i = 0; i < treeNumbers.Length; i++)
            {
                treeNumbers[i] = 0;
            }
            foreach(var n in input)
            {
                if(n == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Can't write 0! Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Program.DoWelcomeScreen();
                    break;
                }
                bool exists;
                FindElement(n, out exists);
                if (!exists)
                    AddElement(n, 0, print: false);
                else
                {
                    Console.WriteLine(n + " is duplicate. Cannot have duplicate values!");
                    Console.ReadKey();
                    Program.DoWelcomeScreen();
                    break;
                }
            }
            this.input = input;
            inputCount = this.input.Length;
        }


        int stepsTaken = 0;
        public void ResetSteps()
        {
            stepsTaken = 0;
        }
        public int GetSteps()
        {
            return stepsTaken;
        }

        public void AddElement(int elementValue, int index = 0, bool print=false)
        {
            stepsTaken++;
            if (treeNumbers[index] == elementValue)
            {
                return;
            }
            else if (treeNumbers[index] == 0)
            {
                treeNumbers[index] = elementValue;
                inputCount++;
                if (print)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Element " + elementValue + " added!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                return;
            }
            else if (treeNumbers[index] != 0)
            {
                if (elementValue < treeNumbers[index])
                {
                    AddElement(elementValue, (2 * index) + 1, print);
                }
                if (elementValue > treeNumbers[index])
                {
                    AddElement(elementValue, (2 * index) + 2, print);
                }
            }
        }

        public void RemoveElement(int index = 0, bool print = true)
        {
            stepsTaken++;
            //check if not has kids
            if (treeNumbers[index*2 + 1] == 0 && treeNumbers[index * 2 + 2] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Element " + treeNumbers[index] + " removed!");
                Console.ForegroundColor = ConsoleColor.White;
                treeNumbers[index] = 0;
                inputCount--;
            }
            //if has 2 persons
            else if(treeNumbers[index * 2 + 1] != 0 && treeNumbers[index * 2 + 2] != 0)
            {
                //int parentIndex = 
                bool right = index % 2 == 0 ? true : false;
                treeNumbers[index] = 0;
                if(right)
                {
                    int newIndex = index * 2 + 2;
                    int smallestValueIndex = newIndex;
                    while(true)
                    {
                        if (treeNumbers[newIndex] == 0) break;
                        smallestValueIndex = newIndex;
                        newIndex = newIndex * 2 + 1;
                    }
                    treeNumbers[index] = treeNumbers[smallestValueIndex];

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Element " + treeNumbers[index] + " removed!");
                    Console.ForegroundColor = ConsoleColor.White;

                    treeNumbers[smallestValueIndex] = 0;
                    inputCount--;
                }
                else
                {
                    int newIndex = index * 2 + 1;
                    int smallestValueIndex = newIndex;
                    while (true)
                    {
                        if (treeNumbers[newIndex] == 0) break;
                        smallestValueIndex = newIndex;
                        newIndex = newIndex * 2 + 2;
                    }
                    treeNumbers[index] = treeNumbers[smallestValueIndex];

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Element " + treeNumbers[index] + " removed!");
                    Console.ForegroundColor = ConsoleColor.White;

                    treeNumbers[smallestValueIndex] = 0;
                    inputCount--;
                }
            }
            //if has 1 
            else
            {
                int childIndex = treeNumbers[index * 2 + 1] == 0 ? index * 2 + 2 : index * 2 + 1;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Element " + treeNumbers[index] + " removed!");
                Console.ForegroundColor = ConsoleColor.White;

                treeNumbers[index] = 0;
                inputCount--;
                RemoveElementAtIndex(childIndex);

            }
        }

        void RemoveElementAtIndex(int index)
        {
            stepsTaken++;
            int val = treeNumbers[index];
            treeNumbers[index] = 0;

            int depth = (int)Math.Ceiling(Math.Log(index + 2, 2));
            int newIndex = index - (int)(Math.Pow(2, depth) / 2);

            treeNumbers[newIndex] = val;
            //left
            if(treeNumbers[index*2+1] != 0)
            {
                RemoveElementAtIndex(index * 2 + 1);
            }
            //right
            if (treeNumbers[index * 2 + 2] != 0)
            {
                RemoveElementAtIndex(index * 2 + 2);
            }
        }

        public int FindElement(int elementValue, out bool exists, int index = 0, bool print=true)
        {
            stepsTaken++;
            bool e = false;
            if(treeNumbers[index] == elementValue)
            {
                if (print)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Element " + elementValue + " found! Index: " + index);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                exists = true;
                return index;
            }
            else if(treeNumbers[index] == 0)
            {
                if (print)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Element " + elementValue + " does not exist.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                exists = false;
                return 0;
            }
            else
            {
                if(elementValue < treeNumbers[index])
                {
                    return FindElement(elementValue, out exists, 2 * index + 1, print);
                }
                if(elementValue > treeNumbers[index])
                {
                    return FindElement(elementValue, out exists, 2 * index + 2, print);
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Something went wrong when searching for " + elementValue);
            Console.ForegroundColor = ConsoleColor.White;
            exists = false;
            return 0;
        }

        public int GetHeight()
        {
            return GetDepth(0, 0);
        }

        int GetDepth(int parentDepth, int index)
        {
            stepsTaken++;
            int currentDepth = parentDepth + 1;
            int leftDepth=0, rightDepth=0;
            if(treeNumbers[index*2+1] != 0)
            {
                leftDepth = GetDepth(currentDepth, index: index * 2 + 1);
            }
            if (treeNumbers[index * 2 + 2] != 0)
            {
                rightDepth = GetDepth(currentDepth, index: index * 2 + 2);
            }

            return Math.Max(Math.Max(leftDepth, rightDepth), currentDepth);
        }

        
        public string PrintTree(bool print=true)
        {
            int i = 0;
            Console.Write("\n");
            string res="";

            foreach (var n in treeNumbers)
            {
                if (n != 0) Console.ForegroundColor = ConsoleColor.Green;
                if(print) Console.Write(n + " ");
                else res += n + " ";
                Console.ForegroundColor = ConsoleColor.White;
                if (n != 0) i++;
                if(i == inputCount)
                {
                    break;
                }
            }
            Console.Write("\n");

            return res;
        }


    }
}
