namespace ACME.Models.VM
{

    public class ClienteEliminarVM
    {
        public ClienteEliminarVM()
        {
            ClienteDto ClienteDto = new();
        }

        public ClienteDto ClienteDto { get; set; }
    }
}
