namespace _09_01_HT
{

    internal class Program
    {
        class CreditCard
        {
            private string cardNumber;
            private string cardHolderName;
            private string cvc;
            private DateTime expirationDate;

            public CreditCard(string cardNumber, string cardHolderName, string cvc, DateTime expirationDate)
            {
               
                if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(cardHolderName) || string.IsNullOrEmpty(cvc)|| cardNumber.Length > 16 || cardNumber.Length < 16)
                {
                    throw new ArgumentException("Uncorrect values of data.");
                }

                this.cardNumber = cardNumber;
                this.cardHolderName = cardHolderName;
                this.cvc = cvc;
                this.expirationDate = expirationDate;
            }
        }
        static void Main(string[] args)
        {
            //task 1
            try
            {
                Console.WriteLine("Enter your number: ");
                int num = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex) { Console.WriteLine(ex.Message);  }
            catch(OverflowException ex) { Console.WriteLine(ex.Message); }
            // task 2
            try
            {
                Console.WriteLine("Enter Card number:");
                CreditCard myCard = new CreditCard(Console.ReadLine(), "John Doe", "123", DateTime.Now.AddYears(2));
                Console.WriteLine("Credit card succesfuly created.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            //task 3
            Console.Write("Enter math example (Only numbers and operator '*'): ");
            string expression = Console.ReadLine();

            try
            {
                string[] numbers = expression.Split('*');
                int result = 1;

                foreach (string number in numbers)
                {
                    result *= Convert.ToInt32(number);
                    
                  
                }

                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error. Enter Correctly.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow. Enter smaller numbers.");
            }
        }
    }
    
}