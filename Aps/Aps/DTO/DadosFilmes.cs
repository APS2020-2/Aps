using Aps.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aps
{
    public class DadosFilmes
    {  
        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string idiomaOriginal { get; set; }
        public string dataLancamento { get; set; }
        public string duracao { get; set; }
        public int ano { get; set; }
        public int generoId { get; set; }
        public Diretor diretor { get; set; }

    }
}
