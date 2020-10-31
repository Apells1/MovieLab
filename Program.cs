using System;
using NLog.Web;
using System.IO;
using System.Collections;
using System.Linq;
namespace MediaLibrary
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

            logger.Info("Program started");

            string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
            MovieFile movieFile = new MovieFile("movies.scrubbed.csv");
            string userchoice = "";

            do
            {
                Console.WriteLine("Press 1 to add a movie to a file, 2 to read from a file, or 3 to search for a movie and any other key to quit");
                userchoice = Console.ReadLine();

                if (userchoice == "1")
                {
                    string id = "";
                    string title = "";
                    string director = "";
                    string runTime = "";
                    string genre = "";
                    ArrayList movieGenre = new ArrayList();
                    Console.WriteLine("Please enter movie id");
                    id = Console.ReadLine();
                    Console.WriteLine("Please enter movie title");
                    id = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Please type the movies genre(s) press -1 to stop");
                        genre = Console.ReadLine();

                        if (genre != "-1")
                        {
                            movieGenre.Add(genre);
                        }
                    } while (genre != "-1");
                    string totalGenre = string.Join("|", (string[])movieGenre.ToArray(Type.GetType("System.String")));

                    Console.WriteLine("Please enter movie runtime (h:m:s)");
                    runTime = Console.ReadLine();
                    Console.WriteLine("Please enter movie director");
                    director = Console.ReadLine();


                }
                if (userchoice == "3")
                {
                    Console.WriteLine("please enter the movies title");

                    string search = Console.ReadLine();
                    movieFile.findMovie(search);

                }



            }
            while (userchoice == "1" || userchoice == "2" || userchoice == "3");








            logger.Info("Program ended");
        }
    }
}
