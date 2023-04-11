using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationModels
{
    public class LoginModel
    {
       
        [Required(ErrorMessage = "Будь ласка, введіть свій логін")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ім'я повинно бути від 3-х до 50-ти символів")]
        public string UserName { get; set; }

   
        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
