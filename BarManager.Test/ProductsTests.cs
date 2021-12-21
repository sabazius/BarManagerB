using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.BL.Services;
using BarManager.Controllers;
using BarManager.DL.Interfaces;
using BarManager.Extensions;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using Xunit;

namespace BarManager.Test
{
    public class ProductsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductsRepository> _productsRepository;
        private readonly IProductsService _productsService;
        private readonly ProductsController _productsController;

        private IList<Products> Productss = new List<Products>()
        {
            {new Products() {Id = 1, Name = "TestName", Price = 3}},
            {new() {Id = 2, Name = "AnotherName", Price = 4.5}}
        };

        public ProductsTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _productsRepository = new Mock<IProductsRepository>();

            var logger = new Mock<ILogger>();

            _productsService = new ProductsService(_productsRepository.Object, logger.Object);

            _productsController = new ProductsController(_productsService, _mapper);
        }

        [Fact]
        public void Products_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 2;

            var mockedService = new Mock<IProductsService>();

            mockedService.Setup(x => x.GetAll()).Returns(Productss);

            //inject
            var controller = new ProductsController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var productss = okObjectResult.Value as IEnumerable<Products>;
            Assert.NotNull(productss);
            Assert.Equal(expectedCount, productss.Count());
        }

        [Fact]
        public void Products_GetById_NameCheck()
        {
            //setup
            var productsId = 2;
            var expectedName = "AnotherName";

            _productsRepository.Setup(x => x.GetById(productsId))
                .Returns(Productss.FirstOrDefault(t => t.Id == productsId));

            //Act
            var result = _productsController.GetById(productsId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ProductsResponse;
            var products = _mapper.Map<Products>(response);

            Assert.NotNull(products);
            Assert.Equal(expectedName, products.Name);
        }

        [Fact]
        public void Products_GetById_PriceCheck()
        {
            //setup
            var productsId = 2;
            var expectedPrice = 4.5;

            _productsRepository.Setup(x => x.GetById(productsId))
                .Returns(Productss.FirstOrDefault(t => t.Id == productsId));

            //Act
            var result = _productsController.GetById(productsId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as ProductsResponse;
            var products = _mapper.Map<Products>(response);

            Assert.NotNull(products);
            Assert.Equal(expectedPrice, products.Price);
        }


        [Fact]
        public void Products_GetById_NotFound()
        {
            //setup
            var productsId = 3;

            _productsRepository.Setup(x => x.GetById(productsId))
                .Returns(Productss.FirstOrDefault(t => t.Id == productsId));

            //Act
            var result = _productsController.GetById(productsId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(productsId, response);
        }

        [Fact]
        public void Products_Update_ProductsName()
        {
            var productsId = 1;
            var expectedName = "Updated Products Name";

            var products = Productss.FirstOrDefault(x => x.Id == productsId);
            products.Name = expectedName;

            _productsRepository.Setup(x => x.GetById(productsId))
                .Returns(Productss.FirstOrDefault(t => t.Id == productsId));
            _productsRepository.Setup(x => x.Update(products))
                .Returns(products);

            //Act
            var productsUpdateRequest = _mapper.Map<ProductsUpdateRequest>(products);
            var result = _productsController.Update(productsUpdateRequest);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Products;
            Assert.NotNull(val);
            Assert.Equal(expectedName, val.Name);

        }

        [Fact]
        public void Products_Delete_ExistingProducts()
        {
            //Setup
            var productsId = 1;

            var products = Productss.FirstOrDefault(x => x.Id == productsId);

            _productsRepository.Setup(x => x.Delete(productsId)).Callback(() => Productss.Remove(products)).Returns(products);

            //Act
            var result = _productsController.Delete(productsId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Products;
            Assert.NotNull(val);
            Assert.Equal(1, Productss.Count);
            Assert.Null(Productss.FirstOrDefault(x => x.Id == productsId));
        }

        [Fact]
        public void Products_Delete_NotExisting_Products()
        {
            //Setup
            var productsId = 3;

            var products = Productss.FirstOrDefault(x => x.Id == productsId);

            _productsRepository.Setup(x => x.Delete(productsId)).Callback(() => Productss.Remove(products)).Returns(products);

            //Act
            var result = _productsController.Delete(productsId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(productsId, response);
        }

        [Fact]
        public void Products_CreateProducts()
        {
            //setup
            var products = new Products()
            {
                Id = 3,
                Name = "Name 3"
            };

            _productsRepository.Setup(x => x.GetAll()).Returns(Productss);

            _productsRepository.Setup(x => x.Create(It.IsAny<Products>())).Callback(() =>
            {
                Productss.Add(products);
            }).Returns(products);

            //Act
            var result = _productsController.CreateProducts(_mapper.Map<ProductsRequest>(products));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Productss.FirstOrDefault(x => x.Id == products.Id));
            Assert.Equal(3, Productss.Count);

        }

    }
}
