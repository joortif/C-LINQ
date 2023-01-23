using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosLINQ;

class Program
{
    static void Main(string[] args)
    {
        Producto p1 = new Producto("A", "a", 34.5, 24);
        Producto p2 = new Producto("A", "aa", 37, 25);
        Producto p3 = new Producto("B", "aaa", 40, 26);
        Producto p4 = new Producto("B", "aaaa", 10, 1);
        Producto p5 = new Producto("C", "aaaaa", 23.5, 2);
        Producto p6 = new Producto("C", "aaaaaa", 15, 3);
        IEnumerable<Producto> ListaProductos = new Producto[]
        {
            p1,p2,p3,p6,p5,p4
        };

        Pedido pe1 = new Pedido(DateTime.Now.AddDays(-20), 1, p1, p1.Precio);
        Pedido pe2 = new Pedido(DateTime.Now.AddDays(-25), 2, p2, p2.Precio);
        Pedido pe3 = new Pedido(DateTime.Now.AddDays(-1), 3, p3, p3.Precio);
        Pedido pe4 = new Pedido(DateTime.Now.AddDays(-15), 4, p1, 101);
        Pedido pe5 = new Pedido(DateTime.Now.AddDays(-10), 5, p4, p4.Precio);
        Pedido pe6 = new Pedido(DateTime.Now.AddDays(-2), 6, p5, p5.Precio);

        IEnumerable<Pedido> ListaPedidos = new Pedido[]
        {
            pe1, pe2,pe3,pe4,pe5,pe6
        };

        Cliente c1 = new Cliente(25, "José", new Pedido[] { pe1, pe6 });
        Cliente c2 = new Cliente(10, "Ana", new Pedido[] { pe2, pe3 });
        Cliente c3 = new Cliente(20, "Pedro", new Pedido[] { pe4 });
        Cliente c4 = new Cliente(30, "Alberto", new Pedido[] { pe6 });

        IEnumerable<Cliente> ListaClientes = new Cliente[]
        {
            c1,c2,c3,c4
        };

        List<Cliente> Clientes = ListaClientes.ToList();
        List<Pedido> Pedidos = ListaPedidos.ToList();
        List<Producto> Productos = ListaProductos.ToList();

        Console.WriteLine("--------Ejercicio 1:--------");
        Productos.Where(p => p.Precio >= 30).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 2:--------");

        Productos.Select(p => p.Descripcion).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 3:--------");

        var pedidosAna = Clientes.Where(c => c.Nombre.Equals("Ana")).SelectMany(c => c.Pedidos).ToList();
        pedidosAna.ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 4:--------");

        var pedidosProdAna = Clientes.Where(c => c.Nombre.Equals("Ana")).SelectMany(c => c.Pedidos).Select(p => p.ProductoPedido).ToList();
        pedidosProdAna.ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 5:--------");

        Clientes.OrderBy(c => c.Nombre).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 6:--------");

        Productos.OrderBy(p => p.Categoria).ThenByDescending(p => p.Precio).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 7:--------");
        //¿?¿?¿?¿?¿?¿¿?¿¿¿?¿?¿?¿
        Productos.SelectMany(p => p.Categoria).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 8:--------");

        var c = Clientes.Where(c => c.ClienteId.Equals(25)).FirstOrDefault();
        if (c == null) { Console.WriteLine("No existe"); } 
        else { Console.WriteLine(c.ToString()); }

        Console.WriteLine("--------Ejercicio 9:--------");

        var p = Pedidos.OrderByDescending(p => p.FechaPedido).FirstOrDefault();
        if (p == null) { Console.WriteLine("Pedidos vacíos"); }
        else { Console.WriteLine( (p as Pedido).ToString()); }

        Console.WriteLine("--------Ejercicio 10:--------");

        var pr = Productos.OrderBy(p => p.Precio).FirstOrDefault();
        if (pr == null) { Console.WriteLine("Productos vacíos"); }
        else { Console.WriteLine((pr as Producto).ToString()); }

        //También se podría
        //var pr2 = Productos.OrderByDescending(p => p.Precio).LastOrDefault();
        //if (pr2 == null) { Console.WriteLine("Productos vacíos"); }
        //else { Console.WriteLine((pr2 as Producto).ToString()); }

        Console.WriteLine("--------Ejercicio 11:--------");

        bool ex = Pedidos.Any(p => p.Total > 100);
        if (ex) { Console.WriteLine("Existe al menos un pedido cuyo importe total sea mayor a 100"); } 
        else { Console.WriteLine("No existe ningun pedido cuyo importe total sea menor que 100"); }

        Console.WriteLine("--------Ejercicio 12:--------");

        Productos.Where(p => p.Categoria.Equals("A")).ToList().ForEach(Console.WriteLine);

        Console.WriteLine("--------Ejercicio 13:--------");

        int i = Productos.Where(p => p.Precio > 30).Count();
        Console.WriteLine("Existen " + i + " productos cuyo precio unitario es mayor 30");

        Console.WriteLine("--------Ejercicio 14:--------");

        double suma = Pedidos.Where(p => p.ProductoPedido.ProductoId.Equals(24)).Select(p => p.Total).Sum();

        Console.WriteLine("La suma de los importes de los pedidos del producto cuyo identificador es 24 es: " + suma);
    }
}
