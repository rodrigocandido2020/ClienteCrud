using System;
using System.Collections.Generic;

namespace ClienteCrud
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
