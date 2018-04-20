namespace Models
{
    public class Cliente : Pessoa
    {
        public int ClienteID { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}