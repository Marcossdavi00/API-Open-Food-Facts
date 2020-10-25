using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDetailsServerRepository
    {
        Task<IList<DetailsServer>> DetailsGet();
        Task<DetailsServer> DetailsInsert(DetailsServer situacao);
    }
}
