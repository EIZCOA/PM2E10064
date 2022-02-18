using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E10064.Models
{
    public class Sitios
    {
        //Lineamientos examen
        //Clase sitios (Imagen, latitud, longitud, descripción)

        [PrimaryKey, AutoIncrement]
        public int id_sitio { get; set; }

        public byte[] imagen { get; set; }

        [MaxLength(50)]
        public String latitud { get; set; }

        [MaxLength(50)]
        public String longitud { get; set; }

        [MaxLength(150)]
        public String descripcion { get; set; }
    }
}
