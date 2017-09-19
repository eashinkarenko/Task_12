using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
    class MyClass
    {
        public int[] Data { get; set; }

        public MyClass(int[] data)
        {
            Data = data;
        }

        public void TreeSort()
        {
            Tree root = new Tree();
            for (int i = 0; i < Data.Length; i++)
            {
                root.AddToTree(Data[i]);
            }

            Data = root.GetSorted();
        }

        class Tree
        {
            class Element
            {
                public readonly int Value;
                public Element Left, Right;

                public Element(int value, Element left = null, Element right = null)
                {
                    Value = value;
                    Left = left;
                    Right = right;
                }
            }
            private Element root;

            private readonly List<int> result = new List<int>();

            public Tree()
            {
                root = null;
            }

            private static void AddToTreeRec(int value, ref Element localRoot)
            {
                if (localRoot == null)
                {
                    localRoot = new Element(value);
                    return;
                }
                Program.ComparisonTree++;
                if (localRoot.Value > value)
                {
                    AddToTreeRec(value, ref localRoot.Right);
                }
                else
                {
                    AddToTreeRec(value, ref localRoot.Left);
                }
            }

            public void AddToTree(int value)
            {
                AddToTreeRec(value, ref root);
            }


            private void GetSortedNumRec(Element node)
            {
                if (node != null)
                {
                    GetSortedNumRec(node.Right);
                    result.Add(node.Value);
                    GetSortedNumRec(node.Left);
                }
            }

            public int[] GetSorted()
            {
                GetSortedNumRec(root);
                return result.ToArray();
            }
        }
    }

    class Program
    {
        public static int ComparisonTree = 0;//количество сравнений

        public static void PrintMas(int [] mas)
        {
            Console.Write("Массив : ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(" " + mas[i] + " ");
            }
        }

        public static void Sort( int[] arr, ref int Transfer, ref int Comparison)
        {
            
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                        Transfer++;
                    }
                    Comparison++;
                }
                int s = arr[i];
                arr[i] = arr[min];
                arr[min] = s;
            }          
        }

            static void Main(string[] args)
        {
            Console.WriteLine(@"Программа анализирует сложность сортировки двоичным деревом и простым выбором.
Анализ проводится с использованием массива в 10 элементов");
           
            // массив для хранения элементов
            int[] MasIntTree = new int[10];
            int[] MasIntChoice = new int[10];
            Random rnd = new Random();

            int Transfer = 0;//количество перемещений 
            int Comparison = 0;//количество сравнений 

            


            for (int i =0; i<10; i++)
            {
                MasIntTree[i] = rnd.Next(-100 , 100);
            }

            MasIntChoice = MasIntTree;

            PrintMas(MasIntChoice);

            


            Console.WriteLine();
            Console.WriteLine("Простой выбор");
            Console.WriteLine("Сортировка неупорядоченного массива");

            Sort(MasIntChoice, ref Transfer, ref Comparison);
            Console.WriteLine(@"После сортировки массива простым выбором
Количество перемещений = " + Transfer);
            Console.WriteLine("Количество сравнений = " + Comparison);
            PrintMas(MasIntChoice);

            Transfer = Comparison = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сортировка упорядоченного по возрастанию массива");
            Sort(MasIntChoice, ref Transfer, ref Comparison);
            Console.WriteLine(@"После сортировки массива простым выбором
Количество перемещений = " + Transfer);
            Console.WriteLine("Количество сравнений = " + Comparison);
            PrintMas(MasIntChoice);

            Console.WriteLine();
            Console.WriteLine();
            Array.Reverse(MasIntChoice);
            PrintMas(MasIntChoice);

            Console.WriteLine();
            Console.WriteLine("Сортировка упорядоченного по убыванию массива");
            Sort(MasIntChoice, ref Transfer, ref Comparison);
            Console.WriteLine(@"После сортировки массива простым выбором
Количество перемещений = " + Transfer);
            Console.WriteLine("Количество сравнений = " + Comparison);
            PrintMas(MasIntChoice);






            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Бинарное дерево");
            Console.WriteLine();

            Console.WriteLine("Сортировка неупорядоченного массива");
            MyClass MasIntTree_2 = new MyClass(MasIntTree);
            MasIntTree_2.TreeSort();
            Console.WriteLine("Количество сравнений: " + ComparisonTree);
            PrintMas(MasIntTree_2.Data);
            ComparisonTree = 0;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сортировка упорядоченного по возрастанию массива");
            MasIntTree_2.TreeSort();
            Console.WriteLine("Количество сравнений: " + ComparisonTree);
            PrintMas(MasIntTree_2.Data);
            ComparisonTree = 0;

            Console.WriteLine();
            Console.WriteLine();
            Array.Reverse(MasIntTree_2.Data);
            PrintMas(MasIntTree_2.Data);

            Console.WriteLine();
            Console.WriteLine("Сортировка упорядоченного по убыванию массива");
            MasIntTree_2.TreeSort();
            Console.WriteLine("Количество сравнений: " + ComparisonTree);
            PrintMas(MasIntTree_2.Data);



            Console.ReadLine();
        }
    }
}
