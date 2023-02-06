using Shared.Core.Models;

namespace Shared.Core.Interfaces
{
    public interface IDictionaryService
    {
        Task<List<RayonDto>> GetRayons();        
    }
}