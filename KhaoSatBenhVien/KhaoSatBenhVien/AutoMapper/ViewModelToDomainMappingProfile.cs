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
            CreateMap<PhieuDanhGiasViewModel, PhieuDanhGia>();
            CreateMap<ChiTietPhieuDanhGiaViewModel, ChiTietPhieuDanhGia>();
            CreateMap<BoPhanViewModel, BoPhan>();
            CreateMap<BenhNhanViewModel, BenhNhan>();

            CreateMap<MauKhaoSatViewModel, MauKhaoSat>();

            CreateMap<CauHoiKhaoSatViewModel, CauHoiKhaoSat>();

        }
    }
}
