using System.Runtime.Serialization;

namespace Microsoft.ApplicationBlocks.ExceptionManagement
{
    // <summary>
    // Descripción breve de Excepciones.
    // </summary>

    namespace db
    {
        public class ConexionException : Exception
        {
            static string TextoError = "Problema de conexión a base de datos";
            public ConexionException() : base(TextoError)
            {
            }
            public ConexionException(Exception inner) : base(TextoError, inner)
            {
            }
            public ConexionException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public class EjecucionException : Exception
        {
            static string TextoError = "Problema en ejecución de script de SQL";
            public EjecucionException() : base(TextoError)
            {
            }
            public EjecucionException(Exception inner) : base(TextoError, inner)
            {
            }
            public EjecucionException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public class EjecucionConRollbackException : Exception
        {
            static string TextoError = "Problema en ejecución de script de SQL ( Se deshizo la operacion )";
            public EjecucionConRollbackException() : base(TextoError)
            {
            }
            public EjecucionConRollbackException(Exception inner) : base(TextoError, inner)
            {
            }
            public EjecucionConRollbackException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public class RollbackException : Exception
        {
            static string TextoError = "Problema al tratar de deshacer la ejecución de un script de SQL";
            public RollbackException() : base(TextoError)
            {
            }
            public RollbackException(Exception inner) : base(TextoError, inner)
            {
            }
            public RollbackException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
    namespace token
    {
        public class NoAutenticadoException : Exception
        {
            static string TextoError = "Usuario-Clave no autenticado en LoginAuthenticarion";
            public NoAutenticadoException() : base(TextoError)
            {
            }
            public NoAutenticadoException(Exception inner) : base(TextoError, inner)
            {
            }
            public NoAutenticadoException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
