using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UAS_059
{
    class Program
    {
        class node
        {
            public string info;
            public node lchild;
            public node rchild;

            public node (string info, node lchild, node rchild)
            {
                this.info = info;
                this.lchild = lchild;
                this.rchild = rchild;
            }
        }
        class BinaryTree
        {
            public node ROOT;

            public BinaryTree()
            {
                ROOT = null;
            }

            public void insert(string element)
            {
                node temp, parent = null, currentnode = null;
                find(element, ref parent, ref currentnode);
                if (currentnode != null)
                {
                    Console.WriteLine("Duplicate words not allowed");
                    return;
                }
                else
                {
                    temp = new node(element, null, null);
                    if (parent == null)
                    {
                        ROOT = temp;
                    }
                    else if (string.Compare(element, parent.info) < 0)
                    {
                        if (string.Compare(element, parent.info) < 0)
                            parent.lchild = temp;
                    }
                    else
                    {
                        parent.rchild = temp;
                    }
                }
            }
            public void find(string element, ref node parent, ref node currentnode)
            {
                currentnode = ROOT;
                parent = null;
                while ((currentnode != null) && (currentnode.info != element))
                {
                    parent = currentnode;
                    if (string.Compare(element, currentnode.info) < 0)
                        currentnode = currentnode.lchild;
                    else
                        currentnode = currentnode.rchild;
                }
            }
            public void inorder(node ptr)
            {
                if (ROOT == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }
                if (ptr != null)
                {
                    inorder(ptr.lchild);
                    Console.WriteLine(ptr.info + " ");
                    inorder(ptr.rchild);
                }
            }
            public void preorder(node ptr)
            {
                if (ROOT == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }
                if (ptr != null)
                {
                    Console.WriteLine(ptr.info + " ");
                    preorder(ptr.lchild);
                    preorder(ptr.rchild);
                }
            }
            public void postorder(node ptr)
            {
                if (ROOT == null)
                {
                    Console.WriteLine("Tree is empty");
                    return;
                }
                if (ptr != null)
                {
                    postorder(ptr.lchild);
                    postorder(ptr.rchild);
                    Console.WriteLine(ptr.info + " ");
                }
            }
        }
        static void Main(string[] args)
        {
            BinaryTree x = new BinaryTree();
            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1.Mencari judul buku ");
                Console.WriteLine("2 Mencari nomor buku ");
                Console.WriteLine("3.Mencari nama pengarang ");
                Console.WriteLine("4.Mencari tahun terbit");
                Console.WriteLine("5. EXIT");
                Console.WriteLine("\nEnter your choice (1-5) :");
                char ch = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case '1':
                        {
                            Console.WriteLine("enter a word :");
                            string word = Console.ReadLine();
                            x.insert(word);
                        }
                        break;
                    case '2':
                        {
                            x.inorder(x.ROOT);
                            Console.WriteLine("Enter a number");
                        }
                        break;
                    case '3':
                        {
                            x.preorder(x.ROOT);
                            Console.WriteLine("Enter a word");
                            
                        }
                        break;
                    case '4':
                        {
                            x.postorder(x.ROOT);
                            Console.WriteLine("Enter a number");
                        }
                        break;
                    case '5':
                        return;
                    default:
                        {
                            Console.WriteLine("invalid option");
                            break;
                        }
                }
            }

        }


    }
}









//2.binarysearch,queue
//3.push,pop                                    
//4.remove,display
//5.a = 17
//b. inorder => angka paling kecil di sebelah kiri yaitu 1,5,8,10,12,20,
// preorder => angka paling besar di sebelah kanan yaitu 8,15,22,36,40,48,50 
// postorder traversal => angka paling awal diatas atau di pertengahan yaitu angka 25