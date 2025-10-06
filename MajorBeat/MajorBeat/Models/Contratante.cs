﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorBeat.Models
{
    public class Contratante
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string  logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }

        public string senha { get; set; }
        public string biografia { get; set; }
        public string nomePerfil { get; set; }
        public string empresa { get; set; }
        public byte[] FotoBytes { get; set; }
        public string linkLinkdin { get; set; }
        public string linkInsta { get; set; }
        public string linkTwitter { get; set; }
        public string linkFacebook { get; set; }
        public List<string> RedesSociais { get; set; }
    }
}
