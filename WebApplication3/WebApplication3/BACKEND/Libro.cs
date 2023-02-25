using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.BACKEND
{
    public class Libro
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int NumeroEdicion { get; set; }
        public string AnioPublicacion { get; set; }
        public string NombreAutores { get; set; }
        public string Pais { get; set; }
        public string Sinopsis { get; set; }
        public string Carrera { get; set; }
        public string Materia { get; set; }
    }
}