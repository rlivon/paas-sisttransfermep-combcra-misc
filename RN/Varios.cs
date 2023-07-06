namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class Varios
    {
        public static DateTime FechaHabilAnterior(Entidades.Sesion sesion)
        {
            DB.Varios db = new DB.Varios(sesion);
            return db.FechaHabilAnterior();
            //return new DateTime(2021, 09, 22);
        }
        public static string IdUsuarioOrquestador(Entidades.Sesion sesion)
        {
            DB.Varios db = new DB.Varios(sesion);
            return db.IdUsuarioOrquestador();
        }
        public static int LeerCantLote(string idLote, Entidades.Sesion sesion)
        {
            DB.Parm db = new DB.Parm(sesion);
            return db.LeerValorInt(idLote + "CantLote");
        }
    }
}
