using System.ComponentModel.DataAnnotations;

namespace ControleFinancasWeb.Models.ViewModel
{
    public class CadUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe o login")]
        [Display(Name = "Login:")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }


        
    }
}