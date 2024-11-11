// // ConsoleApp/Data/BookRepository.cs
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using ConsoleApp.Models;

// namespace ConsoleApp.Data
// {
//     public class BookRepository
//     {
//         private readonly string _filePath;

//         public BookRepository()
//         {
//             // 获取项目根目录
//             var projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
//             _filePath = Path.Combine(projectRoot, "books.txt");
//         }

//         public List<Book> GetAllBooks()
//         {
//             if (!File.Exists(_filePath))
//             {
//                 return new List<Book>();//防止空指针异常
//             }

//             var lines = File.ReadAllLines(_filePath);
//             var books = new List<Book>();

//             foreach (var line in lines)
//             {
//                 var parts = line.Split(',');
//                 if (parts.Length == 4)
//                 {
//                     var book = new Book
//                     {
//                         Id = int.Parse(parts[0]),
//                         Title = parts[1],
//                         Author = parts[2],
//                         ISBN = parts[3]
//                     };
//                     books.Add(book);
//                 }
//             }

//             return books;
//         }

//         public void AddBook(Book book)
//         {
//             var books = GetAllBooks();
//             book.Id = books.Count + 1;
//             books.Add(book);

//             SaveBooks(books);
//         }

//         public void UpdateBook(Book book)
//         {
//             var books = GetAllBooks();
//             var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
//             if (existingBook != null)
//             {
//                 existingBook.Title = book.Title;
//                 existingBook.Author = book.Author;
//                 existingBook.ISBN = book.ISBN;

//                 SaveBooks(books);
//             }
//         }

//         public void DeleteBook(int id)
//         {
//             var books = GetAllBooks();
//             var bookToDelete = books.FirstOrDefault(b => b.Id == id);
//             if (bookToDelete != null)
//             {
//                 books.Remove(bookToDelete);

//                 SaveBooks(books);
//             }
//         }

//         private void SaveBooks(List<Book> books)
//         {
//             var lines = books.Select(book => $"{book.Id},{book.Title},{book.Author},{book.ISBN}");
//             File.WriteAllLines(_filePath, lines);
//         }
//     }
// }