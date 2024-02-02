using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;
using System;
using static _27_01_Ht.Program;

namespace _27_01_Ht
{
    internal class Program
    {
        class Menu
        {
            Array arr = new Array();
            public void MainMenu()
            {
                
                MenuDelegate menuD = MenuFType;
                menuD += MenuSType;
                Console.WriteLine("1.обчислення значення\n2.зміна масиву\n");
                ((MenuDelegate)menuD.GetInvocationList()[int.Parse(Console.ReadLine())-1])?.Invoke();
                
            }
            public void MenuFType()
            {
               
                FTypeDelegate fTypeDelegate = arr.CountOfNegativeNum;
                fTypeDelegate += arr.CountPrime;
                fTypeDelegate += arr.SumArr;
                arr.Print();

                Console.WriteLine("1.Обчислити кількість негативних елементів\r\n2.Визначити суму всіх елементів\r\n3.*Обрахувати кількість простих чисел\r\n");
                int res = ((FTypeDelegate)fTypeDelegate.GetInvocationList()[int.Parse(Console.ReadLine()) - 1]).Invoke();
                Console.WriteLine(res) ;
               

            }
            public void MenuSType()
            {
              
                STypeDelegate sTypeDelegat = arr.ChangeNegativeToZero;
                sTypeDelegat += arr.SortArr;
                sTypeDelegat += arr.SortArrByParne;
                Console.WriteLine("1.Змінити всі негативні елементи на 0\r\n2.Відсортувати масив\r\n3.*Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.\r\n");
                ((STypeDelegate)sTypeDelegat.GetInvocationList()[int.Parse(Console.ReadLine()) - 1])?.Invoke();

            }
        }
        class Array
        {
            private int[] array;
           
            public Array()
            {
                array= new int []{1, 4, -543, 34, -213, 432, -32, 21, 3, -4, 1 };
            }
            
            public int CountOfNegativeNum() {
                int count=0;
                foreach(int item in array)
                {
                    if (item < 0) count++;
                }
                Console.Write("Count of Negative: ");
                return count;
            }
            public int SumArr()
            {
                Console.Write("Array sum: ");
                return array.Sum();
                
            }
            public void Print()
            {
                foreach(var i in array)
                {
                    Console.Write(i+ " ");
                    
                }
                Console.WriteLine();
            }
            public static bool IsPrime(int v)
            {
                if (v < 2)
                {
                    return false;
                }

                for (int i = 2; i <= Math.Sqrt(v); i++)
                {
                    if (v % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            public int CountPrime() {
                int count = 0;
                foreach(int item in array)
                {
                    if (IsPrime(item)) count++;
                }
                Console.Write("Count of prime: ");
                return count;
            }
            public void ChangeNegativeToZero()
            {
                Print();
                for (int i = 0;i < array.Length; i++)
                {
                    if (array[i] < 0) array[i] = 0; 
                }
                Print();
            }
            public void SortArr()
            {
                Print();
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i] > array[j])
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
                Print();
            }
            public void SortArrByParne()
            {
                int left = 0;
                int right = array.Length - 1;
                Print();

                while (left < right)
                {
                    while (left < right && array[left] % 2 == 0)
                    {
                        left++;
                    }

                    while (left < right && array[right] % 2 != 0)
                    {
                        right--;
                    }

                    if (left < right)
                    {
                       
                        int temp = array[left];
                        array[left] = array[right];
                        array[right] = temp;

                        left++;
                        right--;
                    }
                }
                Print();
            }
        }
        public delegate void MenuDelegate();

        public delegate int FTypeDelegate();
        public delegate void STypeDelegate();





        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            
         
           
            Menu menu = new Menu();
            menu.MainMenu();
            
            
           
           
            





        }
    }
}