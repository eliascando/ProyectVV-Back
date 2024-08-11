using Application.Services;
using Domain.DTOs;
using Domain.Interfaces.Services;
using Domain.Models;
using Moq;
using Domain.Interfaces.Repositories;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTesting.Tests.PruebasUnitarias
{
    public class MatriculaServiceTests
    {
        private readonly Mock<IMatriculaRepository<Matricula>> _mockMatriculaRepo;
        private readonly Mock<IUsuarioRepository<Usuario>> _mockUserRepo;
        private readonly Mock<ISystemParameterRepository<SystemParameter, SystemParameterDetails>> _mockParamRepo;
        private readonly Mock<ICursoRepository<Curso, CursoDTO>> _mockCursoRepo;
        private readonly MatriculaService _matriculaService;

        public MatriculaServiceTests()
        {
            _mockMatriculaRepo = new Mock<IMatriculaRepository<Matricula>>();
            _mockUserRepo = new Mock<IUsuarioRepository<Usuario>>();
            _mockParamRepo = new Mock<ISystemParameterRepository<SystemParameter, SystemParameterDetails>>();
            _mockCursoRepo = new Mock<ICursoRepository<Curso, CursoDTO>>();

            _matriculaService = new MatriculaService(
                _mockMatriculaRepo.Object,
                _mockUserRepo.Object,
                _mockParamRepo.Object,
                _mockCursoRepo.Object
            );
        }

        [Fact]
        public void Register_ReturnsMatricula_WhenValidDataIsProvided()
        {
            // Arrange
            var newMatricula = new NewMatriculaDTO
            {
                CourseId = 1,
                UserId = 2,
                TypeId = 3
            };

            var expectedMatricula = new Matricula
            {
                Id = 1,
                CourseId = newMatricula.CourseId,
                UserId = newMatricula.UserId,
                TypeId = newMatricula.TypeId,
                CreationTime = DateTime.Now,
                Status = true
            };

            _mockMatriculaRepo.Setup(repo => repo.Insert(It.IsAny<Matricula>())).Returns(expectedMatricula);

            // Act
            var result = _matriculaService.Register(newMatricula);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedMatricula.CourseId, result.CourseId);
            Assert.Equal(expectedMatricula.UserId, result.UserId);
            Assert.Equal(expectedMatricula.TypeId, result.TypeId);
            Assert.True(result.Status);
        }

        [Fact]
        public void ObtenerTodos_ReturnsAllMatriculas()
        {
            // Arrange
            var matriculas = new List<Matricula>
    {
        new Matricula { Id = 1, CourseId = 1, UserId = 2, TypeId = 3, CreationTime = DateTime.Now, Status = true },
        new Matricula { Id = 2, CourseId = 2, UserId = 3, TypeId = 4, CreationTime = DateTime.Now, Status = true }
    };

            _mockMatriculaRepo.Setup(repo => repo.GetAll()).Returns(matriculas);

            // Act
            var result = _matriculaService.ObtenerTodos();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(matriculas.Count, result.Count);
            Assert.Equal(matriculas[0].Id, result[0].Id);
            Assert.Equal(matriculas[1].Id, result[1].Id);
        }

        [Fact]
        public void ObtenerTodosDto_ReturnsAllMatriculaDTOs()
        {
            // Arrange
            var matriculas = new List<Matricula>
    {
        new Matricula
        {
            Id = 1,
            CourseId = 1,
            UserId = 2,
            TypeId = 3,
            CreationTime = DateTime.Now,
            Status = true
        }
    };

            var cursos = new List<Curso>
    {
        new Curso { Id = 1, Description = "Tercer Curso", Parallel = "ING-S-3-1", CycleId = 1 }
    };

            var user = new Usuario { Id = 2, Name = "UserTest", LastName = "Test" };
            var systemParam = new SystemParameterDetails { Description = "Ciclo 1" };

            _mockMatriculaRepo.Setup(repo => repo.GetAll()).Returns(matriculas);
            _mockCursoRepo.Setup(repo => repo.GetById(It.IsAny<long>())).Returns<long>(id => cursos.FirstOrDefault(c => c.Id == id));
            _mockParamRepo.Setup(repo => repo.GetByDetailId(It.IsAny<long>())).Returns<long>(id => systemParam);
            _mockUserRepo.Setup(repo => repo.GetById(It.IsAny<long>())).Returns<long>(id => user);

            var expectedDto = new MatriculaDTO
            {
                Id = 1,
                CourseDescription = "Tercer Curso | ING-S-3-1",
                Cycle = "Ciclo 1",
                UserName = "UserTest Test",
                TypeName = "Type 3",
                CreationTime = matriculas[0].CreationTime
            };

            // Act
            var result = _matriculaService.ObtenerTodosDto();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            var resultDto = result.First();
            Assert.Equal(expectedDto.Id, resultDto.Id);
            Assert.Equal(expectedDto.CourseDescription, resultDto.CourseDescription);
            Assert.Equal(expectedDto.UserName, resultDto.UserName);
            Assert.Equal(expectedDto.Cycle, resultDto.Cycle);
        }

        [Fact]
        public void Inactivate_ReturnsTrue_WhenMatriculaIsSuccessfullyInactivated()
        {
            // Arrange
            long id = 1;
            _mockMatriculaRepo.Setup(repo => repo.DeleteById(id)).Returns(true);

            // Act
            var result = _matriculaService.Inactivate(id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateInfo_ReturnsUpdatedMatricula()
        {
            // Arrange
            long id = 1;
            var updatedMatricula = new Matricula
            {
                Id = id,
                CourseId = 2,
                UserId = 3,
                TypeId = 4,
                CreationTime = DateTime.Now,
                Status = true
            };

            _mockMatriculaRepo.Setup(repo => repo.Update(id, It.IsAny<Matricula>())).Returns(updatedMatricula);

            // Act
            var result = _matriculaService.UpdateInfo(id, updatedMatricula);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedMatricula.Id, result.Id);
            Assert.Equal(updatedMatricula.CourseId, result.CourseId);
        }
    }
}
