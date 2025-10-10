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

        private const string apiUrlBase = "http://localhost:8080/Musico/cadastrar";

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Musico> PostMusicoAsync(Musico musico)
        {
            string url = apiUrlBase; // Se a rota for algo como /api/musico ou /api/musico/cadastrar, altere aqui
            Musico musicoCadastrado = await _request.PostAsync(url, musico);
            return musicoCadastrado;
        }


    }
}
