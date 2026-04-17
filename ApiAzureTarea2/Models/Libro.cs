using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAzureTarea2.Models;

public class Libro
{
    [Key]
    [Column("libro_id")]
    public int LibroId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Isbn { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Autor { get; set; } = string.Empty;

    [Column(TypeName = "decimal(12,2)")]
    public decimal Precio { get; set; }

    [Column(TypeName = "date")]
    public DateOnly FechaPublicacion { get; set; }

    public int EjemplaresDisponibles { get; set; }
}
