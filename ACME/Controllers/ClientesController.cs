using ACME.Models;
using ACME.Models.VM;
using ACME.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ACME.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepositorio _repositorio;

        public ClienteController(IMapper mapper, IRepositorio repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }


        public async Task<IActionResult> ListadoCliente()
        {
            var clientes = await _repositorio.ObtenerTodasLasClientes<ClienteDto>();

            if (clientes != null)
            {
                List<ClienteDto> listaClientes = new();

                ClienteVM clienteVM = new();

                listaClientes = JsonConvert.DeserializeObject<List<ClienteDto>>(Convert.ToString(clientes.Resultado));
                clienteVM = new ClienteVM()
                {
                    listaDeClientes = listaClientes
                };


                return View(clienteVM);
            }
            return NotFound();

        }



        public async Task<IActionResult> CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente(ClienteCrearVM clienteCrearVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _repositorio.CrearCliente<ClienteDto>();

                    if (cliente != null)
                    {
                        TempData["correcto"] = "Cliente registrado";
                        return RedirectToAction(nameof(ListadoCliente));
                    }
                    else
                    {
                        TempData["error"] = cliente.ErrorMessage;
                    }

                }
                catch (Exception)
                {
                    TempData["error"] = "Ocurrió un error al registrar cliente";
                }
            }

            return View(clienteCrearVM);
        }




        public async Task<IActionResult> ActualizarCliente(int clienteId)
        {
            var cliente = await _repositorio.ObtenerClientePorId<ClienteDto>(clienteId);

            if (cliente != null)
            {
                ClienteActualizarVM clienteActualizarVM = new();

                ClienteDto clienteDto = JsonConvert.DeserializeObject<ClienteDto>(Convert.ToString(cliente));

                clienteActualizarVM.ClienteActualizarDto = _mapper.Map<ClienteActualizarDto>(clienteDto);

                return View(clienteActualizarVM);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> ActualizarCliente(ClienteActualizarVM clienteActualizarVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _repositorio.ActualizarCliente<ClienteDto>();

                    if (cliente != null)
                    {
                        TempData["correcto"] = "Cliente actualizada  ";
                        return RedirectToAction(nameof(ListadoCliente));
                    }
                    else
                    {
                        TempData["error"] = cliente.ErrorMessage;
                    }
                }
                catch (Exception)
                {
                    TempData["error"] = "Ocurrió un error al actualizar cliente";
                }
            }

            return View(clienteActualizarVM);
        }




        public async Task<IActionResult> EliminarCliente(int clienteId)
        {

            var cliente = await _repositorio.ObtenerClientePorId<ClienteDto>();

            if (cliente != null)
            {
                ClienteDto clienteDto = JsonConvert.DeserializeObject<ClienteDto>(Convert.ToString(cliente));

                ClienteEliminarVM clienteEliminarVM = new();

                clienteEliminarVM.ClienteDto = clienteDto;

                return View(clienteEliminarVM);
            }

            return NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> EliminarCliente(ClienteEliminarVM clienteEliminarVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = await _repositorio.EliminarCliente<ClienteDto>();

                    if (cliente != null)
                    {
                        TempData["correcto"] = "Cliente eliminada  ";
                        return RedirectToAction(nameof(ListadoCliente));
                    }
                    else
                    {
                        TempData["error"] = cliente.ErrorMessage;
                    }


                }
                catch (Exception)
                {
                    TempData["error"] = "Ocurrió un error al eliminar cliente";
                }
            }
            return View(clienteEliminarVM);
        }
    }
}
