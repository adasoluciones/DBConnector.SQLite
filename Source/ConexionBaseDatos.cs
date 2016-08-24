using Ada.Framework.Data.DBConnector.Entities.DataBase;
using Ada.Framework.Data.DBConnector.SQLite.Mapper;
using System;
using System.Data;
using System.Data.SQLite;

namespace Ada.Framework.Data.DBConnector.SQLite
{
    /// <summary>
    /// Representa la conexión a una base de datos SqLite.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public class ConexionBaseDatos : Data.DBConnector.ConexionBaseDatos
    {
        /// <summary>
        /// Constructor que instancia el tipo de base de datos SqLite.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="db">Base de datos.</param>
        public ConexionBaseDatos(ConexionTO db)
           :base(db)
        {

            DBConnection = new SQLiteConnection(Conexion.ConnectionString);
        }

        /// <summary>
        /// Obtiene una implementación de la representación de una consulta a base de datos.
        /// </summary>
        /// <returns>Implementación de una  consulta a base de datos.</returns>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        public override Data.DBConnector.Queries.Query CrearQuery()
        {
            return new Queries.Query(this, new MapeadorDeObjetos(), new QueryCreator());
        }

        /// <summary>
        /// Obtiene una implementación de un procedimiento almacenado.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <returns>Implementación de un procedimiento almacenado.</returns>
        /// <exception cref="System.NotImplementedException">¡SqLite no soporta procedimientos almacenados!</exception>
        public override Data.DBConnector.Queries.SP.ProcedimientoAlmacenado CrearProcedimientoAlmacenado()
        {
            throw new NotImplementedException("¡SqLite no soporta procedimientos almacenados!");
        }

        /// <summary>
        /// Crea una transacción para agrupar las ejecuciones de la instancia actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="isolationLevel">Especifica el comportamiento de bloqueo de la transacción para la conexión.Opcional.</param>
        public override void CrearTransaccion(System.Data.IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            transaccionInterna = new Transaction.Transaccion(DBConnection, isolationLevel);
            transaccionInterna.Iniciar();
        }
    }
}
