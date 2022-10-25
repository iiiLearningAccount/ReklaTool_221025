using ReklaTool.Controllers;
using ReklaTool.Models;

namespace ReklaTool.Services
{
    public interface IRequestBuilder
    {
        RequestBuilder WithEinzelpruefbericht(bool includePruefbericht);
        RequestBuilder WithAnwendbar(bool isApplicable);
        RequestModel Build(FilterRequest requestModel);
    }
    public class RequestBuilder : IRequestBuilder
    {
        private RequestModel _request;
        public RequestBuilder()
        {
            _request = new RequestModel();
        }
        public RequestModel Build(FilterRequest requestModel)
        {
            switch (requestModel.Aktenzeichen_Typ)
            {
                case "Vorgangsnummer":
                    _request.Vorgangsnummer = requestModel.Aktenzeichen;
                    break;
                case "Auftragsnummer":
                    _request.Auftraggeber = requestModel.Aktenzeichen;
                    break;
                case "Schadennummer":
                    _request.Schadennummer = requestModel.Aktenzeichen;
                    break;
                case "Dateiname":
                    _request.Dateiname = requestModel.Aktenzeichen;
                    break;
                default:
                    _request.Vorgangsnummer = requestModel.Aktenzeichen;
                    break;
            }
            return _request;
        }
        public RequestBuilder WithAnwendbar(bool isApplicable)
        {
            _request.ClaimsGuard.Anwendbar = isApplicable;
            return this;
        }
        public RequestBuilder WithEinzelpruefbericht(bool includePruefbericht)
        {
            _request.ClaimsGuard.Einzelpruefbericht = includePruefbericht;
            return this;
        }
    }
}
