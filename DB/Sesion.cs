using System.Data;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class Sesion : Base
    {
        public Sesion(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void LeerParm(Entidades.Sesion Sesion, string llave)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select ServicioId, Url, ApimId, ApimKey, Usuario, Password, Escenario from Servicio order by ServicioId ");
            a.AppendLine("select ValorInt from Parm where IdParm = 'BcraRenovPreviaTokenEnMin' ");
            a.AppendLine("select ValorStr from Parm where IdParm = 'Bcra-API-CuentasMepRecUsuario' ");
            a.AppendLine("select ValorInt from Parm where IdParm = 'EncriptaToken' ");

            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            using (DataSet ds = (DataSet)Ejecutar(sqlCmd, TipoRetorno.DS, Transaccion.Usa))
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Entidades.Servicio elem = new Entidades.Servicio();
                    elem.Id = ds.Tables[0].Rows[i]["ServicioId"].ToString();
                    elem.Url = ds.Tables[0].Rows[i]["Url"].ToString();
                    elem.ApimId = ds.Tables[0].Rows[i]["ApimId"].ToString();
                    elem.ApimKey = ds.Tables[0].Rows[i]["ApimKey"].ToString();
                    elem.Usuario = ds.Tables[0].Rows[i]["Usuario"].ToString();
                    elem.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                    elem.Escenario = ds.Tables[0].Rows[i]["Escenario"].ToString();
                    bool encripado = false;
                    try
                    {
                        encripado = Convert.ToBoolean(ds.Tables[3].Rows[0]["ValorInt"]);
                    }
                    catch (Exception)
                    {
                    }
                    if (encripado)
                    {
                        try
                        {
                            if (elem.Password != "")
                            {
                                elem.Password = CedEncriptador.EncryptDecrypt.DecryptCore(elem.Password, llave);
                            }
                        }
                        catch (Exception)
                        {
                            throw new Exception("No se pudo desencriptar las credenciales");
                        }
                    }
                    Sesion.Servicios.Add(elem);
                }
                Sesion.RenovPreviaTokenEnMin = Convert.ToInt32(ds.Tables[1].Rows[0]["ValorInt"]);
                Sesion.CuentasMepRecUsuario = ds.Tables[2].Rows[0]["ValorStr"].ToString();
            }
        }
    }
}
