namespace ExchangeMarket.Models
{
    public class EventLog// %%% Namagaus` pobuduvaty Table yaka bude mistyty kolonku z posylannyamy na samu sebe EventLogID ???
    {
        public int ID { get; set; }
        //public int? EventLogID { get; set; }// Cei zgeneruvavsya yak procno nezalezne pole z mozlyvistu buty NULL
        public int EnrollmentID { get; set; }
        public string Action { get; set;}// request to lock/unlock. giving bonus proposal. requst for iformation...
        public DateTime ActionDateTime { get; set; }

        //public virtual Enrollment Enrollment { get; set; }
        public virtual EventLog? TargetEventLog { get; set; } // Podiya na reakcieu na yaku e cei Action (V sensi pryinyattya/ ne pryinyattya . pytannya/vidpovidi)
    }
}
