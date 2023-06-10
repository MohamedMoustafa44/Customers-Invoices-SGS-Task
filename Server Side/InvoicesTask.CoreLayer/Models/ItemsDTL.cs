using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesTask.CoreLayer;

public class ItemsDTL
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key, Column(Order = 0)]
    public int ItemCode { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Invoice")]
    public int InvoiceId { get; set; }
    public InvoiceHDR? Invoice { get; set; }

    [Required]
    [StringLength(150)]
    public string ItemName { get; set; } = string.Empty;

    [Required]
    public int Qty { get; set; }

    [Required]
    public decimal Price { get; set; }
}
