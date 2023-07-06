namespace paas_sisttransfermep_combcra_misc.RN
{
    public class EstadoServicio
    {
        public static void Registrar(RN.BcraConsultaEstado.ConsultaEstadoResponse estado, Entidades.Sesion sesion)
        {
            DB.EstadoServicio db = new DB.EstadoServicio(sesion);
            db.Registrar(estado);
        }
    }
}
