namespace TupPps.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }


        public Usuario(int id, string mail, string password, string tipo)
        {
            Id = id;
            Mail = mail;
            Password = password;
            Tipo = tipo;
        }

        public bool ValidarPassword(string inputPassword)
        {
            return Password == inputPassword;
        }

        public void CambiarPassword(string nuevaPassword)
        {
            Password = nuevaPassword;
        }
    }
}
