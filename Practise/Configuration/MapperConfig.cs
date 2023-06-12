using AutoMapper;
using Practise.DAL.Models;
using Practise.DAL.ViewModels;
using Practise.DAL.ViewModelsModels;
using Practise.DAL.ViewModelsWithId;
using System.Diagnostics.Metrics;

namespace Practise.Configuration
{
        public class MapperConfig : Profile
        {
            public MapperConfig()
            {
                CreateMap<CategoryViewModel, Category>();
                CreateMap<OrderListViewModel, OrderList>();
                CreateMap<ProductViewModel, Product>();
                CreateMap<CategoryViewModel, Category>();
                CreateMap<OrderListViewModelWithId, OrderList>();
                CreateMap<ProductViewModelWithId, Product>();
            }

        }
    
}
