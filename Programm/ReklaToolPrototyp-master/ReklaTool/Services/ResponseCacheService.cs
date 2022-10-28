using ReklaTool.Models;
using System.Text.Json;

namespace ReklaTool.Services
{
    public interface ICacheService
    {
        void SetElement(CacheElement element);
        bool ElementExists(RequestModel anfrage);
        Vorgaenge? GetElement(RequestModel anfrage);
    }
    public class ResponseCacheService : ICacheService
    {
        private string cacheLocation = Directory.GetCurrentDirectory() + "\\cache\\";
        public void SetElement(CacheElement element)
        {
            string contentHash = element.Anfrage.GetHashCode().ToString();
            File.WriteAllText(Path.Combine(cacheLocation, contentHash + ".json"), JsonSerializer.Serialize(element));
            File.WriteAllText(Path.Combine(cacheLocation, "testing.txt"), "Hello Test!!!");
        }

        public bool ElementExists(RequestModel anfrage)
        {
            string contentHash = anfrage.GetHashCode().ToString();
            return File.Exists(Path.Combine(cacheLocation, contentHash + ".json")); ;
        }
        public Vorgaenge? GetElement(RequestModel anfrage)
        {
            string filename = anfrage.GetHashCode().ToString();
            string fileContent = File.ReadAllText(cacheLocation + filename + ".json");
            CacheElement result = JsonSerializer.Deserialize<CacheElement>(fileContent);
            return result.Vorgang;
        }
    }
    public class CacheElement
    {
        public RequestModel? Anfrage { get; set; }
        public Vorgaenge? Vorgang { get; set; }
    }
}
