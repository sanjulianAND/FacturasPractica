﻿namespace FacturasPractica.Models
{
    public class CatProductos
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public byte[] ImagenProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string ext { get; set; }
    }
}
