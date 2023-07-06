namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class Funciones
    {
        public static Entidades.Servicio Servicio(Entidades.Sesion sesion, string servicioId)
        {
            Entidades.Servicio servicio = sesion.Servicios.Find((delegate (Entidades.Servicio e) { return e.Id.ToLower() == servicioId.ToLower(); }));
            if (servicio == null)
                throw new Exception("Servicio '" + servicioId + "' no encontrado (tabla Servicios)");
            else
                return servicio;
        }
        public static string TextoCompletoExcepcion(Exception Excepcion)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(Excepcion.Message);
            while (Excepcion.InnerException != null)
            {
                Excepcion = Excepcion.InnerException;
                sb.Append(" - ");
                sb.Append(Excepcion.Message);
            }
            return sb.ToString();
        }
    }
}