//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticaAutenticacion
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comentario
    {
        public int IdComentario { get; set; }
        public string NombreComentario { get; set; }
        public string TextoComentario { get; set; }
        public string FechaComentario { get; set; }
        public string PuntosComentario { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
