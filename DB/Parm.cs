using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class Parm : Base
    {
        public Parm(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public int LeerValorInt(string parmId)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select ValorInt as CantLote from Parm where IdParm=@parmId ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            sqlCmd.Parameters.AddWithValue("@parmId", parmId);
            using (DataTable dt = (DataTable)Ejecutar(sqlCmd, TipoRetorno.TB, Transaccion.Usa))
            {
                return Convert.ToInt32(dt.Rows[0]["CantLote"]);
            }
        }
    }
}
