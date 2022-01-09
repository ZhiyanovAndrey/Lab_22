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
            Func<object, int[]> func1 = new Func<object, int[]>(GetArray); //выбрали Func<object, int[]>,
                                                                           //который принимает значение и возвращает массив
            Task<int[]> task1 = new Task<int[]>(func1, n); //начинаем с task что бы понять как должен выглядеть делегат
                                                           //принял значения через конструктор
                                                           //передал делегату funk1

            Action<Task<int[]>> action1 = new Action<Task<int[]>>(PrintArray);
            Task task2 = task1.ContinueWith(action1); //принял значения через ContinueWith из task1
                                                      //передал в делегат action1

            Action<Task<int[]>> action2 = new Action<Task<int[]>>(SumOfArray);
            Task task3 = task1.ContinueWith(action2); 

            Action<Task<int[]>> action3 = new Action<Task<int[]>>(MaxOfArray);
            Task task4 = task1.ContinueWith(action3); 

            task1.Start(); //запускает всю цепочку вывод, ввод, сортировку 

            Console.ReadKey();
        }

        static int[] GetArray(object a) //преобразовываем object a в int n, так требует делегат Funk
        {

            int n = (int)a;
            int[] arr = new int[n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(0, 100);
            }
            return arr;
        }

        static void SumOfArray(Task<int[]> task)
        {
            int[] arr=task.Result;
            int sum = 0;
            foreach (int s in arr)
            {
                sum += s;
            }
            Console.WriteLine("Сумма элементов массива равна: " + sum);
        }

        static void MaxOfArray(Task<int[]> task)
        {
            int[] arr = task.Result;
            int max = 0;
            foreach (int s in arr)
            {
                if (max < s) max = s;

            }
            Console.WriteLine("Максимальное число в массиве равно: " + max);
        }

        static void PrintArray(Task<int[]> task)
        {
            int[] arr = task.Result; //забираем результат из task
            foreach (int s in arr)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();
        }
    }
}
