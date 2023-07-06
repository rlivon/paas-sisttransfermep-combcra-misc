using RestSharp;
using System.Net;

namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class BcraConsultaEstado
    {
        public class ConsultaEstadoResponse
        {
            public int estado { get; set; }
            public string fechaHoraApertura { get; set; }
            public string descripcion { get; set; }
        }
        public static ConsultaEstadoResponse Ejecutar(Entidades.Sesion sesion)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            Entidades.Servicio servicio = RN.Funciones.Servicio(sesion, "v1.1/consulta/estado");
            RestClient client = new RestClient(servicio.Url);
            RestRequest request = BcraRequest.Crear(servicio.Escenario + "v1.1/consulta/estado", Method.GET, sesion, servicio);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                Thread.Sleep(1000);
                response = client.Execute(request);
            }
            BcraResponse.Validar(response, client);
            string content = response.Content;
            ConsultaEstadoResponse data = Newtonsoft.Json.JsonConvert.DeserializeObject<ConsultaEstadoResponse>(content);
            return data;
        }
    }
}