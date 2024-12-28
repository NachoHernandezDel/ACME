namespace ACME.Models
{
    public class ClienteActualizarDto
    {
        public int Id { get; set; }
        public string ClienteVisitado { get; set; }
        public DateTime FechaDeVisita { get; set; }
        public string ComercialResponsable { get; set; }
    }
}
