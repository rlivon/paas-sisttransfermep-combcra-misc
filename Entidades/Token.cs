namespace paas_sisttransfermep_combcra_misc.Entidades
{
    [Serializable]
    public class Token
    {
        private int id;
        private string valor;
        private DateTime fechaExpiracion;
        private DateTime fechaGeneracion;
        private bool renovandose;
        private DateTime fechaInicioRenovacion;

        public Token()
        {
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
        public string Authorization
        {
            get
            {
                return "Bearer " + valor;
            }
        }
        public DateTime FechaExpiracion
        {
            get
            {
                return fechaExpiracion;
            }
            set
            {
                fechaExpiracion = value;
            }
        }
        public DateTime FechaGeneracion
        {
            get
            {
                return fechaGeneracion;
            }
            set
            {
                fechaGeneracion = value;
            }
        }
        public bool Renovandose
        {
            get
            {
                return renovandose;
            }
            set
            {
                renovandose = value;
            }
        }
        public DateTime FechaInicioRenovacion
        {
            get
            {
                return fechaInicioRenovacion;
            }
            set
            {
                fechaInicioRenovacion = value;
            }
        }
    }
}