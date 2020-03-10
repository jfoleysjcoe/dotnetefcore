using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;
using Stripe;
using Stripe.Checkout;

namespace MyStore.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InventoryController : ControllerBase
	{
		readonly InventoryFixedDataService _fixedService;
		readonly InventoryLiteDbService _liteDbservice;
		readonly DataService _dataService;

		public InventoryController(
			InventoryFixedDataService fixedService,
			InventoryLiteDbService liteDbService,
			DataService dataService
		)
		{
			_fixedService = fixedService;
			_liteDbservice = liteDbService;
			_dataService = dataService;
		}

		[HttpGet("populate")]
		public int PopulateData()
		{
			var fixedData = _fixedService.fixedData;
			return _liteDbservice.PopulateData(fixedData);
		}

		[HttpGet]
		public IEnumerable<InventoryItem> GetInventoryItems()
		{
			// return _fixedService.fixedData;
			// return _liteDbservice.getInventoryItems();
			return _dataService.GetInventoryList();
		}

		[HttpGet("{id}")]
		public InventoryItem GetInventoryItem(int id)
		{
			// return _fixedService.fixedData.AsEnumerable().First(x => x.Id == id);
			// return _liteDbservice.GetInventoryItemById(id);
			return _dataService.GetInventoryItemById(id);
		}

		[HttpPost]
		public int AddInventoryItem(InventoryItem item)
		{
			// return _fixedService.Insert(item);
			// return _liteDbservice.Insert(item);
			return _dataService.InsertInventoryItem(item);
		}

		[HttpDelete("{id}")]
		public bool DeleteInventoryItem(int id)
		{
			//return _fixedService.Delete(id);
			return _liteDbservice.Delete(id);
		}

		[HttpPost("update")]
		public InventoryItem Update(InventoryItem item)
		{
			//return _fixedService.Update(item);
			// return _liteDbservice.Update(item);
			return _dataService.UpdateInventoryItem(item);
		}

		[HttpGet("findBelowPrice/{price}")]
		public IEnumerable<InventoryItem> FindBelowPrice(double price)
		{
			// return _fixedService.GetItemsLessThan(price);
			return _liteDbservice.GetItemsLessThan(price);
		}

		[HttpPost("update/name")]
		public bool UpdateName(ChangeNameRequest request)
		{
			return _liteDbservice.UpdateName(request);
		}

		[HttpGet("ItemsInLocation/{location}")]
		public IEnumerable<ChangeNameRequest> GetNameAndIdInLocation(string location)
		{
			return _liteDbservice.GetNameAndIdsInStorageLocation(location);
		}

		[HttpGet("order")]
		public IEnumerable<PurchaseOrder> GetPurchaseOrders()
		{
			return _dataService.GetPurchaseOrdersList();
		}

		[HttpPost("payment")]
		public Session InitiatePaymentWithStripe(PurchaseOrderRequest request)
		{
			var item = _dataService.GetInventoryItemById(request.InventoryItemId);
			// Set your secret key. Remember to switch to your live secret key in production!
		  // See your keys here: https://dashboard.stripe.com/account/apikeys
			StripeConfiguration.ApiKey = "sk_test_FHvCm2i7lm7nOskYNm3nI0Ba";

			var options = new SessionCreateOptions {
					PaymentMethodTypes = new List<string> {
							"card",
					},
					LineItems = new List<SessionLineItemOptions> {
							new SessionLineItemOptions {
									Name = $"{item.Name}",
									Description = $"{item.Description}",
									Amount = (long)item.Price*100,
									Currency = "usd",
									Quantity = request.Quantity,
							},
					},
					SuccessUrl = "http:localhost:4200/success?session_id={CHECKOUT_SESSION_ID}",
					CancelUrl = "http:localhost:4200/cancel",
			};

			var service = new SessionService();
			Session session = service.Create(options);

			return session;
		}
	}
}
