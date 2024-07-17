using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergyApi.Data.Model
{

    public class Organization
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<SubOrganization> SubOrganizations { get; set; }
    }

    public class SubOrganization
    {
        public int SubOrganizationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        public ICollection<ObjectPotrebleniya>? ObjectPotrebleniyas { get; set; }
    }

    public class ObjectPotrebleniya
    {
        public int ObjectPotrebleniyaId { get; set; }
        [RegularExpression(@"^ПС\s\d{3}\/\d{2}\s[А-Я][а-я]+$")] //корректное RegExp, но в данном случае можно ^ и $ не использовать
        public string Name { get; set; }
        public string Address { get; set; }

        public int SubOrganizationId { get; set; }
        [ForeignKey("SubOrganizationId")]
        public SubOrganization SubOrganization { get; set; }
        public List<TochkaIzmereniya> TochkaIzmereniyas { get; set; }
        public List<TochkaPostavki> TochkaPostavki { get; set; }
    }

    public class TochkaPostavki
    {
        public int TochkaPostavkiId { get; set; }
        public float MaxPower { get; set; }

        public int ObjectPotrebleniyaId { get; set; }
        [ForeignKey("ObjectPotrebleniyaId")]
        public ObjectPotrebleniya ObjectPotrebleniya { get; set; }
    }

    public class RaschetnyPriborUcheta
    {
        public int RaschetnyPriborUchetaId { get; set; }

        public int TochkaPostavkisId { get; set; }
        [ForeignKey("TochkaPostavkiId")]
        public ICollection<TochkaPostavki> TochkaPostavkis { get; set; }

        public int TochkaIzmereniyasId { get; set; }
        [ForeignKey("TochkaIzmereniyaId")]
        public ICollection<TochkaIzmereniya> TochkaIzmereniyas { get; set; }
    }

    public class TochkaIzmereniya
    {
        public int TochkaIzmereniyaId { get; set; }
        public string Name { get; set; }

        public int ObjectPotrebleniyaId { get; set; }
        [ForeignKey("ObjectPotrebleniyaId")]
        public ObjectPotrebleniya ObjectPotrebleniya { get; set; }

        public Schetchik Schetchik { get; set; }
        public TransformatorToka TransformatorToka { get; set; }
        public TransformatorNapryazheniya TransformatorNapryazheniya { get; set; }
    }

    public class TransformatorNapryazheniya
    {
        public int TransformatorNapryazheniyaId { get; set; }
        public int Number { get; set; }
        public string TnType { get; set; }
        public DateTime DatePoverki { get; set; }
        public int KTN { get; set; }

        public int TochkaIzmereniyaId;
        [ForeignKey("TochkaIzmereniyaId")]
        public TochkaIzmereniya TochkaIzmereniya { get; set; }
    }

    public class TransformatorToka
    {
        public int TransformatorTokaId { get; set; }
        public int Number { get; set; }
        public string TtType { get; set; }
        public DateTime DatePoverki { get; set; }
        public int KTT { get; set; }

        public int TochkaIzmereniyaId;
        [ForeignKey("TochkaIzmereniyaId")]
        public TochkaIzmereniya TochkaIzmereniya { get; set; }
    }

    public class Schetchik
    {
        public int SchetchikId { get; set; }
        public int Number { get; set; }
        public string SchType { get; set; }
        public DateTime DatePoverki { get; set; }

        public int TochkaIzmereniyaId;
        [ForeignKey("TochkaIzmereniyaId")]
        public TochkaIzmereniya TochkaIzmereniya { get; set; }
    }

}
