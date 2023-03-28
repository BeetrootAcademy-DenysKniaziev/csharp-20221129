using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationModels
{
    public class LessonModel
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public byte Number { get; set; }



        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва повина бути від 3-х до 50-ти символів")]
        public string Name { get; set; }

        [Required]
        [StringLength(10000, ErrorMessage = "Нульова сторінка до 10 000 символів")]
        public string Content { get; set; }

    }
}
