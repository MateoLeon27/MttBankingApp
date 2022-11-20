using MttBankingApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MttBankingApp.Models;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

public class MyBank
{
    public string FirstName;
    public string LastName;
    public string InvestmentAccounts;
    public string CheckingAccounts;
    public decimal Balance;

    public MyBank(string firstName, string lastName, string investmentAccounts, string checkingAccounts, decimal balance)
    {
        FirstName = firstName;
        LastName = lastName;
        InvestmentAccounts = investmentAccounts;
        CheckingAccounts = checkingAccounts;
        Balance = balance;
    }

    public string GetFirstName() { return FirstName; }
    public string GetLastName() { return LastName; }
    public string GetInvestmentAccounts() { return InvestmentAccounts; }
    public string GetCheckingAccounts() { return CheckingAccounts; }    
    public decimal GetBalance() { return Balance; }

    public void SetFirstName(String FirstName)
    {
        this.FirstName = FirstName;   
    }
    public void SetInvestmentAccounts(String InvestmentAccounts)
    {
        this.InvestmentAccounts = InvestmentAccounts;
    }

    public void SetCheckingAccounts(String CheckingAccounts)
    {
        this.CheckingAccounts = CheckingAccounts;
    }
    public void SetBalance(Decimal Balance)
    {
        this.Balance = Balance;
    }

    public static void Main(String[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("How can we help today..");
            Console.WriteLine("Deposit");
            Console.WriteLine("Withdraw");
            Console.WriteLine("Transfer");
            Console.WriteLine("Check Balance");
            Console.WriteLine("Exit");
        }

        void Deposit(MyBank currentUser)
        {
            Console.WriteLine("Enter Deposit Amount:");
            decimal Deposit = Decimal.Parse(Console.ReadLine());
            currentUser.SetBalance(Deposit);
            Console.WriteLine("Your new balance is " + currentUser.GetBalance());
        }
        void Withdraw(MyBank currentUser)
        {
            Console.WriteLine("Enter Withdrawal Amount:");
            decimal Withdraw = Decimal.Parse(Console.ReadLine());

            if(currentUser.GetBalance() > Withdraw)
            {
                Console.WriteLine("Insufficient Funds");
            }
            else if(Withdraw >= 500)
            {
                Console.WriteLine("Reached Withdrawal Limit");
            }
            else
            {
                currentUser.SetBalance(currentUser.GetBalance() - Withdraw);
                Console.WriteLine("Current Balance: " + currentUser.GetBalance());
            }

        }

        List<MyBank> AccountOwners = new List<MyBank>();
        AccountOwners.Add(new MyBank("John","Thomas","Corporate","n/a", (decimal) 3584855.50));
        AccountOwners.Add(new MyBank("Sean", "Urena", "Individual", "Checking", (decimal) 7804855.50));
        AccountOwners.Add(new MyBank("James","Williams", "n/a", "Checking", (decimal) 4855.50));
        AccountOwners.Add(new MyBank("Terrance", "Peterson", "n/a", "Checking", (decimal) 85.70));
        AccountOwners.Add(new MyBank("Jacob", "Walton", "Corporate", "n/a", (decimal) 3445.00));
        AccountOwners.Add(new MyBank("Mark", "Norman", "Individual", "n/a", (decimal) 80003.71));
        AccountOwners.Add(new MyBank("Harry", "Henderson", "Corporate", "n/a", (decimal) 22235.89));

        Console.WriteLine("Welcome to the SimpleBank USA");
        Console.WriteLine("How may we assist you?");

        String InvestmentAccounts = "";
        MyBank currentUser;

        while (true) 
        { 
            try
            {
                InvestmentAccounts = Console.ReadLine();

                currentUser = AccountOwners.FirstOrDefault(a => a.InvestmentAccounts == "Individual");
                
                if (currentUser != null)
                {
                    break;
                   
                }else
                {
                    Console.WriteLine("Reached Withdrawal Limit");
                }
 
            }
            catch
            {
                Console.WriteLine("Reached Withdrawal Limit");
            }
        }

    }
}