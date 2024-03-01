using System;
using System.Data;
using Bank_App_Entity;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to CDBank, India\n\n");
        using (var context = new BankDbContext())
        {
            while (true)
            {
                Console.WriteLine("1. Create New User\n2. Update Existing User\n3. Delete Existing Account\n4. Add Money\n5. Withdraw Money\n6. Check Balance\n7. View All Customers\n8. Exit");

                Console.WriteLine("\nEnter Your Choice: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    createUser(context);
                else if (choice == 2)
                    updateExistingUser(context);
                else if (choice == 3)
                    deleteExistingUser(context);
                else if (choice == 4)
                    addMoney(context);
                else if (choice == 5)
                    withdrawMoney(context);
                else if (choice == 6)
                    showBalance(context);
                else if (choice == 7)
                    viewAllUsers(context);
                else if (choice == 8)
                {
                    Console.WriteLine("\n\nYou're Terminated.\nVisit Again, Thank You...!!\nCDBank, India");
                    Environment.Exit(0);
                }
            }
        }
    }

    static void createUser(BankDbContext context)
    {
        Console.WriteLine("\nCreate Your own Account Number(Enter Here): ");
        int accno = int.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter Your Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("\nEnter Your Date of Birth(DD-MM-YYYY): ");
        DateTime dob = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("\nEnter Your Address: ");
        string address = Console.ReadLine();

        Console.WriteLine("\nEnter Your Mobile No.: ");
        string mobile = Console.ReadLine();

        Console.WriteLine("\nEnter Your Intial Balance: ");
        decimal balance = decimal.Parse(Console.ReadLine());

        var newUser = new Customers
        {
            accno = accno,
            name = name,
            dob = dob,
            address = address,
            mobile = mobile,
            balance = balance
        };

        context.Customers.Add(newUser);
        context.SaveChanges();

        Console.WriteLine("\n\nYour Account created successfully..!!\n\n");
    }

    static void updateExistingUser(BankDbContext context)
    {
        Console.WriteLine("\nEnter Your Account Number to Update: ");
        int updateAccno = int.Parse(Console.ReadLine());

        var customerToUpdate = context.Customers.Find(updateAccno);
        if (customerToUpdate != null)
        {

            Console.WriteLine("\nEnter New Name: ");
            customerToUpdate.name = Console.ReadLine();

            Console.WriteLine("\nEnter New Date of Birth(DD-MM-YYYY): ");
            customerToUpdate.dob = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter New Mobile Number: ");
            customerToUpdate.mobile = Console.ReadLine();

            Console.WriteLine("\nEnter New Address: ");
            customerToUpdate.address = Console.ReadLine();

            context.SaveChanges();

            Console.WriteLine("\n\nCustomer information updated successfully..!!\n\n");
        }
        else
        {
            Console.WriteLine("\n\nCustomer not found with the given Account Number.\n\n");
        }
    }

    static void deleteExistingUser(BankDbContext context)
    {
        Console.WriteLine("\nEnter Your Account Number to delete account: ");
        int deleteAccno = int.Parse(Console.ReadLine());

        var customerToDelete = context.Customers.Find(deleteAccno);
        if (customerToDelete != null)
        {
            context.Customers.Remove(customerToDelete);
            context.SaveChanges();

            Console.WriteLine("\n\nCustomer deleted successfully..!!\n\n");
        }
        else
        {
            Console.WriteLine("\n\nCustomer not found with given Account Number.\n\n");
        }
    }

    static void addMoney(BankDbContext context)
    {
        Console.WriteLine("\nEnter Your Account Number to add money: ");
        int amtToAddAccno = int.Parse(Console.ReadLine());

        var customerToAddMoney = context.Customers.Find(amtToAddAccno);
        if (customerToAddMoney != null)
        {
            Console.WriteLine("\nEnter how much money want to added to your account: ");
            decimal amtToAdd = decimal.Parse(Console.ReadLine());
            customerToAddMoney.balance += amtToAdd;
            context.SaveChanges();

            Console.WriteLine($"\n\nRs. {amtToAdd} is added to your account successfully..!!\n\n");
        }
        else
        {
            Console.WriteLine("\n\nCustomer not found with given Account Number.\n\n");
        }
    }

    static void withdrawMoney(BankDbContext context)
    {
        Console.WriteLine("\nEnter Your Account Number to withdraw money: ");
        int amtToWithdrawAccno = int.Parse(Console.ReadLine());

        var customerToWithdrawMoney = context.Customers.Find(amtToWithdrawAccno);
        if (customerToWithdrawMoney != null)
        {
            Console.WriteLine("\nEnter how much money want to withdraw from your account: ");
            decimal amtToWithdraw = decimal.Parse(Console.ReadLine());
            if (amtToWithdraw <= customerToWithdrawMoney.balance)
            {
                customerToWithdrawMoney.balance -= amtToWithdraw;
                context.SaveChanges();

                Console.WriteLine($"\n\nRs. {amtToWithdraw} is withdrawn successfully..!!\n\n");
            }
            else
            {
                Console.WriteLine("\n\nInsufficient balance, Withdrawn Failed.\n\n");
            }

        }
        else
        {
            Console.WriteLine("\n\nCustomer not found with given Account Number.\n\n");
        }
    }

    static void showBalance(BankDbContext context)
    {
        Console.WriteLine("\nEnter Your Account Number to know balance: ");
        int showBalanceAccno = int.Parse(Console.ReadLine());

        var customerToShowBalance = context.Customers.Find(showBalanceAccno);
        if (customerToShowBalance != null)
        {
            Console.WriteLine($"\n\nAccount No.: {customerToShowBalance.accno}\nName: {customerToShowBalance.name}\nCurrent Balance: Rs. {customerToShowBalance.balance}\n\n");
        }
        else
        {
            Console.WriteLine("\n\nCustomer not found with given Account Number.\n\n");
        }
    }

    static void viewAllUsers(BankDbContext context)
    {
        var test = context.Customers;
        //Console.WriteLine(test);
        //Console.WriteLine(test.GetType());
        var allUsers = context.Customers.ToList();
        Console.WriteLine(allUsers);

        Console.WriteLine("\nUsers Information:");

        foreach (var user in allUsers)
        {
            Console.WriteLine($"\n\nName: {user.name}");
        }
    }
}