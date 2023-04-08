using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationModels
{
    public class LessonModel
    {

        [Required]
        public int CourseId { get; set; }

        [Required]
        public byte Number { get; set; }



        [Required(ErrorMessage = "Назва повинна бути від 3-х до 50-ти символів")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва повинна бути від 3-х до 50-ти символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Наповніть урок змістом")]
        [StringLength(10000, ErrorMessage = "Нульова сторінка до 10 000 символів")]
        public string Content { get; set; }

    }
}
