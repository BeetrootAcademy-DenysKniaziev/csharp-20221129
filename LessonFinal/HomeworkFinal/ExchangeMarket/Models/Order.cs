using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExchangeMarket.Models
{
    public class Order
        //Zayavka pro bazhannya viddaty chy otrymaty
        //Za rahunok togo, scho sutnist` Order vidokremlena vid Locacii ta chasu (yaki znahodyatsya v eEnrolmentah i povyazani z ludynou) Servicy i Materialy Zmozhut` peremischuvatys` "pereizdzaty" ne vplyvauchy na Order bezposerednio
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }
        public string Title { get; set; }
        public string? Descriptions { get; set; }
        public int? OrderStatus { get; set; } //Locked -0//Avalible -1// FirstGain -2 //!!! Will changed after OnEnrolmentActionLogChange()
        public int? Credits { get; set; } // price points for this order seted On Creation

        public virtual ICollection<Item>? Items { get; set; }// Materials and/or Services in this order

        // Mozhna okremo vynesty rol Ownera (ne cherez Enrolments) ale e bazannya zalyshyty mozlyvist davaty kilka owneriv na odne rozmischennya
        public virtual ICollection<Enrollment>? Enrollments { get; set; }// Cnnocted typicly one owner and one or more seekers with this Order

    }
}
