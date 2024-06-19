using System.ComponentModel.DataAnnotations;

namespace SimpleCrudApp.Domain
{
    public class CitizenShip:BaseEntity
    {
        public string CitizenCertificateNo { get; set; }

        public string FullName { get; set; }
        public DateOnly DateofBirth { get; set; }

        public string BirthPlace { get; set; }

        public string PermanentAddress { get; set; }

        public string CitizenShipIssuedAddress { get; set; }


        public DateOnly CitizenShipIssuedDate { get; set; }
    }

}
