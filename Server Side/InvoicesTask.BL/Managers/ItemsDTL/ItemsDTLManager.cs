using InvoicesTask.CoreLayer;
using InvoicesTask.DAL;

namespace InvoicesTask.BL;

public class ItemsDTLManager : IItemsDTLManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ItemsDTLManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public int AddFullInvoiceWithProducts(ItemsInvoiceAddDto itemsToAdd)
    {
        int numberOfChanges = 0;
        var Items = new List<ItemsDTL>();
        var newInvoice = new InvoiceHDR
        {
            InvoiceId = itemsToAdd.InvoiceId,
            InvocieDate = itemsToAdd.InvocieDate,
            PaymentMethod = itemsToAdd.PaymentMethod,
            Customer = itemsToAdd.Customer,
            Description = itemsToAdd.Description,
        };
        _unitOfWork._InvoiceHDRRepo.Add(newInvoice);
        numberOfChanges += _unitOfWork.SaveChanges();

        foreach (var item in itemsToAdd.Items)
        {
            var newItem = new ItemsDTL
            {
                ItemCode = item.ItemCode,
                ItemName = item.ItemName,
                Qty = item.Qty,
                Price = item.Price,
                InvoiceId = item.InvoiceId,
            };
            Items.Add(newItem);
        }
        _unitOfWork._ItemsDTLRepo.AddCollection(Items);
        numberOfChanges += _unitOfWork.SaveChanges();
        return numberOfChanges;

    }
}
