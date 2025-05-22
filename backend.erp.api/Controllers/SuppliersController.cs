using backend.erp.Application.FornecedorDTO;
using backend.erp.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace backend.erp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IFornecedor _fornecedorService;

        public SuppliersController(IFornecedor fornecedor)
        {
            _fornecedorService = fornecedor;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _fornecedorService.GetAllSuppliersAsync();
            if (suppliers == null || !suppliers.Any())
            {
                return NotFound("No suppliers found.");
            }

            return Ok(suppliers);
        }
        [HttpPost]
        public async Task<IActionResult> AddSuppliers([FromBody] RequestFornecedorDTO requestFornecedorDTO)
        {
            if (requestFornecedorDTO == null)
            {
                return BadRequest("Invalid supplier data.");
            }
            var createdSupplier = await _fornecedorService.AddSuppliersAsync(requestFornecedorDTO);
            return CreatedAtAction(nameof(GetAllSuppliers), new { id = createdSupplier.Id }, createdSupplier);
        }
    }
}