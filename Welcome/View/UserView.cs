using System.ComponentModel.DataAnnotations;
using Welcome.ViewModel;

namespace Welcome.View;

public class UserView
{
    private UserViewModel _viewModel;

    public UserView(UserViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"User: {_viewModel.Name}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Role: {_viewModel.Role}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Faculty number: {_viewModel.FacultyNumber}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Email: {_viewModel.Email}");
    }

    public void DisplayError()
    {
        throw new Exception("Display error!");
    }
}