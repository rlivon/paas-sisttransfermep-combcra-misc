using RestSharp;

namespace paas_sisttransfermep_combcra_misc.RN
{
    public static class BcraRequest
    {
        public static RestRequest Crear(string resource, Method method, Entidades.Sesion sesion, Entidades.Servicio servicio)
        {
            RestRequest request = new RestRequest(resource, method);
            Entidades.Token token = RN.Token.Obtener(false, sesion);
            request.AddParameter("Authorization", token.Authorization, ParameterType.HttpHeader);
            request.AddParameter("app_id", servicio.ApimId, ParameterType.HttpHeader);
            request.AddParameter("app_key", servicio.ApimKey, ParameterType.HttpHeader);
            return request;
        }
    }
}