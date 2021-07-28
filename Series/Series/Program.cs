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
                    case "6":
                        FilterByGenre();
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

            // Executes if catalog is empty
            if(list.Count == 0)
            {
                Console.WriteLine("Catalog is currently empty.");
                return;
            }

            // Lists each item from catalog
            foreach (var item in list)
            {
                Console.Write("#ID {0} - {1}", item.GetId(), item.GetTitle());
                // Executes if item was removed from catalog
                // Removed items can be updated
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

            // Calls function to get player input that returns the Movie object
            Movie newMovie = MovieDetailsInput(repository.NextId());
            // If some input was invalid the Movie object is null
            if (newMovie == null) return;
            repository.Insert(newMovie);
        }

        static void UpdateItem()
        {
            Console.WriteLine("Update a movie's details:");
            Console.Write("Insert ID of movie to be updated: ");

            // Function that checks if string input can be parsed as int
            // Returns -1 if parsing isn't possible
            int idInput = CheckIntInput(Console.ReadLine());
            // Function that checks if id is in list's scope
            if (!repository.CheckId(idInput))
            {
                ErrorMessage();
                return;
            }

            // Calls function to get player input that returns the Movie object
            Movie updatedMovie = MovieDetailsInput(idInput);
            // If some input was invalid the Movie object is null
            if (updatedMovie == null) return;
            repository.Update(idInput, updatedMovie);

            Console.WriteLine();
            Console.WriteLine("Movie successfully updated.");
        }

        static void RemoveItem()
        {
            Console.WriteLine("Remove a movie:");
            Console.Write("Insert ID of movie to be removed: ");

            // Function that checks if string input can be parsed as int
            // Returns -1 if parsing isn't possible
            int idInput = CheckIntInput(Console.ReadLine());
            // Function that checks if id is in list's scope
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

            // Function that checks if string input can be parsed as int
            // Returns -1 if parsing isn't possible
            int idInput = CheckIntInput(Console.ReadLine());
            // Function that checks if id is in list's scope
            if (!repository.CheckId(idInput))
            {
                ErrorMessage();
                return;
            }
            var movie = repository.GetById(idInput);

            Console.WriteLine();
            Console.Write(movie);
        }

        static void FilterByGenre()
        {
            foreach (int i in Enum.GetValues<Genre>())
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Select a movie genre from list above: ");
            // Function that checks if string input is int and in Genre's range
            // Returns -1 in case of wrong input
            int genre = ReceiveGenreInput();
            if (genre < 0) return;

            var list = repository.GetList();

            if (list.Count == 0)
            {
                Console.WriteLine("Catalog is currently empty.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Catalog of " + Enum.GetName(typeof(Genre), genre) + " titles:");

            // Variable to show message in case no movies of the selected genre exist
            bool moviesInGenre = false;
            foreach (var item in list)
            {
                if (item.GetGenre() == genre)
                {
                    Console.Write("#ID {0} - {1}", item.GetId(), item.GetTitle());
                    if (item.GetWasRemoved())
                    {
                        Console.Write(" (Removed from catalog)");
                    }
                    Console.WriteLine();
                    moviesInGenre = true;
                }
            }
            if(!moviesInGenre)
            {
                Console.WriteLine();
                Console.WriteLine("No movies of this genre in catalog.");
            }
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
            Console.WriteLine("6- Filter catalog by genre");
            Console.WriteLine("C- Clear screen");
            Console.WriteLine("X- Exit application");
            Console.WriteLine();

            // This input doesn't need check because the default in the switch
            // already handles the exceptions
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
            // Function that checks if string input is int and in Genre's range
            // Returns -1 in case of wrong input
            int genre = ReceiveGenreInput();
            if (genre < 0) return null;

            Console.Write("Enter the name of the movie: ");
            string name = Console.ReadLine();

            Console.Write("Enter the year the movie was published: ");
            // Checks if string can be parsed as int
            int year = CheckIntInput(Console.ReadLine());
            if(year < 0)
            {
                ErrorMessage();
                return null;
            }

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

        static int ReceiveGenreInput()
        {
            int genre = CheckIntInput(Console.ReadLine());
            if(Enum.IsDefined(typeof(Genre), genre))
            {
                return genre;
            }

            ErrorMessage();
            return -1;
        }

        // Displays an error message in case of invalid input
        static void ErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("# Invalid input or ID.");
        }
    }
}
