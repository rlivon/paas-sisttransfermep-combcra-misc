namespace paas_sisttransfermep_combcra_misc.Entidades
{
    [Serializable]
    public class Consumidor
    {
        private string id;
        private string descr;
        private string key;

        public Consumidor()
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
        public string Descr
        {
            get
            {
                return descr;
            }
            set
            {
                descr = value;
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
    }
}