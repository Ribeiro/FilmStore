using System;

namespace FilmStore.Core
{
    public class Film
    {
        

        public Film(long id, string title, DateTime released, int stock, Genre genre)
        {
            assertValid(stock);
            this.Id = id;
            this.Title = title;
            this.Released = released;
            this.Stock = stock;
            this.Genre = genre;
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int Stock { get; set; }
        public Genre Genre { get; set; }

        private void assertValid(int stock)
        {
            if(stock < 0 )
            {
                throw new ArgumentOutOfRangeException("Stock cannot be negative!");
            }

        }

        public override bool Equals(object obj)
        {
            return (null != obj) && (obj is Film) && (this.Id == ((Film)obj).Id);

        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 13;
                hashCode = (hashCode * 397) ^ Convert.ToInt32(Id);
                return hashCode;
            }
        }
    }
}