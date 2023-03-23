using System.Diagnostics.Contracts;
using ExchangeMarket.Controllers;
using Contracts;
using BAL.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExchangeMarket.DAL;
using Microsoft.EntityFrameworkCore;
//using ExchangeMarket.Models;
using System.Linq;
using BAL.Interfaces;

namespace XUnitTests
{
    public class PeopleControllerTests
    {
        private Mock<IPersonService> mockPersonService;
        private PeopleController controller;

        public PeopleControllerTests()
        {
            mockPersonService = new Mock<IPersonService>();
            controller = new PeopleController(mockPersonService.Object);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfPeople()
        {
            // Arrange
            mockPersonService.Setup(repo => repo.GetAllPeopleAsync())
                .ReturnsAsync(GetTestPeople());
            // Act
            var result = await controller.Index();
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task Details_ReturnsNotFoundResult_WhenIdIsNull()
        {
            // Arrange
            int? id = null;
            // Act
            var result = await controller.Details(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsNotFoundResult_WhenPersonIsNull()
        {
            // Arrange
            int? id = 3;
            mockPersonService.Setup(repo => repo.GetPersonByIdAsync(id.Value))
                .ReturnsAsync((Person)null);
            // Act
            var result = await controller.Details(id);
            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsViewResult_WhenPersonIsNotNull()
        {
            // Arrange
            int? id = 1;
            mockPersonService.Setup(repo => repo.GetPersonByIdAsync(id.Value))
                .ReturnsAsync(GetTestPeople().FirstOrDefault(p => p.Id == id));
            // Act
            var result = await controller.Details(id);
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Person>(
                viewResult.ViewData.Model);
            Assert.Equal("John", model.FirstMidName);
            Assert.Equal("Doe", model.LastName);
        }

        [Fact]
        public async Task Create_ReturnsRedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var newPerson = new Person()
            {
                FirstMidName = "John",
                LastName = "Doe",
                Email = "jdoe@test.com",
                Password = "password",
                PhoneNumber = "555-1234"
            };

            // Act
            var result = await controller.Create(newPerson);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithListOfPeople()
        {
            // Arrange
            var mockPersonService = new Mock<IPersonService>();
            var expectedPeople = new List<Person>
        {
            new Person { Id = 1, LastName = "Doe", FirstMidName = "John", Email = "john.doe@example.com", Password = "Pass" },
            new Person { Id = 2, LastName = "Smith", FirstMidName = "Jane", Email = "jane.smith@example.com",Password = "Pass" }
        };
            mockPersonService.Setup(service => service.GetAllPeopleAsync())
                .ReturnsAsync(expectedPeople);
            var controller = new PeopleController(mockPersonService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Person>>(viewResult.ViewData.Model);
            Assert.Equal(expectedPeople.Count, model.Count());
        }



        private List<Person> GetTestPeople()
        {
            var people = new List<Person>
            {
                new Person { Id = 1, LastName = "Doe", FirstMidName = "John", Email = "johndoe@example.com", Password = "12345", PhoneNumber = "1234567890" },
                new Person { Id = 2, LastName = "Smith", FirstMidName = "Jane", Email = "janesmith@example.com", Password = "67890", PhoneNumber = "0987654321" },
                new Person { Id = 3, LastName = "Johnson", FirstMidName = "Bob", Email = "bobjohnson@example.com", Password = "abcde", PhoneNumber = "1234509876" }
            };

            return people;
        }
    }

}