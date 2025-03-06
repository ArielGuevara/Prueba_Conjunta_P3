using System;
using System.ComponentModel.DataAnnotations;

namespace TDDTestingMVC1.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres.")]
        public string Descripcion { get; set; }

        [Required]
        [Range(0.01, 100000.00, ErrorMessage = "El precio debe estar entre 0.01 y 100000.00.")]
        public decimal Precio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
    }
}
