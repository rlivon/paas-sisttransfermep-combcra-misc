namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class Sesion
    {
        public static void LeerParm(Entidades.Sesion sesion, string llave)
        {
            DB.Sesion db = new DB.Sesion(sesion);
            db.LeerParm(sesion, llave);
        }
    }
}
