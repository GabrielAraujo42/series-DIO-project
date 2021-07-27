using System;
using Series.Classes;

namespace Series
{
    class Program
    {
        static MovieRepository repository = new MovieRepository();

        static void Main(string[] args)
        {
            string userInput = GetUserInput();

            while(userInput != "X")
            {
                switch (userInput)
                {
                    case "1":
                        ListCatalog();
                        break;
                    case "2":
                        InsertItem();
                        break;
                    case "3":
                        UpdateItem();
                        break;
                    case "4":
                        RemoveItem();
                        break;
                    case "5":
                        VisualizeDetails();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please type a valid command.");
                        break;
                }

                userInput = GetUserInput();
            }

            Console.WriteLine("Goodbye!");
        }

        static void ListCatalog()
        {
            Console.WriteLine("Catalog:");

            var list = repository.GetList();

            if(list.Count == 0)
            {
                Console.WriteLine("Catalog is currently empty.");
                return;
            }

            foreach(var item in list)
            {
                Console.Write("#ID {0} - {1}", item.GetId(), item.GetTitle());
                if (item.GetWasRemoved())
                {
                    Console.Write(" (Removed from catalog)");
                }
                Console.WriteLine();
            }
        }

        static void InsertItem()
        {
            Console.WriteLine("Insert new movie:");

            Movie newMovie = MovieDetailsInput(repository.NextId());
            repository.Insert(newMovie);
        }

        static void UpdateItem()
        {
            Console.WriteLine("Update a movie's details:");
            Console.Write("Insert ID of movie to be updated: ");

            int idInput = CheckIntInput(Console.ReadLine());
            if (!repository.CheckId(idInput))
            {
                ErrorMessage();
                return;
            }

            Movie updatedMovie = MovieDetailsInput(idInput);
            repository.Update(idInput, updatedMovie);

            Console.WriteLine();
            Console.WriteLine("Movie successfully updated.");
        }

        static void RemoveItem()
        {
            Console.WriteLine("Remove a movie:");
            Console.Write("Insert ID of movie to be removed: ");

            int idInput = CheckIntInput(Console.ReadLine());
            if (!repository.CheckId(idInput))
            {
                ErrorMessage();
                return;
            }

            repository.Remove(idInput);

            Console.WriteLine();
            Console.WriteLine("Movie successfully removed.");
        }

        static void VisualizeDetails()
        {
            Console.WriteLine("Visualize a movie's details:");
            Console.Write("Insert ID of movie to be visualized: ");

            int idInput = CheckIntInput(Console.ReadLine());
            if (!repository.CheckId(idInput))
            {
                ErrorMessage();
                return;
            }
            var movie = repository.GetById(idInput);

            Console.WriteLine();
            Console.Write(movie);
        }

        static string GetUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Movie Catalog project!");
            Console.WriteLine("Select an option:");

            Console.WriteLine("1- Show catalog");
            Console.WriteLine("2- Insert new entry");
            Console.WriteLine("3- Update existing item");
            Console.WriteLine("4- Remove item from catalog");
            Console.WriteLine("5- Visualize item details");
            Console.WriteLine("C- Clear screen");
            Console.WriteLine("X- Exit application");
            Console.WriteLine();

            string input = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return input;
        }

        static Movie MovieDetailsInput(int id)
        {
            foreach (int i in Enum.GetValues<Genre>())
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Select a movie genre from list above: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Enter the name of the movie: ");
            string name = Console.ReadLine();

            Console.Write("Enter the year the movie was published: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter the movie's description: ");
            string desc = Console.ReadLine();

            Movie newMovie = new Movie(id, (Genre)genre, name, desc, year);
            return newMovie;
        }

        static int CheckIntInput(string value)
        {
            if(int.TryParse(value, out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }

        static void ErrorMessage()
        {
            Console.WriteLine("#");
            Console.WriteLine("# Invalid command or ID.");
            Console.WriteLine("#");
        }
    }
}
