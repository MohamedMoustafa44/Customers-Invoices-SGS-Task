namespace InvoicesTask.DAL;

public class UnitOfWork : IUnitOfWork
{
    public IInvoiceHDRRepo _InvoiceHDRRepo { get; }
    public IItemsDTLRepo _ItemsDTLRepo { get; }
    public ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _InvoiceHDRRepo = new InvoiceHDRRepo(_context);
        _ItemsDTLRepo = new ItemsDTLRepo(_context);
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
