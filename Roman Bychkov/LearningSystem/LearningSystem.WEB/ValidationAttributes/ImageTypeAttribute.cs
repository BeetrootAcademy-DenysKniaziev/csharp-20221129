using System.ComponentModel.DataAnnotations;

namespace LearningSystem.WEB.ValidationAttributes
{
    public class ImageTypeAttribute: ValidationAttribute
    {
        private string[] _types;
        public ImageTypeAttribute(string[] types)
        {
            _types = types;
            ErrorMessage = $"Файл повинен бути в форматі {string.Join(", ", _types)}";
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file is null || !_types.Contains(file.ContentType.Substring(file.ContentType.IndexOf('/') + 1)))
            {
                return false;
            }
            else return true;
        }
    }
}
