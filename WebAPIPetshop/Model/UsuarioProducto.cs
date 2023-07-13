using System.ComponentModel.DataAnnotations;

namespace WebAPIPetshop.Model
{
    public class Usuario{
        [Key]
        public int id {get; set;}
        public string? cedula {get; set;}
        public string? foto {get; set;}
        public string? nombre {get; set;}
        public string? apellido {get; set;}
        public string? email {get; set;}
        public string? telefono {get; set;}
    }

    public class Producto{
        [Key]
        public int id {get; set;}
        public string? codigo {get; set;}
        public string? foto {get; set;}
        public string? nombre {get; set;}
        public string? descripcion {get; set;}
        public string? categoria {get; set;}
        public float precio {get; set;}
    }

    public class Compra{
        [Key]
        public int id {get; set;}
        public string? fecha {get; set;}
        public string? IdUsuario {get; set;}
        public string? IdProducto {get; set;}
        public string? cantidad {get; set;}
        public float precio {get; set;}
    }
}