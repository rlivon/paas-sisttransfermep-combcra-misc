using System.Data.SqlClient;
using System.Text;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class CierreCambio : Base
    {
        public CierreCambio(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Registrar(string tipoCierreCambio, string idMoneda, decimal cotizacion, DateTime fechaCotizacion)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("insert CierreCambio (Fecha, TipoCierreCambio, IdMoneda, Cotizacion, FechaCotizacion) values (GETDATE(), @tipoCierreCambio, @idMoneda, @cotizacion, @fechaCotizacion) ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            sqlCmd.Parameters.AddWithValue("@tipoCierreCambio", tipoCierreCambio);
            sqlCmd.Parameters.AddWithValue("@IdMoneda", idMoneda);
            sqlCmd.Parameters.AddWithValue("@Cotizacion", cotizacion);
            sqlCmd.Parameters.AddWithValue("@FechaCotizacion", fechaCotizacion);
            Ejecutar(sqlCmd, TipoRetorno.None, Transaccion.Acepta);
        }
    }
}
