using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosLINQ
{
    internal class Cliente : IEquatable<Cliente>
    {
        private int clienteId;

        public int ClienteId { get { return clienteId; } }

        private string nombre;

        public string Nombre { get { return nombre; } }

        private Pedido[] pedidos;

        public Pedido[] Pedidos { get { return pedidos; } }

        public Cliente(int id, string nom, Pedido[] peds)
        {
            this.clienteId = id;
            this.nombre = nom;
            this.pedidos = peds;
        }

        public bool Equals(Cliente? other)
        {
            if (other == null)
            {
                return this == null;
            } else
            {
                return this.ClienteId.Equals(other.ClienteId);
            }
        }

        public override string ToString()
        {
            string pedidosString = "";
            foreach(Pedido p in this.Pedidos)
            {
                pedidosString += p.ToString();
            }
            return "Id: " + this.ClienteId + "\r\n"
                + "Nombre: " + this.Nombre + "\r\n"
                + "Pedidos: \r\n" + pedidosString + "--------------------------------------\r\n" ;

        }
    }
}
