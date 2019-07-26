using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Logica
{
    public class GestionPlan
    {
        BaseDeDatos bd = new BaseDeDatos();

        public string guardar(Plan p)
        {
            try
            {
                string sentencia = string.Format("insert into planes(id,nombre,precio,duracion) values('{0}','{1}','{2}','{3}')",p.id, p.nombre, p.precio, p.duracion);
                bd.ejecutar(sentencia);
                //aqui inserto todas las rutinas de este plan
                foreach (Rutina rutina in p.rutinas)
                {
                    string sentencia2 = string.Format("insert into relacion_planes_rutinas(id_plan,id_rutina) values('{0}','{1}')", p.id, rutina.id);
                    bd.ejecutar(sentencia2);
                }
                
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
            string sentencia = "select id,nombre,precio,duracion, (select count(*) from dbo.relacion_planes_rutinas where id_plan = p.id) AS Total_de_rutinas  from planes p;";
            return bd.select(sentencia);
        }

        public List<Plan> Lista()
        {
            List<Plan> lista = new List<Plan>();
            string sentencia = "select * from Planes";
            DataTable tabla = bd.select(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {
                Plan p = new Plan();
                p.id = fila["id"].ToString();
                p.nombre = fila["nombre"].ToString();
                p.precio = Decimal.Parse(fila["precio"].ToString());
                p.duracion = fila["duracion"].ToString();
                lista.Add(p);
            }
            return lista;
        }
        public Plan buscar(string id)
        {
            foreach (Plan p in Lista())
            {
                if (p.id.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }

        public string editar(Plan p,string id_original)
        {
            try
            {
                //Aqui edito el plan
                string sentencia = string.Format("update Planes set id ='{0}', nombre='{1}', precio ='{2}', duracion = '{3}' where id = '{4}'",
                    p.id, p.nombre, p.precio, p.duracion,id_original);
                bd.ejecutar(sentencia);
                //aqui elimino las rutinas anteriores de este plan
                string sentencia2 = string.Format("delete from relacion_planes_rutinas where id_plan = '{0}'", p.id);
                bd.ejecutar(sentencia2);
                //aqui inserto las nuevas rutinas de este plan
                foreach (Rutina rutina in p.rutinas)
                {
                    string sentencia3 = string.Format("insert into relacion_planes_rutinas(id_plan,id_rutina) values('{0}','{1}')", p.id, rutina.id);
                    bd.ejecutar(sentencia3);
                }
                //aqui edito el codigo del plan pa los clientes q lo tenian
                string sentencia4 = string.Format("update clientes set idPlan ='{0}' where idPlan = '{1}'",
                    p.id, id_original);
                bd.ejecutar(sentencia4);
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
                string sentencia = string.Format("delete from relacion_planes_rutinas where id_plan = '{0}'", id);
                bd.ejecutar(sentencia);
                string sentencia2 = string.Format("delete from Planes where id = '{0}'", id);
                bd.ejecutar(sentencia2);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public List<Rutina> MiListaDeRutinas(string id_plan)
        {
            List<Rutina> lista = new List<Rutina>();
            string sentencia = string.Format("select r.id as id,r.nombre as nombre ,r.descripcion as descripcion from rutinas r, relacion_planes_rutinas rel where r.id = rel.id_rutina and rel.id_plan ='{0}';",id_plan);
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

        public DataTable top10masescogidos()
        {
            string sentencia = "SELECT DISTINCT TOP 10 p.id as ID,p.nombre as NOMBRE,p.precio as PRECIO, p.duracion AS DURACION,(SELECT COUNT(*) from clientes where idPlan = p.id) as TOTAL_CLIENTES_USANDOLO FROM planes p order by TOTAL_CLIENTES_USANDOLO desc";
            return bd.select(sentencia);
        }
    }
}
