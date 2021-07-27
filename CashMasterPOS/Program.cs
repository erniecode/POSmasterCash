using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



//US: 0.01, 0.05, 0.10, 0.25, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00

//Mexico: 0.05, 0.10, 0.20, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00

//Created by: Ernesto Sosa

namespace CASHMasterPOS
{
    class Program
    {
        static void Main(string[] args)
        {

            double eProductPrice = 0;
            double eBillsCoins = 0;
            ConsoleKeyInfo keyInfo;
            double[] coins = { };
            double amount = 0.00;
            double count;

            do
            {
                Console.Clear();
                //Here we ask for the product price first
                Console.WriteLine("HELLO, WELCOME TO CASH Master! - Created by: Ernesto Sosa \n" +
                "-----------------------------------------------------------------------\n\n Please select your country currency:\n" +
                "- for USD press key (F1) \n" +
                "- for MXN press key (F2)");

                //Here we get the country currency depending on the Key pressed.

                keyInfo = Console.ReadKey();


                if (keyInfo.Key == ConsoleKey.F1)
                {
                    Console.WriteLine("\n\n*** YOUR ACTUAL CURRENCY IS: USD ***\n-----------------------------------------------------------------------");
                    coins = new double[] { 0.01, 0.05, 0.10, 0.25, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00 };
                }
                else if (keyInfo.Key == ConsoleKey.F2)
                {
                    Console.WriteLine("\n\n*** YOUR ACTUAL CURRENCY IS: MXN ***\n-----------------------------------------------------------------------");
                    coins = new double[] { 0.05, 0.10, 0.20, 0.50, 1.00, 2.00, 5.00, 10.00, 20.00, 50.00, 100.00 };
                }
                else
                {
                    Console.WriteLine("\n\nWARNING: You have press (" + keyInfo.Key.ToString() + ") the wrong key!\nit must be (F1) for USD curreny or (F2) " +
                        "for MXN Currency," +
                        "\n\n Please press ENTER to TRY AGAIN!");
                    Console.ReadKey();
                }


            } while (coins.Length == 0);


                //Here we ask for the product price
                Console.Write("• Please introduce product price: ");
                eProductPrice = Convert.ToDouble(Console.ReadLine());
                Console.Write("\nThe product price is $ " + eProductPrice);
                Console.WriteLine("\n====================================================================");

            do
            {
                //Here we ask for the bill to pay with.
                Console.WriteLine("\n\n• Please introduce the bill/coins to pay with ($100.50, $55.00, $20.05, etc.): ");
                eBillsCoins = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("\n Pay with $ " + eBillsCoins + " bill/coins");
                Console.WriteLine("\n====================================================================");

                //Here we will get the correct change amount to determine the actual amount of bills or coins.
                if(eBillsCoins > eProductPrice)
                {
                    amount = eBillsCoins - eProductPrice;
                }
                else
                {
                    Console.WriteLine("\n\nWARNING: The amount of Bills/Coins you are trying to pay" +
                        "with are lower than the product price." +
                        "\n\n Please press ENTER to TRY AGAIN.");
                    Console.ReadKey();
                }
                

                //We will repeat this action until the eBillCoins Qty is more than the product price.
            } while (eBillsCoins < eProductPrice);


            //Here we show the change that we gonna provide
            Console.WriteLine("\n\nYOUR CHANGE IS: " + amount.ToString("0.00"));
            Console.WriteLine("\n====================================================================" +
                "\nPlease return to the client the next bills: \n\n");



            for (int i = coins.Length - 1; i >= 0; i--)
            {
                count = amount / coins[i];
                if ((int)count != 0)
                    Console.WriteLine(" • {1} bills/coins of $ {0}", coins[i], (int)count);
                amount %= coins[i];
            }


            Console.ReadKey();

        }

    }

}