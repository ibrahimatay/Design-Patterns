namespace DesignPatterns.MVC;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public override string ToString() => $"ID: {Id}, Title: {Title}, Author: {Author}";
}

public class BookView
{
    public void DisplayBooks(List<Book> books)
    {
        Console.WriteLine("\nBook List:");
        
        if (!books.Any())
        {
            Console.WriteLine("No books available.");
            return;
        }
        
        books.ForEach(Console.WriteLine);
    }

    public Book GetBookDetails()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();
        return new Book { Title = title, Author = author };
    }
}

public class BookController(BookView view)
{
    List<Book> books = new();
    int nextId = 1;

    public void AddBook()
    {
        Book newBook = view.GetBookDetails();
        newBook.Id = nextId++;
        books.Add(newBook);
        Console.WriteLine("Book added successfully!");
    }

    public void ShowBooks() => view.DisplayBooks(books);
}

class Program
{
    static void Main()
    {
        BookView view = new BookView();
        BookController controller = new BookController(view);

        while (true)
        {
            Console.WriteLine("\n1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Exit");
            Console.Write("Your choice: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    controller.AddBook();
                    break;
                case "2":
                    controller.ShowBooks();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}