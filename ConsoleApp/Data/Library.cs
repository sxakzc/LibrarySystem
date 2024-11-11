using ConsoleApp.Models;

public class Library
{
    public List<Book> Books { get; private set; } = new List<Book>();
    public List<Borrower> Borrowers { get; private set; } = new List<Borrower>();
    public List<Librarian> Librarians { get; private set; } = new List<Librarian>();
    

//  // 获取项目根目录
    public static string GetRootPath(){
        string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        return projectRoot;
    }
    
    private  string BOOKS_FILE_PATH = Path.Combine(GetRootPath(), "books.txt");
    private  string BORROWERS_FILE_PATH = Path.Combine(GetRootPath(), "borrowers.txt");
    private  string LIBRARIANS_FILE_PATH = Path.Combine(GetRootPath(), "librarians.txt");
    
    public Library() {
        LoadBooksFromFile();
        LoadBorrowersFromFile();
        LoadLibrariansFromFile();
    }
    public void SaveBooksToFile() {
        
        using (StreamWriter writer = new StreamWriter(BOOKS_FILE_PATH,false)){
            foreach (var book in Books){
                writer.WriteLine($"{book.Title}|{book.Author}|{book.ISBN}|{book.IsAvailable}");
            }
        }  
    }
    public void SaveBorrowersToFile(){
        
        using (StreamWriter writer = new StreamWriter(BORROWERS_FILE_PATH,false)){
            foreach (var borrower in Borrowers){
                writer.WriteLine($"{borrower.Name}|{borrower.Password}");
            }
        }
    }
    public void SaveLibrarinsToFile(){
        
        using (StreamWriter writer = new StreamWriter(LIBRARIANS_FILE_PATH,false)){
            foreach (var librarian in Librarians){
                writer.WriteLine($"{librarian.Name}|{librarian.Password}");
            }
        }
    }
    public void LoadBooksFromFile(){
        
        if(File.Exists(BOOKS_FILE_PATH)){
            using (StreamReader reader = new StreamReader(BOOKS_FILE_PATH)){
                string line;
                while((line = reader.ReadLine()) != null){
                    var parts = line.Split('|');
                    if(parts.Length == 4){
                        Books.Add(new Book(parts[0],parts[1],parts[2],bool.Parse(parts[3])));
                    }
                }
            }
        } 
    }
    public void LoadBorrowersFromFile(){
        if(File.Exists(BORROWERS_FILE_PATH)){
            using (var reader = new StreamReader(BORROWERS_FILE_PATH)){
                string line;
                while((line = reader.ReadLine())!= null){
                    var parts = line.Split('|');
                    if (parts.Length == 2){
                        Borrowers.Add(new Borrower(parts[0],parts[1]));
                    }
                }
            }
        }
    }
    public void LoadLibrariansFromFile(){
        if (File.Exists(LIBRARIANS_FILE_PATH))
        {
            using (StreamReader reader = new StreamReader(LIBRARIANS_FILE_PATH))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        Librarians.Add(new Librarian(parts[0], parts[1]));
                    }
                }
            }
        }
    }
    public void DisplayAllBooks()
    {
        foreach (var book in Books) Console.WriteLine(book);    
    }
 
    public void DisplayAllBorrowers()
    {
        foreach (var borrower in Borrowers) Console.WriteLine(borrower);    
    }
    
    // public void DisplayAllLibrarians()
    // {
    //     foreach (var librarian in Librarians) Console.WriteLine(librarian);    
    // }
    
    // 根据书名查找书籍
    public Book FindBookByTitle(string title)
    {
        return Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    // 根据姓名查找借阅者
    public Borrower FindBorrowerByName(string name)
    {
        return Borrowers.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // 根据用户名查找管理员
    public Librarian FindLibrarianByUsername(string username)
    {
        return Librarians.FirstOrDefault(l => l.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
    }
}