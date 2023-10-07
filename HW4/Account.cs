using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }
        public Transaction(DateTime date, string type, double amount)
        {
            Date = date;
            Type = type;
            Amount = amount;
        }
    }
    internal class Account
    {
        string accountID, holderID, holderName;
        double balance;
        double interestRate;
        public List<Transaction> Transactions { get; set; }
        public string AccountID
        {
            get { return accountID; }
        }
        public string HolderID
        {
            get { return holderID; }
        }
        public string HolderName
        {
            get { return holderID; }
        }
        public double Balance
        {
            get { return balance; }
        }
        public double InterestRate
        {
            get { return interestRate; }
        }
        public Account(string accountID, string holderID, string holderName, double balance, double interestRate)
        {
            this.accountID = accountID;
            this.holderID = holderID;
            this.holderName = holderName;
            this.balance = balance;
            this.interestRate = interestRate;
            Transactions = new List<Transaction>();
        }
        public void Deposit(double amount)
        {
            balance += amount;
            Transactions.Add(new Transaction(DateTime.Now, "Deposit", amount));
        }
        public void WithDraw(double amount, bool mode = true)
        {
            if (amount > balance)
            {
                throw new ArgumentException(" [!] The balance is not enough");
            }
            balance -= amount;
            if (mode) Transactions.Add(new Transaction(DateTime.Now, "Withdraw", amount));
        }
        public void TransferToAccount(Account account, double amount)
        {
            WithDraw(amount, false);
            account.Deposit(amount);
            Transactions.Add(new Transaction(DateTime.Now, "Transfer", amount));
        }
        public void CalculateInterest()
        {
            double interest = balance * InterestRate / 100;
            balance += interest;
            Transactions.Add(new Transaction(DateTime.Now, "Interest", interest));
        }
    }
    class Bank
    {
        List<Account> accountList;
        public Bank()
        {
            accountList = new List<Account>();
        }
        public void addAccount(string accountID, string holderID, string holderName, double balance, double interestRate)
        {
            accountList.Add(new Account(accountID, holderID, holderName, balance, interestRate));
        }
        public void depositAccount(string accountID, double amount)
        {
            var account = accountList.Find(a => a.AccountID == accountID);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine($"Deposited {amount} into account {accountID}.");
            }
            else
            {
                Console.WriteLine($"Account with number {accountID} not found.");
            }
        }
        public void withdrawAccount(string accountID, double amount)
        {
            var account = accountList.Find(a => a.AccountID == accountID);
            if (account != null)
            {
                account.WithDraw(amount);
                Console.WriteLine($"Withdrawn {amount} from account {accountID}.");
            }
            else
            {
                Console.WriteLine($"Account with number {accountID} not found.");
            }
        }
        public void transferMoney(string source, string dest, double amount)
        {
            var sourceAccount = accountList.Find(a => a.AccountID == source);
            var destAccount = accountList.Find(a => a.AccountID == dest);
            if (sourceAccount != null && destAccount != null)
            {
                sourceAccount.TransferToAccount(destAccount, amount);
                Console.WriteLine($"Transfered {amount} from {sourceAccount} into account {destAccount}.");
            }
            else
            {
                Console.WriteLine(" [!] Source account or Dest account is not valid");
            }
        }
        public void CalculateInterestForAllAccounts()
        {
            foreach (var account in accountList)
            {
                account.CalculateInterest();
                Console.WriteLine($"Interest calculated for account {account.AccountID}.");
            }
        }
        public void GenerateReport()
        {
            Console.WriteLine("\n\t\t\tREPORT\n");
            foreach (var account in accountList)
            {
                Console.WriteLine($"(*) Account Number: {account.AccountID}");
                Console.WriteLine($"Owner ID: {account.HolderID}");
                Console.WriteLine($"Owner Name: {account.HolderName}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine("Transactions:");
                foreach (var transaction in account.Transactions)
                {
                    Console.WriteLine($"- Date: {transaction.Date}, Type: {transaction.Type}, Amount: {transaction.Amount}");
                }
                Console.WriteLine("------------------------------");
            }
        }
    }
}
