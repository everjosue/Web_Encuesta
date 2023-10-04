//namespace Proyec1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models;


    public class ModeloProductos
    {
        [Key]	
        [Column("Idproducto")] // Especifica el nombre de la columnaa
        public int Idproducto { get; set; }
        public string? Nombre { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal Precio { get; set; }
        public string? descripcion { get; set; }
        //public int Stock { get; set; }
        public string? imgprincipal { get; set; }

        [NotMapped]
        public string []? imagenes { get; set; }
        //public int IdCategoria { get; set; }
       // public string? NombreCategoria { get; set; }
    }


