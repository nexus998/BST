using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BST
{
    class BinaryTreeFunction
    {
        string fileName;
        string manualInput;
        int[] treeNumbers;
        public BinaryTreeFunction()
        {
            var f = new ProgramFunction("Load/Enter Binary Tree", BeginFunction);
        }
        void EnterLoadMethod()
        {
            Console.WriteLine("Choose whether to load tree array from a file or from the keyboard");
            Console.WriteLine("1. Load from file");
            Console.WriteLine("2. Enter manually");
            while (true)
            {
                string inp = Console.ReadKey().Key.ToString();
                char res = '0';
                if (inp.StartsWith("NumPad") || inp.StartsWith("D"))
                {
                    res = inp.Last();
                }

                if(res == '1')
                {
                    EnterFileName();
                    break;
                }
                else if(res == '2')
                {
                    EnterManually();
                    break;
                }
                else
                {
                    Console.Write(" - Command not found... try again.");
                    continue;
                }
            }
        }

        int[] GetNumbers(string line)
        {
            string[] splitted = line.Split(' ');
            int[] ans = new int[splitted.Length];
            int i = 0;
            foreach (var s in splitted)
            {
                if (!int.TryParse(s, out ans[i]))
                {
                    Console.WriteLine("Input incorrect. Make sure it only contains numbers.");
                    continue;
                }
                else
                {
                    i++;
                }
            }
            return ans;
        }

        void EnterFileName()
        {
            Console.Clear();
            Console.WriteLine("Please enter the file name.");
            while (true)
            {
                fileName = Directory.GetCurrentDirectory() + "\\" + Console.ReadLine();

                treeNumbers = GetNumbers(File.ReadAllLines(fileName)[0]);
                if (treeNumbers != null)
                {
                    //Console.WriteLine("Calling from file");
                    BuildTree();
                    break;
                }
                else continue;
            }
        }
        void EnterManually()
        {
            Console.Clear();
            Console.WriteLine("Enter integers, seperated with whitespace.");
            while (true)
            {
                treeNumbers = GetNumbers(Console.ReadLine());
                if (treeNumbers != null)
                {
                    //Console.WriteLine("Calling from manual");
                    BuildTree();
                    break;
                }
                else continue;
            }
        }
        void BeginFunction()
        {
            Console.Clear();
            EnterLoadMethod();
        }

        void FindingElement(BinarySearchTree tree)
        {
            tree.ResetSteps();
            Console.Write("\nEnter the value of the element you want to find: ");
            var val = Console.ReadLine();
            int r;
            bool e;
            if(int.TryParse(val, out r))
            {
                tree.FindElement(r, out e);
            }
            Console.WriteLine("Steps taken: " + tree.GetSteps());
        }
        void AddingElement(BinarySearchTree tree)
        {
            tree.ResetSteps();
            Console.Write("\nEnter the value of the element you want to add: ");
            var val = Console.ReadLine();
            int r;
            if (int.TryParse(val, out r))
            {
                tree.AddElement(r, print:true);
            }
            Console.WriteLine("Steps taken: " + tree.GetSteps());
        }

        void RemovingElement(BinarySearchTree tree)
        {
            tree.ResetSteps();
            Console.Write("\nEnter the value of the element you want to remove: ");
            var val = Console.ReadLine();
            int r;
            bool e;
            if (int.TryParse(val, out r))
            {
                tree.RemoveElement(tree.FindElement(r, out e, print:false));
            }
            Console.WriteLine("Steps taken: " + tree.GetSteps());
        }

        void GettingHeight(BinarySearchTree tree)
        {
            tree.ResetSteps();
            Console.WriteLine("Height is " + tree.GetHeight());
            Console.WriteLine("Steps taken: " + tree.GetSteps());
        }

        void PrintFunctions()
        {
            Console.Clear();
            Console.WriteLine("Select what to do with your new binary search tree.");
            Console.WriteLine("1. Find Element");
            Console.WriteLine("2. Add Element");
            Console.WriteLine("3. Remove Element");
            Console.WriteLine("4. Get Height");
            Console.WriteLine("5. Print Tree");
            Console.WriteLine("6. Write to File");
            Console.WriteLine("7. Back to Main Menu");
        }

        void BuildTree()
        {
            var n = treeNumbers;
            Console.Write("\n");
            //Console.ReadKey();
            var t = new BinarySearchTree(treeNumbers);
            PrintFunctions();
            while (true)
            {
                string inp = Console.ReadKey().Key.ToString();
                PrintFunctions();
                char res = '0';
                if (inp.StartsWith("NumPad") || inp.StartsWith("D"))
                {
                    res = inp.Last();
                }

                if (res == '1')
                {
                    FindingElement(t);
                    
                    continue;
                }
                else if (res == '2')
                {
                    AddingElement(t);
                    t.PrintTree();
                    continue;
                }
                else if (res == '3')
                {
                    RemovingElement(t);
                    t.PrintTree();
                    continue;
                }
                else if (res == '4')
                {
                    GettingHeight(t);
                    continue;
                }
                else if (res == '5')
                {
                    t.PrintTree();
                    continue;
                }
                else if (res == '6')
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\output.txt", t.PrintTree(print:false), Encoding.UTF8);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tree written to output.txt!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (res == '7')
                {
                    Program.DoWelcomeScreen();
                    break;
                }
                else
                {
                    Console.Write(" - Command not found... try again.\n");
                    continue;
                }
            }
        }
    }
}
