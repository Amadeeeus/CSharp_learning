class Program
{
static void Main()
{
    var books = new List<Book>{
        new Book { Title = "Dune", Author = "Frank Herbert", Year = 1965, Pages = 412, Genre = "Science Fiction" },
        new Book { Title = "Neuromancer", Author = "William Gibson", Year = 1984, Pages = 271, Genre = "Science Fiction" },
        new Book { Title = "The Martian", Author = "Andy Weir", Year = 2011, Pages = 384, Genre = "Science Fiction" },
        new Book { Title = "Foundation", Author = "Isaac Asimov", Year = 1951, Pages = 244, Genre = "Science Fiction" },
        new Book { Title = "Snow Crash", Author = "Neal Stephenson", Year = 1992, Pages = 470, Genre = "Science Fiction" },
        new Book { Title = "Altered Carbon", Author = "Richard K. Morgan", Year = 2002, Pages = 384, Genre = "Science Fiction" },
        new Book { Title = "The Hunger Games", Author = "Suzanne Collins", Year = 2008, Pages = 374, Genre = "Science Fiction" },
        new Book { Title = "Ready Player One", Author = "Ernest Cline", Year = 2011, Pages = 374, Genre = "Science Fiction" },
        new Book { Title = "The Road", Author = "Cormac McCarthy", Year = 2006, Pages = 287, Genre = "Science Fiction" }
    };

    var sortedbooks = books.Where(x=>x.Genre=="Science Fiction" && x.Year>2000 && x.Pages >300).OrderByDescending(x=>x.Pages).Take(3).Select(x=>x.Title).ToList();
    foreach(var i in sortedbooks)
    {
        Console.WriteLine(i);
    }

}
}
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
}
