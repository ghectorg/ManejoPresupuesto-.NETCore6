namespace ManejoPresupuesto.Models
{
    public class TransaccionActualizacion: TransaccionCreacion
    {
        public int CuentaAnteriorId { get; set; }
        public decimal MontoAnterior { get; set; }
    }
}
