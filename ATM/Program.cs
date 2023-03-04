using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            void options()
            {
                Console.WriteLine("Select from the options given below:");
                Console.WriteLine("1. Deposit \n2. Withdraw \n3. Show balance \n4. Exit");
            }
            void depositmon(cardHolder currUser)
            {
                Console.WriteLine("Enter Amount to deposit:");
                double deposit = Convert.ToDouble(Console.ReadLine());
                currUser.setbalance(deposit+currUser.getbalance());
                Console.WriteLine($"Thank you. Your new balance is {currUser.getbalance()}");
                Console.WriteLine();

            }

            void withdraw(cardHolder currUser)
            {
                Console.WriteLine("Enter the withdrawal amount:");
                double withdrawal = Convert.ToDouble(Console.ReadLine());
                if (!(currUser.getbalance() < withdrawal))
                {
                    currUser.setbalance( currUser.getbalance()-withdrawal);
                    Console.WriteLine("Done. Your new balance is "+currUser.getbalance());
                    Console.WriteLine();
                }
                else Console.WriteLine("Insufficient Balance");
            }
            //fake database
            List <cardHolder> CardHolders = new List<cardHolder>();
            CardHolders.Add(new cardHolder("12345678", "Piyush", 6900, 1234));
            CardHolders.Add(new cardHolder("65346707", "Abhay", 252846, 6969));
            CardHolders.Add(new cardHolder("27294694", "Kunal", 5634, 7895));
            CardHolders.Add(new cardHolder("72336579", "Sanchit", 21200, 3522));
            CardHolders.Add(new cardHolder("86523534", "Paras", 9200, 4534));

            Console.WriteLine("Welcome to LenaDena Bank ATM");
            Console.WriteLine("Please Enter your debit card number: ");
            String cnum = "";
            cardHolder newUser;
            while (true)
            {
                try
                {
                    cnum = Console.ReadLine();
                    newUser = CardHolders.FirstOrDefault(s => s.getnum() == cnum);
                    if (newUser != null) break;
                    else Console.WriteLine("Card not recognised. Please try again.");

                }
                catch { Console.WriteLine("Wrong input. Please try again."); }
            }

            Console.WriteLine("Please enter your pin number:");
            int newpin=0;
            while (true)
            {
                try
                {
                    newpin = Convert.ToInt32(Console.ReadLine());
                    if (newUser.getpin() == newpin) break;
                    else Console.WriteLine("Wrong. Please try again.");

                }
                catch { Console.WriteLine("Wrong input. Please try again."); }
            }

            Console.WriteLine($"Welcome {newUser.getname()}");
            int opt = 0;
            while (opt != 4)
            {
                options();
                opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case(1):
                        depositmon(newUser);
                        break;
                    case (2):
                        withdraw(newUser);
                        break;
                    case (3):
                        Console.WriteLine($"Your current balance is {newUser.getbalance()}");
                        break;
                    case (4):
                        break;
                    default:
                        opt = 0;
                        break;
                }
            }
            Console.WriteLine("Thank you. Bye. Press any key to close.");
            Console.ReadKey();


        }
    }
    public class cardHolder
    {
        string cardnum;
        string name;
        double balance;
        int pin;
        public cardHolder(string cardnum, string name, double balance, int pin)
        {
            this.cardnum = cardnum;
            this.balance = balance;
            this.pin = pin;
            this.name = name;

        }
        //getters
        public string getnum()
        {
            return cardnum;
        }
        public string getname()
        {
            return name;
        }
        public int getpin()
        {
            return pin;
        }
        public double getbalance()
        {
            return balance;
        }

        //setters
        public void setnum(string newnum)
        {
            cardnum = newnum;
        }
        public void setname(string newname)
        {
            name = newname;
        }
        public void setpin(int newpin)
        {
            pin = newpin;
        }
        public void setbalance(double newbal)
        {
            balance = newbal;
        }

    }
}
