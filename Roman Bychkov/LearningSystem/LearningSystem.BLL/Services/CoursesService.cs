﻿using Microsoft.AspNetCore.Http;

namespace LearningSystem.BLL.Services
{
    public class CoursesService : ICoursesService
    {
        private ICoursesRepository _context;
        public CoursesService(ICoursesRepository context)
        {
            _context = context;
        }
        public async Task AddAsync(Course item, IFormFile file)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrWhiteSpace(item.CourseName) || item.CourseName.Length > 50)
                throw new ArgumentException("Invalid Description");
            if (string.IsNullOrWhiteSpace(item.Description) || item.Description.Length > 200)
                throw new ArgumentException("Invalid Description");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 10000)
                throw new ArgumentException("Invalid Content");
            if (string.IsNullOrWhiteSpace(item.ImagePath))
                item.ImagePath = "-";
            
            await _context.AddAsync(item);

            string uploadPath = "wwwroot/image";

            Directory.CreateDirectory(uploadPath);


            var fileName = $"{item.Id}.{Path.GetExtension(file.FileName).Replace(".", "")}";

            string fullPath = $"{uploadPath}/{fileName}";


            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            item.ImagePath = "/image/" + fileName;
            await _context.UpdateAsync(item);

        }

        public async Task DeleteAsync(Course item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            await _context.DeleteAsync(item);
        }

        public async Task<IEnumerable<Course>> GetAsync()
        {
            return await _context.GetAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }
        public async Task<string> AddImage(int id, IFormFile file)
        {
            if (file is null || file.Length > 500000 || file.Length == 0)
            {
                throw new ArgumentException("Файл повинен бути до 500КБ");
            }
            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
            {
                throw new ArgumentException("Image", "Допустимі формати: png, jpg");
            }

            string uploadPath = "wwwroot/image";

            Directory.CreateDirectory(uploadPath);


            var fileName = $"{id}.{Path.GetExtension(file.FileName).Replace(".", "")}";

            string fullPath = $"{uploadPath}/{fileName}";


            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return "/image/" + fileName;
        }
        public async Task UpdateAsync(Course item)
        {
            if (item is null)
                throw new ArgumentNullException("item");
            if (string.IsNullOrWhiteSpace(item.CourseName) || item.CourseName.Length > 50)
                throw new ArgumentException("Invalid Description");
            if (string.IsNullOrWhiteSpace(item.Description) || item.Description.Length > 200)
                throw new ArgumentException("Invalid Description");
            if (string.IsNullOrWhiteSpace(item.Content) || item.Content.Length > 10000)
                throw new ArgumentException("Invalid Content");

            await _context.UpdateAsync(item);
        }

        public Task<bool> VerifiyUserCourse(int userId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
