using AutoMapper;
using KhaoSatBenhVien.Models;
using KhaoSatBenhVien.ViewModels;

namespace KhaoSatBenhVien.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CanBoBenhVien, CanBoBenhVienViewModel>();

            CreateMap<ChiTietPhieuDanhGia, ChiTietPhieuDanhGiaViewModel>();

            CreateMap<PhieuDanhGia, PhieuDanhGiasViewModel>();
        }
    }
}
