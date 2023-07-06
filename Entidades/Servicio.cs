namespace paas_sisttransfermep_combcra_misc.Entidades
{
    [Serializable]
    public class Servicio
    {
        private string id;
        private string url;
        private string apimId;
        private string apimKey;
        private string usuario;
        private string password;
        private string escenario;

        public Servicio()
        {
        }

        public string Id
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
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }
        public string ApimId
        {
            get
            {
                return apimId;
            }
            set
            {
                apimId = value;
            }
        }
        public string ApimKey
        {
            get
            {
                return apimKey;
            }
            set
            {
                apimKey = value;
            }
        }
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string Escenario
        {
            get
            {
                return escenario;
            }
            set
            {
                escenario = value;
            }
        }
    }
}