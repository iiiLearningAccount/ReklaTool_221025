using ReklaTool.Controllers;
using ReklaTool.Models;
using System.Xml.Serialization;

namespace ReklaTool.Services
{
    public interface IMsgService
    {
        Task<Vorgaenge?> GetVorgaengeAsync(FilterRequest model);
        Task<Vorgang> GetVorgangByIdAsync(FilterRequest model);
    }
    public class HttpMsgService : IMsgService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ICacheService _cache;
        private readonly IRequestBuilder _requestBuilder;
        public HttpMsgService(IConfiguration config, IHttpClientFactory clientFactory, ICacheService cache, IRequestBuilder requestBuilder)
        {
            _configuration = config;
            _clientFactory = clientFactory;
            _cache = cache;
            _requestBuilder = requestBuilder;
        }
        public async Task<Vorgaenge?> GetVorgaengeAsync(FilterRequest model)
        {
            RequestModel anfrage = _requestBuilder
                .WithAnwendbar(!model.IsSchnellsuche)
                .WithEinzelpruefbericht(!model.IsSchnellsuche)
                .Build(model);
            if (_cache.ElementExists(anfrage))
            {
                return _cache.GetElement(anfrage);
            }
            else
            {
                HttpClient client = _clientFactory.CreateClient();

                var x4Path = _configuration.GetValue<string>("ReklaConfig:X4Webaddress");
                var requestMsg = new HttpRequestMessage(HttpMethod.Post, x4Path)
                {
                    Content = new StringContent(anfrage.ToXML())
                };

                //async send request to X4-server
                HttpResponseMessage response = await client.SendAsync(requestMsg);

                //string from response
                var content = await response.Content.ReadAsStringAsync();

                //Deserialize Object from String 
                var serializer = new XmlSerializer(typeof(Vorgaenge));
                using TextReader reader = new StringReader(content);
                Vorgaenge? vorgaenge = (Vorgaenge)serializer.Deserialize(reader);

                //Write Object to Cachefile
                _cache.SetElement(new CacheElement { Anfrage = anfrage, Vorgang = vorgaenge });

                return vorgaenge;
            }
        }
        public async Task<Vorgang> GetVorgangByIdAsync(FilterRequest model)
        {
            var vorgaengeAsync = await GetVorgaengeAsync(model);
            var result = vorgaengeAsync.Vorgang[model.VorgangIndex];
            return result;
        }        
    }
}
