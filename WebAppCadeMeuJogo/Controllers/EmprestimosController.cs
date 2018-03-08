using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebAppCadeMeuJogo.Interfaces.Context;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Controllers
{
    [Authorize]
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
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
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
                var jogos = GetJogosFromRequest();

                if (_validation.IsValid(emprestimo) &&
                    _validation.ValidarJogosParaEmprestimo(jogos)){//<== verificar esta validacao

                    IncluirJogosParaEmprestimo(emprestimo, jogos);
                    MudarDisponiblidadeDosJogos(db, jogos);

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
            ViewBag.AmigoId = new SelectList(db.Amigos.Where(a => a.Ativo), "Id", "Nome", emprestimo.AmigoId);
            ViewBag.Jogos = new SelectList(db.Jogos.Where(j => j.Ativo && j.Disponivel), "Id", "Nome");
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataInicio,DataFim,AmigoId,DataCadastro,Ativo")] Emprestimo emprestimo)
        {
            try
            {
                MudarDisponiblidadeDosJogos(db, GetJogos(db, emprestimo.Id));
                RemoverJogosDoEmprestimo(db, emprestimo.Id);
                db.SaveChanges();
                var novosJogos = GetJogosFromRequest();

                if (_validation.IsValid(emprestimo) && _validation.ValidarJogosParaEmprestimo(novosJogos))
                {
                    IncluirJogosParaEmprestimo(emprestimo, novosJogos);
                    MudarDisponiblidadeDosJogos(db, novosJogos);
                    db.Entry(emprestimo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.AmigoId = new SelectList(db.Amigos.Where(a => a.Ativo), "Id", "Nome", emprestimo.AmigoId);
            ViewBag.Jogos = new SelectList(db.Jogos.Where(j => j.Ativo && j.Disponivel), "Id", "Nome");
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
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
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
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
            try
            {
                MudarDisponiblidadeDosJogos(db, GetJogos(db, emprestimo.Id));
                RemoverJogosDoEmprestimo(db, emprestimo.Id);
                emprestimo.Ativo = false;
                db.Entry(emprestimo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
            return View(emprestimo);
        }

        [HttpGet]
        public ActionResult DevolverJogo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
            if (emprestimo == null)
            {
                return HttpNotFound();
            }
            return View(emprestimo);
        }

        [HttpPost]
        public ActionResult DevolverJogo(Emprestimo emprestimo)
        {
            try
            {
                var jogosDevolucao = GetJogosFromRequest("chkJogosDevolucao");
                MudarDisponiblidadeDosJogos(db, jogosDevolucao);
                RemoverJogosDoEmprestimo(db, emprestimo.Id, jogosDevolucao);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
            }
            ViewBag.JogosEmprestados = GetJogos(db, emprestimo.Id);
            return View(emprestimo);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        #region [ Metodos Privados ]

        
        private void IncluirJogosParaEmprestimo(Emprestimo emprestimo, ICollection<Jogo> jogos)
        {
            try
            {               
                foreach (var jogo in jogos)
                {                   
                    var emprestimoJogo = new EmprestimoJogo {
                            Ativo = true,
                            Jogo = jogo,
                            JogoId = jogo.Id,
                            EmprestimoId = emprestimo.Id,
                            Emprestimo = emprestimo
                        };
                    db.Entry(emprestimoJogo).State = EntityState.Added;
                    emprestimo.EmprestimosJogos.Add(emprestimoJogo);
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }

        private ICollection<Jogo> GetJogosFromRequest(string nameRequest = "chkJogos")
        {
            try
            {
                var _jogos = Request.Form[nameRequest];
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

        private void MudarDisponiblidadeDosJogos(ICadeMeuJogoContext context, ICollection<Jogo> jogos)
        {
            foreach (var jogo in jogos)
            {
                jogo.Disponivel = !jogo.Disponivel;
                context.Entry(jogo).State = EntityState.Modified;
            }
        }

        private ICollection<Jogo> GetJogos(ICadeMeuJogoContext context, int emprestimoId)
        {
            var listaJogo = new List<Jogo>();
            var emprestimosJogos = db.EmprestimosJogos.Include(x => x.Jogo);

            foreach(var empJg in emprestimosJogos)
            {
                if(empJg.EmprestimoId == emprestimoId && empJg.Ativo)
                {
                    listaJogo.Add(empJg.Jogo);
                }
            }
            return listaJogo;
        }
                
        private void RemoverJogosDoEmprestimo(ICadeMeuJogoContext context, int emprestimoId)
        {
            var emprestimosJogos = db.EmprestimosJogos;
            foreach (var empJg in emprestimosJogos)
            {
                if (empJg.EmprestimoId == emprestimoId)
                {
                    db.Entry(empJg).State = EntityState.Deleted;
                }
            }
        }

        private void RemoverJogosDoEmprestimo(ICadeMeuJogoContext context, int emprestimoId, ICollection<Jogo> jogos)
        {
            var emprestimosJogos = db.EmprestimosJogos.Where(e=> e.EmprestimoId == emprestimoId);
            foreach (var empJg in emprestimosJogos)
            {
                foreach(var jg in jogos)
                {
                    if(empJg.JogoId == jg.Id)
                    {
                        db.Entry(empJg).State = EntityState.Deleted;
                    }
                }
                
                //if(empJg.EmprestimoId == emprestimoId)
                //{
                //     if(jogos.FirstOrDefault(j => j.Id == empJg.JogoId).Id == empJg.JogoId)
                //    db.Entry(empJg).State = EntityState.Deleted;
                //}
            }
        }


        #endregion
    }
}
