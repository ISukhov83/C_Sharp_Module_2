using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_2_Lab_1
{
    interface ILibraryUser
    {
        void AddBook(string New_Book_Name);
        void RemoveBook(string Remove_Book_Name);
        void BooksInfo();
    }

    class BooksCollection
    {
        private Int32 Books_Limit=20;
        public BooksCollection(Int32 Books_Count)
        {
            Books_Limit = Books_Count;
        }
        public string[] Books_Array = new String[20/*Books_Limit*/]; /*не получается задать размер масива при инициализации экземпляра*/
        private string[] Books_Array_For_Del = new String[20/*Books_Limit*/]; /*не получается задать размер масива при инициализации экземпляра*/
        public void AddBook(string New_Book_Name)
        {
            for(Int32 i=0; i<= Books_Limit- 1; i++)
            {
                if (Books_Array[i] == null || Books_Array[i] == "")
                {
                    Books_Array[i] = New_Book_Name;
                    break;
                }
                //Books_Array[1] = "jjj";

            }
        }
        private Int32 j = 0;
        public void Remove_Book(string Remove_Book_Name)
        {
            j = 0;
            for(Int32 i=0; i<= Books_Limit- 1; i++)
                if(Books_Array[i]!= Remove_Book_Name)
                {
                    Books_Array_For_Del[j] = Books_Array[i];
                    j++;
                };
            for (Int32 i = 0; i <= Books_Limit - 1; i++)
                Books_Array[i] = Books_Array_For_Del[i];
        }
    }

    class LibraryUser: ILibraryUser
    {
        readonly string FirstName;
        readonly string LastName;
        readonly Int32 Id;
        public string Phone { get; set; }
        readonly Int32 BooksLimit;
        private Int32 BooksCount;
        public LibraryUser(string FirstName, string LastName, Int32 Id, Int32 BooksLimit_cunstruct)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Id = Id;
            BooksLimit = BooksLimit_cunstruct;
        }
        private BooksCollection User_BooksList = new BooksCollection(20/*BooksLimit*/); /*не получается задать размер масива при инициализации экземпляра*/
        public void AddBook(string New_Book_Name)
        {
            User_BooksList.AddBook(New_Book_Name);
        }
        public void RemoveBook(string Remove_Book_Name)
        {
            User_BooksList.Remove_Book(Remove_Book_Name);
        }
        public void BooksInfo()
        {
            BooksCount = 0;
            for (Int32 i = 0; i <= BooksLimit-1; i++)
                if (User_BooksList.Books_Array[i] != null && User_BooksList.Books_Array[i] != "")
                    BooksCount++;

            //Console.Clear();
            Console.WriteLine("User_ID: {0}   Full name: {1} {2}", Id.ToString(), FirstName, LastName);
            if(BooksCount>=1)
            for(Int32 i=1; i<= BooksCount; i++)
            {
                Console.WriteLine("Book №{0}   Book name: {1}", (i).ToString(), User_BooksList.Books_Array[i-1]);
            }
            Console.WriteLine("User books limit: {0}, current books count: {1}", BooksLimit, BooksCount);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            LibraryUser User_1 = new LibraryUser("Serhey", "Prybaten", 1, 20);
            LibraryUser User_2 = new LibraryUser("Olha", "Popova", 2, 10);
            User_1.AddBook("Mobi Dick");
            User_2.AddBook("Pither Pen");
            User_1.AddBook("Three pigs");
            User_2.AddBook("Zapovit");
            User_1.AddBook("Lesya Ukrainka");
            User_2.AddBook("C# Advanced");
            Console.WriteLine("*************************************************************");
            Console.WriteLine("Старт лабы");
            Console.WriteLine();
            User_1.BooksInfo();
            Console.WriteLine();
            User_2.BooksInfo();
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("Отработка добавления новых книг");
            Console.WriteLine("Добавляем первому пользователю новую книгу: Bible");
            User_1.AddBook("Bible");
            Console.WriteLine();
            User_1.BooksInfo();
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
            Console.WriteLine("Отработка Удаления книг книг");
            Console.WriteLine("Удаляем у первого пользователя книгу: Three pigs");
            Console.WriteLine();
            User_1.RemoveBook("Three pigs");
            User_1.BooksInfo();
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}
