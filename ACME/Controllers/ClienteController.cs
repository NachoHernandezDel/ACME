using ACME.Models;
using ACME.Models.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMapper _mapper;
        //private readonly IRepositorio _repositorio;

        public ClienteController(IMapper mapper/*, IRepositorio repositorio*/)
        {
            _mapper = mapper;
            //_repositorio = repositorio;
        }


        public async Task<IActionResult> ListadoCliente()
        {
            //var clientes = await _repositorio.ObtenerTodos<ClienteDto>();

            //if (clientes != null)
            //{
            List<ClienteDto> listaClientes = new()
                {
                      new ClienteDto
                        {
                            Id = 1,
                            ClienteVisitado = "Gestoria",
                            FechaDeVisita =  new DateTime(2024, 12, 29),
                            ComercialResponsable = "Francisco Martínez"
                        },
                      new ClienteDto
                        {
                            Id = 2,
                            ClienteVisitado = "Papelería",
                            FechaDeVisita =  new DateTime(2024, 12, 13),
                            ComercialResponsable = "Juan Hernández"
                        }
                };

            //listaClientes = JsonConvert.DeserializeObject<List<ClienteDto>>(Convert.ToString(clientes));

            ClienteVM clienteVM = new();

            clienteVM = new ClienteVM()
            {
                listaDeClientes = listaClientes
            };


            return View(clienteVM);
            //}
            //return NotFound();

        }



        public async Task<IActionResult> CrearCliente()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CrearCliente(ClienteCrearVM clienteCrearVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var cliente = await _repositorio.Crear<ClienteDto>();

        //        if (cliente != null)
        //        {
        //            TempData["correcto"] = "Cliente registrado";
        //                return RedirectToAction(nameof(ListadoCliente));
        //            }

        //    }

        //    return View(clienteCrearVM);
        //}




        public async Task<IActionResult> ActualizarCliente(int clienteId)
        {
            //var cliente = await _repositorio.Obtener<ClienteDto>(clienteId);

            //if (cliente != null)
            //{
            ClienteActualizarVM clienteActualizarVM = new();

            //ClienteDto clienteDto = JsonConvert.DeserializeObject<ClienteDto>(Convert.ToString(cliente));
            ClienteDto clienteDto = new()
            {
                Id = 2,
                ClienteVisitado = "Papelería",
                FechaDeVisita = new DateTime(2024, 12, 13),
                ComercialResponsable = "Juan Hernández"
            };


            clienteActualizarVM.ClienteActualizarDto = _mapper.Map<ClienteActualizarDto>(clienteDto);

            return View(clienteActualizarVM);
            //}
            //return NotFound();

        }

        //[HttpPost]
        //public async Task<IActionResult> ActualizarCliente(ClienteActualizarVM clienteActualizarVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var cliente = await _repositorio.Actualizar<ClienteDto>();

        //            if (cliente != null)
        //            {
        //                TempData["correcto"] = "Cliente actualizado  ";
        //                return RedirectToAction(nameof(ListadoCliente));
        //            }
        //            else
        //            {
        //                TempData["error"] = cliente.ErrorMessage;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            TempData["error"] = "Ocurrió un error al actualizar cliente";
        //        }
        //    }

        //    return View(clienteActualizarVM);
        //}




        public async Task<IActionResult> EliminarCliente(int clienteId)
        {

            //var cliente = await _repositorio.Obtener<ClienteDto>();

            //if (cliente != null)
            //{
            //    ClienteDto clienteDto = JsonConvert.DeserializeObject<ClienteDto>(Convert.ToString(cliente));

            ClienteDto clienteDto = new()
            {
                Id = 2,
                ClienteVisitado = "Papelería",
                FechaDeVisita = new DateTime(2024, 12, 13),
                ComercialResponsable = "Juan Hernández"
            };

            ClienteEliminarVM clienteEliminarVM = new();

            clienteEliminarVM.ClienteDto = clienteDto;

            return View(clienteEliminarVM);
            //}

            //return NotFound();

        }

        //    [HttpPost]
        //    public async Task<IActionResult> EliminarCliente(ClienteEliminarVM clienteEliminarVM)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                var cliente = await _repositorio.Eliminar<ClienteDto>();

        //                if (cliente != null)
        //                {
        //                    TempData["correcto"] = "Cliente eliminada  ";
        //                    return RedirectToAction(nameof(ListadoCliente));
        //                }
        //                else
        //                {
        //                    TempData["error"] = cliente.ErrorMessage;
        //                }


        //            }
        //            catch (Exception)
        //            {
        //                TempData["error"] = "Ocurrió un error al eliminar cliente";
        //            }
        //        }
        //        return View(clienteEliminarVM);
        //    }
    }
}
