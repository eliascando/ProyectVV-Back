using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTesting.Tests.PruebasIntegracion
{
    public class UsuarioServiceIntegrationTests : IntegrationTestBase
    {
        [Fact]
        public void Register_CreatesUserSuccessfully()
        {
            // Arrange
            var registerDto = new UsuarioRegistroDTO
            {
                NumberIdentification = "12345",
                Name = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                RoleId = 1
            };

            // Act
            var result = _usuarioService.Register(registerDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(registerDto.NumberIdentification, result.NumberIdentification);
            Assert.Equal(registerDto.Name, result.Name);
            Assert.Equal(registerDto.LastName, result.LastName);
            Assert.Equal(registerDto.Email, result.Email);
            Assert.Equal(registerDto.RoleId, result.RoleId);
            Assert.Equal("Admin", result.RoleName); // Assuming RoleId 1 is Admin
        }

        [Fact]
        public void ObtenerEstudiantesPorCurso_ReturnsListOfStudents()
        {
            // Arrange
            var cursoId = 1;
            var typeId = 2; // Student

            // Seed the database with users and their course enrollment
            var user = new Usuario
            {
                Id = 1,
                NumberIdentification = "12345",
                Name = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                RoleId = typeId
            };

            _context.Usuarios.Add(user);
            _context.SaveChanges();

            // Act
            var result = _usuarioService.ObtenerEstudiantesPorCurso(cursoId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(user.Id, resultDto.Id);
            Assert.Equal(user.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(user.Name, resultDto.Name);
            Assert.Equal(user.LastName, resultDto.LastName);
            Assert.Equal(user.Email, resultDto.Email);
            Assert.Equal(typeId, resultDto.RoleId);
            Assert.Equal("Student", resultDto.RoleName); // Assuming RoleId 2 is Student
        }

        [Fact]
        public void ObtenerDocentes_ReturnsListOfTeachers()
        {
            // Arrange
            var typeId = 3; // Teacher

            // Seed the database with teachers
            var teacher = new Usuario
            {
                Id = 1,
                NumberIdentification = "67890",
                Name = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                RoleId = typeId
            };

            _context.Usuarios.Add(teacher);
            _context.SaveChanges();

            // Act
            var result = _usuarioService.ObtenerDocentes();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(teacher.Id, resultDto.Id);
            Assert.Equal(teacher.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(teacher.Name, resultDto.Name);
            Assert.Equal(teacher.LastName, resultDto.LastName);
            Assert.Equal(teacher.Email, resultDto.Email);
            Assert.Equal(typeId, resultDto.RoleId);
            Assert.Equal("Teacher", resultDto.RoleName); // Assuming RoleId 3 is Teacher
        }

        [Fact]
        public void ObtenerTodosPorCursoId_ReturnsListOfUsers()
        {
            // Arrange
            var cursoId = 1;
            var typeId = 2; // Student

            // Seed the database with users for the course
            var user = new Usuario
            {
                Id = 2,
                NumberIdentification = "54321",
                Name = "Emily",
                LastName = "Davis",
                Email = "emily.davis@example.com",
                RoleId = typeId
            };

            _context.Usuarios.Add(user);
            _context.SaveChanges();

            // Act
            var result = _usuarioService.ObtenerTodosPorCursoId(cursoId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(user.Id, resultDto.Id);
            Assert.Equal(user.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(user.Name, resultDto.Name);
            Assert.Equal(user.LastName, resultDto.LastName);
            Assert.Equal(user.Email, resultDto.Email);
            Assert.Equal(typeId, resultDto.RoleId);
            Assert.Equal("Student", resultDto.RoleName); // Assuming RoleId 2 is Student
        }
    }
}
