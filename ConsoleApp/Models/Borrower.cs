using ConsoleApp.Models;

public class Borrower{
    public string Name{get;set;}
    public string Password{get;set;}
    public List<Book> BorrowedBooks{get;set;} = new List<Book>();
    public Borrower(string name, string password)
    {
        Name = name;
        Password = password;
    }
    public void BorrowBook(Book book){
        if(book.IsAvailable){
            book.Borrow();
            BorrowedBooks.Add(book);
            Console.WriteLine($"{Name} borrowed '{book.Title}' by {book.Author}.");
        }
        else{
            Console.WriteLine($"Sorry, '{book.Title}' is not available for borrowing.");
        }
    }
    public void ReturnBook(Book book){
        if(BorrowedBooks.Contains(book)){
            book.Return();
            BorrowedBooks.Remove(book);
            Console.WriteLine($"{Name} returned '{book.Title}'.");
        }
        else{
            Console.WriteLine($"{Name} did not borrow '{book.Title}'.");
        }
    }
    public override string ToString(){
        return $"{Name} - Borrowed Books: {string.Join(", ", BorrowedBooks)}";
    }
}