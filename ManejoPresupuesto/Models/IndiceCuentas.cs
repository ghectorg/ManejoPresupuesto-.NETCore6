namespace ManejoPresupuesto.Models
{
    public class IndiceCuentas
    {
        public string TipoCuenta { get; set; }
        public IEnumerable<Cuenta> Cuentas { get; set; }
        public decimal Balance => Cuentas.Sum(c => c.Balance);
    }
}
