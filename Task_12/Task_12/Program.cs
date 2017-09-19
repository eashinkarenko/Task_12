using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
    class Program
    {
        public void PrintMas(int [] mas)
        {
            Console.Write("Массив : ");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i]);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(@"Программа анализирует сложность сортировки двоичным деревом.
Анализ проводится с использованием массива в 100 элементов");
           
            // массив для хранения элементов
            int[] MasIntTree = new int[100];
            int[] MasIntChoice = new int[100];
            Random rnd = new Random();

            for (int i =0; i<100; i++)
            {
                MasIntTree[i] = rnd.Next(-100 , 100);
            }

            MasIntChoice = MasIntTree;


        }
    }
}
