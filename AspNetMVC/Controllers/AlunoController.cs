using AspNetMVC.Models;
using AspNetMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMVC.Controllers
{
    public class AlunoController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            //Aluno a1 = new Aluno();
            //a1.Id = 1;
            //a1.Nome = "Camilo";

            //Aluno a2 = new Aluno();
            //a2.Id = 2;
            //a2.Nome = "Rafael";

            //List<Aluno> alunos = new List<Aluno>();
            //alunos.Add(a1);
            //alunos.Add(a2);

            //ViewBag.ListaAlunos = alunos;
            //ViewBag.ID = id;

            AlunoServices alunoServices = new AlunoServices();
            Aluno aluno = await alunoServices.Integracao(id);
            
            if(aluno.Id == 0)
            {
                return View("NotFound");
            }

            ViewBag.aluno = aluno;

            


            return View();
        }

        public async Task<IActionResult> Lista()
        {

            AlunoServices alunoServices = new AlunoServices();
            var alunos = await alunoServices.GetAlunos();

            if (alunos.Count == 0)
            {
                return View("NotFound");
            }

            ViewBag.ListaAlunos = alunos;




            return View();
        }
    }
}
