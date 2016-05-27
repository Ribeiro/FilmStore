using FilmStore.Core;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmStore.UnitTests
{
    class CollectionFilmRepositoryTest
    {
        private Mock<ISerializer> serializer;
        private static Film film1 = new FilmBuilder().Build();
        private static Film film2 = new FilmBuilder().WithId(2L).WithTitle("Star Wars: The Empire Strikes Back").ReleasedOn(new DateTime(1987, 1, 21)).WithStockOf(5).WithGenre(Genre.Science_Fiction).Build();
        private List<Film> films = new List<Film> { film1, film2 };

        public CollectionFilmRepositoryTest()
        {
            serializer = new Mock<ISerializer>();
        }

        [OneTimeSetUp]
        public void RunOnceForAllTests()
        {
            serializer.Setup(s => s.Read()).Returns(films);
        }

        [Test]
        public void SelectByIdReturnsCorrectFilm()
        {
            CollectionFilmRepository sut = new CollectionFilmRepository(serializer.Object);
            Film retrievedFilm = sut.SelectById(2);
            Assert.AreEqual(film2, retrievedFilm);
        }

        [Test]
        public void InsertAddsFilmToCollection()
        {
            int collectionCountAtTimeOfCall = 0;
            serializer.Setup(s => s.Write(It.IsAny<ICollection<Film>>())).Callback((ICollection<Film> collection) => collectionCountAtTimeOfCall = collection.Count());

            CollectionFilmRepository sut = new CollectionFilmRepository(serializer.Object);

            Film film3 = new FilmBuilder().WithId(3L).WithTitle("Blade Runner").ReleasedOn(new DateTime(1982, 12, 25)).WithStockOf(5).WithGenre(Genre.Science_Fiction).Build();
            long id = sut.Insert(film3);

            Assert.AreEqual(3, collectionCountAtTimeOfCall);
            serializer.Verify(s => s.Write(films), Times.Once);

        }
    }
}
