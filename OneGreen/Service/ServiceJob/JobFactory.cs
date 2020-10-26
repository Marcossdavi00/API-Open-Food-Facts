using Domain.Interfaces;
using Quartz;
using System.Threading.Tasks;

namespace Service.ServiceJob
{
    public class JobFactory : IJob
    {
        private readonly IConnectRepository _connectRepository;
        private readonly IDetailsServerRepository _serverRepository;

        public JobFactory(IConnectRepository ConnectRepository, IDetailsServerRepository serverRepository)
        {
            _connectRepository = ConnectRepository;
            _serverRepository = serverRepository;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await ImportArchivo.exportArchivo();
            await _serverRepository.DetailsInsert(new Domain.Entity.DetailsServer() { SituacaoDoServidor = "OK" });
            await _connectRepository.ConnectProducts();
        }
    }
}
