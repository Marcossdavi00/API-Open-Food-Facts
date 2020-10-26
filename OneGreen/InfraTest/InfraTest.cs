using Domain.Entity;
using Domain.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace InfraTest
{
    public class InfraTest
    {
        private Mock<IProductsRepository> _repositoryMock;


        [Fact]
        public void MostrarListaDeProdutos()
        {
            _repositoryMock = new Mock<IProductsRepository>();
            Products products = new Products() { code = 1 };

            _repositoryMock.Setup(p => p.Create(products));

            var response = _repositoryMock.Setup(p => p.FindAllGet());

            Assert.NotNull(response);
        }
        [Fact]
        public void MostrarPorCodeDeProdutos()
        {
            _repositoryMock = new Mock<IProductsRepository>();
            Products products = new Products() { code = 1 };

            _repositoryMock.Setup(p => p.Create(products));

            var response = _repositoryMock.Setup(p => p.GetId(products.code));

            Assert.NotNull(response);
        }
        [Fact]
        public void DeletarPorCodeDeProdutos()
        {
            _repositoryMock = new Mock<IProductsRepository>();
            Products products = new Products() { code = 1 };

            _repositoryMock.Setup(p => p.Create(products));

            var result = _repositoryMock.Setup(p => p.Delete(products.code));

            Assert.NotNull(result);
        }
        [Fact]
        public void AlterarPorCodeDeProdutos()
        {
            //Arrage
            _repositoryMock = new Mock<IProductsRepository>();
            Products products = new Products() { code = 1 };

            _repositoryMock.Setup(p => p.Create(products));

            //Act
            Products products2 = new Products() { Status = (Domain.Helper.Enumerable.Status?)1 };

            var result = _repositoryMock.Setup(p => p.Update(products2, products.id));

            //Assert
            Assert.NotNull(result);
        }
     
    }
}
