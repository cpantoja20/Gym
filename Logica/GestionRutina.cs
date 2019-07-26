using System;
using System.Collections.Generic;
using System.Text;
using Datos;
using Entidades;
using System.Data;
namespace Logica
{
    public class GestionRutina
    {
        BaseDeDatos bd = new BaseDeDatos();

        public string guardar(Rutina p)
        {
            try
            {
               
                string sentencia = string.Format("insert into rutinas(nombre,descripcion) values ('{0}','{1}')", p.nombre, p.descripcion);
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
            string sentencia = "select * from Rutinas";
            return bd.select(sentencia);
        }

        public List<Rutina> Lista()
        {
            List<Rutina> lista = new List<Rutina>();
            string sentencia = "select * from Rutinas";
            DataTable tabla = bd.select(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {
                Rutina p = new Rutina();
                p.id = fila["id"].ToString();
                p.nombre = fila["nombre"].ToString();
                p.descripcion = fila["descripcion"].ToString();

                lista.Add(p);
            }
            return lista;
        }

        public Rutina buscar(string id)
        {
            foreach (Rutina p in Lista())
            {
                if (p.id.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }

        public string editar(Rutina p)
        {
            try
            {
                string sentencia = string.Format("update rutinas set nombre='{1}', descripcion ='{2}' where id = '{0}'", 
                    p.id, p.nombre, p.descripcion);
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
                string sentencia = string.Format("delete from Rutinas where id = '{0}'", id);
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
