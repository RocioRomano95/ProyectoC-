﻿namespace ProyectoDeCsharp.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal? Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
