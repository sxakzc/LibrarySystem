// ConsoleApp/Program.cs
using System;
using ConsoleApp.Data;
using ConsoleApp.Models;
//git修改测试
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookRepository = new BookRepository();
                
            while (true)
            {
                Console.WriteLine("图书管理系统");
                Console.WriteLine("1. 添加图书");
                Console.WriteLine("2. 查看所有图书");
                Console.WriteLine("3. 更新图书");
                Console.WriteLine("4. 删除图书");
                Console.WriteLine("5. 退出");
                Console.Write("请选择操作: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(bookRepository);
                        break;
                    case "2":
                        ViewAllBooks(bookRepository);
                        break;
                    case "3":
                        UpdateBook(bookRepository);
                        break;
                    case "4":
                        DeleteBook(bookRepository);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("无效的选择，请重新输入。");
                        break;
                }
            }
        }

        static void AddBook(BookRepository bookRepository)
        {
            Console.Write("请输入书名: ");
            var title = Console.ReadLine();
            Console.Write("请输入作者: ");
            var author = Console.ReadLine();
            Console.Write("请输入ISBN: ");
            var isbn = Console.ReadLine();

            var book = new Book { Title = title, Author = author, ISBN = isbn };
            bookRepository.AddBook(book);
            Console.WriteLine("图书添加成功。");
        }

        static void ViewAllBooks(BookRepository bookRepository)
        {
            var books = bookRepository.GetAllBooks();
            if (books.Count == 0)
            {
                Console.WriteLine("没有图书记录。");
            }
            else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, 书名: {book.Title}, 作者: {book.Author}, ISBN: {book.ISBN}");
                }
            }
        }

        static void UpdateBook(BookRepository bookRepository)
        {
            Console.Write("请输入要更新的图书ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = bookRepository.GetAllBooks().FirstOrDefault(b => b.Id == id);
                if (book != null)
                {
                    Console.Write("请输入新的书名: ");
                    book.Title = Console.ReadLine();
                    Console.Write("请输入新的作者: ");
                    book.Author = Console.ReadLine();
                    Console.Write("请输入新的ISBN: ");
                    book.ISBN = Console.ReadLine();

                    bookRepository.UpdateBook(book);
                    Console.WriteLine("图书更新成功。");
                }
                else
                {
                    Console.WriteLine("未找到指定的图书。");
                }
            }
            else
            {
                Console.WriteLine("无效的ID。");
            }
        }

        static void DeleteBook(BookRepository bookRepository)
        {
            Console.Write("请输入要删除的图书ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bookRepository.DeleteBook(id);
                Console.WriteLine("图书删除成功。");
            }
            else
            {
                Console.WriteLine("无效的ID。");
            }
        }
    }
}