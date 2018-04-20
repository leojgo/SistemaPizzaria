namespace Controllers
{
    public class AdministradorController
    {
        public bool Permissao(string login, string senha)
        {
            return login.Equals("adm") && senha.Equals("123");
        }
    }
}