using System;
using RestSharp;
using System.Net;
using System.Threading;

namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class BcraLoginAuthenticate
    {
        [Serializable]
        public class Body
        {
            private string usuario;
            private string clave;
            public Body()
            {
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
            public string Clave
            {
                get
                {
                    return clave;
                }
                set
                {
                    clave = value;
                }
            }
        }
        public class LoginAuthenticateResponse
        {
            public string usuario { get; set; }
            public object clave { get; set; }
            public bool autenticado { get; set; }
            public string token { get; set; }
            public string fechaExpiracion { get; set; }
            public object mensaje { get; set; }
        }
        public static LoginAuthenticateResponse Ejecutar(Entidades.Sesion sesion)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            Entidades.Servicio servicio = RN.Funciones.Servicio(sesion, "v1.1/login/authenticate");
            if (servicio.Usuario == string.Empty && servicio.Password == string.Empty) throw new Exception("Token vencido con renovación automática deshabilitada");
            RestClient client = new RestClient(servicio.Url);
            RestRequest request = new RestRequest(servicio.Escenario + "v1.1/login/authenticate", Method.POST);
            request.AddParameter("app_id", servicio.ApimId, ParameterType.HttpHeader);
            request.AddParameter("app_key", servicio.ApimKey, ParameterType.HttpHeader);
            Body body = new Body();
            body.Usuario = servicio.Usuario;
            body.Clave = servicio.Password;
            string bodyString = Newtonsoft.Json.JsonConvert.SerializeObject(body);
            request.AddParameter("application/json; charset=utf-8", bodyString, ParameterType.RequestBody);
            request.Parameters[2].DataFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                Thread.Sleep(1000);
                response = client.Execute(request);
            }
            BcraResponse.Validar(response, client);
            string content = response.Content;
            LoginAuthenticateResponse data = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginAuthenticateResponse>(content);
            return data;
        }
    }
}