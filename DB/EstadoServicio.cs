using System.Data.SqlClient;
using System.Text;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class EstadoServicio : Base
    {
        public EstadoServicio(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Registrar(RN.BcraConsultaEstado.ConsultaEstadoResponse estado)
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("update Parm set ValorStr='" + estado.descripcion + "'+' - Ult.Actualiz.: '+'" + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "' where IdParm='Bcra-EstadoMep' ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            Ejecutar(sqlCmd, TipoRetorno.None, Transaccion.Usa);
        }
    }
}
