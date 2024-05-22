using System.ComponentModel.DataAnnotations;

namespace GalloFlix.ViewModels;

public class LoginVM
{
    [Display(Name = "Email ou nome de usuário")]
    [Required(ErrorMessage = "Por favor, informe seu email ou nome de usuário!")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha de acesso")]
    [Required(ErrorMessage = "Por favor, informe sua senha!")]
    public string Password { get; set; }
    
    [Display(Name = "Deseja se manter conectado?")]
    public bool RememberMe { get; set; } = false;
    public string ReturnUrl { get; set; }
}
