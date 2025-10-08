using System.ComponentModel.DataAnnotations;

namespace loginLucasAttila.Models
{
    public class Colaborador
    {
        [Display(Name = "Código.", Description = "Código.")]
        public int Id { get; set; }

        [Display(Name = "Nome completo.", Description = "Nome completo.")]
        public string Nome { get; set; }

        [Display(Name = "Senha.", Description = "Senha.")]
        public string Senha { get; set; }

        [Display(Name = "Email completo.", Description = "Email completo.")]
        public string Email { get; set; }

        [Display(Name = "Tipo de colaborador.", Description = "Tipo de colaborador.")]
        public string Tipo { get; set; }
    }
}
