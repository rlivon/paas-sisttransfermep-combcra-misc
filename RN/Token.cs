namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class Token
    {
        public static Entidades.Token Obtener(bool forzarRenovacion, Entidades.Sesion sesion)
        {
            DB.Token db = new DB.Token(sesion);
            Entidades.Token token = db.Leer();
            if (token.Id == 0 || forzarRenovacion || DateTime.Compare(DateTime.Now, token.FechaExpiracion.Subtract(new TimeSpan(0, sesion.RenovPreviaTokenEnMin, 0))) > 0)
            {
                BcraLoginAuthenticate.LoginAuthenticateResponse tokenBCRA = BcraLoginAuthenticate.Ejecutar(sesion);
                if (tokenBCRA.autenticado)
                {
                    if (token.Id != 0) db.RegistrarRenovacionEnProceso(token);
                    token.Valor = tokenBCRA.token;
                    token.FechaExpiracion = DateTime.ParseExact(tokenBCRA.fechaExpiracion, "dd/MM/yyyy H:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    db.DarDeAlta(token);
                }
                else
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.token.NoAutenticadoException();
                }
            }
            return token;
        }

    }
}
