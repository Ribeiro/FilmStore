using NUnit.Framework;
using System;
using FilmStore.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace FilmStore.UnitTests
{
    class FilmTest
    {
        [Test]
        public void ConstructorShouldSetProperties()
        {
            Film film = new FilmBuilder().Build();
            film.Title.Should().Be("Aliens");
            film.Released.Should().Be(new DateTime(1984, 1, 20));
            film.Stock.Should().Be(5);
            film.Genre.Should().Be(Genre.Science_Fiction);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfStockIsNegative()
        {
            Action action = () => new Film(1L, "Aliens", new DateTime(1984, 1, 20), -1, Genre.Science_Fiction);
            action.ShouldThrow<ArgumentOutOfRangeException>().And.Message.Contains("Stock cannot be negative!");
        }

        [Test]
        public void FilmsWithSameidShouldBeEqual()
        {
            Film film1 = new FilmBuilder().Build();
            Film film2 = new FilmBuilder().WithId(1L).WithTitle("Star Wars: The Empire Strikes Back").ReleasedOn(new DateTime(1987, 1, 21)).WithStockOf(5).WithGenre(Genre.Science_Fiction).Build();

            Assert.That(film1, Is.EqualTo(film2));
            Assert.That(film1.GetHashCode(), Is.EqualTo(film2.GetHashCode()));
        }

        [Test]
        public void FilmsWithDifferentIdsShouldBeUnequalAndShouldHaveUnequalHashCodes()
        {
            Film film1 = new FilmBuilder().Build();
            Film film2 = new FilmBuilder().WithId(2L).WithTitle("Star Wars: The Empire Strikes Back").ReleasedOn(new DateTime(1987, 1, 21)).WithStockOf(5).WithGenre(Genre.Science_Fiction).Build();

            Assert.That(film1, Is.Not.EqualTo(film2));
            Assert.That(film1.GetHashCode(), Is.Not.EqualTo(film2.GetHashCode()));
        }

    }

}