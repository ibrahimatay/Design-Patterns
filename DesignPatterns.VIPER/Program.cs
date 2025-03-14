using System.Collections.Concurrent;

namespace DesignPatterns.VIPER;

using System;
using System.Collections.Generic;

// Entity (Model)
public record User(int Id, string Name, string Email)
{
    public override string ToString() => $"ID: {Id}, Name: {Name}, Email: {Email}";
}

// Interactor (Business Logic)
public interface IUserInteractor
{
    void FetchUsers();
    User GetUserById(int userId);
}

public class UserInteractor(IUserPresenter presenter, IUserRouter router) : IUserInteractor
{
    // Using ConcurrentBag for thread-safe operations
    ConcurrentBag<User> _users = new();
    public void FetchUsers()
    {
        // Simulating fetching data from a real data source (DB, API, etc.)
        _users.Add(new(1,"Ibrahim", "contact@ibrahimatay.com"));
        _users.Add(new(2,"Betul", "betul@example.com"));

        // Pass the fetched data to the presenter
        presenter.OnUsersFetched(_users.ToList());
    }
    public User GetUserById(int userId) => _users.FirstOrDefault(u => u.Id == userId);
}

// Presenter (Bridge between View and Interactor)
public interface IUserPresenter
{
    void OnUsersFetched(List<User> users);
}

public class UserPresenter(IUserView view) : IUserPresenter
{
    // Send the retrieved data to the view
    public void OnUsersFetched(List<User> users) => view.DisplayUsers(users);
}

// View (User Interface)
public interface IUserView
{
    void DisplayUsers(List<User> users);
}

public class ConsoleUserView : IUserView
{
    public void DisplayUsers(List<User> users) => users.ForEach(Console.WriteLine);
}

// Router (Navigation)
public interface IUserRouter
{
    void NavigateToUserDetails(int userId);
}

public class UserRouter : IUserRouter
{
    public void NavigateToUserDetails(int userId) 
        => Console.WriteLine($"Navigating to User Details for User ID: {userId}");
}

// Main Program to Initialize VIPER Components
class Program
{
    static void Main(string[] args)
    {
        // Creating VIPER components
        IUserView view = new ConsoleUserView();
        IUserPresenter presenter = new UserPresenter(view);
        IUserRouter router = new UserRouter();
        IUserInteractor interactor = new UserInteractor(presenter, router);
        
        // Start the process of fetching user data
        interactor.FetchUsers();
       
        Console.WriteLine( interactor.GetUserById(2));
    }
}
