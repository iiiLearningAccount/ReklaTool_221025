using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReklaTool.Models;
using ReklaTool.Services;

namespace ReklaTool.Controllers
{    
    [Authorize]
    public class VorgangController : Controller
    {
        private readonly IEndpointService _uiEndpointService;
        public VorgangController(IEndpointService uiEndpointService)
        {
            _uiEndpointService = uiEndpointService;
        }            
		public async Task<ActionResult> VorgangAuswahl_Read([DataSourceRequest] DataSourceRequest request, FilterRequest model)
        {
            try
            {
                var vorgangInfos = _uiEndpointService.GetVorgangInfos(model);
                var result = Json(await vorgangInfos.ToDataSourceResultAsync(request));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();                
            }
        }
        public async Task<ActionResult> Fahrzeugdaten_Read([DataSourceRequest] DataSourceRequest request, FilterRequest model)
        {
            try
            {
                var outputObject = _uiEndpointService.GetFahrzeugDaten(model);
                var result = Json(await outputObject.ToDataSourceResultAsync(request));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();
            }
        }
        public async Task<ActionResult> Kosten_Read([DataSourceRequest] DataSourceRequest request, FilterRequest model)
        {
            try
            {
                var outputObject = _uiEndpointService.GetKosten(model);
                var result = Json(await outputObject.ToDataSourceResultAsync(request));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();
            }
        }
        public async Task<ActionResult> Ausstattung_Read([DataSourceRequest] DataSourceRequest request, FilterRequest model)
        {
            try
            {
                var outputObject = _uiEndpointService.GetAusstattung(model);
                var result = Json(await outputObject.ToDataSourceResultAsync(request));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();
            }
        }
        public async Task<ActionResult> Positionen_Read([DataSourceRequest] DataSourceRequest request, FilterRequest model)
        {
            try
            {
                var outputObject = _uiEndpointService.GetPositionen(model);
                var result = Json(await outputObject.ToDataSourceResultAsync(request));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();
            }
        }
        public async Task<ActionResult> Regeln_Read([DataSourceRequest] DataSourceRequest request, FilterRequest model)
        {
            try
            {
                var outputObject = _uiEndpointService.GetRegeln(model);
                var result = Json(await outputObject.ToDataSourceResultAsync(request));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public FileResult Pdf_Read(FilterRequest model)
        {
            try
            {
                var byteData = _uiEndpointService.GetPdf(model);
                var output = File(byteData, "application/pdf");
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return ;
            }
        }

        public FileContentResult Xml_Read(string aktenzeichen_typ, string aktenzeichen, bool isSchnellsuche, int vorgangIndex)
        {
            try
            {
                FilterRequest model = new FilterRequest()
                {
                    Aktenzeichen_Typ = aktenzeichen_typ,
                    Aktenzeichen = aktenzeichen,
                    IsSchnellsuche = isSchnellsuche,
                    VorgangIndex = vorgangIndex
                };
                byte[] byteData = _uiEndpointService.GetXml(model);
                return File(byteData, "text/xml", "Kalkulation.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return BadRequest();
            }
        }      
    }
}
