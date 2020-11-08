using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aps
{   
    public class FilmesApiResponse: ApiController
    {
        public IHttpActionResult iniciar(DadosFilmes dados)
        {
            var client = new RestClient("http://localhost:5000/CatalogoFilmesAPI/filme/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            DadosFilmes filmes = JsonConvert.DeserializeObject<DadosFilmes>(response.Content);
            var teste = response.Content;
            return (IHttpActionResult)Task.FromResult(response);
        }
    }
}
