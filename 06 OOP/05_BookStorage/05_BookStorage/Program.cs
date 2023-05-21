namespace _05_BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new BookStorage().Run();
        }
    }

    class BookStorage
    {
        private List<Book> _books;

        public BookStorage()
        {
            _books = new List<Book>();
        }

        public void Run()
        {
            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandBooksByParameter = "4";
            const string CommandExit = "5";

            bool isProgramWork = true;

            while (isProgramWork)
            {
                Console.WriteLine($"{CommandAddBook}. Добавить книгу.");
                Console.WriteLine($"{CommandRemoveBook}. Убрать книгу.");
                Console.WriteLine($"{CommandShowAllBooks}. Показать все книги.");
                Console.WriteLine($"{CommandBooksByParameter}. Показать книги по параметру.");
                Console.WriteLine($"{CommandExit}. Выйти.");
                Console.Write("Введите команду: ");

                string userInput = Console.ReadLine();
                Console.WriteLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        AddBook();
                        break;

                    case CommandRemoveBook:
                        RemoveBook();
                        break;

                    case CommandShowAllBooks:
                        ShowAllBooks();
                        break;

                    case CommandBooksByParameter:
                        ShowByParameter();
                        break;

                    case CommandExit:
                        isProgramWork = false;
                        break;
                }
            }
        }

        private void ShowByParameter()
        {
            const string CommandShowByName = "1";
            const string CommandShowByAuthor = "2";
            const string CommandShowByYear = "3";
            const string CommandExit = "4";

            bool isChosen = false;

            while (isChosen == false)
            {
                Console.WriteLine($"{CommandShowByName}. Показать по названию.");
                Console.WriteLine($"{CommandShowByAuthor}. Показать по автору.");
                Console.WriteLine($"{CommandShowByYear}. Показать по году.");
                Console.WriteLine($"{CommandExit}. Выйти из меню.");
                Console.Write("Введите команду: ");

                string userInput = Console.ReadLine();
                Console.WriteLine();

                switch (userInput)
                {
                    case CommandShowByName:
                        ShowBooks(GetBooksByName());
                        break;

                    case CommandShowByAuthor:
                        ShowBooks(GetBooksByAuthor());
                        break;

                    case CommandShowByYear:
                        ShowBooks(GetBooksByYear());
                        break;

                    case CommandExit:
                        isChosen = true;
                        break;

                    default:
                        Console.WriteLine("Команда не корректна!");
                        break;
                }
            }
        }

        private Dictionary<int, Book> GetBooksByYear()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            int year = TryGetInt("Введите год ");

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Year == year)
                {
                    books.Add(i, _books[i]);
                }
            }

            return books;
        }

        private Dictionary<int, Book> GetBooksByAuthor()
        {
            Console.Write("Введите автора ");
            string userInput = Console.ReadLine();
            Dictionary<int, Book> books = new Dictionary<int, Book>();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Author.ToLower() == userInput.ToLower())
                {
                    books.Add(i, _books[i]);
                }
            }

            return books;
        }

        private Dictionary<int, Book> GetBooksByName()
        {
            Console.Write("Введите название ");
            string userInput = Console.ReadLine();
            Dictionary<int, Book> books = new Dictionary<int, Book>();

            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Name.ToLower() == userInput.ToLower())
                {
                    books.Add(i, _books[i]);
                }
            }

            return books;
        }

        private void ShowBooks(Dictionary<int, Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Таких книг нету.");
            }

            foreach (var book in books)
            {
                Console.WriteLine(book.Key + ". " + book.Value.Name + " " + book.Value.Author + " " + book.Value.Year);
            }

            Console.WriteLine();
        }

        private void ShowAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Книг нету.\n");
                return;
            }

            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine(i + ". " + _books[i].Name + " " + _books[i].Author + " " + _books[i].Year);
            }

            Console.WriteLine();
        }

        private void RemoveBook()
        {
            int index = TryGetInt("Введите индекс ");

            if (index >= 0 && index < _books.Count)
            {
                _books.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Некорректный индекс");
            }

            Console.WriteLine();
        }

        private int TryGetInt(string message)
        {
            string userInput;
            int number = 0;
            bool isInt = false;

            while (isInt == false)
            {
                Console.Write(message);
                userInput = Console.ReadLine();
                isInt = int.TryParse(userInput, out number);

                if (isInt == false)
                {
                    Console.WriteLine("Ошибка! Введите число!");
                }
            }

            return number;
        }

        private void AddBook()
        {
            string name;
            string author;
            int year;

            Console.Write("Введите название ");
            name = Console.ReadLine();
            Console.Write("Введите автора ");
            author = Console.ReadLine();
            year = TryGetInt("Введите год ");
            _books.Add(new Book(name, author, year));
            Console.WriteLine();
        }
    }

    class Book
    {
        public Book(string name, string author, int year)
        {
            Name = name;
            Author = author;
            Year = year;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
    }
}