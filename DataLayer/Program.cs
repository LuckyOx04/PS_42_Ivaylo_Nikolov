using DataLayer.Database;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using (var context = new DatabaseContext())
{
    context.Database.EnsureCreated();
    // context.Add<DatabaseUser>(new DatabaseUser()
    // {
    //     Names = "user",
    //     Password = "password",
    //     Expires = DateTime.Now,
    //     Role = Welcome.Others.UserRolesEnum.STUDENT,
    //     Email = null,
    //     FacultyNumber = null
    // });
    // context.SaveChanges();
    var users = context.Users.ToList();

    string username = "";
    string password = "";
    int choice = 0;
    int stopper = 1;
    while(stopper == 1)
    {
        Console.WriteLine("Options:");
        Console.WriteLine("1. Add user");
        Console.WriteLine("2. Remove user");
        Console.WriteLine("3. Show all users");
        Console.WriteLine("4. Check if user exists\n");
        Console.Write("Your choice: ");
        choice = int.Parse(Console.ReadLine());
        Console.WriteLine();

        switch(choice)
        {
            case 1:
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                var newUser = new DatabaseUser()
                {
                    Names = username,
                    Password = password,
                    Expires = DateTime.Now,
                    Role = Welcome.Others.UserRolesEnum.ANONYMOUS,
                    Email = null,
                    FacultyNumber = null
                };
                context.Add(newUser);
                context.SaveChanges();
                Console.WriteLine("User added!\n");
                break;
            case 2:
                Console.Write("Enter username: ");
                username = Console.ReadLine();

                var user = context.Users.Where(e => e.Names == username)
                    .First();

                context.Remove(user);
                context.SaveChanges();
                Console.WriteLine("User removed!\n");
                break;
            case 3:
                Console.WriteLine("All users are:");
                await context.Users.ForEachAsync(x => 
                    Console.WriteLine($"Name: {x.Names}; Expires: {x.Expires}"));
                
                Console.WriteLine();

                break;
            case 4:
                Console.Write("Enter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                string message = (users.Where(e => e.Names == username && e.Password == password)
                    .FirstOrDefault()) != null ? "Valid user!" : "Invalid data!";
                Console.WriteLine(message + '\n');
                break;
            default:
                Console.WriteLine("Goodbye!");
                stopper = 0;
                break;
        }
    }
}
