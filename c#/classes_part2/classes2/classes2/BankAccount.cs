using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes2
{
    public enum TypeOfAccount
    {
        Loan,
        Deposit,
        Mortage
    }
    public abstract class Customer
    {
        public string name;
        public virtual double giveInterest(uint numberOfMonths, double interestedRate, TypeOfAccount type)
        {
            return numberOfMonths* interestedRate;
        }

        Customer(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name can not be null ");
            }

            this.name = name;
        }

        public class IndividualCustomer : Customer
        {
            public override double giveInterest(uint numberOfMonths, double interestedRate, TypeOfAccount type)
            {
                double sum = 0;
                if (type == TypeOfAccount.Loan)
                {
                    if (numberOfMonths > 3)
                    {
                        sum = (numberOfMonths - 3) * interestedRate;
                    }
                }

                if (type == TypeOfAccount.Mortage)
                {
                    if (numberOfMonths > 6)
                    {
                        sum = (numberOfMonths - 6) * interestedRate;
                    }
                }

                if (type == TypeOfAccount.Deposit)
                {
                    sum = base.giveInterest(numberOfMonths, interestedRate, type);
                }

                return sum;
            }

            IndividualCustomer(string name) : base(name) { }    

        }

        public class CompanyCustomer : Customer
        {
            public override double giveInterest(uint numberOfMonths, double interestedRate, TypeOfAccount type)
            {
                double sum = 0;
                if (type == TypeOfAccount.Loan)
                {
                    if (numberOfMonths > 2)
                    {
                        sum = (numberOfMonths - 2) * interestedRate;
                    }
                }

                if (type == TypeOfAccount.Mortage)
                {
                    if (numberOfMonths > 12)
                    {
                        sum = (numberOfMonths - 12) * interestedRate + 6 * interestedRate;
                    }
                    else
                    {
                        sum = numberOfMonths / 2 * interestedRate;
                    }
                }

                if (type == TypeOfAccount.Deposit)
                {
                    sum = base.giveInterest(numberOfMonths, interestedRate, type);
                }

                return sum;
            }

            CompanyCustomer(string name) : base(name) { }

        }

        public abstract class Account
        {
            protected TypeOfAccount type;
            protected Customer customer;
            protected double balance;
            protected double interestedRate;
            protected Account(TypeOfAccount type, Customer customer, double balance, double interestedRate) 
            {
                if (type == null ||  customer == null || interestedRate < 0)
                {
                    throw new ArgumentNullException("incorrect input");
                }

                this.type = type;
                this.customer = customer;
                this.balance = balance;

            }

            public virtual double calculateInterested(uint numbersOfMonth)
            {
                return customer.giveInterest(numbersOfMonth, interestedRate, type);
            }

            public void withDrawMoney(double amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("The amount should be possitive");
                }

                if (type != TypeOfAccount.Deposit)
                {
                    return;
                }

                balance -= amount; 
            }

            public void depositMoney(double amount)
            {
                if (amount < 0)
                {
                    throw new ArgumentException("The amount should be possitive");
                }

                balance += amount; 
            }
        }

        public class MortageAccount : Account
        {
            public MortageAccount(Customer customer, double balance, double interestedRate) : base(TypeOfAccount.Mortage, customer, balance, interestedRate)
            {}
        }

        public class LoanAccount : Account
        {
            public LoanAccount(Customer customer, double balance, double interestedRate) : base(TypeOfAccount.Loan, customer, balance, interestedRate)
            {}
        }

        public class DepositAccount : Account
        {
            public DepositAccount(Customer customer, double balance, double interestedRate) : base(TypeOfAccount.Deposit, customer, balance, interestedRate)
            {}
        }

    }
   
}
