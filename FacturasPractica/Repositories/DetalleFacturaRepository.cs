using FacturasPractica.Models;
using FacturasPractica.Helpers;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace FacturasPractica.Repositories
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly string _connectionString;

        public DetalleFacturaRepository(IOptions<DatabaseConfig> config)
        {
            _connectionString = config.Value.DefaultConnection;
        }

        public async Task<IEnumerable<TblDetallesFactura>> GetDetallesFactura(int facturaId)
        {
            var detalles = new List<TblDetallesFactura>();
            var query = "GetDetallesFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FacturaId", facturaId);
                    connection.Open();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var detalle = new TblDetallesFactura
                            {
                                Id = reader.GetInt32("Id"),
                                IdFactura = reader.GetInt32("IdFactura"),
                                IdProducto = reader.GetInt32("IdProducto"),
                                CantidadDeProducto = reader.GetInt32("CantidadDeProducto"),
                                PrecioUnitarioProducto = reader.GetDecimal("PrecioUnitarioProducto"),
                                SubtotalProducto = reader.GetDecimal("SubtotalProducto"),
                                Notas = reader.GetString("Notas")
                            };
                            detalles.Add(detalle);
                        }
                    }
                }
            }

            return detalles;
        }

        public async Task AddDetalleFactura(TblDetallesFactura detalleFactura)
        {
            var query = "InsertDetalleFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdFactura", detalleFactura.IdFactura);
                    command.Parameters.AddWithValue("@IdProducto", detalleFactura.IdProducto);
                    command.Parameters.AddWithValue("@CantidadDeProducto", detalleFactura.CantidadDeProducto);
                    command.Parameters.AddWithValue("@PrecioUnitarioProducto", detalleFactura.PrecioUnitarioProducto);
                    command.Parameters.AddWithValue("@SubtotalProducto", detalleFactura.SubtotalProducto);
                    command.Parameters.AddWithValue("@Notas", detalleFactura.Notas);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateDetalleFactura(TblDetallesFactura detalleFactura)
        {
            var query = "UpdateDetalleFactura";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", detalleFactura.Id);
                    command.Parameters.AddWithValue("@IdFactura", detalleFactura.IdFactura);
                    command.Parameters.AddWithValue("@IdProducto", detalleFactura.IdProducto);
                    command.Parameters.AddWithValue("@CantidadDeProducto", detalleFactura.CantidadDeProducto);
                    command.Parameters.AddWithValue("@PrecioUnitarioProducto", detalleFactura.PrecioUnitarioProducto);
                    command.Parameters.AddWithValue("@SubtotalProducto", detalleFactura.SubtotalProducto);
                    command.Parameters.AddWithValue("@Notas", detalleFactura.Notas);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteDetalleFactura(int id)
        {
            var query = "DeleteDetalleFactura";

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
