// ConsoleApp/Models/Book.cs
using System.Data.Common;


namespace ConsoleApp.Models
{
    public class Book
    {
       public string Title { get; set; }
       public string Author { get; set; }
       public string ISBN { get; set; }
       public bool IsAvailable { get; set; } = true ;
       public Book(string title, string author, string isbn)     
       {
           Title = title;
           Author = author;
           ISBN = isbn;
       }
        public Book(string title, string author, string isbn,bool isAvailable)     
       {
           Title = title;
           Author = author;
           ISBN = isbn;
           IsAvailable =isAvailable;
           
       }

       public void Borrow()
       {
           IsAvailable = false;
       }
       
       public void Return()    
       {
           IsAvailable = true;
       } 

       public override string ToString()
       {
           return $"{Title} by {Author} with ISBN: {ISBN}";
       }
       
        // public int Id { get ; set ;}
        // public string Title { get; set; }
        // public string Author { get; set; }
        // public string ISBN { get; set; }

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