
namespace TupPps.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }

        public Admin(int id, string nombre, string password)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
        }

        public bool VerificarPassword(string password)
        {
            return password == Password;
        }

        public void CambiarContraseña(string newPassword)
        {
            Password = newPassword;
        }
    }
}
