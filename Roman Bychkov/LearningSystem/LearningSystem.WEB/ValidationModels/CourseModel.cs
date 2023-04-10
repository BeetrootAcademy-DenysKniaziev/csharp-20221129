using LearningSystem.WEB.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationModels
{
    public class CourseModel
    {

        [Required(ErrorMessage = "Введіть назву курса")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва курсу повинна бути від 3-х до 50-ти символів")]
        public string CourseName { get; set; }

        [StringLength(200, ErrorMessage = "Опис курсу до 200-х символів")]
        [Required( ErrorMessage = "Введіть опис курсу")]
        public string Description { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Введіть зміст курсу")]
        [StringLength(10000, ErrorMessage = "Нульова сторінка до 10 000 символів")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Додайте зображення на прев'ю")]
        [ImageType(new string[] { "jpg", "png", "jpeg" })]
        [MaxFileSize(500 * 1024, ErrorMessage = "Максимальний розмір файлу - 500 КБ")]
        public IFormFile Uploads { get; set; }
    }
}

