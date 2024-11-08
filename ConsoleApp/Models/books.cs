// ConsoleApp/Models/Book.cs
using System.Data.Common;

namespace ConsoleApp.Models
{
    public class Book
    {
        public int Id { get ; set ;}
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        // public Book(){}


        // public Book(string title, string author, string isbn)
        // {
            
        //     Title = title;
        //     Author = author;
        //     ISBN = isbn;
        // }
        
       
        // public void SetId(int id)
        // {
        //     if (id > 0){
        //         Id = id;
        //     }
        // }

        // public int GetId()
        // {
        //     return Id;
        // }
    }
}