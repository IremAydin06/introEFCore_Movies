using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introEFCore.Models
{
    public class Artist
    {
        //Bir oyuncunun ......... vardır.

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }


        public IList<MovieArtist> Movies { get; set; }  //Sanatçı-film bağlantısı. Bir sanatçının çok filmi olabilir.


    }
}
