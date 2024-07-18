using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Teledoc.DAL.Models;

[Index(nameof(Inn), IsUnique = true)]
public class Founder
{
    [Key]
    public int Id { get; set; }
    
    [RegularExpression("([0-9]*)")]
    [Length(10, 12)]
    public string Inn { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? AddAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdateAt { get; set; }

    public virtual IEnumerable<Client>? Clients { get; set; } = new List<Client>();
}