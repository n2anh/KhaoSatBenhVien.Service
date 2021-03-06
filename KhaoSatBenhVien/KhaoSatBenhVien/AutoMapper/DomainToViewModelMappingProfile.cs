﻿using AutoMapper;
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

            CreateMap<BoPhan, BoPhanViewModel>();
            CreateMap<BenhNhan, BenhNhanViewModel>();

            CreateMap<MauKhaoSat, MauKhaoSatViewModel>();

            CreateMap<CauHoiKhaoSat, CauHoiKhaoSatViewModel>();

            CreateMap<MucDoHaiLong, MucDoHaiLongViewModel>();
        }
    }
}
