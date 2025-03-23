using System;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers;

public static class UserHelper
{
    public static string OtherToString(this User user)
    {
        return $"Name = {user.Names}, Password: {user.Password}, " +
        $"Role: {user.Role}";
    }

    public static bool ValidateCredentials(this UserData userData, string name, string password)
    {
        if (name == "" || password == "")
        {
            throw new InvalidDataException("The name or password cannot be empty!");
        }
        return userData.ValidateUser(name, password);
    }

    public static User GetUser(this UserData userData, string name, string password)
    {
        return userData.GetUser(name, password);
    }
}
