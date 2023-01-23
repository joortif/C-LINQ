using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosLINQ
{
    internal class Pedido : IEquatable<Pedido>
    {

        private DateTime fechaPedido;

        public DateTime FechaPedido { get { return fechaPedido; } }

        private int pedidoId;

        public int PedidoId { get { return pedidoId; } }

        private Producto productoPedido;

        public Producto ProductoPedido { get { return this.productoPedido; } }

        private double total;

        public double Total { get { return this.total; } }

        public Pedido(DateTime fechaPedido, int pedidoId, Producto productoPedido, double total)
        {
            this.fechaPedido = fechaPedido;
            this.pedidoId = pedidoId;
            this.productoPedido = productoPedido;
            this.total = total;
        }

        public bool Equals(Pedido? other)
        {
            if (other == null)
            {
                return this == null;
            }
            else
            {
                return this.PedidoId.Equals(other.PedidoId);
            }
        }

        public override string ToString()
        {
            return "Id: " + this.PedidoId + "\r\n"
                + "Fecha: " + this.FechaPedido + "\r\n"
                + "Producto: \r\n" + this.ProductoPedido.ToString()
                + "Total: " + this.Total + "\r\n";
        }
    }
}
