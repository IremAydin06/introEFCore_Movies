using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introEFCore.Models
{
    public class Genre
    {
        //Bir türün ......... vardır.

        public int Id { get; set; }

        public string Name { get; set; }


        public IList<Movie> Movies{ get; set; }   //Tür-Film bağlantısı. Bir türün birden çok filmi olabilir.

    }
}
