using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Assignmet02
{

    // Answer 1 //

    class Accounts
    {
        private int AccountNo;
        private string CustomerName;
        private string AccountType;
        private char TransactionType;
        private double Amount;
        private double Balance;

        //initializing a constructor for account details

        public Accounts(int AccountNo, string CustomerName, string AccountType)
        {
            this.AccountNo = AccountNo;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
            this.Balance = 0.0;
        }
        //ENCAPSULATED property for accountNO,CustomerName,Account,Transaction,Amount and for balance



        public int AccountNum
        {
            get { return AccountNo; }
            private set { AccountNo = value; }
        }

        public string CustomerNAME
        {
            get { return CustomerName; }
            private set { CustomerName = value; }
        }
        public string AccountTyp
        {
            get { return AccountType; }
            private set { AccountType = value; }

        }
        public char Transactiontyp
        {
            get { return TransactionType; }
            set
            {
                if (value == 'D' || value == 'W')
                {
                    TransactionType = value;
                }
                else
                {
                    Console.WriteLine("Invalid Transaction Type! Use 'D' for Deposit or 'W' for Withdrawal.");
                }
            }
        }
        public double TotalAmount
        {
            get { return Amount; }
            private set { Amount = value; }
        }
        public double Balancee
        {
            get { return Balance; }
            private set { Balance = value; }
            
        }

        // this is the method of take input from the user details
        public static Accounts getUserInput()
        {
            Console.WriteLine("Hello sir \n Welcome to Infinite Banking Services. \n Please Enter Your Account No");
            int AccountNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Name : ");
            string CustomerName = Console.ReadLine();
            Console.WriteLine("Enter Account Type");
            string AccountType = Console.ReadLine();


            Console.WriteLine("----------------------------------------------------------------");
            return new Accounts(AccountNo, CustomerName, AccountType);
           

        }
        //method for taking the user input for transaction details
        
        public void getTransactionInput()
        {
            Console.WriteLine("Enter Transacction Type (D= Deposit/W=Withdrawl) : ");
            TransactionType = char.Parse(Console.ReadLine().ToUpper());

            Console.WriteLine("Enter Amount : ");
            Amount = double.Parse(Console.ReadLine());

        }

        // Passing the value to the credit or debit functionality

        public void Process()
        {
            Char CT;
            do
            {
                
                Console.WriteLine("Current Account Details");
                ShowData();
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("Do want to permorm any transation in this Account? (Y/N) ");
                


                CT = char.Parse(Console.ReadLine().ToUpper());
                if (CT == 'Y')
                {
                    getTransactionInput();
                    if (TransactionType == 'D')
                    {
                        Credit();
                    }
                    else if (TransactionType == 'W')
                    {

                        Debit();
                    }
                }
            } while (CT == 'Y');
            //if (TransactionType == 'D')
            //{
            //    Credit();
            //}
            //else if (TransactionType == 'W')
            //{
            //    Debit();
            //}
        }
        private void Credit()
        {
            Balance += Amount;
        }
        private void Debit()
        {
            if (Amount <= Balance)
            {
                Balance -= Amount;
            }
            else
            {
                Console.WriteLine($"Your Account has Insufficient Balance ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Transaction FAILED");
                Console.WriteLine("----------------------------------------");
            }

        }


            //Writing a method for showing all the data of user
            public void ShowData()
            {
                Console.WriteLine("Account No: " +AccountNum);
                Console.WriteLine("Customer Name: " + CustomerNAME);
                Console.WriteLine("Account Type: " + AccountTyp);
                Console.WriteLine("Transaction Type: " + Transactiontyp);
                Console.WriteLine("Amount: " + AccountTyp);
                Console.WriteLine("Balance: " + Balancee);
            }


        }

    class AccountProgram
    {
        static void Main()
        {
            Accounts Detail = Accounts.getUserInput();
           
            Detail.Process();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("FINAL ACCOUNT Deatail for this account");
            Detail.ShowData();
            Console.ReadKey();
        }
    }

} 

