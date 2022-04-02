using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TargetInvestimento.Application.Interfaces;
using TargetInvestimento.Application.Models.Cliente;
using TargetInvestimento.Application.Models.Endereco;
using System.Net.Http;
using TargetInvestimento.Application.Models.Estados;
using TargetInvestimento.Application.Models.IBGE;
using TargetInvestimento.Application.Models;

namespace TargetInvestimento.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplicationService _clienteApplicationService;
        public ClientesController
            (IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        [HttpPost("CreateCliente")]
        public IActionResult CreateCliente(ClienteCreateModel model)
        {
            try
            {
                _clienteApplicationService.Create(model);

                if (model.RendaMensal >= 6000)
                {
                    var resultado = new
                    {
                        OferecerPlanoVip = true,
                    };

                    return new JsonResult(resultado);
                }

                return Ok(new { Mensagem = "Cliente cadastrado com sucesso." });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet("GetEnderecoClienteByCpf")]
        public IActionResult GetEnderecoClienteByCpf(string CPF)
        {
            try
            {
                return Ok(_clienteApplicationService.GetEnderecoClientByCpf(CPF));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet("GetUFs")]
        public JsonResult GetUFs()
        {
            try
            {
                var UFs = _clienteApplicationService.GetUFs();
                return new JsonResult(UFs);

            }
            catch (ArgumentException e)
            {
                return new JsonResult(500, new { Mensagem = e.Message });
            }

        }

        [HttpGet("GetCidadesByUF")]
        public JsonResult GetCidadesByUF(int idUF)
        {
            try
            { 
                return new JsonResult(_clienteApplicationService.GetCidadesByUF(idUF));
            }
            catch (ArgumentException e)
            {
                return new JsonResult(500, new { Mensagem = e.Message });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteApplicationService.Delete(id);
                return Ok(new { Mensagem = "Pessoa excluída com sucesso." });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_clienteApplicationService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_clienteApplicationService.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }


        [HttpPut("UpdateEnderecoClienteById")]
        public IActionResult UpdateEnderecoClienteById(EnderecoUpdateModel model)
        {
            try
            {
                _clienteApplicationService.UpdateEnderecoClienteById(model);
                return Ok(new { Mensagem = "Endereço atualizado com sucesso." });
            }
            catch (ArgumentException e)
            {
                return StatusCode(400, new { Mensagem = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Mensagem = e.Message });
            }
        }
    }
}

