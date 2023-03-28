using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationModels
{
    public class CourseModel
    {

        [Required(ErrorMessage = "Введіть назву курса")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва курсу повина бути від 3-х до 50-ти символів")]
        public string CourseName { get; set; }

        [StringLength(200, ErrorMessage ="Опис курсу до 200-х символів")]
        [Required]
        public string Description { get; set; }

    
        public int Id { get; set; }
        [Required]
        
        [StringLength(10000, ErrorMessage ="Нульова сторінка до 10 000 символів")]
        public string Content { get; set; }

        //[Required]
        public IFormFile Uploads { get; set; }

    }
}
