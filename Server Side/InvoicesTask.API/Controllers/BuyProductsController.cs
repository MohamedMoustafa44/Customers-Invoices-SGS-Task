using InvoicesTask.BL;
using InvoicesTask.CoreLayer;
using Microsoft.AspNetCore.Mvc;

namespace InvoicesTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyProductsController : ControllerBase
    {
        private readonly IItemsDTLManager _itemsDTLManager;

        public BuyProductsController(IItemsDTLManager itemsDTLManager)
        {
            _itemsDTLManager = itemsDTLManager;
        }
        [HttpPost]
        public ActionResult AddInvoiceWithProducts(ItemsInvoiceAddDto itemsToAdd)
        {
            int numberOfChanges = _itemsDTLManager.AddFullInvoiceWithProducts(itemsToAdd);
            if (numberOfChanges <= 0)
            {
                return NoContent();
            }
            return Ok(numberOfChanges);
        }
    }
}
