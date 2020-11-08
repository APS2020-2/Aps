using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.DTO
{
    public class DTO_Filme
    {
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string idiomaOriginal { get; set; }
        public string dataLancamento { get; set; }
        public string duracao { get; set; }
        public Genero genero { get; set; }
        public Diretor diretor { get; set; }
    }
}
