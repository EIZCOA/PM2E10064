using System;
using System.Collections.Generic;
using System.Text;
using PM2E10064.Models;
using SQLite;
using System.Threading.Tasks;
using System.IO;


namespace PM2E10064.Controlador
{
    public class ExamenDB
    {
        readonly SQLiteAsyncConnection db;

        // Declaramos constructor de clase (vacio)
        public ExamenDB()
        {
        }

        //Declaramos constructor de clase con parametros

        public ExamenDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // Create Table DB
            db.CreateTableAsync<Sitios>();

        }

        // Procedimientos y funciones CRUD

        // Retorna la tabla de sitios como una lista
        public Task<List<Sitios>> listasitios()
        {

            return db.Table<Sitios>().ToListAsync();


        }

        // Buscar sitio por ID
        public Task<Sitios> ObtenerSitio(int scodigo)
        {
            return db.Table<Sitios>()
                .Where(i => i.id_sitio == scodigo)
                .FirstOrDefaultAsync();
        }

        // Save and update sitio
        public Task<Int32> SitioGuardar(Sitios sitio)
        {
            if (sitio.id_sitio != 0)
            {
                return db.UpdateAsync(sitio);
            }
            else
            {
                return db.InsertAsync(sitio);
            }
        }

        // Delete sitio
        public Task<Int32> SitioEliminar(Sitios sitio)
        {
            return db.DeleteAsync(sitio);
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }


    }
}
