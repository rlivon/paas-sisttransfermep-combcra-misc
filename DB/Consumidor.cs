using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace paas_sisttransfermep_combcra_misc.DB
{
    public class Consumidor : Base
    {
        public Consumidor(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void ObtenerLista()
        {
            StringBuilder a = new StringBuilder(String.Empty);
            a.AppendLine("select ValorStr from Parm where IdParm='IdentificarConsumidores' ");
            a.AppendLine("select ConsumidorId, ConsumidorDescr, Clave from Consumidor order by ConsumidorId ");
            SqlCommand sqlCmd = new SqlCommand(a.ToString());
            using (DataSet ds = (DataSet)Ejecutar(sqlCmd, TipoRetorno.DS, Transaccion.Usa))
            {
                try
                {
                    sesion.IdentificarConsumidores = ds.Tables[0].Rows[0]["ValorStr"].ToString().ToUpper();
                }
                catch
                {
                    throw new Exception("Consumer setting not found");
                }
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    Entidades.Consumidor elem = new Entidades.Consumidor();
                    elem.Id = ds.Tables[1].Rows[i]["ConsumidorId"].ToString();
                    elem.Descr = ds.Tables[1].Rows[i]["ConsumidorDescr"].ToString();
                    elem.Key = ds.Tables[1].Rows[i]["Clave"].ToString();
                    sesion.Consumidores.Add(elem);
                }
            }
        }
    }
}
