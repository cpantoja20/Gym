using System;
using System.Collections.Generic;
using System.Text;
using Datos;
using Entidades;
using System.Data;
namespace Logica
{
    public class GestionProducto
    {
        BaseDeDatos bd = new BaseDeDatos();

        public string guardar(Producto p)
        {
            try
            {
               
                string sentencia = string.Format("insert into productos(nombre,descripcion,cantidad,precio_compra,precio_venta) values ('{0}','{1}','{2}','{3}','{4}')", p.nombre, p.descripcion, p.cantidad, p.precio_compra, p.precio_venta);
                bd.ejecutar(sentencia);
                return "Guardado Correctamente";
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
            string sentencia = "select * from productos";
            return bd.select(sentencia);
        }

       

        public List<Producto> Lista()
        {
            List<Producto> lista = new List<Producto>();
            string sentencia = "select * from productos";
            DataTable tabla = bd.select(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {
                Producto p = new Producto();
                p.id = fila["id"].ToString();
                p.nombre = fila["nombre"].ToString();
                p.descripcion = fila["descripcion"].ToString();
                p.cantidad = int.Parse(fila["cantidad"].ToString());
                p.precio_compra = Decimal.Parse(fila["precio_compra"].ToString());
                p.precio_venta = Decimal.Parse(fila["precio_venta"].ToString());
           
                lista.Add(p);
            }
            return lista;
        }

        public Producto buscar(string id)
        {
            foreach (Producto p in Lista())
            {
                if (p.id.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }

        public string editar(Producto p)
        {
            try
            {
                string sentencia = string.Format("update productos set nombre='{1}', descripcion ='{2}', cantidad = '{3}',precio_compra ='{4}',precio_venta = '{5}' where id = '{0}'", 
                    p.id, p.nombre, p.descripcion, p.cantidad, p.precio_compra, p.precio_venta);
                bd.ejecutar(sentencia);
                return "Editado Correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }
        public Boolean eliminar(string id)
        {
            try
            {
                string sentencia = string.Format("delete from Productos where id = '{0}'", id);
                bd.ejecutar(sentencia);
                return true;
            }
            catch (Exception e)
            {
                return  false;
                throw;
            }
        }

        public DataTable top10masvendidos()
        {
            string sentencia = "SELECT DISTINCT TOP 10 p.id as ID,p.nombre as PRODUCTO,p.descripcion as DESCRIPCION, p.cantidad AS CANTIDAD_ACTUAL,p.precio_compra as PRECIO_DE_COMPRA,p.precio_venta as PRECIO_DE_VENTA,(SELECT SUM(cantidad_por_producto) from detalle_venta where id_producto = p.id) as TOTAL_VENDIDO FROM productos p order by TOTAL_VENDIDO desc";
            return bd.select(sentencia);
        }
    }
}
