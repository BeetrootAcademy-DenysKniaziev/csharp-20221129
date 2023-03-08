using Lesson29;
using Lesson29.Models;
using System;

await using var dbContext = new MyDBContext();
dbContext.Database.EnsureCreated();

//var genre1 = new Genre
//{
//    Id = 1,
//    Title = "Fantasy"
//};
//var genre2 = new Genre
//{
//    Id = 2,
//    Title = "Thriller"
//};
//var genre3 = new Genre
//{
//    Id = 3,
//    Title = "Comedy"
//};

//await dbContext.Genres.AddAsync(genre1);
//await dbContext.Genres.AddAsync(genre2);
//await dbContext.Genres.AddAsync(genre3);

await dbContext.SaveChangesAsync();
