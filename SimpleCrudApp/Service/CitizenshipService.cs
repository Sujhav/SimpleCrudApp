using Microsoft.EntityFrameworkCore;
using SimpleCrudApp.Domain;
using SimpleCrudApp.ViewModels;

namespace SimpleCrudApp.Service
{
    public class CitizenshipService : ICitizenshipService
    {
        private readonly CitizenshipDbContext _citizenshipDbContext;
        public CitizenshipService(CitizenshipDbContext citizenshipDbContext)
        {
            _citizenshipDbContext = citizenshipDbContext;
        }

        public async Task<string> CreateCitizenshipAsync(CitizenShipViewModel model)
        {

            var citizenship = new CitizenShip
            {
                BirthPlace = model.BirthPlace,
                CitizenCertificateNo = model.CitizenCertificateNo,
                CitizenShipIssuedAddress = model.CitizenShipIssuedAddress,
                CitizenShipIssuedDate = model.CitizenShipIssuedDate,
                FullName = model.FullName,
                CreatedDate = DateTime.Now,
                DateofBirth = model.DateofBirth,
                PermanentAddress = model.PermanentAddress,
            };
            _citizenshipDbContext.Citizenship.Add(citizenship);
            await _citizenshipDbContext.SaveChangesAsync();
            return "Citienship created sucessfully.";

        }
        public async Task<CitizenShipViewModel> GetByIdAsync(Guid id)
        {
            var citizenship = await _citizenshipDbContext.Citizenship.Where(x => x.Id == id).Select(x => new CitizenShipViewModel
            {
                Id = x.Id,
                BirthPlace = x.BirthPlace,
                CitizenCertificateNo = x.CitizenCertificateNo,
                CitizenShipIssuedAddress = x.CitizenShipIssuedAddress,
                CitizenShipIssuedDate = x.CitizenShipIssuedDate,
                FullName = x.FullName,
                DateofBirth = x.DateofBirth,
                PermanentAddress = x.PermanentAddress,

            }).FirstOrDefaultAsync();
            return citizenship;

        }

        public async Task<List<CitizenShipViewModel>> GetAllCitizenship()
        {

            var citizenships = await _citizenshipDbContext.Citizenship.Select(x => new CitizenShipViewModel
            {
                Id= x.Id,
                BirthPlace = x.BirthPlace,
                CitizenCertificateNo = x.CitizenCertificateNo,
                CitizenShipIssuedAddress = x.CitizenShipIssuedAddress,
                CitizenShipIssuedDate = x.CitizenShipIssuedDate,
                FullName = x.FullName,
                DateofBirth = x.DateofBirth,
                PermanentAddress = x.PermanentAddress,

            }).ToListAsync();
            return citizenships;



        }

        public async Task<bool> DeleteCitizenshipAsync(Guid id)
        {

            var citizenship = await _citizenshipDbContext.Citizenship.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (citizenship != null)
            {
                _citizenshipDbContext.Citizenship.Remove(citizenship);
                await _citizenshipDbContext.SaveChangesAsync();
                return false;
            }
            return false;



        }

        public async Task<bool> UpdateCitizenshipAsync(CitizenShipViewModel model)
        {

            var citizenship = await _citizenshipDbContext.Citizenship.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (citizenship != null)
            {

                citizenship.BirthPlace = model.BirthPlace;
                citizenship.CitizenCertificateNo = model.CitizenCertificateNo;
                citizenship.CitizenShipIssuedAddress = model.CitizenShipIssuedAddress;;
                citizenship.CitizenShipIssuedDate = model.CitizenShipIssuedDate;
                citizenship.FullName = model.FullName;
                citizenship.DateofBirth = model.DateofBirth;
                citizenship.PermanentAddress = model.PermanentAddress;
                citizenship.ModifiedDate = DateTime.Now;
                
                _citizenshipDbContext.Citizenship.Update(citizenship);
                await _citizenshipDbContext.SaveChangesAsync();
                return true;
            }
            return false;



        }
    }
}
