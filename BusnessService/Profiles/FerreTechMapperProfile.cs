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
        public FerreTechMapperProfile()
        {
            CreateMap<Account, AccountBe>().ReverseMap();
            CreateMap<Account, AccountCreationDto>().ReverseMap();
            CreateMap<Category, CategoryBe>().ReverseMap();
            CreateMap<Account, AccountWithoutRoleWithUsersBe>().ReverseMap();
            CreateMap<Account, AccountWithoutRoleBe>().ReverseMap();
            CreateMap<Account, AuthLogin>().ReverseMap();
            CreateMap<Brand, BrandBe>().ReverseMap();
            CreateMap<Brand, BrandToCreateBe>().ReverseMap();
            CreateMap<Category, CategoryBe>().ReverseMap();
            CreateMap<Category, CategoryToCreateBe>().ReverseMap();
            CreateMap<EntityBase, EntityBaseBe>().ReverseMap();
            CreateMap<HistoryPrice, HistoryPriceBe>().ReverseMap();
            CreateMap<Account, LoginResponse>().ReverseMap();
            CreateMap<Order, OrderBe>().ReverseMap();
            CreateMap<OrderItem, OrderItemBe>().ReverseMap();
            CreateMap<Product, ProductBe>().ReverseMap();
            CreateMap<Product, ProductToCreateBe>().ReverseMap();
            CreateMap<Role, RoleBe>().ReverseMap();
            CreateMap<Role, RoleWithoutUsersBe>().ReverseMap();
       
        }
    }
}
