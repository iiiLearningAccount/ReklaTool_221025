using ReklaTool.Controllers;
using ReklaTool.Models;
using ReklaTool.Models.ViewModels;

namespace ReklaTool.Services
{
    public interface IEndpointService
    {
        List<VorgangInfoModel> GetVorgangInfos(FilterRequest model);
        List<FahrzeugdatenViewModel> GetFahrzeugDaten(FilterRequest model);
        List<KostenViewModel> GetKosten(FilterRequest model);
        List<AusstattungViewModel> GetAusstattung(FilterRequest model);
        List<PositionViewModel> GetPositionen(FilterRequest model);
        List<RegelViewModel> GetRegeln(FilterRequest model);
        byte[] GetPdf(FilterRequest model);
    }
    public class UiEndpointService : IEndpointService
    {
        private readonly IMsgService _msgService;
        public UiEndpointService(IMsgService msgService)
        {
            _msgService = msgService;
        }
        public List<VorgangInfoModel> GetVorgangInfos(FilterRequest model)
        {
            //List<VorgangInfoModel> vorgangInfos = _msgService.GetVorgangInfos(model).Result;
            //return vorgangInfos;
            var vorgaengeAsync = _msgService.GetVorgaengeAsync(model).Result;
            List<VorgangInfoModel> vorgangInfos = new List<VorgangInfoModel>();
            foreach (Vorgang vorgang in vorgaengeAsync.Vorgang)
            {
                vorgangInfos.Add(new VorgangInfoModel
                {
                    Aktenzeichen = vorgang.Kopfdaten.Aktenzeichen,
                    Kalkulationsdatum = vorgang.Kopfdaten.KalkulationsDatum,
                    Kalkulationssystem = vorgang.Kopfdaten.Kalksystem
                });
            }
            return vorgangInfos;
        }
        private PositionViewModel MapToPositionViewModel(Position position, string kategorie)
        {
            PositionViewModel positionViewModel = new PositionViewModel
            {
                Kategorie = kategorie,
                Code = position.Code,
                Bezeichnung = position.Bezeichnung,
                Leitnummer = position.Leitnummer,
                Repart = position.Repart,
                ReparaturText = position.ReparaturText,
                AW = position.AW,
                AWinStunden = position.AWinStunden,
                Betrag = position.Betrag,
                Bauart = position.Bauart,
                MaterialEigenschaft = position.MaterialEigenschaft,
                Lohnstufe = position.Lohnstufe,
                Materialeigenschaft = position.Materialeigenschaft,
                Teilenummer = position.Teilenummer,
                Platzhalter = position.Platzhalter,
                Stern = position.Stern,
                Lackbezeichnung = position.Lackbezeichnung,
                ArbeitspositionsNummer = position.ArbeitspositionsNummer,
                Lackart = position.Lackart
            };
            return positionViewModel;
        }
        public List<FahrzeugdatenViewModel> GetFahrzeugDaten(FilterRequest model)
        {
            var vorgang = _msgService.GetVorgangByIdAsync(model).Result;
            var fahrzeugdatenViewModels = new List<FahrzeugdatenViewModel>();
            Fahrzeugdaten fahrzeugdaten = vorgang.Fahrzeugdaten;
            FahrzeugdatenViewModel viewModel = new FahrzeugdatenViewModel
            {
                HerstellerID = fahrzeugdaten.HerstellerID,
                HerstellerBezeichnung = fahrzeugdaten.HerstellerBezeichnung,
                HaupttypID = fahrzeugdaten.HaupttypID,
                HaupttypBezeichnung = fahrzeugdaten.HaupttypBezeichnung,
                UntertypID = fahrzeugdaten.UntertypID,
                UntertypBezeichnung = fahrzeugdaten.UntertypBezeichnung
            };
            fahrzeugdatenViewModels.Add(viewModel);
            return fahrzeugdatenViewModels;
        }
        public List<KostenViewModel> GetKosten(FilterRequest model)
        {
            var vorgang = _msgService.GetVorgangByIdAsync(model).Result;
            var kostenViewModels = new List<KostenViewModel>();
            Reparaturkosten reparaturkosten = vorgang.Reparaturkosten;
            Lohnklassen lohnklassen = vorgang.Lohnklassen;
            KostenViewModel viewModel = new KostenViewModel()
            {
                GesamtMitMwST = reparaturkosten.GesamtMitMwST,
                GesamtOhneMwST = reparaturkosten.GesamtOhneMwST,
                Lackierung = reparaturkosten.Lackierung,
                Arbeitslohn = reparaturkosten.Arbeitslohn,
                Ersatzteile = reparaturkosten.Ersatzteile,
                Nebenkosten = reparaturkosten.Nebenkosten,
                Lohnklasse1 = lohnklassen.Lk1,
                Lohnklasse2 = lohnklassen.Lk2,
                Lohnklasse3 = lohnklassen.Lk3,
                Lohnklasse5 = lohnklassen.Lk5,
                LackierungKlasse = lohnklassen.Lackierung
            };
            kostenViewModels.Add(viewModel);
            return kostenViewModels;
        }
        public List<AusstattungViewModel> GetAusstattung(FilterRequest model)
        {
            var vorgang = _msgService.GetVorgangByIdAsync(model).Result;
            var ausstattungViewModels = new List<AusstattungViewModel>();
            var ausstattung = vorgang.Fahrzeugdaten.Ausstattung.Position;
            foreach (var position in ausstattung)
            {
                ausstattungViewModels.Add(new AusstattungViewModel { Code = position.Code, Bezeichnung = position.Bezeichnung });
            }
            return ausstattungViewModels;
        }
        public List<PositionViewModel> GetPositionen(FilterRequest model)
        {
            var vorgang = _msgService.GetVorgangByIdAsync(model).Result;
            List<IKategorie> Kategorien = new List<IKategorie>
            {
                vorgang.Instandsetzungen,
                vorgang.Ersatzteile,
                vorgang.Lackierung,
                vorgang.AnAbbau,
                vorgang.Hohlraum
            };
            List<PositionViewModel> positionViewModels = new List<PositionViewModel>();
            foreach (var Kat in Kategorien)
            {
                if (Kat != null)
                {
                    foreach (var pos in Kat.Position)
                    {
                        if (pos != null)
                        {
                            positionViewModels.Add(MapToPositionViewModel(pos, Kat.GetType().Name));
                        }
                    }
                }
            }
            return positionViewModels;
        }
        public List<RegelViewModel> GetRegeln(FilterRequest model)
        {
            var vorgang = _msgService.GetVorgangByIdAsync(model).Result;
            var regelViewModels = new List<RegelViewModel>();
            if (vorgang.Regeln != null)
            {
                var regeln = vorgang.Regeln.Regel;
                foreach (var regel in regeln)
                {
                    regelViewModels.Add(new RegelViewModel { Name = regel.Name, Text = regel.Text, RegelID = regel.RegelID });
                }
            }
            return regelViewModels;
        }
        public byte[] GetPdf(FilterRequest model)
        {
            var vorgang = _msgService.GetVorgangByIdAsync(model).Result;
            PdfViewModel pdfViewModel = new PdfViewModel();
            byte[] byteData;
            if (vorgang.Einzelpruefbericht != null)
            {
                pdfViewModel = new PdfViewModel { pdfBase64 = vorgang.Einzelpruefbericht.Base64 };
                byteData = Convert.FromBase64String(pdfViewModel.pdfBase64);
            }
            else
            {
                string fileName = "PDFnochNichtVorhanden.pdf";
                string path = Path.Combine(Environment.CurrentDirectory, @"resources\", fileName);
                byteData = File.ReadAllBytes(path);
            }
            return byteData;
        }
    }
}
