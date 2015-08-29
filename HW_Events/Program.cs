namespace HW_Events
{
    delegate void ActionsWithBook(Book book);
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            library.CollectionChanged += library.book_collChanged;
            Student firstStudent = new Student("Saveliy","Prokopenko",23);
            Student secondStudent = new Student("Pavlo","Tarasenko",23);
            library.addBook += firstStudent.NewBookComputerLiterature;
            library.addBook += secondStudent.NewBookFantastik;
            library.removeBook += secondStudent.RemovedBookFromLibrary;
            Book book1 = new Book("BookName1", "AuthorName1", "Fantastic");
            library.AddBook(book1);
            Book book2 = new Book("BookName2", "AuthorName2", "ComputerLiterature");
            library.AddBook(book2);
            library.AddBook(book2);
            library.AddBook(book2);
            library.RemoveBook(book2);


        }
    }
}
