namespace TupPps.Entities
{
    public class Cliente
    {
        // Atributos
        public int Id { get; set; }
        public int CUIT { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string RazonSocial { get; set; }

        // Constructor 
        public Cliente(int id, int cuit, string nombre, string apellido, string telefono, string direccion, string email, string razonSocial)
        {
            Id = id;
            CUIT = cuit;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
            RazonSocial = razonSocial;
        }
        // Métodos 
        public void ModificarDatos(string telefono, string direccion, string email, string razonSocial)
        {
            Telefono = telefono;
            Direccion = direccion;
            Email = email;
            RazonSocial = razonSocial;
        }

        public static Cliente AgregarCliente(int id, int cuit, string nombre, string apellido, string telefono, string direccion, string email, string razonSocial)
        {
            Cliente nuevoCliente = new Cliente(id, cuit, nombre, apellido, telefono, direccion, email, razonSocial);
            return nuevoCliente;
        }
    }
}
