namespace InvoicesTask.CoreLayer;

public class ItemsAddDto
{
    public int ItemCode { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public int InvoiceId { get; set; }
}
