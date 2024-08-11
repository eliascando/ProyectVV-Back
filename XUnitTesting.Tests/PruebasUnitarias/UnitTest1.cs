using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Moq;
using Domain.Interfaces.Repositories;
using Application.Services;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace XUnitTesting.Tests.PruebasUnitarias

{
    public class AuthServiceTests
    {
        private readonly Mock<IAuthRepository<Usuario>> _mockAuthRepo;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockAuthRepo = new Mock<IAuthRepository<Usuario>>();
            _authService = new AuthService(Mock.Of<IConfiguration>(), _mockAuthRepo.Object);
        }

        [Fact]
        public void AUTH001_LoginSuccessful_ReturnsLoginResult()
        {
            // Arrange
            var loginDTO = new LoginDTO { NumberIdentification = "12345", Password = "testAU1" };
            var usuario = new Usuario
            {
                Id = 1,
                NumberIdentification = "12345",
                Password = BCrypt.Net.BCrypt.HashPassword("testAU1"),
                Name = "John",
                LastName = "Gonzalez",
                Email = "john.g@test.com",
                RoleId = 1
            };
            _mockAuthRepo.Setup(repo => repo.GetByNumberIdentification("12345")).Returns(usuario);
            _mockAuthRepo.Setup(repo => repo.GetRoleName("12345")).Returns("Admin");

            // Act
            var result = _authService.Login(loginDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("12345", result.NumberIdentification);
            Assert.Equal("John Gonzalez", result.CompleteName);
            Assert.Equal("john.g@example.com", result.Email);
            Assert.Equal("Admin", result.RoleName);
        }

        [Fact]
        public void AUTH002_UserNotFound_ThrowsException()
        {
            // Arrange
            var loginDTO = new LoginDTO { NumberIdentification = "67890", Password = "testAU2" };
            _mockAuthRepo.Setup(repo => repo.GetByNumberIdentification("67890")).Returns((Usuario)null);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _authService.Login(loginDTO));
            Assert.Equal("Usuario no encontrado!", exception.Message);
        }

        [Fact]
        public void AUTH003_IncorrectPassword_ThrowsException()
        {
            // Arrange
            var loginDTO = new LoginDTO { NumberIdentification = "12345", Password = "failtest" };
            var usuario = new Usuario
            {
                Id = 1,
                NumberIdentification = "12345",
                Password = BCrypt.Net.BCrypt.HashPassword("password123")
            };
            _mockAuthRepo.Setup(repo => repo.GetByNumberIdentification("12345")).Returns(usuario);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => _authService.Login(loginDTO));
            Assert.Equal("Contraseña incorrecta!", exception.Message);
        }
    }
}