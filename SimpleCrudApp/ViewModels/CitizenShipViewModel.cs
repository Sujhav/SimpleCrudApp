using System.ComponentModel.DataAnnotations;

namespace SimpleCrudApp.ViewModels
{
    public class CitizenShipViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage="Please enter your CitizenShip Certificate No.")]
        [Display(Name ="Citizen Certificatate No.")]
        public string CitizenCertificateNo {  get; set; }

        [Required(ErrorMessage = "Please enter your FullName")]
        [Display(Name = "Full Name")]
        public string FullName {  get; set; }

        [Required(ErrorMessage = "Please enter your Date of birth")]
        [Display(Name = "Date Of Birth")]
        public DateOnly DateofBirth { get; set; }

        [Required(ErrorMessage = "Please enter your Birth Place")]
        [Display(Name = "Birth Place")]
        public string BirthPlace {  get; set; }

        [Required(ErrorMessage = "Please enter your Permanent Address")]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress {  get; set; }

        [Required(ErrorMessage = "Please enter your CitizenShip Issued Address")]
        [Display(Name = "CitizenShip Issued Address ")]
        public string CitizenShipIssuedAddress {  get; set; }

        [Required(ErrorMessage = "Please enter your CitizenShip Issued Date")]
        [Display(Name = " CitizenShip Issued Date")]

        public DateOnly CitizenShipIssuedDate {  get; set; }
    }
}
