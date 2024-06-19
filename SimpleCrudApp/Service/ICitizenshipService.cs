using SimpleCrudApp.ViewModels;

namespace SimpleCrudApp.Service
{
    public interface ICitizenshipService
    {
        Task<string> CreateCitizenshipAsync(CitizenShipViewModel model);
        Task<bool> DeleteCitizenshipAsync(Guid id);
        Task<List<CitizenShipViewModel>> GetAllCitizenship();
        Task<CitizenShipViewModel> GetByIdAsync(Guid id);
        Task<bool> UpdateCitizenshipAsync(CitizenShipViewModel model);
    }
}