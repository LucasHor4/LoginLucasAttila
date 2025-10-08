using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace loginLucasAttila.Models
{
    public class Cliente
    {
        [Display(Name = "Código.", Description = "Código.")]
        public int Id { get; set; }

        [Display (Name = "Nome completo.", Description = "Nome completo.")]
        public string Nome { get; set; }
        
        [Display (Name = "Data de nascimento.", Description = "Data de nascimento.")]
        public DateOnly Nasc {  get; set; }
        
        [Display (Name = "Sexo.", Description = "Sexo.")]
        public string Sexo { get; set; }
        
        [Display (Name = "Senha.", Description = "Senha.")]
        public string Senha { get; set; }
                
        [Display (Name = "CPF.", Description = "CPF.")]
        public string CPF { get; set; }

        [Display (Name = "Telefone.", Description = "Telefone.")]
        public int Telefone { get; set; }

        [Display (Name = "Email completo.", Description = "Email completo.")]
        public string Email { get; set; }

        [Display (Name = "Situação.", Description = "Situação.")]
        public string Situacao { get; set; }
    }
}
