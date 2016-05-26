using System.Collections.Generic;

namespace FilmStore.Core
{
    public interface ISerializer
    {
       ICollection<Film> Read();
       void Write(ICollection<Film> film); 
        
    }
}