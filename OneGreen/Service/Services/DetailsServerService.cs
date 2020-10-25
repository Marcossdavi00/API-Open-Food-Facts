using Domain.Entity;
using Domain.Interfaces;
using Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DetailsServerService : IDetailsServerService
    {
        private readonly IDetailsServerRepository _repository;

        public DetailsServerService(IDetailsServerRepository repository)
        {
            _repository = repository;
        }
        public async Task<IList<DetailsServer>> DetailsGet()
        {
            return await _repository.DetailsGet();
        }

        public async Task<DetailsServer> DetailsInsert(DetailsServer situacao)
        {
            return await _repository.DetailsInsert(situacao);
        }
    }
}
