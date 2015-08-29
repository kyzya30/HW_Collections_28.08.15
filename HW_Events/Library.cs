using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace HW_Events
{
   internal class Library
    {
        ObservableCollection<Book> _books = new ObservableCollection<Book>();  
        public  event NotifyCollectionChangedEventHandler CollectionChanged;
        public event ActionsWithBook addBook;
        public event ActionsWithBook removeBook;
       

        public void book_collChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            Console.WriteLine("В библиотеке произошло событие : {0}", e.Action);
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Была добавлена следующая книга:");
                foreach (Book b in e.NewItems)
                {
                    Console.WriteLine(b.ToString());
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Была удалена следующая книга:");
                foreach (Book b in e.OldItems)
                {
                    Console.WriteLine(b.ToString());
                }

                Console.WriteLine("После удаления книги в библиотеке остались следующие книги:");
                foreach (var b in _books)
                {
                    Console.WriteLine("{0} {1} {2}",b.AuthorName, b.BookName , b.Genre);
                }
            }
        }
        public void AddBook(Book book)
        {
            _books.Add(book);
            addBook(book);

            NotifyCollectionChangedEventArgs Args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,book);
            CollectionChanged(this,Args);

        }
        public void RemoveBook(Book book)
        {
            _books.Remove(book);
            removeBook(book);
            NotifyCollectionChangedEventArgs Args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, book);
            CollectionChanged(this, Args);
        }
    }
}
