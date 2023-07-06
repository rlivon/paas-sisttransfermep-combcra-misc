using System.Globalization;

namespace paas_sisttransfermep_combcra_misc.Entidades
{
    [Serializable]
    public class Sesion
    {
        private string ambiente;
        private string cnnStr;
        private CultureInfo cultura;
        private int renovPreviaTokenEnMin;
        private string cuentasMepRecUsuario;
        private List<Servicio> servicios;
        private string identificarConsumidores;
        private List<Consumidor> consumidores;

        public Sesion()
        {
            servicios = new List<Servicio>();
            consumidores = new List<Consumidor>();
        }

        public string Ambiente
        {
            get
            {
                return ambiente;
            }
            set
            {
                ambiente = value;
            }
        }
        public string CnnStr
        {
            get
            {
                return cnnStr;
            }
            set
            {
                cnnStr = value;
            }
        }
        [System.Xml.Serialization.XmlIgnore]
        public CultureInfo Cultura
        {
            get
            {
                return cultura;
            }
            set
            {
                cultura = value;
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
        public List<Servicio> Servicios
        {
            get
            {
                return servicios;
            }
            set
            {
                servicios = value;
            }
        }
        public string IdentificarConsumidores
        {
            get
            {
                return identificarConsumidores;
            }
            set
            {
                identificarConsumidores = value;
            }
        }
        public List<Consumidor> Consumidores
        {
            get
            {
                return consumidores;
            }
            set
            {
                consumidores = value;
            }
        }
    }
}