using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCadeMeuJogo.Interfaces.Context;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Context;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Controllers
{
    public class EmprestimosController : Controller
    {
        private ICadeMeuJogoContext db;
        private IEmprestimoValidation _validation;

        public EmprestimosController(ICadeMeuJogoContext context, IEmprestimoValidation validation)
        {
            db = context;
            _validation = validation;
        }

        // GET: Emprestimos
        public ActionResult Index()
        {
            var emprestimos = db.Emprestimos.Where(e => e.Ativo).Include(e => e.Amigo);
            return View(emprestimos.ToList());
        }

        // GET: Emprestimos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public ActionResult Create()
        {
            ViewBag.AmigoId = new SelectList(db.Amigos.Where(a => a.Ativo), "Id", "Nome");
            ViewBag.Jogos = new SelectList(db.Jogos.Where(j => j.Ativo && j.Disponivel), "Id", "Nome");
            return View();
        }

        // POST: Emprestimos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataInicio,DataFim,AmigoId,DataCadastro,Ativo")] Emprestimo emprestimo)
        {
            try
            {
                IncluirJogosParaEmprestimo(emprestimo);
                if (_validation.IsValid(emprestimo))
                {
                    MudarEstadoDoJogo(db, emprestimo.Jogos);
                    db.Emprestimos.Add(emprestimo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.AmigoId = new SelectList(db.Amigos.Where(a => a.Ativo), "Id", "Nome");
            ViewBag.Jogos = new SelectList(db.Jogos.Where(j => j.Ativo && j.Disponivel), "Id", "Nome");
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmigoId = new SelectList(db.Amigos.Where(a => a.Ativo), "Id", "Nome");
            ViewBag.Jogos = new SelectList(db.Jogos.Where(j => j.Ativo && j.Disponivel), "Id", "Nome");
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataInicio,DataFim,AmigoId,DataCadastro,Ativo")] Emprestimo emprestimo)
        {
            try
            {
                IncluirJogosParaEmprestimo(emprestimo);
                if (_validation.IsValid(emprestimo))
                {
                    MudarEstadoDoJogo(db, emprestimo.Jogos);
                    db.Entry(emprestimo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.AmigoId = new SelectList(db.Amigos.Where(a => a.Ativo), "Id", "Nome");
            ViewBag.Jogos = new SelectList(db.Jogos.Where(j => j.Ativo && j.Disponivel), "Id", "Nome");
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            emprestimo.Ativo = false;
            db.Entry(emprestimo).State = EntityState.Modified;
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

        private void IncluirJogosParaEmprestimo(Emprestimo emprestimo)
        {
            try
            {               
                var jogosLista = GetJogosFromRequest();
                foreach (var _jogo in jogosLista)
                {
                    emprestimo.Jogos.Add(_jogo);
                }                
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }

        private ICollection<Jogo> GetJogosFromRequest()
        {
            try
            {
                var _jogos = Request.Form["jogos"];
                if (String.IsNullOrEmpty(_jogos))
                    throw new Exception("Selecione pelo menos um jogo para o empréstimo");

                int[] idJogos = _jogos.Split(',').Select(Int32.Parse).ToArray();
                return db.Jogos.Where(j => idJogos.Contains(j.Id)).ToList();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }    

        }

        private void MudarEstadoDoJogo(ICadeMeuJogoContext context, ICollection<Jogo> jogos)
        {
            foreach (var jogo in jogos)
            {
                jogo.Disponivel = !jogo.Disponivel;
                context.Entry(jogo).State = EntityState.Modified;
            }
        }

        
    }
}
