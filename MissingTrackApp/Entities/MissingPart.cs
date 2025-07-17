using System;
//seri numarası için eski mantık : modelcode + productiondatecode + serialnumber.
namespace MissingTrackApp.Entities
{
    public class MissingPart
    {
        public int Id { get; set; }
        public string ModelCode { get; set; }
        public string ProductionDateCode { get; set; }
        public string SerialNumber { get; set; }
        public string MissingCode { get; set; }
        public int EnteredByUserId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
