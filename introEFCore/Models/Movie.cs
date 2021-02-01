using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace introEFCore.Models
{
    public class Movie
    {
        //Bir filmin ............ vardır.
       //Mesela string boş geçilebilir ama double boş geçilemez.Primitive tipler boş geçilemez. Complex tipler boş geçilebilirdir.

        public int Id { get; set; }
        [MaxLength(50)]                  //Maksimum uzunluğu belirttik. (DB de yaptığımız gibi)
        [Required]                      //Boş geçilemez yaptık.
        public string Name { get; set; }

        public double Rating { get; set; }

        public string Summary { get; set; }

        public DateTime? ReleaseDate { get; set; }     //Boş geçilebilir olması için sonuna ? ekledik.

        public string Country { get; set; }


        public int DirectorId { get; set; }   //Yönetmen-Film bağlantısı. Bir filmin bir yönetmeni var.
        public Director Director { get; set; }

        public int GenreId { get; set; }    //Tür-Film bağlantısı. Bir filmin bir türü var.
        public Genre Genre { get; set; }

        public IList<MovieArtist> Artists { get; set; }  //Oyuncu-Film bağlantısı. Bir filmin birden çok oyuncusu olabilir.


    }
}
