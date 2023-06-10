using InvoicesTask.CoreLayer;

namespace InvoicesTask.DAL;

public class InvoiceHDRRepo : GenericRepo<InvoiceHDR>, IInvoiceHDRRepo
{
    private readonly ApplicationDbContext _context;
    public InvoiceHDRRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
