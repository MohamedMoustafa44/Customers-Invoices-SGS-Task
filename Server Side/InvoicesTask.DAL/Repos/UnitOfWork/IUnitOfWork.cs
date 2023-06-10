namespace InvoicesTask.DAL;

public interface IUnitOfWork
{
    public IInvoiceHDRRepo _InvoiceHDRRepo { get;}
    public IItemsDTLRepo _ItemsDTLRepo { get; }
    int SaveChanges();
}
