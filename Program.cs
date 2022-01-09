using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_22
{
    /*Задание 22. Параллельное программирование и библиотека TPL
     Сформировать массив случайных целых чисел (размер  задается пользователем).
    Вычислить сумму чисел массива и максимальное число в массиве.  
    Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.*/
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Ведите целое число - размер массива");
            int n = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Массив из случайных чисел");
            PrintArray(GetArray(n));

            Console.WriteLine();

            Console.WriteLine("Отсортированный массив");
                      
            PrintArray(SortArray(GetArray(n)));

            Console.WriteLine();

            SumOfArray(GetArray(n));
            MaxOfArray(GetArray(n));



            Console.ReadKey();
        }

        static int[] GetArray(int n) //вместо int[] можно писать Array
        {
        
        int[] arr = new int[n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(0, 100);
            }
            return arr;
        }

        static int[] SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
            }

            return arr;
        }

        static void SumOfArray(int[] arr)
        {
            int sum = 0;
            foreach (int s in arr)
            {
                sum += s;
            }
            Console.WriteLine("Сумма элементов массива равна: "+sum);
        }

        static void MaxOfArray(int[] arr)
        {
            int max = 0;
            foreach (int s in arr)
            {
                if (max < s) max = s;
                
            }
            Console.WriteLine("Максимальное число в массиве равно: " + max);
        }

        static void PrintArray(int[] arr)
        {
            foreach (int s in arr)
            {
                Console.Write($"{s} ");
            }
        }

    }
}
