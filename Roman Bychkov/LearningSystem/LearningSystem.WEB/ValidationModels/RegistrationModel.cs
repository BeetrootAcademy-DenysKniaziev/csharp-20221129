using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationModels
{
    public class RegistrationModel
    {

        [Required(ErrorMessage = "Введіть електрону адресу")]
        [EmailAddress(ErrorMessage = "Будь ласка, укажіть акутальну електрону адресу")]
        public string Email { get; set; }

        

        [Required(ErrorMessage = "Будь ласка, введіть свій логін")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Ім'я повино бути від 3-х до 50-ти символів")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Пароль повинен бути від 3-х до 20-ти символів")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{3,20}$", ErrorMessage = "Пароль повинен містити: хоча б літеру, нижнього та верхнього регістру, та хоча б одну цифру")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
