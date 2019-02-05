using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaAutenticacion.ViewModel
{
    public class EstructuraComentarios
    {
       [Key]
        public int IdComentario { get; set; }
        public string NombreComentario { get; set; }

        public string TextoComentario { get; set; }

        public string PuntajeComentario { get; set; }
        public string Estado { get; set; }
        public string Area { get; set; }
    }
}