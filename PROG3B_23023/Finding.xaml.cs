using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG3B_2023
{
    /// <summary>
    /// Interaction logic for Finding.xaml
    /// </summary>
    public partial class Finding : Window
    {
        public Finding()
        {
            InitializeComponent();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Load load = new Load();
            load.LoadTree();
            Load2 load2 = new Load2();  
            load2.LoadTree2();
            Load3 load3 = new Load3();
            load3.LoadTree3();
            // Loads the random items
            //random1 random1 = new random1();
            //Node tree = new Node();

            //// Creating a simple binary tree
            //StringBinaryTree.Node root = new StringBinaryTree.Node(1);
            //root.Left = new StringBinaryTree.Node(2);
            //root.Right = new StringBinaryTree.Node(3);
            //root.Left.Left = new StringBinaryTree.Node(4);
            //root.Left.Right = new StringBinaryTree.Node(5);
            //root.Right.Left = new StringBinaryTree.Node(6);
            //root.Right.Right = new StringBinaryTree.Node(7);

            //// Get 4 random nodes from the tree
            //List<StringBinaryTree.Node> randomNodes = tree.GetRandomNodes(root);
        }
    }

    



}
