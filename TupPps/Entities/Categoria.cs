namespace TupPps.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }


        public Categoria(int idCategoria, string nombre)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
        }

        public void ModificarCategoria(string nuevoNombre)
        {
            Nombre += nuevoNombre;
        }

        public string ObtenerInformacion()
        {
            string informacion = $"Id Categoria: {IdCategoria}\n";
            informacion += $"Nombre: {Nombre}\n";
            return informacion;
        }
    }
}
