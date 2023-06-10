using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoicesTask.CoreLayer;

public class InvoiceHDR
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int InvoiceId { get; set; }

    [Required]
    public DateTime InvocieDate { get; set; }

    [Required]
    public bool PaymentMethod { get; set; }

    [Required]
    [StringLength(150)]
    public string Customer { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
}
