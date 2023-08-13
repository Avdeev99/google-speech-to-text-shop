using System.Collections.Generic;
using System.Threading.Tasks;
using TRM_STT.Core.Domain.Models;

namespace TRM_STT.Core.Services.Interfaces
{
    public interface IGoodService
    {
        Task CreateAsync(Good good);

        Task<IEnumerable<Good>> GetAllAsync();

        Task<IEnumerable<Good>> GetAllByAudioAsync(string fileName);
    }
}