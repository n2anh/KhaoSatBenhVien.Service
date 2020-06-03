using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;

namespace KhaoSatBenhVien.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<CanBoBenhVienViewModel, CanBoBenhVien>();
         
        }
    }
}
