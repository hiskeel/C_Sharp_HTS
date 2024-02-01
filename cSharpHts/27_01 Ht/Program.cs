using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System.Xml.Linq;
using System;

namespace _27_01_Ht
{
    internal class Program
    {
        class Menu
        {
            public void MainMenu()
            {

                Console.WriteLine("1.обчислення значення\n2.зміна масиву\n");
                
            }
            public void MenuFType()
            {
                Console.WriteLine("1.Обчислити кількість негативних елементів\r\n2.Визначити суму всіх елементів\r\n3.*Обрахувати кількість простих чисел\r\n");
               
            }
            public void MenuSType()
            {
                Console.WriteLine("1.Змінити всі негативні елементи на 0\r\n2.Відсортувати масив\r\n3.*Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.\r\n");
                
            }
        }
        class Array
        {
            private int[] array;
           
            public Array()
            {
                array= null;
            }
            public Array(int[] array)
            {
                this.array = array;
            }
            public int CountOfNegativeNum(int[] arr) {
                int count=0;
                foreach(int item in arr)
                {
                    if (item < 0) count++;
                }
                return count;
            }
            public int SumArr(int[] arr)
            {
                return arr.Sum();
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
            public int CountPrime(int[] arr) {
                int count = 0;
                foreach(int item in arr)
                {
                    if (IsPrime(item)) count++;
                }
                return count;
            }
            public void ChangeNegativeToZero(int[] arr)
            {
                for(int i = 0;i < arr.Length; i++)
                {
                    if (arr[i] < 0) arr[i] = 0; 
                }
            }
            public void SortArr(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            int temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
            public void SortArrByParne(int[] arr)
            {
                int left = 0;
                int right = array.Length - 1;

                while (left < right)
                {
                    while (left < right && arr[left] % 2 == 0)
                    {
                        left++;
                    }

                    while (left < right && arr[right] % 2 != 0)
                    {
                        right--;
                    }

                    if (left < right)
                    {
                       
                        int temp = arr[left];
                        arr[left] = arr[right];
                        arr[right] = temp;

                        left++;
                        right--;
                    }
                }
            }
        }
        public delegate void MenuDelegate();

        public delegate int FTypeDelegate(int[] arr);
        public delegate void STypeDelegate(int[] arr);





        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] array = { 1, 4, -543, 34,-213, 432, -32, 21, 3, -4, 1 };
            Array arr = new Array(array);
            
            Menu menu = new Menu();
            MenuDelegate menuD = menu.MainMenu;
            menuD += menu.MenuFType;
            menuD += menu.MenuSType;
            FTypeDelegate fTypeDelegate = arr.CountOfNegativeNum;
            
            fTypeDelegate += arr.SumArr;
            fTypeDelegate += arr.CountPrime;
            STypeDelegate sTypeDelegate = arr.ChangeNegativeToZero;
            sTypeDelegate = arr.SortArr;
            sTypeDelegate = arr.SortArrByParne;
            ((MenuDelegate)menuD.GetInvocationList()[0])?.Invoke();
            int choice = int.Parse(Console.ReadLine());
            ((MenuDelegate)menuD.GetInvocationList()[choice])?.Invoke();
            for(int i =0; i <2; i++) 
            {

            }






        }
    }
}