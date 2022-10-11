using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Juguetes.BL.Models
{
    [Table("Productos", Schema ="dbo")]
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int RestriccionEdad { get; set; }
        public string Compania { get; set; }
        public decimal Precio { get; set; }

    }
}
