using System;
using System.Linq;

namespace CDStore
{
    class Program
    {
        static void Main()
        {
            var context = new CDStoreDbContext();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.Write("\n\nEnter 1 to add an Artist \n2 to List Artists \n3 Find artist \n4 List Songs on CDs \n5 Create CD\n9 to Quit : ");
                char key = Console.ReadLine()[0];
                switch (key)
                {
                    case '1':
                        AddArtist(context);
                        break;
                    case '2':
                        ListArtists(context);
                        break;
                    case '3':
                        FindArtist(context);
                        break;
                    case '4':
                        FindCDByTitle(context);
                        break;
                    case '5':
                        CreateCD(context);
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                }
            }
        }

        private static void CreateCD(CDStoreDbContext context)
        {
            Console.Write("Enter name of new CD: ");
            string title = Console.ReadLine();
            CD cd = new CD() { Title = title };
            Console.WriteLine("Saving ...");
            context.CDs.Add(cd);
            context.SaveChanges();

            Console.WriteLine("Enter Songs's name: ");
            var name = Console.ReadLine();
            var song = context.Songs.FirstOrDefault(x => x.Title.Contains(name));
            Console.WriteLine("Songs: " + song.Title);
    
        }

        private static Song NewSong(CDStoreDbContext context)
        {
            Console.Write("Enter name of new Song: ");
            string name = Console.ReadLine();
            Song a = new Song() { Title = name };
            Console.WriteLine("Saving ...");
            context.Songs.Add(a);
            context.SaveChanges();
            return a;
        }

        private static void FindCDByTitle(CDStoreDbContext context)
        {
            Console.WriteLine("Enter CD's name: ");
            var name = Console.ReadLine();
            var cd = context.CDs.FirstOrDefault(a => a.Title.Contains(name));
            Console.WriteLine("CD: " + cd.Title);
            foreach (Song s in cd.Songs)
            {
                Console.WriteLine(s.Title + "\t" + s.Artist.Name);
            }

        }

        private static void FindArtist(CDStoreDbContext context)
        {
            Console.WriteLine("Enter Artist's name: ");
            var name = Console.ReadLine();
            var artist = context.Artists.FirstOrDefault(a => a.Name.Contains(name));
            Console.WriteLine("Artist: " + artist.Name);
            foreach (Song s in artist.Songs)
            {
                Console.WriteLine(s.Title + "\t" + s.MusicType);
            }
            Console.WriteLine("Do you want to add a new song? yes or no:");
            string choice = Console.ReadLine();
            if (choice == "yes") 
            {
                Song BrandNewSong = NewSong(context);
                artist.Songs.Add(BrandNewSong);
            }

        }

        private static void ListArtists(CDStoreDbContext context)
        {
            foreach (Artist a in context.Artists)
            {
                Console.WriteLine(a.Name + " " + a.ArtistId);
            }
            Console.WriteLine();
        }

        private static void AddArtist(CDStoreDbContext context)
        {
            Console.Write("Enter name of new Artist: ");
            string name = Console.ReadLine();
            Artist a = new Artist() { Name = name };
            Console.WriteLine("Saving ...");
            context.Artists.Add(a);
            context.SaveChanges();
        }
    }
}

    


