using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        [Display(Name = "Fecha Transacción")]
        [DataType(DataType.DateTime)]
        public DateTime FechaTransaccion { get; set; } = DateTime.Today;// DateTime.Parse(DateTime.Now.ToString("g")); <- = -> DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:MM tt"));
        public decimal Monto { get; set; }

        [Range(1, maximum: int.MaxValue, ErrorMessage = "Debe seleccionar una categoria")]
        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }

        [StringLength(maximumLength: 1000, ErrorMessage ="La nota no puede pasar de {1} caracteres")]
        public string Nota { get; set; }

        [Range(1, maximum:int.MaxValue, ErrorMessage ="Debe seleccionar una cuenta")]
        [Display(Name = "Cuentas")]
        public int CuentaId { get; set; }

        [Display(Name = "Tipo Operacion")]
        public TipoOperacion TipoOperacionId { get; set; } = TipoOperacion.Ingreso;

    }
}
