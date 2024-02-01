using System.Collections;
using System.Collections.Generic;

namespace _25_01_Ht
    
{
    internal class Program
    {
        public enum Genre
        {
            Action,
            Comedy,
            Drama,
            Horror,
            SciFi,
            Romance,
            Other
        }

        public class Director : ICloneable
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public object Clone()
            {
                return new Director { Name = this.Name, Age = this.Age };
            }

            public override string ToString()
            {
                return $"Director: {Name}, Age: {Age}";
            }
        }

        public class Movie : IComparable<Movie>, ICloneable
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public Director Director { get; set; }
            public string Country { get; set; }
            public Genre Genre { get; set; }
            public int Year { get; set; }
            public double Rating { get; set; }

            public int CompareTo(Movie other)
            {
                return this.Year.CompareTo(other.Year);
            }

            public object Clone()
            {
                return new Movie
                {
                    Title = this.Title,
                    Description = this.Description,
                    Director = (Director)this.Director.Clone(),
                    Country = this.Country,
                    Genre = this.Genre,
                    Year = this.Year,
                    Rating = this.Rating
                };
            }

            public override string ToString()
            {
                return $"Title: {Title}, Director: {Director}, Country: {Country}, Genre: {Genre}, Year: {Year}, Rating: {Rating}";
            }
        }

        public class Cinema : IEnumerable<Movie>
        {
            private List<Movie> movies;

            public Cinema()
            {
                movies = new List<Movie>();
            }

            public void AddMovie(Movie movie)
            {
                movies.Add(movie);
            }

            public IEnumerator<Movie> GetEnumerator()
            {
                return movies.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void SortMovies(IComparer<Movie> comparer)
            {
                movies.Sort(comparer);
            }

            public override string ToString()
            {
                return string.Join("\n", movies);
            }
        }

        public class RatingComparer : IComparer<Movie>
        {
            public int Compare(Movie x, Movie y)
            {
                return x.Rating.CompareTo(y.Rating);
            }
        }
        
            static void Main()
            {
                Cinema cinema = new Cinema();

                cinema.AddMovie(new Movie
                {
                    Title = "Interstellar",
                    Description = "Science Fantasy",
                    Director = new Director { Name = "Christopher Nolan", Age = 50 },
                    Country = "USA",
                    Genre = Genre.SciFi,
                    Year = 2010,
                    Rating = 8.8
                });

                cinema.AddMovie(new Movie
                {
                    Title = "The Shawshank Redemption",
                    Description = "Drama about hope and redemption",
                    Director = new Director { Name = "Frank Darabont", Age = 62 },
                    Country = "USA",
                    Genre = Genre.Drama,
                    Year = 1994,
                    Rating = 9.3
                });

                cinema.AddMovie(new Movie
                {
                    Title = "The Dark Knight",
                    Description = "Superhero action film",
                    Director = new Director { Name = "Christopher Nolan", Age = 50 },
                    Country = "USA",
                    Genre = Genre.Action,
                    Year = 2008,
                    Rating = 9.0
                });

                Console.WriteLine("Original Order:");
                Console.WriteLine(cinema);

                cinema.SortMovies(new RatingComparer());

                Console.WriteLine("\nSorted by Rating:");
                Console.WriteLine(cinema);
            }
        
    }
}