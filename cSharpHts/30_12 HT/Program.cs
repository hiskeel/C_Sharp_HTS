namespace _30_12_HT
{
    internal class Program
    {
        class Worker
        {
            public string Name { get; set; }
            public short Age { get; set; }
            public int Salary { get; set; }
            public DateTime JoinDate { get; set; }

            
            public Worker() { 
                Name= string.Empty;
                Age= 0;
                Salary= 0;
                JoinDate = new DateTime();
            }
            public Worker(string name, short age, DateTime joinDate, int salary)
            {
                this.Name = name;
                this.Age = age;
                this.JoinDate = joinDate;
                this.Salary = salary;
            }
            public override string ToString()
            {
                return $"Name: {Name}\nAge: {Age}\nSalary: {Salary}\nJoin Date: {JoinDate.Year}.{JoinDate.Month}.{JoinDate.Day}\n---------------------------";
            }
        }
        static void Main(string[] args)
        {
            string name;
            short age;
            int salary;
            int day;
            int year;
            int month;
            DateTime joinDate;
            Worker[] workers = new Worker[2];
            for (int i = 0; i < workers.Length;i++)
            {
                workers[i] = new Worker();
            }
            for (int i = 0; i < workers.Length; i++)
            {
                
                Console.WriteLine("Enter name:");
                workers[i].Name = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                try
                {
                    workers[i].Age = short.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Salary: ");
                    workers[i].Salary = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter day of join:");

                    day = int.Parse(Console.ReadLine());


                    Console.WriteLine("Enter month of join:");


                    month = int.Parse(Console.ReadLine());


                    Console.WriteLine("Enter year of join:");

                    year = int.Parse(Console.ReadLine());
                    workers[i].JoinDate = new DateTime(year, month, day, 0, 0, 0);
                    
                   
                }

                catch (Exception e) { Console.WriteLine(e.Message); }
            }
                
            foreach (Worker worker in workers)
                {
                Console.WriteLine(worker.ToString());
                }


            }
        }
    }
