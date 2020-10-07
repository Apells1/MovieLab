using System;
using NLog.Web;
using System.IO;
using System.Collections; 
namespace MediaLibrary
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

            logger.Info("Program started");

        //    Movie movie = new Movie
        //     {
        //         mediaId = 123,
        //         title = "Greatest Movie Ever, The (2020)",
        //         director = "Jeff Grissom",
        //         // timespan (hours, minutes, seconds)
        //         runningTime = new TimeSpan(2, 21, 23),
        //         genres = { "Comedy", "Romance" }
        //     };
        //     Album album = new Album
        //     {
        //         mediaId = 321,
        //         title = "Greatest Album Ever, The (2020)",
        //         artist = "Jeff's Awesome Band",
        //         recordLabel = "Universal Music Group",
        //         genres = { "Rock" }
        //     };
        //       Book book = new Book
        //     {
        //         mediaId = 111,
        //         title = "Super Cool Book",
        //         author = "Jeff Grissom",
        //         pageCount = 101,
        //         publisher = "",
        //         genres = { "Suspense", "Mystery" }
        //     };
        //     Console.WriteLine(book.Display());
        //     Console.WriteLine(album.Display());
        //     Console.WriteLine(movie.Display());
string scrubbedFile = FileScrubber.ScrubMovies("movies.csv");
            logger.Info(scrubbedFile);
            logger.Info("Program ended");
            MediaLibrary.MovieFile mv = new MediaLibrary.MovieFile();
            string id = "";
            string title = "";
            string genre = "";
            string director = "";
            string time = "";
            string userchoice = "";
            
            ArrayList movieGenre = new ArrayList();
            do{
                Console.WriteLine("type 1 to add a movie or 2 to read all movies and anything else to end");
                userchoice = Console.ReadLine();
                if(userchoice == "1"){
                    Console.WriteLine("Please type the movies ID");
                    id = Console.ReadLine();
                    Console.WriteLine("Please type the movies Title");
                    title = Console.ReadLine();

                    do{
                        Console.WriteLine("Please type the movies genre(s) press -1 to stop");
                    genre = Console.ReadLine();

                    if(genre != "-1"){
                        movieGenre.Add(genre);
                    }
                    }while(genre != "-1");
                    string totalGenre = string.Join("|", (string[])movieGenre.ToArray(Type.GetType("System.String")));
                     Console.WriteLine("Please type the movies director (or blank if not known)");
                    director = Console.ReadLine();
                     Console.WriteLine("Please type the movies runtime (h:m:s)");
                    time = Console.ReadLine();
                 mv.addMovie(id, title, genre, director, time);



                }
                if(userchoice == "2"){
                    mv.readMovie();
                }

            }
            while(userchoice == "1" || userchoice == "2");

         
//  ticketClasser.Cvs cvs =new ticketClasser.Cvs();
            
        }
    }
}
