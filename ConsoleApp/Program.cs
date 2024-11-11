// ConsoleApp/Program.cs
using System;
using ConsoleApp.Models;
namespace ConsoleApp{
         class Program
        {
        
            static Library library = new Library(); 
            static Librarian currentLibrarian;
            static Borrower currentBorrower;
            static void Main(string[] args){
                Console.WriteLine("欢迎来到图书馆管理系统");
                
                while(true){
                    Console.WriteLine("\n请选择你的身份：");
                    Console.WriteLine("[1] 管理员");
                    Console.WriteLine("[2] 借阅者");
                    Console.WriteLine("[3] 退出");

                    var option = Console.ReadLine();
                    
                    switch (option)
                    {
                        case "1":
                            // 管理员身份
                            // Console.WriteLine("请输入管理员用户名：");
                            LoginAsLibrarian();
                            break;
                        case "2":
                            // 用户身份
                            // Console.WriteLine("请输入用户名：");
                            LoginAsBorrower();
                            break;
                        case "3":
                            return;
                        default:
                            Console.WriteLine("无效的选择，请重新输入。");
                            break;
                    }
                }
            }
            static void LoginAsLibrarian()
            {
                Console.WriteLine("请输入管理员用户名：");
                var username = Console.ReadLine();
                Console.WriteLine("请输入管理员密码：");
                var password = Console.ReadLine();
                
                currentLibrarian = library.FindLibrarianByUsername(username);
                if(currentLibrarian != null && currentLibrarian.Password == password){
                    Console.WriteLine("登录成功！");
                    LibrarianMenu();
                }
                else{
                    Console.WriteLine("用户名或密码不正确，请重新输入。");
                }
            } 
            static void LoginAsBorrower()
            {
                Console.Write("请输入借阅者姓名: ");
                var name = Console.ReadLine();
                Console.Write("请输入借阅者密码: ");
                var password = Console.ReadLine();

                currentBorrower = library.FindBorrowerByName(name);
                if (currentBorrower != null && currentBorrower.Password == password)
                {
                    Console.WriteLine("登录成功。");
                    BorrowerMenu();
                }
                else
                {
                    Console.WriteLine("登录失败。姓名或密码无效。");
                }
            }
            static void LibrarianMenu(){
                Console.WriteLine("欢迎进入管理员菜单！");
                while (true)
                {
                    Console.WriteLine("\n请选择你的操作：");
                    Console.WriteLine("[1] 添加图书");
                    Console.WriteLine("[2] 移除图书");
                    Console.WriteLine("[3] 注册借阅者");
                    Console.WriteLine("[4] 注销借阅者");
                    Console.WriteLine("[5] 显示所有书籍");
                    Console.WriteLine("[6] 显示所有借阅者");
                    Console.WriteLine("[7] 退出");

                    var option = Console.ReadLine();
                    
                    switch (option)
                    {
                        case "1":
                            AddBook();
                            break;
                        case "2":
                            RemoveBook();
                            break;
                        case "3":
                            RegisterBorrower();
                            break;
                        case "4":
                            UnregisterBorrower();
                            break;
                        case "5":
                            library.DisplayAllBooks();
                            break;
                        case "6":
                            library.DisplayAllBorrowers();
                            break;
                        case "7":
                            return;
                        case "8":
                            Console.WriteLine("无效输入，请重新选择。");
                            break;
                    }
                }
            }
            static void BorrowerMenu(){
                Console.WriteLine("欢迎进入借阅者菜单！");
                while (true)
                {
                    Console.WriteLine("\n请选择你的操作：");
                    Console.WriteLine("[1] 借阅图书");
                    Console.WriteLine("[2] 归还图书");
                    Console.WriteLine("[3] 查看已借阅图书");
                    Console.WriteLine("[4] 退出");
                    
                    var option = Console.ReadLine();
                    
                    switch (option)
                    {
                        case "1":
                            BorrowBook();
                            break;
                        case "2":
                            ReturnBook();
                            break;
                        case "3":
                            Console.WriteLine(currentBorrower);
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("无效输入，请重新选择。");
                            break;
                    }
                }
            }
            static void AddBook(){
                Console.WriteLine("请输入书名：");
                var title = Console.ReadLine();
                Console.WriteLine("请输入作者：");
                var author = Console.ReadLine();
                Console.WriteLine("请输入ISBN：");
                var isbn = Console.ReadLine();
                
                var book = new Book(title,author,isbn);
                
                currentLibrarian.AddBook(library,book);
            }
            static void RemoveBook(){
                Console.WriteLine("请输入要删除的书名：");
                var title = Console.ReadLine();
                var book = library.FindBookByTitle(title);
                if(book!= null){
                    currentLibrarian.RemoveBook(library,book);
                }
                else {
                    Console.WriteLine("未找到该图书。");
                }
            }
            static void RegisterBorrower(){
                Console.WriteLine("请输入借阅者姓名：");
                var name = Console.ReadLine();
                Console.WriteLine("请输入借阅者密码：");
                var password = Console.ReadLine();
                var borrower = new Borrower(name,password);
                currentLibrarian.RegisterBorrower(library,borrower);
            }
            static void UnregisterBorrower(){
                Console.WriteLine("请输入要注销的借阅者姓名：");
                var name = Console.ReadLine();
                var borrower = library.FindBorrowerByName(name);
                if(borrower!=null){
                    currentLibrarian.RemoveBorrower(library,borrower);
                }
                else {
                    Console.WriteLine("未找到该借阅者。");
                }
            }
            static void BorrowBook(){
                Console.WriteLine("请输入要借阅的书名：");
                var title = Console.ReadLine();
                var book = library.FindBookByTitle(title);
                if(book!=null){
                    currentBorrower.BorrowBook(book);
                }
                else {
                    Console.WriteLine("未找到该图书。");
                }
            }
            static void ReturnBook(){
                Console.WriteLine("请输入要归还的书名：");
                var title = Console.ReadLine();
                var book = library.FindBookByTitle(title);
                if(book!=null){
                    currentBorrower.ReturnBook(book);
                }
                else {
                    Console.WriteLine("未找到该图书。"); 
                }
            }
            
            


        }
    }

    
       
    //     static void Main(string[] args)
    //     {
    //         var bookRepository = new BookRepository();
                
    //         while (true)
    //         {
    //             Console.WriteLine("图书管理系统");
    //             Console.WriteLine("1. 添加图书");
    //             Console.WriteLine("2. 查看所有图书");
    //             Console.WriteLine("3. 更新图书");
    //             Console.WriteLine("4. 删除图书");
    //             Console.WriteLine("5. 退出");
    //             Console.Write("请选择操作: ");
    //             var choice = Console.ReadLine();

    //             switch (choice)
    //             {
    //                 case "1":
    //                     AddBook(bookRepository);
    //                     break;
    //                 case "2":
    //                     ViewAllBooks(bookRepository);
    //                     break;
    //                 case "3":
    //                     UpdateBook(bookRepository);
    //                     break;
    //                 case "4":
    //                     DeleteBook(bookRepository);
    //                     break;
    //                 case "5":
    //                     return;
    //                 default:
    //                     Console.WriteLine("无效的选择，请重新输入。");
    //                     break;
    //             }
    //         }
    //     }

    //     static void AddBook(BookRepository bookRepository)
    //     {
    //         Console.Write("请输入书名: ");
    //         var title = Console.ReadLine();
    //         Console.Write("请输入作者: ");
    //         var author = Console.ReadLine();
    //         Console.Write("请输入ISBN: ");
    //         var isbn = Console.ReadLine();
    //         var book = new Book { Title = title, Author = author, ISBN = isbn };
    //         bookRepository.AddBook(book);
    //         Console.WriteLine("图书添加成功。");
    //     }

    //     static void ViewAllBooks(BookRepository bookRepository)
    //     {
    //         var books = bookRepository.GetAllBooks();
    //         if (books.Count == 0)
    //         {
    //             Console.WriteLine("没有图书记录。");
    //         }
    //         else
    //         {
    //             foreach (var book in books)
    //             {
    //                 Console.WriteLine($"ID: {book.Id}, 书名: {book.Title}, 作者: {book.Author}, ISBN: {book.ISBN}");
    //             }
    //         }
    //     }

    //     static void UpdateBook(BookRepository bookRepository)
    //     {
    //         Console.Write("请输入要更新的图书ID: ");
    //         if (int.TryParse(Console.ReadLine(), out int id))
    //         {
    //             var book = bookRepository.GetAllBooks().FirstOrDefault(b => b.Id == id);
    //             if (book != null)
    //             {
    //                 Console.Write("请输入新的书名: ");
    //                 book.Title = Console.ReadLine();
    //                 Console.Write("请输入新的作者: ");
    //                 book.Author = Console.ReadLine();
    //                 Console.Write("请输入新的ISBN: ");
    //                 book.ISBN = Console.ReadLine();

    //                 bookRepository.UpdateBook(book);
    //                 Console.WriteLine("图书更新成功。");
    //             }
    //             else
    //             {
    //                 Console.WriteLine("未找到指定的图书。");
    //             }
    //         }
    //         else
    //         {
    //             Console.WriteLine("无效的ID。");
    //         }
    //     }

    //     static void DeleteBook(BookRepository bookRepository)
    //     {
    //         Console.Write("请输入要删除的图书ID: ");
    //         if (int.TryParse(Console.ReadLine(), out int id))
    //         {
    //             bookRepository.DeleteBook(id);
    //             Console.WriteLine("图书删除成功。");
    //         }
    //         else
    //         {
    //             Console.WriteLine("无效的ID。");
    //         }
    //     }
    