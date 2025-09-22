using MajorBeat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorBeat.Services.Usuarios
{
    public class UsuarioService:Request
    {
        private readonly Request _request;

        private const string apiUrlBase = "https://majorbbeat-gmc9fef0gaaxesbt.brazilsouth-01.azurewebsites.net/Usuarios";

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Contratante> PostRegistrarUsuarioAsync(Contratante u)
        {
            string urlComplementar = "/PostUsuarios";
            u.id = await _request.PostReturnIntAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }

       
    }
}
