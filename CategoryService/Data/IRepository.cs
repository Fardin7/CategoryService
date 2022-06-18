using CategoryService.Dtos;

namespace CategoryService.Data
{
    public interface IRepository
    {
        Task<NewsCategoryRead> Add(NewsCategoryCreate newsCategoryCreate);
        Task<NewsCategoryRead> GetById(int id);
        Task<IEnumerable<NewsCategoryRead>> Get();
    }
}
