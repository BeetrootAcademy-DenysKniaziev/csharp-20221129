using DeepLearn.Contracts.LessonsStructs;
using DeepLearn.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DeepLearn.Web.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<AppDbContext>>()))
            {
                if (context.Courses.Any())
                {
                    return;
                }

                context.Courses.AddRange(
                    new Course
                    {
                        Title = "C#",
                        PhotoName = "csharp.jpg",
                        Modules = new List<Module>
                        {
                            new Module
                            {
                                Title = "I. Basic Concepts",
                                Lessons = new List<Lesson>
                                {
                                    new Lesson
                                    {
                                        Title = "1. What is C#?",
                                        TheoryBlocks = new List<TheoryBlock>
                                        {
                                            new TheoryBlock
                                            {
                                                Title = "Welcome to C#",
                                                Text = "C# is an elegant object-oriented language that enables developers to build a variety of secure and robust applications that run on the .NET Framework.\r\nYou can use C# to create Windows applications, Web services, mobile applications, client-server applications, database applications, and much, much more.",
                                                TestBlock = new TestBlock
                                                {
                                                    Question = "C# applications run",
                                                    Answers = new List<Answer>
                                                    {
                                                        new Answer
                                                        {
                                                            Text = "using Java",
                                                            IsCorrect = false
                                                        },
                                                        new Answer
                                                        {
                                                            Text = "only on Linux",
                                                            IsCorrect = false
                                                        },
                                                        new Answer
                                                        {
                                                            Text = "on the .NET Framework",
                                                            IsCorrect = true
                                                        }
                                                    }
                                                }

                                            },
                                            new TheoryBlock
                                            {
                                                Title = "The .NET Framework",
                                                Text = "The .NET Framework consists of the Common Language Runtime (CLR) and the .NET Framework class library.\r\nThe CLR is the foundation of the .NET Framework. It manages code at execution time, providing core services such as memory management, code accuracy, and many other aspects of your code.\r\nThe class library is a collection of classes, interfaces, and value types that enable you to accomplish a range of common programming tasks, such as data collection, file access, and working with text.\r\nC# programs use the .NET Framework class library extensively to do common tasks and provide various functionalities.",
                                                TestBlock = new TestBlock
                                            {
                                                Question = "Which one is not part of the .NET Framework"
                                            }},
                                            new TheoryBlock
                                            {
                                                Title = "title 3",
                                                Text = "text 3"
                                            },
                                            new TheoryBlock
                                            {
                                                Title = "title 4",
                                                Text = "text 4"
                                            },
                                            new TheoryBlock
                                            {
                                                Title = "title 5",
                                                Text = "text 5"
                                            }
                                        }
                                    },
                                    new Lesson
                                    {
                                        Title = "2. Variables"
                                    },
                                    new Lesson
                                    {
                                        Title = "3. Your First C# Program"
                                    },
                                    new Lesson
                                    {
                                        Title = "4. Printing Text"
                                    },
                                    new Lesson
                                    {
                                        Title = "5. Getting User Input"
                                    }
                                }
                            },
                            new Module
                            {
                                Title = "II. Conditionals and Loops"
                            },
                            new Module
                            {
                                Title = "III. Methods"
                            },
                            new Module
                            {
                                Title = "IV. Classes & Objects"
                            },
                            new Module
                            {
                                Title = "V. Arrays and Strings"
                            }
                        }
                    },
                    new Course
                    {
                        Title = "Python",
                        PhotoName = "python.png"
                    },
                    new Course
                    {
                        Title = "PHP",
                        PhotoName = "php.jpg"
                    },
                    new Course
                    {
                        Title = "Ruby",
                        PhotoName = "ruby.png"
                    },
                    new Course
                    {
                        Title = "JavaScript",
                        PhotoName = "js.png"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
