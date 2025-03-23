using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome;

class Program
{
    static void Main(string[] args)
    {
        User user = new User {Names = "Ivan", Password = "123123",
        FacultyNumber = "121222123", Email = "ivan@tu-sofia.bg", Role = UserRolesEnum.STUDENT};
        UserViewModel userViewModel = new UserViewModel(user);
        UserView userView = new UserView(userViewModel);
        
        userView.Display();
    }
}