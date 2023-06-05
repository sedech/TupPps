using AutoMapper;
using BussnessEntities;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnessService.Profiles
{
    public class FerreTechMapperProfile : Profile
    {
        protected FerreTechMapperProfile()
        {
            CreateMap<Account, AccountBe>().ReverseMap();
            CreateMap<Category, CategoryBe>().ReverseMap();
            CreateMap<Customer, CustomerBe>().ReverseMap();
            CreateMap<HistoryPrice, HistoryPriceBe>().ReverseMap();
            CreateMap<Order, OrderBe>().ReverseMap();
            CreateMap<OrderItem, OrderItemBe>().ReverseMap();
            CreateMap<Product, ProductBe>().ReverseMap();
            CreateMap<Provider, ProviderBe>().ReverseMap();
            CreateMap<Role, RoleBe>().ReverseMap();
         
        }
    }
}
