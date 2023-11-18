namespace Product_System.Services.Services.Sales;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper, IStaticDataRepository staticDataRepository) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IStaticDataRepository _staticDataRepository = staticDataRepository;

    public async Task<IEnumerable<SelectListItem>> ListOfProductsCategoriesAsync() =>
        await GetAllProductsCategories();

    public async Task<IEnumerable<SalGetAllProductsVM>> GetAllProductsAsync(int productCategoryId)
    {
        var list = await _unitOfWork.Products.GetAllAsync(x => x.ProductCategoryId == productCategoryId);
        var mapped = _mapper.Map<IEnumerable<SalGetAllProductsVM>>(list);
        return mapped;
    }

    public async Task CreateProductAsync(SalCreateProductVM model)
    {
        var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, GoRootPath.ProductImagesPath);
        string imageName = fileObj.FileName;
        string imageExtension = fileObj.FileExtension;

        var mapped = _mapper.Map<SalProduct>(model);

        mapped.ImageName = imageName;
        mapped.ImageExtension = imageExtension;

        await _unitOfWork.Products.AddAsync(mapped);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<SalGetProductByIdVM> GetProductByIdAsync(int id)
    {
        var obj = await _unitOfWork.Products.GetFirstOrDefaultAsync(x => x.Id == id, includeProperties: "ProductCategory");
        if (obj is null)
            return null!;

        var mapped = _mapper.Map<SalGetProductByIdVM>(obj);
        mapped.ProductsCategories = await GetAllProductsCategories();

        return mapped;
    }

    public async Task<SalUpdateProductVM> UpdateProductAsync(int id, SalUpdateProductVM model)
    {
        if (id != model.Id)
            return null!;

        var obj = await _unitOfWork.Products.GetByIdAsync(id);
        var mapped = _mapper.Map<SalUpdateProductVM, SalProduct>(model, obj);

        string path = GoRootPath.ProductImagesPath;

        ManageFilesHelper.RemoveFile(path + "/" + obj.ImageName);
        var fileObj = ManageFilesHelper.UploadFile(model.ImagePath, path);
        mapped.ImageName = fileObj.FileName;
        mapped.ImageExtension = fileObj.FileExtension;

        _unitOfWork.Products.Update(mapped);
        await _unitOfWork.CompleteAsync();
        return model;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        _unitOfWork.Products.Remove(await _unitOfWork.Products.GetByIdAsync(id));

        return await _unitOfWork.CompleteAsync() > 0;
    }

    private async Task<IEnumerable<SelectListItem>> GetAllProductsCategories() =>
        await Task.Run(_staticDataRepository.GetAllProductsCategories);

}
