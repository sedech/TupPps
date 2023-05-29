namespace TupPps.Entities
{
    public class Proveedor
    {
        public int CUIT { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public String SitioWeb { get; set; }
        public string RazonSocial { get; set; }

        public Proveedor(int cuit, string nombre, string apellido, string direccion, string email, string sitioWeb, string razonSocial)
        {
            CUIT = cuit;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Email = email;
            SitioWeb = sitioWeb;
            RazonSocial = razonSocial;
        }

        public void ModificarProveedor(string direccion, string email, string sitioWeb)
        {
            Direccion += direccion;
            Email += email;
            SitioWeb += sitioWeb;
        }

        public static Proveedor AgregarProveedor(int cuit, string nombre, string apellido, string direccion, string email, string sitioWeb, string razonSocial)
        {
            Proveedor nuevoProveedor = new Proveedor(cuit, nombre, apellido, direccion, email, sitioWeb, razonSocial);
            return nuevoProveedor;
        }
    }
}
