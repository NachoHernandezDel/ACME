using ACME.Models;

namespace ACME.Models.VM
{

    public class ClienteActualizarVM
    {
        public ClienteActualizarVM()
        {
            ClienteActualizarDto ClienteActualizarDto = new();
        }

        public ClienteActualizarDto ClienteActualizarDto { get; set; }
    }
}
