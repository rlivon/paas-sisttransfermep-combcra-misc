namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class CierreCambio
    {
        public static void Registrar(string tipoCierreCambio, string idMoneda, decimal cotizacion, DateTime fechaCotizacion, Entidades.Sesion sesion)
        {
            DB.CierreCambio db = new DB.CierreCambio(sesion);
            db.Registrar(tipoCierreCambio, idMoneda, cotizacion, fechaCotizacion);
        }
    }
}