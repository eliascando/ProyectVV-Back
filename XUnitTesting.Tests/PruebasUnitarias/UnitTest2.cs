using Application.Services;
using Domain.DTOs;
using Domain.Models;
using Moq;
using Domain.Interfaces.Repositories;

namespace XUnitTesting.Tests.PruebasUnitarias
{
    public class CursoServiceTests
    {
        private readonly Mock<ICursoRepository<Curso, CursoDTO>> _mockCursoRepo;
        private readonly CursoService _cursoService;

        public CursoServiceTests()
        {
            _mockCursoRepo = new Mock<ICursoRepository<Curso, CursoDTO>>();
            _cursoService = new CursoService(_mockCursoRepo.Object);
        }

        [Fact]
        public void CURSO001_RegisterCurso_ReturnsCurso()
        {
            // Arrange
            var newCursoDTO = new NewCursoDTO { Description = "Ingles Avanzado", Price = 100 };
            var newCurso = new Curso
            {
                Id = 1,
                Description = "Ingles Avanzado",
                Price = 100,
                Status = true
            };
            _mockCursoRepo.Setup(repo => repo.Insert(It.IsAny<Curso>())).Returns(newCurso);

            // Act
            var result = _cursoService.Register(newCursoDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ingles Avanzado", result.Description);
            Assert.Equal(100, result.Price);
            Assert.True(result.Status);
        }

        [Fact]
        public void CURSO002_UpdateCurso_ReturnsUpdatedCurso()
        {
            // Arrange
            var updateCursoDTO = new UpdateCursoDTO { Description = "Ingles Intermedio", Price = 150 };
            var updatedCurso = new Curso
            {
                Id = 1,
                Description = "Ingles Intermedio",
                Price = 150,
                Status = true
            };
            _mockCursoRepo.Setup(repo => repo.Update(1, It.IsAny<Curso>())).Returns(updatedCurso);

            // Act
            var result = _cursoService.UpdateInfo(1, updateCursoDTO);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ingles Intermedio", result.Description);
            Assert.Equal(150, result.Price);
        }

        [Fact]
        public void CURSO003_ObtenerTodos_ReturnsListOfCursos()
        {
            // Arrange
            var cursos = new List<Curso>
        {
            new Curso { Id = 1, Description = "Ingles Avanzado", Price = 100 },
            new Curso { Id = 2, Description = "Ingles Intermedio", Price = 150 }
        };
            _mockCursoRepo.Setup(repo => repo.GetAll()).Returns(cursos);

            // Act
            var result = _cursoService.ObtenerTodos();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void CURSO004_ObtenerTodosDto_ReturnsListOfCursoDTO()
        {
            // Arrange
            var cursosDto = new List<CursoDTO>
        {
            new CursoDTO { Id = 1, Description = "Ingles Avanzado", Price = 100 },
            new CursoDTO { Id = 2, Description = "Ingles Intermedio", Price = 150 }
        };
            _mockCursoRepo.Setup(repo => repo.ObtenerCursosDto()).Returns(cursosDto);

            // Act
            var result = _cursoService.ObtenerTodosDto();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void CURSO005_ObtenerCursosPorDocente_ReturnsListOfCursoDTO()
        {
            // Arrange
            var cursosDto = new List<CursoDTO>
        {
            new CursoDTO { Id = 1, Description = "Ingles Avanzado", Price = 100 },
            new CursoDTO { Id = 2, Description = "Ingles Intermedio", Price = 150 }
        };
            _mockCursoRepo.Setup(repo => repo.ObtenerCursosPorDocente(1)).Returns(cursosDto);

            // Act
            var result = _cursoService.ObtenerCursosPorDocente(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
