using System.Xml.Serialization;

namespace ReklaTool.Models
{
    public interface IKategorie
    {
        public List<Position> Position { get; set; }
    }
    //[XmlElement(ElementName = "Vorgaenge")]
    //public Vorgaenge? Vorgaenge { get; set; }


    [XmlRoot(ElementName = "Vorgaenge")]
    public class Vorgaenge
    {
        [XmlElement(ElementName = "Vorgang")]
        public List<Vorgang> Vorgang { get; set; }
    }

    [XmlRoot(ElementName = "Vorgang")]
    public class Vorgang
    {
        [XmlElement(ElementName = "Kopfdaten")]
        public Kopfdaten Kopfdaten { get; set; }

        [XmlElement(ElementName = "Fahrzeugdaten")]
        public Fahrzeugdaten Fahrzeugdaten { get; set; }

        [XmlElement(ElementName = "Reparaturkosten")]
        public Reparaturkosten Reparaturkosten { get; set; }

        [XmlElement(ElementName = "Lohnklassen")]
        public Lohnklassen Lohnklassen { get; set; }

        [XmlElement(ElementName = "Instandsetzungen")]
        public Instandsetzungen Instandsetzungen { get; set; }

        [XmlElement(ElementName = "Ersatzteile")]
        public Ersatzteile Ersatzteile { get; set; }

        [XmlElement(ElementName = "Lackierung")]
        public Lackierung Lackierung { get; set; }

        [XmlElement(ElementName = "AnAbbau")]
        public AnAbbau AnAbbau { get; set; }

        [XmlElement(ElementName = "Unterboden")]
        public Unterboden Unterboden { get; set; }

        [XmlElement(ElementName = "Hohlraum")]
        public Hohlraum Hohlraum { get; set; }

        [XmlElement(ElementName = "SchwemmMaterial")]
        public string SchwemmMaterial { get; set; }

        [XmlElement(ElementName = "VID")]
        public VID VID { get; set; }
        [XmlElement(ElementName = "Regeln")]
        public Regeln Regeln { get; set; }

        [XmlElement(ElementName = "Einzelpruefbericht")]
        public Einzelpruefbericht Einzelpruefbericht { get; set; }

        [XmlElement(ElementName = "Kalkulation")]
        public Kalkulation Kalkulation { get; set; }
    }

    [XmlRoot(ElementName = "Kopfdaten")]
    public class Kopfdaten
    {
        [XmlElement(ElementName = "Kalksystem")]
        public string Kalksystem { get; set; }

        [XmlElement(ElementName = "Aktenzeichen")]
        public string Aktenzeichen { get; set; }

        [XmlElement(ElementName = "KalkulationsDatum")]
        public string KalkulationsDatum { get; set; }
    }

    [XmlRoot(ElementName = "Fahrzeugdaten")]
    public class Fahrzeugdaten
    {
        [XmlElement(ElementName = "HerstellerID")]
        public string HerstellerID { get; set; }

        [XmlElement(ElementName = "HerstellerBezeichnung")]
        public string HerstellerBezeichnung { get; set; }

        [XmlElement(ElementName = "HaupttypID")]
        public string HaupttypID { get; set; }

        [XmlElement(ElementName = "HaupttypBezeichnung")]
        public string HaupttypBezeichnung { get; set; }

        [XmlElement(ElementName = "UntertypID")]
        public string UntertypID { get; set; }

        [XmlElement(ElementName = "UntertypBezeichnung")]
        public string UntertypBezeichnung { get; set; }

        [XmlElement(ElementName = "Ausstattung")]
        public Ausstattung Ausstattung { get; set; }

        [XmlElement(ElementName = "AusstattungVID")]
        public AusstattungVID AusstattungVID { get; set; }
    }

    [XmlRoot(ElementName = "Ausstattung")]
    public class Ausstattung : IKategorie
    {
        [XmlElement(ElementName = "Position")]
        public List<Position> Position { get; set; }

        [XmlElement(ElementName = "Montageteile")]
        public Montageteile Montageteile { get; set; }
    }

