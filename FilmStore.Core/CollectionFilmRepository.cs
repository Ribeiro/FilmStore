using System.Collections.Generic;
using System.Linq;

namespace FilmStore.Core
{
    public class CollectionFilmRepository
    {
        private ISerializer serializer;

        public CollectionFilmRepository(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        public long Insert(Film film)
        {
            ICollection<Film> films = serializer.Read();
            films.Add(film);
            serializer.Write(films);
            return film.Id;
        }

        public Film SelectById(long id)
        {
            ICollection<Film> films = serializer.Read();
            return films.FirstOrDefault(f => f.Id == id);
        }
    }
}