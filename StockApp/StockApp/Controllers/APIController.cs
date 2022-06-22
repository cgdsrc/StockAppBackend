using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CahceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using StockApp.Model;

namespace StockApp.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly string URL = "https://styles.redditmedia.com/t5_3lo9l9/styles/communityIcon_p61qlexxb9581.png";
        private readonly string USER_KEY = "user";

        public APIController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }


        [HttpGet]
        public User GetUserDetail()
        {
            var user = _cacheService.GetCacheUser(USER_KEY);

            return user;
        }

        [HttpPost]
        [Route("GetStocks")]
        public Stock GetStocks()
        {
            Stock stock = new Stock()
            {
                Id = 1,
                StockName = "Apple Inc",
                Price = 135
            };

            return stock;
        }

        [HttpPost]
        [Route("ValidateOrder")]
        public bool ValidateOrder(ValidateOrderRequest validateOrderRequest)
        {
            if (validateOrderRequest.Balance > validateOrderRequest.Order)
                return true;
            return false;
        }

        [HttpPost]
        [Route("ExecuteOrder")]
        public bool ExecuteOrder(ExecuteOrderRequest executeOrderRequest)
        {

            bool isUpdated = _cacheService.UpdateCache(executeOrderRequest.OrderAmount, USER_KEY);
            if (isUpdated)
                return true;
            return false;
        }

    }
}
