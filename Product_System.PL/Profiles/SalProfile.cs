namespace Product_System.PL.Profiles;

public class SalProfile : Profile
{
    public SalProfile()
    {
        #region Product

        CreateMap<SalProduct, SalGetAllProductsVM>()
                .ReverseMap();

        CreateMap<SalProduct, SalCreateProductVM>()
                .ReverseMap();

        CreateMap<SalUpdateProductVM, SalProduct>()
                .ReverseMap();

        CreateMap<SalProduct, SalGetProductByIdVM>()
            //.ForMember(dest => dest.Image, src => src.MapFrom(src => string.Concat(ReadRootPath.SharedImagesPath, src.ImageName)))
                .ReverseMap();

        #endregion
    }
}
