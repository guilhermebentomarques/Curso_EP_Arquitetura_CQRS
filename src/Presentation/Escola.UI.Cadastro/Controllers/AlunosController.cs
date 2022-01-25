using System;
using System.Web.Mvc;
using Cadastro.Application.Interfaces;
using Cadastro.Application.ViewModels;

namespace Escola.UI.Cadastro.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunosController(IAlunoAppService alunoAppService)
        {
            _alunoAppService = alunoAppService;
        }

        // GET: Alunos
        public ActionResult Index()
        {
            return View(_alunoAppService.ObterTodos());
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        [HttpPost]
        public ActionResult Create(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                alunoViewModel = _alunoAppService.Adicionar(alunoViewModel);

                if (!alunoViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in alunoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(alunoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(alunoViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            var aluno = _alunoAppService.ObterPorId(id);

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                alunoViewModel = _alunoAppService.Atualizar(alunoViewModel);

                if (!alunoViewModel.ValidationResult.IsValid)
                {
                    foreach (var error in alunoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(alunoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(alunoViewModel);
        }

        public JsonResult AlunoHistory(Guid id)
        {
            var history = _alunoAppService.AlunoHistory(id);
            var dto = history.ToJavaScriptAlunoHistory();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }
    }
}
