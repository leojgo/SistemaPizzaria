using System;

namespace Models
{
    public class Endereco
    {
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public String Rua { get; set; }
        public int Numero { get; set; }
        public String Bairro { get; set; }
        public String Referencia { get; set; }
        public String Complemento { get; set; }
    }
}