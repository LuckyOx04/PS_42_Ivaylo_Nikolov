using System;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data;

public class UserData
{
    private List<User> _users;
    private int _nextId;

    public UserData()
    {
        this._users = new List<User>();
        this._nextId = 0;
    }

    public void AddUser(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
    }

    public void DeleteUser(User user)
    {
        _users.Remove(user);
    }

    public bool ValidateUser(string name, string password)
    {
        foreach (var user in _users)
        {
            if (user.Names == name && user.Password == password)
            {
                return true;
            }
        }
        return false;
    }

    public bool ValidateUserLambda(string name, string password)
    {
        return _users.Where(x => x.Names == name && x.Password == password)
        .FirstOrDefault() != null ? true : false;
    }

    public bool ValidateUserLinq(string name, string password)
    {
        var ret = from user in _users
            where user.Names == name && user.Password == password
            select user.Id;
        
        return ret != null ? true : false;
    }

    public User GetUser(string name, string password)
    {
        return _users.Where(x => x.Names == name && x.Password == password)
        .First();
    }

    public void SetActive(string name, DateTime date)
    {
        var people = _users.Where(x => x.Names == name).ToList();
        for (int i = 0; i < people.Count; i++)
        {
            people[i].Expires = date;
        }
    }

    public void AssignUserRole(string name, UserRolesEnum role)
    {
        var personId = _users.Where(x => x.Names == name)
        .Select(x => x.Id).FirstOrDefault();
        _users[personId].Role = role;
    }
}
