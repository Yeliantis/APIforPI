using APIforPI.Controllers;
using APIforPI.Infrastracture.Dto;
using APIforPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APIforPI.Testing.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly ProductController _controller;
        public ProductControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _controller = new ProductController(_productServiceMock.Object);
        }

        [Fact]
        public async Task GetItemAsync_ReturnsRightTypeAndValue()
        {
            // Arrange
            _productServiceMock.Setup(serv => serv.GetItemAsync(1)).ReturnsAsync(new ProductDto
            {
                Id = 1,
                Name = "Красный дракон",
                Price = 770,
                ImageURL = "/Images/Rolls/Красный дракон.jpg",
                Category = "Sushi"
            });

            var controller = new ProductController(_productServiceMock.Object);

            // Act
            var result = await controller.GetProductAsync(1);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<ProductDto>(viewResult.Value);
            Assert.Equal("Красный дракон", model.Name);
        }

        [Fact]
        public async Task GetItemAsync_ReturnsBadRequestWhenModelIsInvalid()
        {

            //Arrange
            _productServiceMock.Setup(serv => serv.GetItemAsync(1)).ReturnsAsync(GetInvalidProduct());

            // Act

            var result = await _controller.GetProductAsync(1);

            //Assert
            Assert.False(_controller.ModelState.IsValid);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetProductAsync_ReturnsNotFoundWhenNoProduct()
        {
            // Arrange
            _productServiceMock.Setup(serv => serv.GetItemAsync(It.IsAny<int>()))
                              .ReturnsAsync((ProductDto)null!);

            // Act
            var result = await _controller.GetProductAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsOkResultWithValidModel()
        {
            // Arrange
            var products = GetProductsList();

            _productServiceMock.Setup(serv => serv.GetProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAllProductsAsync();

            // Assert
            Assert.True(_controller.ModelState.IsValid);
            Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(((OkObjectResult)result.Result).Value);
            Assert.Equal(products, model);
        }

        [Fact]
        public async Task GetAllProductsAsync_ReturnsNotFoundWhenNoProducts()
        {
            // Arrange
            _productServiceMock.Setup(serv=>serv.GetProductsAsync()).ReturnsAsync((IEnumerable<ProductDto>)null!);

            // Act
            var result = await _controller.GetAllProductsAsync();
            // Assert
            Assert.True(_controller.ModelState.IsValid);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        private ProductDto GetProduct()
        {
            return new ProductDto
            {
                Id = 1,
                Name = "Красный дракон",
                Price = 770,
                ImageURL = "/Images/Rolls/Красный дракон.jpg",
                Category = "Sushi"
            };
        }

        private List<ProductDto> GetProductsList()
        {
            return new List<ProductDto> {

                new ProductDto
                {
                Id = 1,
                Name = "Красный дракон",
                Price = 770,
                ImageURL = "/Images/Rolls/Красный дракон.jpg",
                Category = "Sushi"
                },

                new ProductDto
                {
                Id = 2,
                Name = "Юта",
                Price = 410,
                ImageURL = "/Images/Rolls/Юта.jpg",
                Category = "Sushi"
                },

                new ProductDto
                {
                    Id = 3,
                    Name = "Осака",
                    Price = 470,
                    ImageURL = "/Images/Rolls/Осака.jpg",
                    Category = "Sushi"
                },

                new ProductDto
                {
                    Id = 3,
                    Name = "Чидзу",
                    Price = 390,
                    ImageURL = "/Images/Rolls/Чидзу.jpg",
                    Category = "Sushi"
                }
            };
        }
        private ProductDto GetInvalidProduct()
        {
            return new ProductDto
            {
                Id = 1,
                Price = 770,
                ImageURL = "/Images/Rolls/Красный дракон.jpg",
                Category = "Sushi"
            };
        }



    } 
}