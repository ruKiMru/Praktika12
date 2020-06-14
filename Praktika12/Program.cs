using System;
using System.Linq;
using System.Threading;

namespace Praktika12
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;

            int[] masUp = GenerateRandomMasUp(size);
            Console.WriteLine("Возрастающий массив:");
            Show(masUp);
            CountingSort(masUp);
            Show(masUp);
            masUp = GenerateRandomMasUp(size);
            Console.WriteLine("\nВозвращаем значения массива:");
            Show(masUp);
            ShakerSort(ref masUp);
            Show(masUp);

            int[] masDown = GenerateRandomMasDown(size);
            Console.WriteLine("\nУбывающий массив:");
            Show(masDown);
            CountingSort(masUp);
            Show(masDown);
            masDown = GenerateRandomMasDown(size);
            Console.WriteLine("\nВозвращаем значения массива:");
            Show(masDown);
            ShakerSort(ref masDown);
            Show(masDown);

            int[] masRand = GenerateRandomMas(size);
            Console.WriteLine("\nПеремешанный массив:");
            Show(masRand);
            CountingSort(masRand);
            Show(masRand);
            masRand = GenerateRandomMas(size);
            Console.WriteLine("\nВозвращаем значения массива:");
            Show(masRand);
            ShakerSort(ref masRand);
            Show(masRand);

            Console.ReadLine();
        }

        public static int[] GenerateRandomMasUp(int size)
        {
            var rand = new Random();
            var mas = new int[size];

            for (int i = 0; i < size; i++)
            {
                mas[i] = rand.Next(0, 100);
            }

            Array.Sort(mas);

            return mas;
        }

        public static int[] GenerateRandomMasDown(int size)
        {
            var rand = new Random();
            var mas = new int[size];

            for (int i = 0; i < size; i++)
            {
                mas[i] = rand.Next(0, 100);
            }

            Array.Sort(mas, (a, b) =>
            {
                if (a > b)
                    return -1;
                if (a < b)
                    return 1;
                return 0;
            });

            return mas;
        }

        public static int[] GenerateRandomMas(int size)
        {
            var rand = new Random();
            var mas = new int[size];

            for (int i = 0; i < size; i++)
            {
                mas[i] = rand.Next(0, 100);
            }

            return mas;
        }

        // Сортровка подсчета
        public static void CountingSort(int[] mas)
        {
            int countCompares = 0; //счетчик сравнений
            int countChanges = 0; //счетчик перемещений

            int[] subMas = new int[mas.Max() + 1];

            foreach (var t in mas)
            {
                subMas[t]++;
            }

            for (int i = 0, j = 0; i < mas.Length; ++i)
            {
                while (subMas[j] == 0)
                {
                    countCompares++;
                    j++;
                }

                countChanges++;
                mas[i] = j;
                subMas[j]--;
            }

            Console.WriteLine("Количество сравнений = " + countCompares);
            Console.WriteLine("Количество перемещений (пересылок) = " + countChanges);
        }

        // Сортировка перемешиванием
        static void ShakerSort(ref int[] myint)
        {
            int left = 0; //левая граница
            int right = myint.Length - 1; //правая граница
            int countCompares = 0; //счетчик сравнений
            int countChanges = 0; //счетчик перемещений

            Console.WriteLine("\nСортировка перемешиванием:");
            while (left <= right)
            {
                for (int i = left; i < right; i++) //Сдвигаем к концу массива "тяжелые элементы"
                {
                    countCompares++;
                    if (myint[i] > myint[i + 1])
                    {
                        Swap(myint, i, i + 1); //меняем местами
                        countChanges++;
                    }
                }

                right--; // уменьшаем правую границу

                for (int i = right; i > left; i--) //Сдвигаем к началу массива "легкие элементы"
                {
                    countCompares++;
                    if (myint[i - 1] > myint[i])
                    {
                        Swap(myint, i - 1, i); //меняем местами
                        countChanges++;
                    }
                }

                left++; // увеличиваем левую границу
            }

            Console.WriteLine("Количество сравнений = " + countCompares);
            Console.WriteLine("Количество перемещений (пересылок) = " + countChanges);
        }

        // Меняем элементы массива местами
        static void Swap(int[] myint, int i, int j)
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }

        // Вывод массива
        static void Show(int[] a)
        {
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}

