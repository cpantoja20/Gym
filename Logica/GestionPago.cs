using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Logica
{
    public class GestionPago
    {
        BaseDeDatos bd = new BaseDeDatos();

        public string guardar(Pago p)
        {
            try
            {
                string sentencia = string.Format("insert into pagos(id_cliente,forma_de_pago,opcion_de_pago,valor) values ('{0}','{1}','{2}','{3}')", p.cliente.cedula,p.forma_de_pago,p.opcion_de_pago,p.valor);
                bd.ejecutar(sentencia);
                return "Pago Registrado Correctamente";
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
            string sentencia = "select p.id as ID, c.cedula as CEDULA, c.nombre as CLIENTE,'('+pl.id +') '+pl.nombre as PLAN_ADQUIRIDO,p.forma_de_pago AS FORMA_DE_PAGO,p.opcion_de_pago as OPCION_DE_PAGO, p.valor AS VALOR_PAGADO, fecha as FECHA from pagos p ,clientes c, planes pl where p.id_cliente=c.cedula and c.idPlan=pl.id";
            return bd.select(sentencia);
        }

        public List<Pago> Lista()
        {
            List<Pago> lista = new List<Pago>();
            string sentencia = "select * from pagos";
            DataTable tabla = bd.select(sentencia);


            foreach (DataRow fila in tabla.Rows)
            {

                Pago p = new Pago();
                p.id = fila["id"].ToString();
                p.fecha = DateTime.Parse(fila["fecha"].ToString());
                p.valor = Double.Parse(fila["valor"].ToString());
                GestionCliente lcl = new GestionCliente();
                p.cliente = lcl.buscar(fila["id_cliente"].ToString());
                p.forma_de_pago = fila["forma_de_pago"].ToString();
                p.opcion_de_pago = fila["opcion_de_pago"].ToString();

                lista.Add(p);
            }
            return lista;
        }
        public Pago buscar(string id)
        {
            foreach (Pago p in Lista())
            {
                if (p.id.Equals(id))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
