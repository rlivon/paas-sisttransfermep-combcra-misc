using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class Token : Base
    {
        public Token(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public Entidades.Token Leer()
        {
            Entidades.Token token = new Entidades.Token();
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select top 1 IdToken, Valor, FechaExpiracion, FechaGeneracion, Renovandose, FechaInicioRenovacion from Token order by IdToken desc ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            using (DataTable dt = (DataTable)Ejecutar(sqlCmd, TipoRetorno.TB, Transaccion.Usa))
            {
                if (dt.Rows.Count != 0)
                {
                    token.Id = Convert.ToInt32(dt.Rows[0]["IdToken"]);
                    token.Valor = Convert.ToString(dt.Rows[0]["Valor"]);
                    token.FechaExpiracion = Convert.ToDateTime(dt.Rows[0]["FechaExpiracion"]);
                    token.FechaGeneracion = Convert.ToDateTime(dt.Rows[0]["FechaGeneracion"]);
                    token.Renovandose = Convert.ToBoolean(dt.Rows[0]["Renovandose"]);
                    token.FechaInicioRenovacion = Convert.ToDateTime(dt.Rows[0]["FechaInicioRenovacion"]);
                }
                return token;
            }
        }
        public void RegistrarRenovacionEnProceso(Entidades.Token token)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("update Token set Renovandose=1, FechaInicioRenovacion=getdate() where IdToken=@IdToken ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            sqlCmd.Parameters.AddWithValue("@IdToken", token.Id);
            Ejecutar(sqlCmd, TipoRetorno.None, Transaccion.Usa);
        }
        public void DarDeAlta(Entidades.Token token)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("insert Token (Valor, FechaExpiracion, FechaGeneracion, Renovandose, FechaInicioRenovacion) values (@Valor, @FechaExpiracion, getdate(), 0, @FechaExpiracion) ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            sqlCmd.Parameters.AddWithValue("@Valor", token.Valor);
            sqlCmd.Parameters.AddWithValue("@FechaExpiracion", token.FechaExpiracion);
            Ejecutar(sqlCmd, TipoRetorno.None, Transaccion.Usa);
        }
    }
}