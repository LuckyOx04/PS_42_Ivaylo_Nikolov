// See https://aka.ms/new-console-template for more information
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;

try
{
    UserData userData = new UserData();

    User studentUser = new User()
    {
        Names = "student",
        Password = "123",
        Role = UserRolesEnum.STUDENT
    };
    User student2User = new User()
    {
        Names = "Student2",
        Password = "1233",
        Role = UserRolesEnum.STUDENT
    };
    User teacherUser = new User()
    {
        Names = "Teacher",
        Password = "1234",
        Role = UserRolesEnum.PROFESSOR
    };
    User adminUser = new User()
    {
        Names = "Admin",
        Password = "12345",
        Role = UserRolesEnum.ADMIN
    };

    userData.AddUser(studentUser);
    userData.AddUser(student2User);
    userData.AddUser(teacherUser);
    userData.AddUser(adminUser);

    Console.Write("Enter name: ");
    string name = Console.ReadLine();
    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    if (userData.ValidateCredentials(name, password))
    {
        var user = userData.GetUser(name, password);
        Console.WriteLine(user.OtherToString());
    }
    else
    {
        throw new Exception("User not found.");
    }
}
catch (Exception e)
{
    Action<string> log = Delegates.Log;
    log(e.Message);
}
finally
{
    Console.WriteLine("Executed in any case!");
}