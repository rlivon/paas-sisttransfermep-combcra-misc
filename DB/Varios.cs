using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class Varios : Base
    {
        public Varios(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public DateTime FechaHabilAnterior()
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select max(Fecha) as FechaHabilAnterior from Mep where convert(varchar(8),Fecha,112)<convert(varchar(8),getdate(),112) ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            using (DataTable dt = (DataTable)Ejecutar(sqlCmd, TipoRetorno.TB, Transaccion.Usa))
            {
                if (dt.Rows.Count != 0)
                {
                    return Convert.ToDateTime(dt.Rows[0]["FechaHabilAnterior"]).Date;
                }
                else
                {
                    throw new Exception("No se puede determinar la FechaHabilAnterior");
                }
            }
        }
        public string IdUsuarioOrquestador()
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select ValorStr from Parm where IdParm='IdUsuarioOrquestador' ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            using (DataTable dt = (DataTable)Ejecutar(sqlCmd, TipoRetorno.TB, Transaccion.Usa))
            {
                System.Console.WriteLine("Obtuvo el resultado de la consulta : " + Convert.ToString(dt.Rows[0]["ValorStr"]));
                return Convert.ToString(dt.Rows[0]["ValorStr"]);
            }
        }
    }
}