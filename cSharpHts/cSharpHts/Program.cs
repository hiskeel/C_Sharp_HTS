using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace cSharpHts
{
    internal class Program
    {
        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],4} ");
                }
                Console.WriteLine();
            }
            
        }
        static int SumBetweenMinAndMax(int[,] arr, int iminR,int iminC, int imaxR, int imaxC)
        {
            int sum = 0;
            bool first = false;
            if (iminR < imaxR) first = true;
            else if (iminR == imaxR && iminC < imaxC) first = true;
            if (first)
            {
                for (int i = iminR; i <= imaxR; i++)
                {
                    if (i == imaxR)
                    {
                        if (iminC != 4)
                        {
                            for (int j = iminC + 1; j < imaxC; j++)
                            {
                                sum += arr[i, j];
                            }
                        }
                        else
                        {
                            for (int j = 0; j < imaxC; j++)
                            {
                                i++;
                                sum += arr[i, j];
                            }
                        }
                    }
                    else
                    {
                        if (iminC != 4)
                        {
                            for (int j = iminC + 1; j < arr.GetLength(1); j++)
                            {
                                sum += arr[i, j];
                            }
                        }
                        else
                        {
                            i++;
                            for (int j = 0; j < imaxC; j++)
                            {
                                
                                sum += arr[i, j];
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = imaxR; i <= iminR; i++)
                {
                    if (i == iminR)
                    {
                        if (imaxC != 4)
                        {
                            for (int j = imaxC + 1; j < iminC; j++)
                            {
                                sum += arr[i, j];
                            }
                        }
                        else
                        {
                            i++;
                            for (int j = 0; j < iminC; j++)
                            {
                                
                                sum += arr[i, j];
                            }
                        }
                    }
                    else
                    {
                        if (imaxC != 4)
                        {
                            for (int j = imaxC + 1; j < arr.GetLength(1); j++)
                            {
                                sum += arr[i, j];
                            }
                        }
                        else
                        {
                            i++;
                            for (int j = 0; j < iminC; j++)
                            {
                                
                                sum += arr[i, j];
                            }
                        }
                    }
                }
            }


            return sum;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //            task 1 Створіть додаток, який відображає кількість парних,
            //непарних, унікальних елементів масиву.
            //int[] arr= {1,3,4,4,7,7,8,10,11 };

            //int count = 0;
            //foreach(int i in arr) { if(i%2==0) count++; }
            //Console.WriteLine($"count of parnuh {count}\n Count of ne parnuh {arr.Length - count}");
            //bool check = false;
            //count = 0;
            //for(int i = 0; i < arr.Length; i++)
            //{
            //    check = false;
            //    for (int j = i+1; j < arr.Length; j++)
            //    {
            //        if (arr[i] == arr[j]) check = true;
            //    }
            //    if (!check ) count++;
            //}
            //Console.WriteLine($"Count of unique elements { count }");

            //task 2 Створіть додаток, який відображає кількість значень у
            //            масиві менше заданого параметра користувачем.Наприклад,
            //кількість значень менших, ніж 7(7 введено користувачем
            //з клавіатури).

            //int[] arr = { 1, 3, 4, 4, 7, 7, 8, 10, 11 };
            //Console.WriteLine("Enter your value:");
            //int value = int.Parse(Console.ReadLine());
            //foreach(int i in arr) { if (i <value) Console.Write($"{i} "); }

         // task 3
            //int[] A = new int[5];         
            //Console.WriteLine("Введіть 5 цілих чисел для масиву A:");
            //for (int i = 0; i < A.Length; i++)
            //{
            //    Console.Write($"Елемент {i + 1}: ");
            //    A[i] = int.Parse(Console.ReadLine());
            //}

            //double[,] B = new double[3, 4];

            //Random random = new Random();
            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(1); j++)
            //    {
            //        B[i, j] = random.NextDouble() * 100; 
            //    }
            //}

           
            //Console.WriteLine("\nМасив A:");
            //foreach (int element in A)
            //{
            //    Console.Write(element + " ");
            //}
            //Console.WriteLine("\n\nМасив B:");
            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(1); j++)
            //    {
            //        Console.Write($"{B[i, j]:F2}\t");
            //    }
            //    Console.WriteLine();
            //}

            
            //int maxA = A.Max();
            //int minA = A.Min();
            //double maxB = B.Cast<double>().Max();
            //double minB = B.Cast<double>().Min();

            //Console.WriteLine($"\nЗагальний максимальний елемент в масиві A: {maxA}");
            //Console.WriteLine($"Загальний мінімальний елемент в масиві A: {minA}");
            //Console.WriteLine($"Загальний максимальний елемент в масиві B: {maxB:F2}");
            //Console.WriteLine($"Загальний мінімальний елемент в масиві B: {minB:F2}");

           
            //int sumA = A.Sum();
            //double sumB = B.Cast<double>().Sum();
            //double productA = A.Aggregate(1, (acc, x) => acc * x);
            //double productB = B.Cast<double>().Aggregate(1.0, (acc, x) => acc * x);

            //Console.WriteLine($"\nЗагальна сума елементів в масиві A: {sumA}");
            //Console.WriteLine($"Загальний добуток елементів в масиві A: {productA}");
            //Console.WriteLine($"Загальна сума елементів в масиві B: {sumB:F2}");
            //Console.WriteLine($"Загальний добуток елементів в масиві B: {productB:F2}");

           
            //int sumEvenA = A.Where(x => x % 2 == 0).Sum();
            //Console.WriteLine($"\nСума парних елементів в масиві A: {sumEvenA}");

           
            //double sumOddColumnsB = 0.0;
            //for (int j = 0; j < B.GetLength(1); j += 2)
            //{
            //    sumOddColumnsB += B.Cast<double>().Where((value, index) => index % B.GetLength(1) == j).Sum();
            //}
            //Console.WriteLine($"Сума непарних стовпців в масиві B: {sumOddColumnsB:F2}");


            //task 4
            int[,] array = new int[5, 5];

            // Заповнення масиву випадковими числами
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(-100, 101); // Випадкові числа від -100 до 100
                }
            }

            // Виведення масиву
            Console.WriteLine("Двовимірний масив:");
            PrintArray(array);

            // Знаходження мінімального та максимального елементів
            int minElement = array[0, 0];
            int maxElement = array[0, 0];
            int indexMinR = 0;
            int indexMaxR = 0;
            int indexMinC = 0;
            int indexMaxC = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < minElement)
                    {
                        minElement = array[i, j];
                        indexMinC = j;
                        indexMinR = i;
                    }

                    if (array[i, j] > maxElement)
                    {
                        maxElement = array[i, j];
                        indexMaxC = j;
                        indexMaxR = i;
                    }
                }
            }

            // Знаходження і виведення суми елементів між мінімальним і максимальним
            int sumBetweenMinMax = SumBetweenMinAndMax(array, indexMinR, indexMinC, indexMaxR, indexMaxC);
            Console.WriteLine($"\nСума елементів між мінімальним ({minElement}) та максимальним ({maxElement}) елементами: {sumBetweenMinMax}");

        }
    }
}