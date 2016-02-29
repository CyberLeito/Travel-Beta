using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Models;

namespace Travel_Beta
{
    public partial class _Default : Page
    {

        public IQueryable<Category> GetCategories()
        {
            var _db = new Travel_Beta.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        }
    }
}