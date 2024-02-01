namespace _22_01_HTs
{
    internal class Program
    {
        interface IOutput
        {
            void Show();
            void Show(string info);
        }

        interface IMath
        {
            int Max();
            int Min();
            float Avg();
            bool Search(int valueToSearch);
        }

        interface ISort
        {
            void SortInc();
            void SortDec();
            void SortByParam(bool isAsc);
        }

        class Array : IOutput, IMath, ISort
        {
            private int[] elements;

            public Array(params int[] values)
            {
                elements = values;
            }

            public void Show()
            {
                Console.WriteLine("Array Elements:");
                foreach (var element in elements)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }

            public void Show(string info)
            {
                Console.WriteLine("Array Elements:");
                foreach (var element in elements)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("\nInfo: " + info);
            }

            public int Max()
            {
                return elements.Max();
            }

            public int Min()
            {
                return elements.Min();
            }

            public float Avg()
            {
                return (float)elements.Average();
            }

            public bool Search(int valueToSearch)
            {
                return elements.Contains(valueToSearch);
            }

            public void SortInc()
            {
                for (int i =0;i < elements.Length;i++)
                {
                    for(int j = i; j < elements.Length;j++)
                    {
                        if (elements[i] > elements[j])
                        {
                            int temp = elements[i];
                            elements[i] = elements[j];
                            elements[j] = temp;
                        }
                    }
                }
            }

            public void SortDec()
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    for (int j = i; j < elements.Length; j++)
                    {
                        if (elements[i] < elements[j])
                        {
                            int temp = elements[i];
                            elements[i] = elements[j];
                            elements[j] = temp;
                        }
                    }
                }
            }

            public void SortByParam(bool isAsc)
            {
                if (isAsc)
                    SortInc();
                else
                    SortDec();
            }
        }



        static void Main()
        {
            Array array = new Array(5, 2, 8, 1, 7, 3);

            array.Show();
            array.Show("This is an array");

            
            Console.WriteLine("Max: " + array.Max());
            Console.WriteLine("Min: " + array.Min());
            Console.WriteLine("Avg: " + array.Avg());
            Console.WriteLine("Search 7: " + array.Search(7));
            Console.WriteLine("Search 10: " + array.Search(10));

            Console.WriteLine("Sorted in Increasing Order:");
            array.SortInc();
            array.Show();

            Console.WriteLine("Sorted in Decreasing Order:");
            array.SortDec();
            array.Show();

            Console.WriteLine("Sorted by Param (Increasing):");
            array.SortByParam(true);
            array.Show();

            Console.WriteLine("Sorted by Param (Decreasing):");
            array.SortByParam(false);
            array.Show();
        }

    } 
}