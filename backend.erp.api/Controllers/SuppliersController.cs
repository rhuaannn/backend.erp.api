using backend.erp.Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

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
            var suppliers = await _fornecedorService.GetAllFornecedoresAsync();
            if (suppliers == null || !suppliers.Any())
            {
                return NotFound("No suppliers found.");
            }

            return Ok(suppliers);
        }
    }
}