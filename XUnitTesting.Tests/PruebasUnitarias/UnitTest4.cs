using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Moq;
using Domain.Interfaces.Repositories;
using Application.Services;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTesting.Tests.PruebasUnitarias
{
    public class UsuarioServiceTests
    {
        private readonly UsuarioService _usuarioService;
        private readonly Mock<IUsuarioRepository<Usuario>> _usuarioRepositoryMock;
        private readonly Mock<ISystemParameterRepository<SystemParameter, SystemParameterDetails>> _systemParameterRepositoryMock;
        private readonly Mock<IMatriculaRepository<Matricula>> _matriculaRepositoryMock;

        public UsuarioServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository<Usuario>>();
            _systemParameterRepositoryMock = new Mock<ISystemParameterRepository<SystemParameter, SystemParameterDetails>>();
            _matriculaRepositoryMock = new Mock<IMatriculaRepository<Matricula>>();

            // Ahora se pasa el mock adicional al constructor de UsuarioService
            _usuarioService = new UsuarioService(
                _usuarioRepositoryMock.Object,
                _systemParameterRepositoryMock.Object,
                _matriculaRepositoryMock.Object
            );
        }

        [Fact]
        public void Register_CreatesUserSuccessfully()
        {
            // Arrange
            var registerDto = new UsuarioRegistroDTO
            {
                NumberIdentification = "12345",
                Name = "Emilio",
                LastName = "Romero",
                Email = "emilio@test.com",
                Password = "testUS1",
                RoleId = 1
            };

            var user = new Usuario
            {
                Id = 1,
                NumberIdentification = registerDto.NumberIdentification,
                Name = registerDto.Name,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                RoleId = registerDto.RoleId,
                Status = true
            };

            _usuarioRepositoryMock.Setup(repo => repo.Insert(It.IsAny<Usuario>())).Returns(user);

            var roleDetail = new SystemParameterDetails
            {
                Id = 1,
                Value = "Admin"
            };

            _systemParameterRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(new SystemParameter
            {
                Details = new List<SystemParameterDetails> { roleDetail }
            });

            var expectedDto = new NewUserDTO
            {
                Id = user.Id,
                NumberIdentification = user.NumberIdentification,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Adress = user.Adress,
                RoleId = user.RoleId,
                RoleName = roleDetail.Value
            };

            // Act
            var result = _usuarioService.Register(registerDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result.Id);
            Assert.Equal(expectedDto.NumberIdentification, result.NumberIdentification);
            Assert.Equal(expectedDto.Name, result.Name);
            Assert.Equal(expectedDto.LastName, result.LastName);
            Assert.Equal(expectedDto.Email, result.Email);
            Assert.Equal(expectedDto.Phone, result.Phone);
            Assert.Equal(expectedDto.Adress, result.Adress);
            Assert.Equal(expectedDto.RoleId, result.RoleId);
            Assert.Equal(expectedDto.RoleName, result.RoleName);
        }

        [Fact]
        public void ObtenerEstudiantesPorCurso_ReturnsListOfStudents()
        {
            // Arrange
            var cursoId = 1;
            var typeId = 2; // Adjust this if needed based on your actual logic
            var estudiantes = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    NumberIdentification = "12345",
                    Name = "Emilio",
                    LastName = "Romero",
                    Email = "emilio@test.com",
                    RoleId = 2
                }
            };

            var roleDetail = new SystemParameterDetails
            {
                Id = 2,
                Value = "Student"
            };

            _usuarioRepositoryMock.Setup(repo => repo.ObtenerPorCursoId(cursoId, typeId)).Returns(estudiantes);
            _systemParameterRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(new SystemParameter
            {
                Details = new List<SystemParameterDetails> { roleDetail }
            });

            var expectedDto = new NewUserDTO
            {
                Id = 1,
                NumberIdentification = "12345",
                Name = "Emilio",
                LastName = "Romero",
                Email = "emilio.r@test.com",
                RoleId = 2,
                RoleName = roleDetail.Value
            };

            // Act
            var result = _usuarioService.ObtenerEstudiantesPorCurso(cursoId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(expectedDto.Id, resultDto.Id);
            Assert.Equal(expectedDto.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(expectedDto.Name, resultDto.Name);
            Assert.Equal(expectedDto.LastName, resultDto.LastName);
            Assert.Equal(expectedDto.Email, resultDto.Email);
            Assert.Equal(expectedDto.Phone, resultDto.Phone);
            Assert.Equal(expectedDto.Adress, resultDto.Adress);
            Assert.Equal(expectedDto.RoleId, resultDto.RoleId);
            Assert.Equal(expectedDto.RoleName, resultDto.RoleName);
        }

        [Fact]
        public void ObtenerDocentes_ReturnsListOfTeachers()
        {
            // Arrange
            var typeId = 1; // Adjust this if needed based on your actual logic
            var docentes = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    NumberIdentification = "67890",
                    Name = "Julia",
                    LastName = "Perez",
                    Email = "julia.p@test.com",
                    RoleId = 1
                }
            };

            var roleDetail = new SystemParameterDetails
            {
                Id = 1,
                Value = "Teacher"
            };

            _usuarioRepositoryMock.Setup(repo => repo.ObtenerUsuariosPorRol(typeId)).Returns(docentes);
            _systemParameterRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(new SystemParameter
            {
                Details = new List<SystemParameterDetails> { roleDetail }
            });

            var expectedDto = new NewUserDTO
            {
                Id = 1,
                NumberIdentification = "67890",
                Name = "Julia",
                LastName = "Perez",
                Email = "julia.p@test.com",
                RoleId = 1,
                RoleName = roleDetail.Value
            };

            // Act
            var result = _usuarioService.ObtenerDocentes();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(expectedDto.Id, resultDto.Id);
            Assert.Equal(expectedDto.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(expectedDto.Name, resultDto.Name);
            Assert.Equal(expectedDto.LastName, resultDto.LastName);
            Assert.Equal(expectedDto.Email, resultDto.Email);
            Assert.Equal(expectedDto.Phone, resultDto.Phone);
            Assert.Equal(expectedDto.Adress, resultDto.Adress);
            Assert.Equal(expectedDto.RoleId, resultDto.RoleId);
            Assert.Equal(expectedDto.RoleName, resultDto.RoleName);
        }

        [Fact]
        public void ObtenerTodosPorCursoId_ReturnsListOfUsers()
        {
            // Arrange
            var cursoId = 1;
            var typeId = 2; // Adjust this if needed based on your actual logic
            var users = new List<Usuario>
            {
                new Usuario
                {
                    Id = 2,
                    NumberIdentification = "54321",
                    Name = "Emily",
                    LastName = "Molina",
                    Email = "emily.m@test.com",
                    RoleId = 2
                }
            };

            var roleDetail = new SystemParameterDetails
            {
                Id = 2,
                Value = "Student"
            };

            _usuarioRepositoryMock.Setup(repo => repo.ObtenerPorCursoId(cursoId, typeId)).Returns(users);
            _systemParameterRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(new SystemParameter
            {
                Details = new List<SystemParameterDetails> { roleDetail }
            });

            var expectedDto = new NewUserDTO
            {
                Id = 2,
                NumberIdentification = "54321",
                Name = "Emily",
                LastName = "Molina",
                Email = "emily.m@test.com",
                RoleId = 2,
                RoleName = roleDetail.Value
            };

            // Act
            var result = _usuarioService.ObtenerTodosPorCursoId(cursoId);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(expectedDto.Id, resultDto.Id);
            Assert.Equal(expectedDto.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(expectedDto.Name, resultDto.Name);
            Assert.Equal(expectedDto.LastName, resultDto.LastName);
            Assert.Equal(expectedDto.Email, resultDto.Email);
            Assert.Equal(expectedDto.Phone, resultDto.Phone);
            Assert.Equal(expectedDto.Adress, resultDto.Adress);
            Assert.Equal(expectedDto.RoleId, resultDto.RoleId);
            Assert.Equal(expectedDto.RoleName, resultDto.RoleName);
        }

        [Fact]
        public void ObtenerEstudiantes_ReturnsListOfStudents()
        {
            // Arrange
            var estudiantes = new List<Usuario>
            {
                new Usuario
                {
                    Id = 1,
                    NumberIdentification = "12345",
                    Name = "Emilio",
                    LastName = "Romero",
                    Email = "emilio.r@test.com",
                    RoleId = 2
                }
            };

            var roleDetail = new SystemParameterDetails
            {
                Id = 2,
                Value = "Student"
            };

            _usuarioRepositoryMock.Setup(repo => repo.ObtenerUsuariosPorRol(2)).Returns(estudiantes);
            _systemParameterRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(new SystemParameter
            {
                Details = new List<SystemParameterDetails> { roleDetail }
            });

            var expectedDto = new NewUserDTO
            {
                Id = 1,
                NumberIdentification = "12345",
                Name = "Emilio",
                LastName = "Romero",
                Email = "emilio.r@test.com",
                RoleId = 2,
                RoleName = roleDetail.Value
            };

            // Act
            var result = _usuarioService.ObtenerEstudiantes();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(expectedDto.Id, resultDto.Id);
            Assert.Equal(expectedDto.NumberIdentification, resultDto.NumberIdentification);
            Assert.Equal(expectedDto.Name, resultDto.Name);
            Assert.Equal(expectedDto.LastName, resultDto.LastName);
            Assert.Equal(expectedDto.Email, resultDto.Email);
            Assert.Equal(expectedDto.Phone, resultDto.Phone);
            Assert.Equal(expectedDto.Adress, resultDto.Adress);
            Assert.Equal(expectedDto.RoleId, resultDto.RoleId);
            Assert.Equal(expectedDto.RoleName, resultDto.RoleName);
        }
    }
}
