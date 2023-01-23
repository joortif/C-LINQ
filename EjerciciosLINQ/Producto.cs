using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosLINQ
{
    internal class Producto : IEquatable<Producto>
    {
        private string categoria;
        public string Categoria { get { return categoria; } }
        private string descripcion;
        public string Descripcion { get { return descripcion; } }
        private double precio;
        public double Precio { get { return precio; } }

        private int productoId;
        public int ProductoId { get { return productoId; } }

        public Producto(string categoria, string descripcion, double precio, int productoId)
        {
            this.categoria = categoria;
            this.descripcion = descripcion;
            this.precio = precio;
            this.productoId = productoId;
        }

        public bool Equals(Producto? other)
        {
            if (other == null)
            {
                return this == null;
            }
            else
            {
                return this.ProductoId.Equals(other.ProductoId);
            }
        }

        public override string ToString()
        {
            return "Id: " + this.ProductoId + "\r\n"
                + "Categoria: " + this.Categoria + "\r\n"
                + "Descripcion: " + this.Descripcion + "\r\n"
                + "Precio: " + this.Precio + "\r\n";
        }
    }
}
