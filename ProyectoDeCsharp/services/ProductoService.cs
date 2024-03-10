﻿using Proyecto_finalRocioBRomano.database;
using Proyecto_finalRocioBRomano.models;

namespace ProyectoDeCsharp.services
{
    public class ProductoService
    {
        private CoderContext context;

        public ProductoService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public List<Producto> ObtenerTodosLosProductos()
        {
            try
            {
                return this.context.Productos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los productos: {ex.Message}", ex);
            }
        }

        public static Producto ObtenerProductoPorID(int id)
        {
            try
            {
                using (CoderContext contexto = new CoderContext())
                {
                    Producto productoBuscado = contexto.Productos.FirstOrDefault(p => p.Id == id)
                        ?? throw new Exception($"No se encontró un producto con ID {id}");

                    return productoBuscado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el producto por ID: {ex.Message}", ex);
            }
        }

        public bool AgregarProducto(ProductoDTO dto)
        {
            try
            {
                // puedo generar capa de mapper con automapper. 1:02
                Producto p = new Producto();
                p.Id = dto.Id;
                p.Descripciones = dto.Descripciones;
                p.Costo = dto.Costo;
                p.PrecioVenta = dto.PrecioVenta;
                p.Stock = dto.Stock;
                p.IdUsuario = dto.IdUsuario;

                this.context.Productos.Add(p);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el producto: {ex.Message}", ex);
            }
        }

        public bool ModificarProductoPorId(int id, ProductoDTO productoDTO)
        {
            try
            {
                Producto? producto = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

                if (producto is not null)
                {
                    producto.PrecioVenta = productoDTO.PrecioVenta;
                    producto.Stock = productoDTO.Stock;
                    producto.Descripcion = productoDTO.Descripciones;
                    producto.IdUsuario = productoDTO.IdUsuario;
                    producto.Costo = productoDTO.Costo;

                    this.context.Productos.Update(producto);
                    this.context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar el producto: {ex.Message}", ex);
            }
        }

        public bool EliminarProductoPorID(int id)
        {
            try
            {
                Producto? producto = this.context.Productos.Where(p => p.Id == id).FirstOrDefault();

                if (producto is not null)
                {
                    this.context.Remove(producto);
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto: {ex.Message}", ex);
            }
        }
    }
}