    [XmlRoot(ElementName = "Montageteile")]
    public class Montageteile
    {
        [XmlElement(ElementName = "neueMontTeileLack")]
        public string NeueMontTeileLack { get; set; }

        [XmlElement(ElementName = "montTeileEingebaut")]
        public string MontTeileEingebaut { get; set; }

        [XmlElement(ElementName = "montTeileAusgebaut")]
        public string MontTeileAusgebaut { get; set; }
    }

    [XmlRoot(ElementName = "AusstattungVID")]
    public class AusstattungVID
    {
        [XmlElement(ElementName = "VID_MontageTeileAusgebaut")]
        public string VID_MontageTeileAusgebaut { get; set; }

        [XmlElement(ElementName = "VID_MontageTeileEingebaut")]
        public string VID_MontageTeileEingebaut { get; set; }

        [XmlElement(ElementName = "VID_NeueMontageTeileAusgebaut")]
        public string VID_NeueMontageTeileAusgebaut { get; set; }

        [XmlElement(ElementName = "VID_TeileAugebautVorlackiert")]
        public string VID_TeileAugebautVorlackiert { get; set; }

        [XmlElement(ElementName = "VID_Lackart")]
        public string VID_Lackart { get; set; }
    }

    [XmlRoot(ElementName = "Reparaturkosten")]
    public class Reparaturkosten
    {
        [XmlElement(ElementName = "GesamtMitMwST")]
        public string GesamtMitMwST { get; set; }

        [XmlElement(ElementName = "GesamtOhneMwST")]
        public string GesamtOhneMwST { get; set; }

        [XmlElement(ElementName = "Lackierung")]
        public string Lackierung { get; set; }

        [XmlElement(ElementName = "Arbeitslohn")]
        public string Arbeitslohn { get; set; }

        [XmlElement(ElementName = "Ersatzteile")]
        public string Ersatzteile { get; set; }

        [XmlElement(ElementName = "Nebenkosten")]
        public string Nebenkosten { get; set; }
    }

    [XmlRoot(ElementName = "Lohnklassen")]
    public class Lohnklassen
    {
        [XmlElement(ElementName = "Lk1")] public string Lk1 { get; set; }
        [XmlElement(ElementName = "Lk2")] public string Lk2 { get; set; }
        [XmlElement(ElementName = "Lk3")] public string Lk3 { get; set; }
        [XmlElement(ElementName = "Lk5")] public string Lk5 { get; set; }

        [XmlElement(ElementName = "Lackierung")]
        public string Lackierung { get; set; }
    }

    [XmlRoot(ElementName = "Instandsetzungen")]
    public class Instandsetzungen : IKategorie
    {
        [XmlElement(ElementName = "Position")]
        public List<Position> Position { get; set; }
    }

    [XmlRoot(ElementName = "Ersatzteile")]
    public class Ersatzteile : IKategorie
    {
        [XmlElement(ElementName = "Position")]
        public List<Position> Position { get; set; }
        [XmlElement(ElementName = "Zusatz")]
        public Zusatz Zusatz { get; set; }
    }

    [XmlRoot(ElementName = "Lackierung")]
    public class Lackierung : IKategorie
    {
        [XmlElement(ElementName = "Lacksystem")]
        public string Lacksystem { get; set; }

        [XmlElement(ElementName = "Position")]
        public List<Position> Position { get; set; }

        [XmlElement(ElementName = "Zusatz")]
        public Zusatz Zusatz { get; set; }
    }

    [XmlRoot(ElementName = "AnAbbau")]
    public class AnAbbau : IKategorie
    {
        [XmlElement(ElementName = "Position")]
        public List<Position> Position { get; set; }
    }

    [XmlRoot(ElementName = "Unterboden")]
    public class Unterboden
    {
        [XmlElement(ElementName = "Material")]
        public string Material { get; set; }
    }

    [XmlRoot(ElementName = "Hohlraum")]
    public class Hohlraum : IKategorie
    {
        [XmlElement(ElementName = "Position")]
        public List<Position> Position { get; set; }
        [XmlElement(ElementName = "Material")]
        public string Material { get; set; }
    }

