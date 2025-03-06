using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDDTestingMVC1.Models
{
    public class OpinionesCliente
    {
        [Key]
        public int OpinionID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [ForeignKey("ClienteID")]
        public virtual Cliente Cliente { get; set; }

        [Required]
        public int ProductoID { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Producto Producto { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Calificacion { get; set; }

        [StringLength(255, ErrorMessage = "El comentario no puede exceder los 255 caracteres.")]
        public string? Comentario { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
