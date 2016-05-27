using FilmStore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.UnitTests
{
    public class FilmBuilder
    {
        private long id = 1L;
        private string title = "Aliens";
        private DateTime released = new DateTime(1984, 1, 20);
        private int stock = 5;
        private Genre genre = Genre.Science_Fiction;

        public Film Build()
        {
            return new Film(id, title, released, stock, genre);
        }

        public FilmBuilder WithId(long number)
        {
            this.id = number;
            return this;
        }

        public FilmBuilder WithTitle(string name)
        {
            this.title = name;
            return this;
        }

        public FilmBuilder ReleasedOn(DateTime releaseDate)
        {
            this.released = releaseDate;
            return this;
        }

        public FilmBuilder WithStockOf(int quantity)
        {
            this.stock = quantity;
            return this;
        }

        public FilmBuilder WithGenre(Genre filmGenre)
        {
            this.genre = filmGenre;
            return this;
        }

        public static implicit operator Film(FilmBuilder instance)
        {
            return instance.Build();
        }

    }
}