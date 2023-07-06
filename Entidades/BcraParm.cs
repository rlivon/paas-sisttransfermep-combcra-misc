namespace paas_sisttransfermep_combcra_misc.Entidades
{
    [Serializable]
    public class BcraParm
    {
        private string url;
        private string id;
        private string key;
        private string usuario;
        private string password;
        private string escenario;
        private int renovPreviaTokenEnMin;
        private string cuentasMepRecUsuario;

        public BcraParm()
        {
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
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
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
        public int RenovPreviaTokenEnMin
        {
            get
            {
                return renovPreviaTokenEnMin;
            }
            set
            {
                renovPreviaTokenEnMin = value;
            }
        }
        public string CuentasMepRecUsuario
        {
            get
            {
                return cuentasMepRecUsuario;
            }
            set
            {
                cuentasMepRecUsuario = value;
            }
        }
    }
}