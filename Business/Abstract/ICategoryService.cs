using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult AddCategory(Category category);
        IResult UpdateCategory(Category category);
        IResult DeleteCategory(Category category);
        IDataResult<Category> GetCategoryById(int categoryId);
        IDataResult<List<Category>> GetAllCategories();
    }
}
