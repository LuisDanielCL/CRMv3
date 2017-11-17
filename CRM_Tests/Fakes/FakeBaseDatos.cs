using CRM_Proyect.Modelo.ClassTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CRM_Tests.Fakes
{
    class FakeBaseDatos : IBaseDatos
    {
        bool salidaAbrir = true;
        bool salidaCerrar = true;
        bool salidaCargarQuery = true;
        bool salidaEjecutarQuery = true;
        bool salidaReader = true;

        public FakeBaseDatos(bool pSalidaCargarQuery, bool pSalidaEjecutarQuery, bool pSalidaReader)
        {
            salidaCargarQuery = pSalidaCargarQuery;
            salidaEjecutarQuery = pSalidaEjecutarQuery;
            salidaReader = pSalidaReader;
        }
        public bool Abrir()
        {
            return salidaAbrir;
        }

        public bool cargarQuery(string query)
        {
            return salidaCargarQuery;
        }

        public bool Cerrar()
        {
            return salidaCerrar; ;
        }

        public bool ejecutarQuery()
        {
            return salidaEjecutarQuery;
        }

        public IDataReader getSalida()
        {
            DataTable table = new DataTable();
            DataRow row = table.NewRow();
            for (int i = 0; i < 25; i++)
            {
                table.Columns.Add(new DataColumn("Salida"+i));
                row["Salida"+i] = "OK";
                
            }
            table.Rows.Add(row);
            DataTableReader reader = new DataTableReader(table);
            if (salidaReader)
            {
                return reader;
            }
            else
            {
                return null;
            }
        }
    }

}  