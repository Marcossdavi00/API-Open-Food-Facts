using Domain.Entity;
using Domain.Interfaces;
using Moq;
using Xunit;

namespace InfraaTest
{
    public class InfraTest
    {
        private Mock<IDetailsServerRepository> _repositoryMock;
        [Fact]
        public void InserindoDetalhesDoServidor()
        {
            _repositoryMock = new Mock<IDetailsServerRepository>();

            DetailsServer details = new DetailsServer() { SituacaoDoServidor = "OK" };

            var result = _repositoryMock.Setup(d => d.DetailsInsert(details));

            Assert.NotNull(result);
        }

        [Fact]
        public void MotrandoDetalhesDoServidor()
        {
            _repositoryMock = new Mock<IDetailsServerRepository>();

            DetailsServer details = new DetailsServer() { SituacaoDoServidor = "OK" };

            _repositoryMock.Setup(d => d.DetailsInsert(details));

            var result = _repositoryMock.Setup(d => d.DetailsGet());

            Assert.NotNull(result);
        }

    }
}
