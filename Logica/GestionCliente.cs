using System;
using System.Collections.Generic;
using System.Text;
using Datos;
using Entidades;
using System.Data;
namespace Logica
{
    public class GestionCliente
    {
        BaseDeDatos bd = new BaseDeDatos();

        public string guardar(Cliente p)
        {
            try
            {
                string sentencia = string.Format("insert into clientes values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", p.cedula, p.nombre, p.direccion, p.telefono, p.fechaNacimiento, p.pecho, p.cintura, p.cadera, p.idPlan);
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
            string sentencia = "select * from clientes";
            return bd.select(sentencia);
        }

        public List<Cliente> Lista()
        {
            List<Cliente> lista = new List<Cliente>();
            string sentencia = "select * from clientes";
            DataTable tabla = bd.select(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {
                Cliente p = new Cliente();
                p.cedula = fila["cedula"].ToString();
                p.nombre = fila["nombre"].ToString();
                p.direccion = fila["direccion"].ToString();
                p.telefono = fila["telefono"].ToString();
                p.fechaNacimiento = DateTime.Parse(fila["fechaNacimiento"].ToString());
                p.pecho = Double.Parse(fila["pecho"].ToString());
                p.cintura = Double.Parse(fila["cintura"].ToString());
                p.cadera = Double.Parse(fila["cadera"].ToString());
                p.idPlan = fila["idPlan"].ToString();
                lista.Add(p);
            }
            return lista;
        }

        public Cliente buscar(string cedula)
        {
            foreach (Cliente p in Lista())
            {
                if (p.cedula.Equals(cedula))
                {
                    return p;
                }
            }
            return null;
        }

        public string editar(Cliente p)
        {
            try
            {
                string sentencia = string.Format("update clientes set cedula ='{0}', nombre='{1}',direccion ='{2}',telefono = '{3}',fechaNacimiento ='{4}',pecho = '{5}',cintura = '{6}',cadera= '{7}',idPlan = '{8}' where cedula = '{0}'", p.cedula, p.nombre, p.direccion, p.telefono, p.fechaNacimiento, p.pecho, p.cintura, p.cadera, p.idPlan);
                bd.ejecutar(sentencia);
                return "Editado Correctamente";
            }
            catch (Exception e)
            {
                return e.Message;
                throw;
            }
        }
        public Boolean eliminar(string cedula)
        {
            try
            {
                string sentencia = string.Format("delete from clientes where cedula = '{0}'", cedula);
                bd.ejecutar(sentencia);
                return true;
            }
            catch (Exception e)
            {
                return  false;
                throw;
            }
        }
    }
}
