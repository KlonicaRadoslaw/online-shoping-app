﻿using Blazored.LocalStorage;
using online_shoping.Models.Dtos;
using online_shoping_app.web.Interfaces;

namespace online_shoping_app.web.Services
{
    public class ManageCartItemsLocalStorageService : IManageCartItemsLocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IShoppingCartService _shoppingCartService;

        const string key = "CartItemCollcetion";

        public ManageCartItemsLocalStorageService(ILocalStorageService localStorageService, IShoppingCartService shoppingCartService)
        {
            _localStorageService = localStorageService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<List<CartItemDto>> GetCollection()
        {
            return await _localStorageService.GetItemAsync<List<CartItemDto>>(key) ?? await AddCollection();
        }

        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(key);
        }

        public async Task SaveCollection(List<CartItemDto> cartItemDtos)
        {
            await _localStorageService.SetItemAsync(key, cartItemDtos);
        }

        private async Task<List<CartItemDto>> AddCollection()
        {
            var shoppingCartCollection = await _shoppingCartService.GetItems(HardCoded.UserId);

            if (shoppingCartCollection != null)
                await _localStorageService.SetItemAsync(key, shoppingCartCollection);

            return shoppingCartCollection;
        }
    }
}
