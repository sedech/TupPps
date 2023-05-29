using TupPps.Models.Response;

namespace TupPps.Controllers
{
    internal class Repuesta
    {
        public int Exito { get; internal set; }
        public string Mensaje { get; internal set; }

        public static implicit operator Repuesta(Respuesta v)
        {
            throw new NotImplementedException();
        }
    }
}