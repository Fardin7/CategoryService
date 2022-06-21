using CategoryService.Dtos;

namespace CategoryService.NewsClient
{
    public interface IClientUpdate
    {
        Task<string> Send(NewsCategoryCreate newsCategoryRead);
    }
}
