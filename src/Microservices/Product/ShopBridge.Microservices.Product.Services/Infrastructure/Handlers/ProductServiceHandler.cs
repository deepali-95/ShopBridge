using ShopBridge.Microservices.Product.DataInterfaces;
using ShopBridge.Microservices.Product.Models;
using ShopBridge.Microservices.Product.Models.Requests;
using ShopBridge.Microservices.Product.Services.Infrastructure.Builders.Interfaces;
using ShopBridge.Microservices.Product.Services.Infrastructure.Handlers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Microservices.Product.Services.Infrastructure.Handlers
{
    public class ProductServiceHandler : IProductServiceHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductBuilder _productBuilder;
        private readonly ApplicationUser _applicationUser;

        public ProductServiceHandler(IProductRepository productRepository, IProductBuilder productBuilder, ApplicationUser applicationUser)
        {
            _productRepository = productRepository;
            _productBuilder = productBuilder;
            _applicationUser = applicationUser;
        }

        public async Task<BaseResponse> HandleAddProductAsync(CreateProductItem productItem)
        {
            BaseResponse baseResponse = new BaseResponse();
            var productDto = _productBuilder.Build(productItem);
            productDto.CreatedAt = DateTime.UtcNow;
            productDto.ModifiedAt = DateTime.UtcNow;
            productDto.CreatedBy = _applicationUser.UserGuid.ToString();
            productDto.ModifiedBy = _applicationUser.UserGuid.ToString();

            await _productRepository.AddAsync(productDto);

            if(productDto.ProductId > 0)
            {
                baseResponse.status = 0;
                baseResponse.message = "Product is successfully added.";
            }
            else
            {
                baseResponse.status = 1;
                baseResponse.message = "Issue in adding product. Please check the values supplied or in server logs";
            }
            return baseResponse;
        }

        public async Task<BaseResponse> HandleDeleteProductAsync(int productId)
        {
            BaseResponse baseResponse = new BaseResponse();
            var productDto = await _productRepository.GetAsync(productId);
            if (productDto is null)
            {
                baseResponse.status = 1;
                baseResponse.message = "Please provice correct ProductId";
                return baseResponse;
            }
            if (await _productRepository.DeleteAsync(productDto))
            {
                baseResponse.status = 0;
                baseResponse.message = "Product is successful deleted.";
            }
            return baseResponse;
        }

        public async Task<List<ProductItem>> HandleGetAllProductAsync()
        {
            var productDtos = await _productRepository.GetAllAsync();
            List<ProductItem> productItems = productDtos.Select((ld) => _productBuilder.Build(ld)).ToList();

            return productItems;
        }

        public async Task<ProductItem> HandleGetProductAsync(int productId)
        {
            var productDto = await _productRepository.GetAsync(productId);
            
            ProductItem productItem = _productBuilder.Build(productDto);

            return productItem;
        }

        public async Task<BaseResponse> HandleUpdateProductAsync(UpdateProductItem productItem)
        {
            BaseResponse baseResponse = new BaseResponse();
            var productDto = _productBuilder.Build(productItem);
            productDto.CreatedAt = DateTime.UtcNow;
            productDto.ModifiedAt = DateTime.UtcNow;
            productDto.CreatedBy = _applicationUser.UserGuid.ToString();
            productDto.ModifiedBy = _applicationUser.UserGuid.ToString();
            if (productDto is null)
            {
                baseResponse.status = 1;
                baseResponse.message = "Please provice correct ProductId";
                return baseResponse;
            }
            if (await _productRepository.UpdateAsync(productDto))
            {
                baseResponse.status = 0;
                baseResponse.message = "Product is successful updated.";
            }
            return baseResponse;
        }
    }
}
