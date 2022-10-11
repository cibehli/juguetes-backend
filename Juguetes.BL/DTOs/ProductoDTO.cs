using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Juguetes.BL.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="La longitud máxima es de 50 Caracteres")]
        public string Nombre { get; set; }
        [StringLength(100, ErrorMessage = "La longitud máxima es de 50 Caracteres")]
        public string Descripcion { get; set; }
        [Range(0,100, ErrorMessage = "El rango de Edad es de 0 a 100")]
        public int RestriccionEdad { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima es de 50 Caracteres")]
        public string Compania { get; set; }
        [Required]
        [Range(1.00, 1000.00,ErrorMessage = "El Rango del Precio debe estar entre 1 y 1000")]
        public decimal Precio { get; set; }
    }
}
