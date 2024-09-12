using Drinks_Info.Data.DTOs.Categories;

namespace Drinks_Info.Data.Repositories.Interfaces;

public interface ICategoryRepository
{
    public Task<List<CategoryDTO>> All();
}
