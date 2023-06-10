namespace InvoicesTask.CoreLayer;

public class ItemsInvoiceAddDto
{
    public int InvoiceId { get; set; }
    public DateTime InvocieDate { get; set; }
    public bool PaymentMethod { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<ItemsAddDto> Items { get; set; } = new List<ItemsAddDto>();
}
