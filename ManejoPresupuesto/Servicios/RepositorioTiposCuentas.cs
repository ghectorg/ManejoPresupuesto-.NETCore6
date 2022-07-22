﻿using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public interface IRepositorioTiposCuentas
    {
        Task Crear(TipoCuenta tipoCuenta);
        Task<bool> Existe(string nombre, int usuarioId);
        Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId);
    }
    public class RepositorioTiposCuentas: IRepositorioTiposCuentas
    {
        private readonly string connectionString; 
        public RepositorioTiposCuentas(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO TiposCuentas(Nombre, UsuarioId, Orden)
                                                    VALUES (@Nombre, @UsuarioId, 0);
                                                    SELECT SCOPE_IDENTITY();", tipoCuenta);
        }

        public async Task<bool> Existe(string nombre, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1
                                                    FROM TiposCuentas
                                                    WHERE Nombre = @nombre AND UsuarioId = @usuarioId;", 
                                                    new {nombre, usuarioId});

            return existe == 1;

        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            return await connection.QueryAsync<TipoCuenta>(@"SELECT Id, Nombre, Orden
                                                            FROM TiposCuentas
                                                            WHERE UsuarioId = @usuarioId", new {usuarioId});
        }
    }
}
