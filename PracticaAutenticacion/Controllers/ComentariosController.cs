using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticaAutenticacion;
using PracticaAutenticacion.ViewModel;

namespace PracticaAutenticacion.Controllers
{
    public class ComentariosController : Controller
    {
        private ModelMuseoContainer db = new ModelMuseoContainer();

        // GET: Comentarios
        public ActionResult Index()
        {
            List<EstructuraComentarios> ComentarioList = new List<EstructuraComentarios>();
            var equipoList = (from Com in db.ComentarioSet
                              join Est in db.EstadoSet on Com.Estado.IdEstado equals Est.IdEstado join area in 
                              db.AreaSet on Com.Area.IdArea equals area.IdArea
                              select new
                              {
                                  Com.IdComentario,
                                  Com.NombreComentario,
                                  Com.PuntosComentario,
                                  Com.TextoComentario,
                                  Est.NombreEstado,
                                  area.NombreArea
                              }).ToList();
            foreach (var items in equipoList)
            {
                EstructuraComentarios objcvm = new EstructuraComentarios();
                objcvm.IdComentario = items.IdComentario;
                objcvm.NombreComentario = items.NombreComentario;
                objcvm.TextoComentario = items.TextoComentario;
                objcvm.PuntajeComentario = items.PuntosComentario;
                /**/
                /**/
                objcvm.Estado = items.NombreEstado;
                objcvm.Area = items.NombreArea;
                if (objcvm.Estado.Equals("Aprobado"))
                {
                    objcvm.Estado = "✔";
                    ComentarioList.Add(objcvm);
                }
            }
            return View(ComentarioList);
        }

        //GET: Comentarios Moderador
        public ActionResult ListModerador()
        {
            List<EstructuraComentarios> ComentarioList = new List<EstructuraComentarios>();
            var equipoList = (from Com in db.ComentarioSet
                              join Est in db.EstadoSet on Com.Estado.IdEstado equals Est.IdEstado
                              join area in db.AreaSet on Com.Area.IdArea equals area.IdArea
                              select new
                              {
                                  Com.IdComentario,
                                  Com.NombreComentario,
                                  Com.PuntosComentario,
                                  Com.TextoComentario,
                                  Est.NombreEstado,
                                  area.NombreArea
                              }).ToList();
            foreach (var items in equipoList)
            {
                EstructuraComentarios objcvm = new EstructuraComentarios();
                objcvm.IdComentario = items.IdComentario;
                objcvm.NombreComentario = items.NombreComentario;
                objcvm.TextoComentario = items.TextoComentario;
                objcvm.PuntajeComentario = items.PuntosComentario;
                /**/
                /**/
                objcvm.Estado = items.NombreEstado;
                objcvm.Area = items.NombreArea;
               // if (objcvm.Estado.Equals("Aprobado")==false)
                //{
                   ComentarioList.Add(objcvm);
                //}
            }
            return View(ComentarioList);
        }
        // GET: Comentarios/Details/5
        public ActionResult Details(int? id)
        {
            EstructuraComentarios comen = new EstructuraComentarios();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var equipoList = (from Com in db.ComentarioSet
                                  where Com.IdComentario == id
                                  join Est in db.EstadoSet on Com.Estado.IdEstado equals Est.IdEstado
                                  join area in db.AreaSet on Com.Area.IdArea equals area.IdArea
                                  select new
                                  {
                                      Com.IdComentario,
                                      Com.NombreComentario,
                                      Com.PuntosComentario,
                                      Com.TextoComentario,
                                      Est.NombreEstado,
                                      area.NombreArea
                                  }).ToList();
                foreach (var items in equipoList)
                {
                    EstructuraComentarios objcvm = new EstructuraComentarios();
                    objcvm.IdComentario = items.IdComentario;
                    objcvm.NombreComentario = items.NombreComentario;
                    objcvm.TextoComentario = items.TextoComentario;
                    objcvm.PuntajeComentario = items.PuntosComentario;
                    objcvm.Estado = items.NombreEstado;
                    objcvm.Area = items.NombreArea;
                    comen = objcvm;
                }
            }
            return View(comen);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            LenarComboAreas();
            ViewBag.FechaGenerada = System.DateTime.Now.ToString();
            return View();
        }

        // POST: Comentarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Create([Bind(Include = "IdComentario,NombreComentario,TextoComentario,FechaComentario,PuntosComentario")] Comentario comentario)
        public ActionResult Create(Comentario Objcomentario)
        {
            if (ModelState.IsValid)
            {
                //db.ComentarioSet.Add(comentario);
                // db.SaveChanges();
                // return RedirectToAction("Index");
                ModelMuseoContainer bd = new ModelMuseoContainer();
                int currentArea = Convert.ToInt32(Request.Form["IdArea"]);
                string puntaje = Request.Form["Puntajecomentario"].ToString();
                int defaultEstado = 3;
                var ObjArea = (from q in bd.AreaSet where q.IdArea == currentArea select q).FirstOrDefault();
                var ObjEstado = (from q in bd.EstadoSet where q.IdEstado == defaultEstado select q).FirstOrDefault();
                Objcomentario.Area = ObjArea;
                Objcomentario.Estado = ObjEstado;
                Objcomentario.PuntosComentario = puntaje;
                bd.ComentarioSet.Add(Objcomentario);
                bd.SaveChanges();  
            }

            return RedirectToAction("Index");
        }

        // GET: Comentarios/Edit/5
        public ActionResult Edit(int? id)
        {
            LenarCombo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.ComentarioSet.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comentario Objcomentario)
        {
            if (ModelState.IsValid)
            {
                //db.ComentarioSet.Add(comentario);
                // db.SaveChanges();
                // return RedirectToAction("Index");
                using (ModelMuseoContainer bd = new ModelMuseoContainer())
                {
                    int currentArea = Convert.ToInt32(Request.Form["IdArea"]);
                    int currentEstado = Convert.ToInt32(Request.Form["IdEstado"]);
                    //var ObjArea = (from q in bd.AreaSet where q.IdArea == currentArea select q).FirstOrDefault();
                    var ObjEstado = (from q in bd.EstadoSet where q.IdEstado == currentEstado select q).FirstOrDefault();
                    //Objcomentario.Area = ObjArea;
                    //Objcomentario.Estado = ObjEstado;
                    //bd.ComentarioSet.Add(Objcomentario);
                    var u  = (from q in bd.ComentarioSet where q.IdComentario == Objcomentario.IdComentario select q).FirstOrDefault();
                    if(u != null)
                    {
                        u.Estado = ObjEstado;
                    }
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("ListModerador");
        }

        public void LenarCombo(object selectedEstado = null)
        {
            var estado_query = (from d in db.EstadoSet orderby d.NombreEstado select d);
            ViewBag.IdEstado = new SelectList(estado_query,"IdEstado","NombreEstado",selectedEstado);
        }

        public void LenarComboAreas(Object selectedArea = null)
        {
            var areas_query = (from d in db.AreaSet orderby d.NombreArea select d);
            ViewBag.IdArea = new SelectList(areas_query, "IdArea", "NombreArea", selectedArea);
        }

        
        // GET: Comentarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.ComentarioSet.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.ComentarioSet.Find(id);
            db.ComentarioSet.Remove(comentario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
