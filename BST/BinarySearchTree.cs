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

        public BinarySearchTree(int[] input)
        {
            treeNumbers = new int[input.Length*input.Length];
            for(int i = 0; i < treeNumbers.Length; i++)
            {
                treeNumbers[i] = 0;
            }
            foreach(var n in input)
            {
                Console.Write(n + " ");
                AddElement(n, 0);
            }
            Console.Write("\nSorted values: ");
            foreach(var n in treeNumbers)
            {
                Console.Write(n + " ");
            }
            Console.ReadKey();
        }

        public void AddElement(int elementValue, int index = 0)
        {
            if (treeNumbers[index] == elementValue)
            {
                return;
            }
            else if (treeNumbers[index] == 0)
            {
                treeNumbers[index] = elementValue;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Element " + elementValue + " added!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else if (treeNumbers[index] != 0)
            {
                if (elementValue < treeNumbers[index])
                {
                    AddElement(elementValue, (2 * index) + 1);
                }
                if (elementValue > treeNumbers[index])
                {
                    AddElement(elementValue, (2 * index) + 2);
                }
            }
        }

        public void RemoveElement(int elementValue)
        {

        }

        public int FindElement(int elementValue, int index = 0, bool print=true)
        {
            if(treeNumbers[index] == elementValue)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Element " + elementValue +  " found!");
                Console.ForegroundColor = ConsoleColor.White;
                return treeNumbers[index];
            }
            else if(treeNumbers[index] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Element " + elementValue + " does not exist.");
                Console.ForegroundColor = ConsoleColor.White;
                return 0;
            }
            else
            {
                if(elementValue < treeNumbers[index])
                {
                    return FindElement(elementValue, 2 * index + 1);
                }
                if(elementValue > treeNumbers[index])
                {
                    return FindElement(elementValue, 2 * index + 2);
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Something went wrong when searching for " + elementValue);
            Console.ForegroundColor = ConsoleColor.White;
            return 0;
        }

        public int GetHeight()
        {
            return 0;
        }

        public void PrintTree()
        {
            Console.Write("\n");
            foreach (var n in treeNumbers)
            {
                Console.Write(n + " ");
            }
            Console.Write("\n");
        }
    }
}
