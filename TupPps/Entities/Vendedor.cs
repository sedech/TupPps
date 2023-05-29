namespace TupPps.Entities
{
    public class Vendedor
    {
        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }


        public Vendedor(string nombre, string apellido, int idVendedor, string telefono, string direccion, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            IdVendedor = idVendedor;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
        }

        public void ModificarVendedor(string telefono, string direccion, string email)
        {
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
        }

        public static Vendedor AgregarVendedor(string nombre, string apellido, int idVendedor, string telefono, string direccion, string email)
        {
            Vendedor nuevoVendedor = new Vendedor(nombre, apellido, idVendedor, telefono, direccion, email);
            return nuevoVendedor;
        }
    }
}
