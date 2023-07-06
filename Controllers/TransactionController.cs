using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace paas_sisttransfermep_combcra_misc.Controllers
{
    [ApiController]
    [Route("/v1/paas/sisttransfermep/combcra/Varios")]
    public class TransactionController : BaseController
    {
        public TransactionController(IMemoryCache cache) : base(cache)
        {
        }

        [HttpGet("ConsultarEstadoServicio")]
        public Entidades.ApiResponse<RN.BcraConsultaEstado.ConsultaEstadoResponse> ConsultarEstadoServicio()
        {
            Entidades.ApiResponse<RN.BcraConsultaEstado.ConsultaEstadoResponse> apiResponse = new Entidades.ApiResponse<RN.BcraConsultaEstado.ConsultaEstadoResponse>();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                apiResponse.Data = RN.BcraConsultaEstado.Ejecutar(sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }
        [HttpGet("RegistrarEstadoServicio")]
        public Entidades.ApiResponse RegistrarEstadoServicio()
        {
            Entidades.ApiResponse apiResponse = new Entidades.ApiResponse();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                RN.BcraConsultaEstado.ConsultaEstadoResponse estado = RN.BcraConsultaEstado.Ejecutar(sesion);
                RN.EstadoServicio.Registrar(estado, sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }
        [HttpGet("RenovarTokenContingencia")]
        public Entidades.ApiResponse RenovarTokenContingencia()
        {
            Entidades.ApiResponse apiResponse = new Entidades.ApiResponse();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                Entidades.Token token = RN.Token.Obtener(true, sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }
        [HttpPost("ObteneryRegistrarToken")]
        public Entidades.ApiResponse ObteneryRegistrarToken(string usuario, string password)
        {
            Entidades.ApiResponse apiResponse = new Entidades.ApiResponse();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                Entidades.Servicio servicio = RN.Funciones.Servicio(sesion, "v1.1/login/authenticate");
                string usrAux = servicio.Usuario;
                string passAux = servicio.Password;
                servicio.Usuario = usuario;
                servicio.Password = password;
                Entidades.Token token = RN.Token.Obtener(true, sesion);
                servicio.Usuario = usrAux;
                servicio.Password = passAux;
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }

        [HttpGet("FechaHabilAnterior")]
        public Entidades.ApiResponse<DateTime> FechaHabilAnterior()
        {
            Entidades.ApiResponse<DateTime> apiResponse = new Entidades.ApiResponse<DateTime>();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                apiResponse.Data = RN.Varios.FechaHabilAnterior(sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }
        [HttpGet("IdUsuarioOrquestador")]
        public Entidades.ApiResponse<string> IdUsuarioOrquestador()
        {
            Entidades.ApiResponse<string> apiResponse = new Entidades.ApiResponse<string>();
            try
            {
                System.Console.WriteLine("Va crear la variable Sesion");
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                apiResponse.Data = RN.Varios.IdUsuarioOrquestador(sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }

        [HttpPut("RegistrarCierreCambio")]
        public Entidades.ApiResponse RegistrarCierreCambio(string tipoCierreCambio, string idMoneda, decimal cotizacion, DateTime fechaCotizacion)
        {
            Entidades.ApiResponse apiResponse = new Entidades.ApiResponse();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                RN.CierreCambio.Registrar(tipoCierreCambio, idMoneda, cotizacion, fechaCotizacion, sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }
        [HttpGet("LeerCantLote")]
        public Entidades.ApiResponse<int> LeerCantLote(string idLote)
        {
            Entidades.ApiResponse<int> apiResponse = new Entidades.ApiResponse<int>();
            try
            {
                Entidades.Sesion sesion = Sesion;
                IdentificarConsumidor(sesion);
                apiResponse.Data = RN.Varios.LeerCantLote(idLote, sesion);
            }
            catch (Exception ex)
            {
                apiResponse.SetearExcepcion(ex);
            }
            return apiResponse;
        }
    }
}