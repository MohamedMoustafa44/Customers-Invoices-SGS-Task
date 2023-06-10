using InvoicesTask.CoreLayer;

namespace InvoicesTask.BL;

public interface IItemsDTLManager
{
    int AddFullInvoiceWithProducts(ItemsInvoiceAddDto itemsToAdd);
}