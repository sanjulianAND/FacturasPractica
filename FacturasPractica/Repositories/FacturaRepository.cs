using FacturasPractica.Models;
using FacturasPractica.Helpers;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace FacturasPractica.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly string _connectionString;

        public FacturaRepository(IOptions<DatabaseConfig> config)
        {
            _connectionString = config.Value.DefaultConnection;
        }

        public async Task<IEnumerable<TblFacturas>> GetFacturas()
        {
            var facturas = new List<TblFacturas>();
            var query = "GetFacturas";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var factura = new TblFacturas
                            {
                                Id = reader.GetInt32("Id"),
                                FechaEmisionFactura = reader.GetDateTime("FechaEmisionFactura"),
                                IdCliente = reader.GetInt32("IdCliente"),
                                NumeroFactura = reader.GetInt32("NumeroFactura"),
                                NumeroTotalArticulos = reader.GetInt32("NumeroTotalArticulos"),
                                SubTotalFacturas = reader.GetDecimal("SubTotalFacturas"),
                                TotalImpuestos = reader.GetDecimal("TotalImpuestos"),
                                TotalFactura = reader.GetDecimal("TotalFactura"),
                                Cliente = new TblClientes
                                {
                                    Id = reader.GetInt32("IdCliente"),
                                    RazonSocial = reader.GetString("RazonSocial")
                                }
                            };
                            facturas.Add(factura);
                        }
                    }
                }
            }

            return facturas;
        }

        public async Task<TblFacturas> GetFactura(int id)
        {
            TblFacturas factura = null;
            var query = "GetFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            factura = new TblFacturas
                            {
                                Id = reader.GetInt32("Id"),
                                FechaEmisionFactura = reader.GetDateTime("FechaEmisionFactura"),
                                IdCliente = reader.GetInt32("IdCliente"),
                                NumeroFactura = reader.GetInt32("NumeroFactura"),
                                NumeroTotalArticulos = reader.GetInt32("NumeroTotalArticulos"),
                                SubTotalFacturas = reader.GetDecimal("SubTotalFacturas"),
                                TotalImpuestos = reader.GetDecimal("TotalImpuestos"),
                                TotalFactura = reader.GetDecimal("TotalFactura"),
                                Cliente = new TblClientes
                                {
                                    Id = reader.GetInt32("IdCliente"),
                                    RazonSocial = reader.GetString("RazonSocial")
                                }
                            };
                        }
                    }
                }
            }

            return factura;
        }

        public async Task AddFactura(TblFacturas factura)
        {
            var query = "InsertFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FechaEmisionFactura", factura.FechaEmisionFactura);
                    command.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                    command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                    command.Parameters.AddWithValue("@NumeroTotalArticulos", factura.NumeroTotalArticulos);
                    command.Parameters.AddWithValue("@SubTotalFacturas", factura.SubTotalFacturas);
                    command.Parameters.AddWithValue("@TotalImpuestos", factura.TotalImpuestos);
                    command.Parameters.AddWithValue("@TotalFactura", factura.TotalFactura);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateFactura(TblFacturas factura)
        {
            var query = "UpdateFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", factura.Id);
                    command.Parameters.AddWithValue("@FechaEmisionFactura", factura.FechaEmisionFactura);
                    command.Parameters.AddWithValue("@IdCliente", factura.IdCliente);
                    command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                    command.Parameters.AddWithValue("@NumeroTotalArticulos", factura.NumeroTotalArticulos);
                    command.Parameters.AddWithValue("@SubTotalFacturas", factura.SubTotalFacturas);
                    command.Parameters.AddWithValue("@TotalImpuestos", factura.TotalImpuestos);
                    command.Parameters.AddWithValue("@TotalFactura", factura.TotalFactura);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteFactura(int id)
        {
            var query = "DeleteFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
