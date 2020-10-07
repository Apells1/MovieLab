using System;
using System.Collections.Generic;
using System.IO;
using System.Collections; 
namespace MediaLibrary
{
    public abstract class Media
    {
        // public properties
        public UInt64 mediaId { get; set; }
        public string title { get; set; }
        public List<string> genres { get; set; }

        // constructor
        public Media()
        {
            genres = new List<string>();
        }

        // public method
        public virtual string Display()
        {
            return $"Id: {mediaId}\nTitle: {title}\nGenres: {string.Join(", ", genres)}\n";
        }
    }
    public class Movie : Media
    {
public string director { get; set; }
        public TimeSpan runningTime { get; set; }
         public override string Display()
        {
            return $"Id: {mediaId}\nTitle: {title}\nDirector: {director}\nRun time: {runningTime}\nGenres: {string.Join(", ", genres)}\n";
        }
    }
     public class Album : Media
    {
        public string artist { get; set; }
        public string recordLabel { get; set; }

        public override string Display()
        {
            return $"Id: {mediaId}\nTitle: {title}\nArtist: {artist}\nLabel: {recordLabel}\nGenres: {string.Join(", ", genres)}\n";
        }
    }
    public class Book : Media
    {
        public string author { get; set; }
        public UInt16 pageCount { get; set; }
        public string publisher { get; set; }

        public override string Display()
        {
            return $"Id: {mediaId}\nTitle: {title}\nAuthor: {author}\nPages: {pageCount}\nPublisher: {publisher}\nGenres: {string.Join(", ", genres)}\n";
        }
    }
    public class MovieFile : Media{

    public void addMovie(string id, string title, string genre, string director, string time){
        //make id and check for quotation marks 
        string id2 = id;
        string title2 = title;
        string genre2 = genre;
        string director2 = director;
        if(director2 == ""){
            director2 = "unassigned";
        }
        string time2 = time;

            double testForComma = title2.IndexOf(',');
            if(testForComma == -1){
                 using (StreamWriter sw = new StreamWriter("movies.scrubbed.csv", true))
            {
                string liner = id2+", "+title2+", "+genre2+", "+director2+", "+time2;

                 sw.WriteLine(liner);
         
            }
            }
            if(testForComma != -1){
                title2 = '"'+title2+'"';
                 using (StreamWriter sw = new StreamWriter("movies.scrubbed.csv", true))
            {
                string liner = id2+", "+title2+", "+genre2+", "+director2+", "+time2;

                 sw.WriteLine(liner);
         
            }
            }

    }
public void readMovie(){

      using(StreamReader sr = new StreamReader("movies.scrubbed.csv")) {
           ArrayList movieNumber = new ArrayList();
              ArrayList movieTitle = new ArrayList();
              ArrayList movieGenre = new ArrayList();
              ArrayList userGenre = new ArrayList();
              ArrayList movieDirector = new ArrayList();
              ArrayList movieTime = new ArrayList();
                      sr.ReadLine();
                 while(!sr.EndOfStream) {
                 string reader = sr.ReadLine();
                   double testForComma = reader.IndexOf('"');
                        if (testForComma == -1)
                        {
                            if(reader != null){
                                 string[] entireLine = reader.Split(',');
                                  movieNumber.Add(int.Parse(entireLine[0]));
                      
                           movieTitle.Add(entireLine[1]);
                           
                          var testVar = entireLine[2].Replace("|", ", ");
                           movieGenre.Add(testVar);
                              movieDirector.Add(entireLine[3]);
                              movieTime.Add(entireLine[4]);
                            }
                           
                        }
                        else
                        {
                            
                           if(reader != null){
                                 string[] entireLine = reader.Split('"');
                                  
                                   string removeId = entireLine[0].Replace("," , "");
                                     string removeGenre = entireLine[2].Replace("," , "");

                                        string[] extra = entireLine[2].Split(",");
                                        // for(int x = 0; x < extra.Length; x++){
                                        //     Console.WriteLine(extra[0]);
                                        // }

                                     movieNumber.Add(int.Parse(removeId));
                      
                                    movieTitle.Add(entireLine[1]);
                           
                          var testVar = extra[1].Replace("|", ", ");
                           movieGenre.Add(testVar);
                             movieDirector.Add(extra[2]);
                              movieTime.Add(extra[3]);
                            
    
                       

                            }
                        }

                 
    }
    for(var x = 0; x < movieNumber.Count; x++){
       
          Console.WriteLine("{0,-15}{1,12}","Movie Id:", movieNumber[x] );
           Console.WriteLine("{0,-15}{1,12}","Movie Title:", movieTitle[x] );
            Console.WriteLine("{0,-15}{1,12}","Movie Genre:", movieGenre[x] );
              Console.WriteLine("{0,-15}{1,12}","Movie Director:", movieDirector[x] );
               Console.WriteLine("{0,-15}{1,12}","Movie Runtime:", movieTime[x] );
            Console.WriteLine();
            
    }
  }
}


    }
}