    [XmlRoot(ElementName = "VID")]
    public class VID
    {
        [XmlElement(ElementName = "Data")]
        public Data Data { get; set; }
    }

    [XmlRoot(ElementName = "Data")]
    public class Data
    {
        [XmlElement(ElementName = "Platzhalter")]
        public Platzhalter Platzhalter { get; set; }
    }

    [XmlRoot(ElementName = "Platzhalter")]
    public class Platzhalter
    {
        [XmlElement(ElementName = "KindOfReparation")]
        public string KindOfReparation { get; set; }

        [XmlElement(ElementName = "LeadingNumber")]
        public string LeadingNumber { get; set; }

        [XmlElement(ElementName = "PlaceHolder")]
        public string PlaceHolder { get; set; }
    }

    [XmlRoot(ElementName = "Regeln")]
    public class Regeln
    {
        [XmlElement(ElementName = "Regel")]
        public List<Regel> Regel { get; set; }
    }

    [XmlRoot(ElementName = "Regel")]
    public class Regel
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Text")]
        public string Text { get; set; }
        [XmlElement(ElementName = "RegelID")]
        public string RegelID { get; set; }
    }

    [XmlRoot(ElementName = "Einzelpruefbericht")]
    public class Einzelpruefbericht
    {
        [XmlElement(ElementName = "Base64")]
        public string Base64 { get; set; }
    }

    [XmlRoot(ElementName = "Kalkulation")]
    public class Kalkulation
    {
        [XmlElement(ElementName = "Base64")]
        public string Base64 { get; set; }
    }

    [XmlRoot(ElementName = "Position")]
    public class Position
    {
        [XmlElement(ElementName = "Code")]
        public string? Code { get; set; }

        [XmlElement(ElementName = "Bezeichnung")]
        public string? Bezeichnung { get; set; }

        [XmlElement(ElementName = "Leitnummer")]
        public string? Leitnummer { get; set; }

        [XmlElement(ElementName = "Repart")]
        public string? Repart { get; set; }

        [XmlElement(ElementName = "ReparaturText")]
        public string? ReparaturText { get; set; }

        [XmlElement(ElementName = "AW")]
        public string? AW { get; set; }

        [XmlElement(ElementName = "AWinStunden")]
        public string? AWinStunden { get; set; }

        [XmlElement(ElementName = "Betrag")]
        public string? Betrag { get; set; }
        [XmlElement(ElementName = "Bauart")]
        public string? Bauart { get; set; }

        [XmlElement(ElementName = "MaterialEigenschaft")]
        public string? MaterialEigenschaft { get; set; }

        [XmlElement(ElementName = "Lohnstufe")]
        public string? Lohnstufe { get; set; }

        [XmlElement(ElementName = "Materialeigenschaft")]
        public string? Materialeigenschaft { get; set; }

        [XmlElement(ElementName = "Teilenummer")]
        public string? Teilenummer { get; set; }

        [XmlElement(ElementName = "Platzhalter")]
        public string? Platzhalter { get; set; }

        [XmlElement(ElementName = "Stern")]
        public string? Stern { get; set; }

        [XmlElement(ElementName = "Lackbezeichnung")]
        public string? Lackbezeichnung { get; set; }

        [XmlElement(ElementName = "ArbeitspositionsNummer")]
        public string? ArbeitspositionsNummer { get; set; }

        [XmlElement(ElementName = "Lackart")]
        public string? Lackart { get; set; }
    }

    [XmlRoot(ElementName = "Zusatz")]
    public class Zusatz
    {
        [XmlElement(ElementName = "UpeAufschlag")]
        public string UpeAufschlag { get; set; }

        [XmlElement(ElementName = "UpeAbschlag")]
        public string UpeAbschlag { get; set; }

        [XmlElement(ElementName = "Kleinersatzteile")]
        public string Kleinersatzteile { get; set; }

        [XmlElement(ElementName = "LackMaterial")]
        public string LackMaterial { get; set; }

        [XmlElement(ElementName = "LackierkostenGesamt")]
        public string LackierkostenGesamt { get; set; }
    }

}
