using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    //Constructor
    //
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }


    //getters
    //
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //setters
    //
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //main method to run atm
    //
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one oif the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("thank you for you money. your new balance is " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? :");
            double withdrawal = Double.Parse(Console.ReadLine());

            //check if user has enough moeny
            //
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient Balance:");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Youre good to go, thank you");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance" + currentUser.getBalance());
        }

        List<cardHolder> cardHolder = new List<cardHolder>();
        cardHolder.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolder.Add(new cardHolder("4562782898027390", 2849, "Jeremy", "Blake", 420.21));
        cardHolder.Add(new cardHolder("5532772818547312", 4068, "Jake", "Bolger", 2380.43));
        cardHolder.Add(new cardHolder("3479000818527397", 1234, "Jill", "Jones", 264.32));
        cardHolder.Add(new cardHolder("4532772818527395", 1234, "Josh", "Smith", 904.45));

        //prompt user
        //
        Console.WriteLine("Welcome to simple ATM");
        Console.WriteLine("Please insert debit card");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against db
                currentUser = cardHolder.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser !=  null){break;}
                else{Console.WriteLine("card not recognised. please try again");}
            }
            catch {Console.WriteLine("Card not recognised Please try again");}
        }

        Console.WriteLine("Please enter your pin");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check against db
                if(currentUser.getPin() == userPin){break;}
                else{Console.WriteLine("Incorrect pin please try again");}
            }
            catch {Console.WriteLine("Incorrect pin please try again");}
        }
        Console.WriteLine("Welcome" + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch{}
            if(option == 1){deposit(currentUser);}
            else if(option == 2){withdraw(currentUser);}
            else if(option == 3){balance(currentUser);}
            else if(option == 4){break;}
            else {option = 0;}
            
        } while (option != 4);
        Console.WriteLine("Thankyou have a nice day");
    }
}