using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationAttributes
{
    public class MaxFileSizeAttribute:ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
            ErrorMessage = $"Максимал {maxFileSize / 1024} KB";
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file != null && file.Length <= _maxFileSize)
            {
                return true;
            }

            return false;
        }
    }
}
