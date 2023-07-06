using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace paas_sisttransfermep_combcra_misc.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMemoryCache cache;

        public BaseController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        protected Entidades.Sesion Sesion
        {
            get
            {
                var cacheId = "sesion";
                return cache.GetOrCreate<Entidades.Sesion>(cacheId,
                    cacheEntry =>
                    {
                        cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                        Entidades.Sesion sesion = new Entidades.Sesion();

                var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appSettings.json", true, true);

                IConfigurationRoot configurationRoot = builder.Build();

                string servernameDBEnv = configurationRoot.GetConnectionString("servernameDBEnv"); //@"172.23.160.1\MSQL2019";
                string instancenameDBEnv = configurationRoot.GetConnectionString("instancenameDBEnv");
                string nameDBEnv = configurationRoot.GetConnectionString("nameDBEnv");
                string usuarioDBEnv = configurationRoot.GetConnectionString("usuarioDBEnv");
                string passwordDBEnv = CedEncriptador.EncryptDecrypt.DecryptCore(configurationRoot.GetConnectionString("passwordDBEnv"), configurationRoot.GetConnectionString("semilla"));
                string llave = "";

                try
                {
                    llave = configurationRoot.GetConnectionString("llave");
                }
                catch (Exception)
                {
                }

                System.Console.WriteLine("Lee Llave: " + llave);

                //CON USUARIO SQL Y PS ENCRIPADA
                string CnnStr = string.Format("Server={2}\\{3};Database={4};Trusted_Connection=false;user id={0};password={1};", usuarioDBEnv, passwordDBEnv, servernameDBEnv, instancenameDBEnv, nameDBEnv);
                //CON SEGURIDAD INTEGRADA
                //string CnnStr = string.Format("Server={2}\\{3};Database={4};Trusted_Connection=false;Integrated Security=SSPI;", usuarioDBEnv, passwordDBEnv, servernameDBEnv, instancenameDBEnv, nameDBEnv);

                if (!string.IsNullOrEmpty(instancenameDBEnv))
                {
                    sesion.CnnStr = CnnStr;
                }
                else
                {

                    //CON USUARIO SQL Y PS ENCRIPADA
                    sesion.CnnStr = string.Format("Server={2};Database={3};Trusted_Connection=false;user id={0};password={1};", usuarioDBEnv, passwordDBEnv, servernameDBEnv, nameDBEnv);
                    //CON SEGURIDAD INTEGRADA
                    //sesion.CnnStr = string.Format("Server={2};Database={3};Trusted_Connection=false;Integrated Security=SSPI;", usuarioDBEnv, passwordDBEnv, servernameDBEnv, nameDBEnv);
                }
                System.Console.WriteLine("Va a intenar conectar con" + CnnStr);

                //sesion.CnnStr = string.Format("Server={2};Database={3};Trusted_Connection=false;Integrated Security=SSPI;", usuarioDBEnv, passwordDBEnv, servernameDBEnv, nameDBEnv);

                System.Console.WriteLine("Intentado Actualizar Sesión...");
                sesion.Ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                sesion.Cultura = new System.Globalization.CultureInfo("en-GB");
                System.Console.WriteLine("Sesión actualizada");
                RN.Sesion.LeerParm(sesion, llave);
                return sesion;
                });
            
            }
        }
        protected void IdentificarConsumidor(Entidades.Sesion sesion)
        {
            if (sesion.IdentificarConsumidores == null)
            {
                DB.Consumidor db = new DB.Consumidor(sesion);
                db.ObtenerLista();
            }
            if (sesion.IdentificarConsumidores == "SI")
            {
                string id = HttpContext.Request.Headers["app_id"].ToString().ToLower();
                string key = HttpContext.Request.Headers["app_key"].ToString().ToLower();
                Entidades.Consumidor consumidor = sesion.Consumidores.Find((delegate (Entidades.Consumidor e) { return e.Id.ToLower() == id; }));
                if (consumidor == null || consumidor.Key != key) throw new Exception("Authorization Failed (unidentified consumer)");
            }
        }
    }
    public class LogHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogHeadersMiddleware> _logger;
        public static readonly List<string> RequestHeaders = new List<string>();
        public static readonly List<string> ResponseHeaders = new List<string>();

        public LogHeadersMiddleware(RequestDelegate next, ILogger<LogHeadersMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var originalBody = context.Response.Body;

            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            try
            {
                await _next(context);
            }
            finally
            {
                newBody.Seek(0, SeekOrigin.Begin);
                var bodyRequest = await new StreamReader(context.Request.Body).ReadToEndAsync();
                var bodyResponse = await new StreamReader(context.Response.Body).ReadToEndAsync();
                Console.WriteLine($"------------------------   " + System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "   ------------------------");
                Console.WriteLine($"Request Method: {context.Request.Method}");
                Console.WriteLine($"Request Path: {context.Request.Path + context.Request.QueryString}");
                if (bodyRequest != string.Empty) Console.WriteLine($"Request Body: {bodyRequest}");
                Console.WriteLine($"Response StatusCode: {context.Response.StatusCode}");
                Console.WriteLine($"Response Body: {bodyResponse}");
                newBody.Seek(0, SeekOrigin.Begin);
                await newBody.CopyToAsync(originalBody);
            }
        }
    }
}