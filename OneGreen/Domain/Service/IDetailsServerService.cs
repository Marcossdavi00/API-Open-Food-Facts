using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IDetailsServerService
    {
        Task<IList<DetailsServer>> DetailsGet();
        Task<DetailsServer> DetailsInsert(DetailsServer situacao);
    }
}
