using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01_02_HTs
{
    //Extensions-------------------

    //public static class StringExtensions
    //{

    //    public static bool IsPalindrome(this string str)
    //    {

    //        string cleanedString = str.Replace(" ", "").ToLower();

    //        int length = cleanedString.Length;
    //        for (int i = 0; i < length / 2; i++)
    //        {
    //            if (cleanedString[i] != cleanedString[length - i - 1])
    //            {
    //                return false;
    //            }
    //        }
    //        return true;
    //    }


    //    public static string Encrypt(this string str, int key)
    //    {
    //        char[] encryptedChars = new char[str.Length];

    //        for (int i = 0; i < str.Length; i++)
    //        {
    //            char originalChar = str[i];
    //            char encryptedChar = (char)(originalChar + key);
    //            encryptedChars[i] = encryptedChar;
    //        }

    //        return new string(encryptedChars);
    //    }
    //}

    //public static class ArrayExtensions
    //{

    //    public static int CountOccurrences<T>(this T[] array, T element)
    //    {
    //        int count = 0;
    //        foreach (var item in array)
    //        {
    //            if (item.Equals(element))
    //            {
    //                count++;
    //            }
    //        }
    //        return count;
    //    }
    //}

    //internal class Program
    //{
    //    static void Main()
    //    {

    //        string palindromeCheck = "did oko vupuv oko did";
    //        Console.WriteLine(palindromeCheck.IsPalindrome()); 

    //        string originalString = "Avhraam Lincoln";
    //        int encryptionKey = 3;
    //        string encryptedString = originalString.Encrypt(encryptionKey);
    //        Console.WriteLine(encryptedString); 

    //        int[] numbers = { 1, 2, 3, 1, 4, 1, 5 };
    //        int occurrences = numbers.CountOccurrences(1);
    //        Console.WriteLine(occurrences); 
    //    }
    //}
    // BIRZHA-----------------------------------
    public class Exchange
    {
        public event EventHandler<decimal> ExchangeRateChanged;
        public event EventHandler<string> MaximumRateReached;
        public event EventHandler<string> MinimumRateReached;

        private decimal currentRate;
        private decimal maxRate;
        private decimal minRate;

        private Random random = new Random();

        public Exchange(decimal initialRate, decimal maxRate, decimal minRate)
        {
            this.currentRate = initialRate;
            this.maxRate = maxRate;
            this.minRate = minRate;
        }

        public void SimulateExchange()
        {
        
            decimal newRate = currentRate + (decimal)(random.NextDouble() - 0.5);
            currentRate = Math.Max(minRate, Math.Min(maxRate, newRate));

       
            ExchangeRateChanged?.Invoke(this, currentRate);

          
            if (currentRate == maxRate)
            {
                MaximumRateReached?.Invoke(this, "Maximum rate reached!");
            }
            else if (currentRate == minRate)
            {
                MinimumRateReached?.Invoke(this, "Minimum rate reached!");
            }
        }
    }

    public class Trader
    {
        private decimal balance;
        private string name;

        public Trader(string name, decimal initialBalance)
        {
            this.name = name;
            this.balance = initialBalance;
        }

        public void HandleExchangeRateChange(object sender, decimal newRate)
        {
          
            Console.WriteLine($"{name} received new exchange rate: {newRate}");
            if (newRate > 1.02M)
            {
                BuyMoney();
            }
            else if (newRate < 0.98M)
            {
                SellMoney();
            }
        }

        private void BuyMoney()
        {
          
            Console.WriteLine($"{name} is buying money!");
            balance -= 100;
        }

        private void SellMoney()
        {
            
            Console.WriteLine($"{name} is selling money!");
            balance += 100; 
        }
    }

    internal class Program
    {
        static void Main()
        {
            Exchange exchange = new Exchange(initialRate: 1.0M, maxRate: 1.1M, minRate: 0.9M);

            Trader trader1 = new Trader("Trader 1", initialBalance: 1000);
            Trader trader2 = new Trader("Trader 2", initialBalance: 1500);

        
            exchange.ExchangeRateChanged += trader1.HandleExchangeRateChange;
            exchange.ExchangeRateChanged += trader2.HandleExchangeRateChange;
            exchange.MaximumRateReached += (sender, message) => Console.WriteLine($"Maximum Rate Reached: {message}");
            exchange.MinimumRateReached += (sender, message) => Console.WriteLine($"Minimum Rate Reached: {message}");

            for (int i = 0; i < 10; i++)
            {
                exchange.SimulateExchange();
                Console.WriteLine("-----------------");
            }
        }
    }
}