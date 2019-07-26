using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Logica
{
    public class GestionVenta
    {
        BaseDeDatos bd = new BaseDeDatos();

        public string guardar(Venta p)
        {
            try
            {
                string sentencia = string.Format("insert into ventas(id_cliente,total) values ('{0}','{1}')",p.cliente.cedula,p.total);
                bd.ejecutar(sentencia);
                string sentencia2 = "select max(id) as id from ventas";
                string id_venta = bd.select(sentencia2).Rows[0]["id"].ToString();
                foreach (Producto producto in p.productos)
                {
                    string sentencia3 = string.Format("insert into detalle_venta(id_venta,id_producto,cantidad_por_producto) values ('{0}','{1}','{2}')", id_venta, producto.id, producto.cantidad);
                    bd.ejecutar(sentencia3);
                    string sentencia4 = string.Format("update productos set cantidad = (cantidad - {0}) where id ='{1}'", producto.cantidad, producto.id);
                    bd.ejecutar(sentencia4);
                }
                return "Venta Registrada Correctamente";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
                throw;
            }
        }

        //-----------------------------------------------------------------------------------

        public DataTable listar()
        {
            string sentencia = "SELECT v.id as ID,c.cedula as CEDULA, c.nombre as CLIENTE,v.fecha as FECHA, (select count(*) from detalle_venta where id_venta = v.id) as TOTAL_DE_PRODUCTOS, v.total as TOTAL_NETO_VENTA  from ventas v, clientes c where v.id_cliente = c.cedula";
            return bd.select(sentencia);
        }

        public List<Venta> Lista()
        {
            List<Venta> lista = new List<Venta>();
            string sentencia = "select * from ventas";
            DataTable tabla = bd.select(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {

                Venta p = new Venta();
                p.id = fila["id"].ToString();
                p.fecha = DateTime.Parse(fila["fecha"].ToString());
                p.total = Double.Parse(fila["total"].ToString());
                GestionCliente lcl = new GestionCliente();
                p.cliente = lcl.buscar(fila["id_cliente"].ToString());
                p.productos = MiListaDeProductos(p.id);
                lista.Add(p);
            }
            return lista;
        }
        public Venta buscar(string id)
        {
            foreach (Venta p in Lista())
            {
                if (p.id.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }



        

        public List<Producto> MiListaDeProductos(string id_Venta)
        {
            List<Producto> lista = new List<Producto>();
            string sentencia = string.Format("select * from detalle_venta where id_venta ='{0}';",id_Venta);
            DataTable tabla = bd.select(sentencia);
            GestionProducto lpr = new GestionProducto();
            foreach (DataRow fila in tabla.Rows)
            {
                string id_producto = fila["id_producto"].ToString();
                Producto p = lpr.buscar(id_producto) ;
                p.cantidad = int.Parse(fila["cantidad_por_producto"].ToString());

                lista.Add(p);
            }
            return lista;
        }

        public DataTable listarVentasPorFecha(string fecha1,string fecha2)
        {
            string sentencia = string.Format("SELECT v.id as ID,c.cedula as CEDULA, c.nombre as CLIENTE,v.fecha as FECHA, (select count(*) from detalle_venta where id_venta = v.id) as TOTAL_DE_PRODUCTOS, v.total as TOTAL_NETO_VENTA  from ventas v, clientes c where v.id_cliente = c.cedula and v.fecha BETWEEN '{0}' and '{1}'", fecha1,fecha2);
            return bd.select(sentencia);
        }
    }
}
