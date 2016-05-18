using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Models;
using System.Web.ModelBinding;



namespace Travel_Beta
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new Travel_Beta.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }
        public IQueryable<Category> GetCategories()
        {
            var _db = new Travel_Beta.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        }
    }
}