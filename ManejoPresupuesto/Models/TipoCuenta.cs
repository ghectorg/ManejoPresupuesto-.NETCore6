using ManejoPresupuesto.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta  //: IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        //[StringLength(maximumLength:50, MinimumLength =3, ErrorMessage = "La longitud del campo {0} debe estar entre {2} y {1}")]
        //[Display(Name ="Nombre del tipo cuenta")]
        [PrimeraLetraMayus] //VALIDACION PERSONALIZADA POR ATRIBUTO
        [Remote(action: "VerificarExisteTipoCuenta", controller: "TiposCuentas")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

        /* VALIDACION PERSOLAZADA POR MODELO */
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length > 0)
        //    {
        //        var primeraLetra = Nombre[0].ToString();

        //        if (primeraLetra != primeraLetra.ToUpper())
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayuscula", new[] {nameof(Nombre)});
        //        }
        //    }
        //}

        /* PRUEBAS DE OTRAS VALIDACIONES POR DEFECTO */

        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }
        //[Required]
        //[Range(minimum:18, maximum:130)]
        //public int Edad { get; set; }
        //[Required]
        //[Url(ErrorMessage ="El campo debe ser una URL valida")]
        //public string URL { get; set; }
        //[Required]
        //[CreditCard(ErrorMessage ="La tarjeta de credito no es valida")]
        //public string TarjetaDeCredito { get; set; }
    }
}
