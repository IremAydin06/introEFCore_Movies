using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introEFCore.Models
{
    public class Director
    {
        //Bir yönetmenin ....... vardır.
        public int Id { get; set; }
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Info { get; set; }

        //Interface kullanmak önemli çünkü bunu daha sonra farklı bir implementasyonla geliştirebilirsin. 
        //Navigation Property :
        public IList<Movie> Movies { get; set; }         //Yönetmen-Film bağlantısı. Bir yönetmenin birden çok filmi olabilir.



    }
}
