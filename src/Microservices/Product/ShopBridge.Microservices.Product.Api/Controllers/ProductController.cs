using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Microservices.Product.Api.Infrastructure.Handlers.Interfaces;
using ShopBridge.Microservices.Product.Api.Models.Response;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductHandler _productHandler;

        public ProductController(IProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: ((int)HttpStatusCode.OK), type: typeof(ResponseWrapper<int>))]
        public async Task<BaseResponse> Post(CreateProductItem productItem)
        {
            Guard.Against.Null(productItem, nameof(CreateProductItem), "Request cannot be empty");
            Guard.Against.NegativeOrZero(productItem.ProductCategoryId, nameof(Int32), "Invalid product category Id <= 0");
            Guard.Against.NegativeOrZero(productItem.ProductBrandId, nameof(Int32), "Invalid product brand Id <= 0");
            return await _productHandler.AddProductAsync(productItem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: ((int)HttpStatusCode.OK), type: typeof(ResponseWrapper<bool>))]
        public async Task<BaseResponse> Delete(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(Int32), "Invalid productId <= 0"); ;
            return await _productHandler.DeleteProductAsync(id);
        }

        [HttpPut]
        [ProducesResponseType(statusCode: ((int)HttpStatusCode.OK), type: typeof(ResponseWrapper<bool>))]
        public async Task<BaseResponse> Update(UpdateProductItem productItem)
        {
            Guard.Against.Null(productItem, nameof(UpdateProductItem), "Request cannot be empty");
            Guard.Against.NegativeOrZero(productItem.ProductId, nameof(Int32), "Invalid productId <= 0");
            Guard.Against.NegativeOrZero(productItem.ProductCategoryId, nameof(Int32), "Invalid product category Id <= 0");
            Guard.Against.NegativeOrZero(productItem.ProductBrandId, nameof(Int32), "Invalid product brand Id <= 0");
            return await _productHandler.UpdateProductAsync(productItem);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: ((int)HttpStatusCode.OK), type: typeof(ResponseWrapper<ProductItem>))]
        public async Task<ActionResult<ProductItem>> Get(int id)
        {
            Guard.Against.NegativeOrZero(id, nameof(Int32), "Invalid productId <= 0");
            var productItem = await _productHandler.GetProductAsync(id);

            if(productItem is null)
            {
                return NotFound();
            }
            return productItem;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: ((int)HttpStatusCode.OK), type: typeof(ResponseWrapper<List<ProductItem>>))]
        public async Task<List<ProductItem>> Get()
        {
            return await _productHandler.GetAllProductAsync();
        }
    }
}
