using NUnit.Framework;
using System;
using FilmStore.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.UnitTests
{
    class FilmTest
    {
        [Test]
        public void ConstructorShouldSetProperties()
        {
            Film film = new FilmBuilder().Build();
            Assert.AreEqual("Aliens", film.Title);
            Assert.AreEqual(new DateTime(1984, 1, 20), film.Released);
            Assert.AreEqual(5, film.Stock);
            Assert.AreEqual(Genre.Science_Fiction, film.Genre);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfStockIsNegative()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Film(1L,"Aliens", new DateTime(1984, 1, 20), -1, Genre.Science_Fiction));
            StringAssert.Contains("Stock cannot be negative!", ex.Message);
           
        }

        [Test]
        public void FilmsWithSameidShouldBeEqual()
        {
            Film film1 = new FilmBuilder().Build();
            Film film2 = new FilmBuilder().WithId(1L).WithTitle("Star Wars: The Empire Strikes Back").ReleasedOn(new DateTime(1987, 1, 21)).WithStockOf(5).WithGenre(Genre.Science_Fiction).Build();

            Assert.AreEqual(film1, film2);
            Assert.AreEqual(film1.GetHashCode(), film2.GetHashCode());
        }

        [Test]
        public void FilmsWithDifferentIdsShouldBeUnequalAndShouldHaveUnequalHashCodes()
        {
            Film film1 = new FilmBuilder().Build();
            Film film2 = new FilmBuilder().WithId(2L).WithTitle("Star Wars: The Empire Strikes Back").ReleasedOn(new DateTime(1987, 1, 21)).WithStockOf(5).WithGenre(Genre.Science_Fiction).Build();

            Assert.AreNotEqual(film1, film2);
            Assert.AreNotEqual(film1.GetHashCode(), film2.GetHashCode());
        }


    }
}