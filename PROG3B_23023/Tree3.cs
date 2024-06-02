using PROG3B_2023;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG3B_2023
{
    //Contains tree for third level items
    class Node3
    {
        public int Data;
        public Node3 Left, Right;

        public Node3(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    class StringNode3
    {
        public string Data;
        public StringNode Left, Right;

        public StringNode3(string data)
        {
            Data = data;
            Left = Right = null;
        }
    }

    class StringBinaryTree3
    {
        public StringNode Root;

        public void Insert(string data)
        {
            Root = InsertRec(Root, data);
        }

        private StringNode InsertRec(StringNode root, string data)
        {
            if (root == null)
            {
                return new StringNode(data);
            }

            if (string.Compare(data, root.Data) < 0)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (string.Compare(data, root.Data) > 0)
            {
                root.Right = InsertRec(root.Right, data);
            }

            return root;
        }

        public void InorderTraversal(StringNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.Write(root.Data + " ");
                InorderTraversal(root.Right);
            }
        }
    }

    public class Load3
    {
        public void LoadTree3()
        //Loads the data from the .txt file
        {
            string filePath = "C:\\Users\\NIKYLE\\source\\repos\\PROG3B_23023\\PROG3B_23023\\3.txt"; // Replace with your file path
            string[] data = ReadDataFromFile(filePath);

            StringBinaryTree stringBinaryTree = new StringBinaryTree();
            foreach (string value in data)
            {
                stringBinaryTree.Insert(value);
            }

            Console.WriteLine("Inorder Traversal of String Binary Tree:");
            stringBinaryTree.InorderTraversal(stringBinaryTree.Root);
        }

        static string[] ReadDataFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }
    }
}
