using ExpertCenterTask.Application.Dto.PriceList;
using ExpertCenterTask.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpertCenterTask.Mvc.Controllers
{
    public class PriceListController : Controller
    {
        private readonly IPriceListService<PriceListDto, PriceListDetailDto, CreatePriceListDto, UpdatePriceListDto> _priceListService;

        public PriceListController(IPriceListService<PriceListDto, PriceListDetailDto, CreatePriceListDto, UpdatePriceListDto> priceListService) =>
            (_priceListService) = (priceListService);

        public async Task<IActionResult> GetPriceLists(CancellationToken cancellationToken) => View(await _priceListService.GetAll(cancellationToken));

        public async Task<ActionResult> GetPriceList(int id, CancellationToken cancellationToken) => View(await _priceListService.GetById(id, cancellationToken));

        public async Task<ActionResult> CreatePriceList() => View();

        [HttpPost]
        public async Task<IActionResult> CreatePriceList(CreatePriceListDto priceListDto, CancellationToken cancellationToken)
            => View(await _priceListService.Create(priceListDto, cancellationToken));
    }
}
