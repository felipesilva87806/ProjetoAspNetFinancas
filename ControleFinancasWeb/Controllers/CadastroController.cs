using ControleFinancasWeb.Models;
using ControleFinancasWeb.Models.ViewModel;
using System.Web.Mvc;

namespace ControleFinancasWeb.Controllers
{

    public class CadastroController : Controller
    {

        public ActionResult Usuario()
        {
            return View(UsuarioModel.RecuperLista());
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult CadUsuario(CadUsuarioViewModel cad)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var retorno = CadastroUsuarioModel.InserirNewUsuario(cad.Login,cad.Senha,cad.Nome);
            if (retorno > 0)
            {
                ViewBag.Mensagem = " # Usuário inserido com sucesso !!";
                return View(cad);
            }
            else
            {
                ModelState.AddModelError("", " # Erro ao Inserir Verifique!");
            }
            return View(cad);
        }

        public ActionResult CadUsuario()
        {
            return View();
        }

        /*
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarUsuario(int id)
        {
            return Json(UsuarioModel.RecuperarPeloId(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirUsuario(int id)
        {
            return Json(UsuarioModel.ExcluirPeloId(id));
        }
        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarUsuario(UsuarioModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    if (model.Senha == _senhaPadrao)
                    {
                        model.Senha = "";
                    }

                    var id = model.Salvar();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }*/
    }
}