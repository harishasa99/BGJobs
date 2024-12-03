namespace Projekat2.Models
{
    public class Osoba
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Godine { get; set; }
        public DateTime DatumVremePoslednjegLogovanja { get; set; }
    }
}
