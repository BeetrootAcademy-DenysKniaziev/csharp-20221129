using System.Drawing;

namespace Homework34.Models
{
    public enum Grade
    {
        Standard, Selected
    }

    public class Enrollment//!!! Communication thrugh enrolment should check that one Person can have only one Enrolment to One Order
    {
        public int EnrollmentID { get; set; }
        public int OrderID { get; set; }// Material or service
        public int PersonID { get; set; }// Owner or Seeker

        public bool Role { get; set; } //Owner or Seeker role
        public decimal Longitude{ get; set; } //Center of Location of interest for seeker or Place of material 
        public decimal Lattitude { get; set; } //Center of Location of interest for seeker or Place of material 
        public int Radius { get; set; } //Radius of interest in Km
        public DateTime TimeOfAppearance { get; set; }
        public TimeSpan AvaliblityPeriod { get; set; }// Time of Existence for Owner and Time of Interest for Seeker
        //public string? ActionLog { get; set; } // Actions taken by Person regarding this Order (Request for Lock/Unlock, recieved, Claim in case of nonconformity) with time
        public Grade? Grade { get; set; } //

        public virtual Order Order { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<EventLog>? EventLogs { get; set; }// Cherez EventLog budu dyvytys` hto koly, scho robyv, a v Orderi status bude zminuvatys` tilky pislya perevirki vsih logiv vsih Enrolmentiv do ciogo Ordera

    }
}
