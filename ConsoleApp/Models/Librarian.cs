using System.Runtime.InteropServices;
using ConsoleApp.Models;

public class Librarian{
    public string Name { get; set; } 
    public string Password{ get; set; }
    public Librarian(string name, string password){
        Name = name;
        Password = password;
    }
    public void AddBook(Library library,Book book){
        library.Books.Add(book);
        Console.WriteLine($"添加书籍: {book.Title}");
        // Console.WriteLine($"添加作者: {book.Author}");
        // Console.WriteLine($"添加ISBN: {book.ISBN}");
        library.SaveBooksToFile();
    }
    public void RemoveBook(Library library,Book book){
        if(library.Books.Contains(book)){
            library.Books.Remove(book);
            Console.WriteLine($"移除书籍: {book.Title}");
            library.SaveBooksToFile();
        }
    }
    public void RegisterBorrower(Library library,Borrower borrower){
        library.Borrowers.Add(borrower);
        Console.WriteLine($"注册用户: {borrower.Name}");
        library.SaveBorrowersToFile();
    }
    public void RemoveBorrower(Library library,Borrower borrower){
        if(library.Borrowers.Contains(borrower)){
            library.Borrowers.Remove(borrower);
            Console.WriteLine($"注销用户: {borrower.Name}");
            library.SaveBorrowersToFile();
        }
        else{
            Console.WriteLine("用户不存在。");
        }
    }
}