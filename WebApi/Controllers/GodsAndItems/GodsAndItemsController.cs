using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.ViewModel.God;
using WebApi.ViewModel.Item;

namespace WebApi.Controllers.GodsAndItems
{
    [ApiController]
    [Route("v1/GodsAndItems")]
    public class GodsAndItemsController : ControllerBase
    {
        [Route("GodList"), HttpPost]
        public ActionResult<GodListResponse> GodList(GodListRequest request)
        {
            GodListResponse response = new();
            try
            {
                if (request == null)
                    throw new Exception("Request não pode ser nulo.");

                response.Items = new Core.Business.God.GodBusiness(DateTime.UtcNow.ToString("yyyyMMddHHmmss")).GodList();
                response.Message = "Lista de deuses consultada com sucesso.";
                response.Success = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"ERROR -- Consulta da lista de deuses -- {MethodBase.GetCurrentMethod()?.Name} -- {ex.Message}";
                return BadRequest(response);
            }
        }

        [Route("ItemList"), HttpPost]
        public ActionResult<ItemListResponse> ItemList(ItemListRequest request)
        {
            ItemListResponse response = new();
            try
            {
                if (request == null)
                    throw new Exception("Request não pode ser nulo.");

                response.Items = new Core.Business.God.GodBusiness(DateTime.UtcNow.ToString("yyyyMMddHHmmss")).ItemList();
                response.Message = "Lista de items consultada com sucesso.";
                response.Success = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"ERROR -- Consulta da lista de items -- {MethodBase.GetCurrentMethod()?.Name} -- {ex.Message}";
                return BadRequest(response);
            }
        }

        [Route("ItemRecomendedList"), HttpPost]
        public ActionResult<ItemRecomendedListResponse> ItemRecomendedList(ItemRecomendedListRequest request)
        {
            ItemRecomendedListResponse response = new();
            try
            {
                if (request == null)
                    throw new Exception("Request não pode ser nulo.");

                response.Items = new Core.Business.God.GodBusiness(DateTime.UtcNow.ToString("yyyyMMddHHmmss")).ItemRecomendedList(request.GodID);
                response.Message = "Lista de items consultada com sucesso.";
                response.Success = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Message = $"ERROR -- Consulta da lista de items -- {MethodBase.GetCurrentMethod()?.Name} -- {ex.Message}";
                return BadRequest(response);
            }
        }
    }
}
