using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Library library = new Library();

Book book1 = new Book("Приключения Шерлока Холмса", "Артур Конан Дойл", 1892, "Детектив", "978-5-389-11175-0");
Book book2 = new Book("Гарри Поттер и Философский камень", "Дж. К. Роулинг", 1997, "Фэнтези", "978-5-17-126031-3");
Book book3 = new Book("Война и мир", "Лев Толстой", 1869, "Роман", "978-5-389-11175-1");

library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);

Reader reader1 = new Reader("Иван", 123456);

library.AddReader(reader1);

reader1.TakeBook(book1);

List<Book> foundBooks = library.SearchBooks(book => book.Author == "Артур Конан Дойл" && book.Genre == "Детектив");
foreach (var book in foundBooks)
{
    Console.WriteLine($"Найденная книга: {book.Title} ({book.Author})");
}

library.PrintStatistics();

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, int year, string genre, string isbn)
    {
        Title = title;
        Author = author;
        Year = year;
        Genre = genre;
        ISBN = isbn;
    }
}

class Reader
{
    public string Name { get; set; }
    public int LibraryCardNumber { get; set; }
    public List<Book> BooksTaken { get; set; }

    public Reader(string name, int libraryCardNumber)
    {
        Name = name;
        LibraryCardNumber = libraryCardNumber;
        BooksTaken = new List<Book>();
    }

    public void TakeBook(Book book)
    {
        BooksTaken.Add(book);
    }

    public void ReturnBook(Book book)
    {
        BooksTaken.Remove(book);
    }
}

class Library
{
    public List<Book> Books { get; set; }
    public List<Reader> Readers { get; set; }

    public Library()
    {
        Books = new List<Book>();
        Readers = new List<Reader>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
    }

    public void AddReader(Reader reader)
    {
        Readers.Add(reader);
    }

    public void RemoveReader(Reader reader)
    {
        Readers.Remove(reader);
    }

    public List<Book> SearchBooks(Func<Book, bool> criteria)
    {
        return Books.Where(criteria).ToList();
    }

    public void PrintStatistics()
    {
            }
}

