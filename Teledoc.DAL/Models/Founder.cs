using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teledoc.DAL.Models;

public class Founder
{
    [RegularExpression("([0-9]*)")] 
    [Length(10, 12)] 
    [Key] public string Inn { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? AddAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdateAt { get; set; }

    public virtual IEnumerable<Client>? Clients { get; set; }
}