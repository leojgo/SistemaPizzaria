using System;

namespace Models
{
    public abstract class Pessoa
    {
        public String Nome { get; set; }

        public String Cpf { get; set; }

        public String Telefone { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}