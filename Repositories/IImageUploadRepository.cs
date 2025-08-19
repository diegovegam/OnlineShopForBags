namespace OnlineShopForBags.Repositories
{
    public interface IImageUploadRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
