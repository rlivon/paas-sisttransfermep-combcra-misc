using System.Formats.Asn1;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace paas_sisttransfermep_combcra_misc.Entidades
{
    [Serializable]
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            this.Meta = new Meta();
            this.Data = default(T);
        }
        public Meta Meta { get; set; }
        public T Data { get; set; }
        public Error[] Errors { get; set; }

        public void SetearExcepcion(Exception ex)
        {
            Error error = new Error();
            error.message = RN.Funciones.TextoCompletoExcepcion(ex);
            List<Error> errores = new List<Error>() { error };
            this.Errors = errores.ToArray();
        }

    }
    public class Meta
    {
        public string method { get; set; }
        public string operation { get; set; }
    }
    public class Error
    {
        public string code { get; set; }
        public int? status_code { get; set; }
        public string detail { get; set; }
        public string message { get; set; }
        public string lang { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string code_backend { get; set; }
        public string code_internal { get; set; }
        public string method_uri_path { get; set; }
        public string error_type { get; set; }
        public string data { get; set; }
        public string trace { get; set; }
    }
    public class converter<T> : CustomCreationConverter<ApiResponse<T>>
    {
        public override bool CanConvert(Type objectType)
        {
            try
            {
                if (base.CanConvert(objectType))
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public override ApiResponse<T> Create(Type objectType)
        {
            return new ApiResponse<T>() { Data = (T)Activator.CreateInstance(typeof(T)) };
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

    }
    public class ApiResponse
    {
        public ApiResponse()
        {
            this.Meta = new Meta();
        }
        public Meta Meta { get; set; }
        public string Data { get; set; }
        public Error[] Errors { get; set; }

        public void SetearExcepcion(Exception ex)
        {
            Error error = new Error();
            error.message = ex.Message;
            List<Error> errores = new List<Error>() { error };
            this.Errors = errores.ToArray();
        }

    }
}

