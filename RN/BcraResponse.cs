using RestSharp;

namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class BcraResponse
    {
        public static void Validar(IRestResponse response, RestClient client)
        {
            if (!response.IsSuccessful)
            {
                if (response.ErrorMessage != null)
                {
                    string mensaje = string.Format("{0}({1})", response.ErrorMessage, client.BaseUrl); 
                    throw new Exception(mensaje);
                }
                if (response.Content != string.Empty)
                {
                    string mensaje = string.Format("{0}({1})", response.Content, client.BaseUrl);
                    throw new Exception(mensaje);
                }
                if (response.StatusDescription != string.Empty)
                {
                    string mensaje = string.Format("{0}({1})", response.StatusDescription, client.BaseUrl);
                    throw new Exception(mensaje);
                }
            }
        }
    }
}