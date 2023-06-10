using InvoicesTask.CoreLayer;

namespace InvoicesTask.DAL;

public class ItemsDTLRepo : GenericRepo<ItemsDTL>, IItemsDTLRepo
{
    private readonly ApplicationDbContext _context;
    public ItemsDTLRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
