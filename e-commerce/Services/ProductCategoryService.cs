using e_commerce.Base;
using e_commerce.Data;
using e_commerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace e_commerce.Services
{
    public class ProductCategoryService : BaseService<ProductCategory>
    {
        public ProductCategoryService(ApplicationDbContext context, dbconnection dbconn) : base(context, dbconn)
        {
        }

        public DataTable GetTableCategory(int? id = null)
        {
            var cnn = this.GetConnection();
            var cmd = cnn.CreateCommand();
            cmd.CommandText = 
                @"select * 
from ProductCategories";
            if (id != null)
            {
                cmd.CommandText +=
                    @"
where id = @p_id";
                cmd.Parameters.AddWithValue("p_id", id);
            }
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public async Task<string> UpdateTableCategory(ProductCategory category)
        {
            var cnn = this.GetConnection();
            var cmd = cnn.CreateCommand();
            cmd.CommandText =
                @"update ProductCategories set
name = @p_name,
description = @p_description,
UpdatedAt = get date()
where id = @p_id
";
            cmd.Parameters.AddWithValue("p_id", category.Id);
            cmd.Parameters.AddWithValue("p_name", category.Name);
            cmd.Parameters.AddWithValue("p_description", category.Description);
            await cmd.ExecuteNonQueryAsync();

            return "OK";
        }
        public string UpdateTableCategory(DataTable updated)
        {
            var cnn = this.GetConnection();
            for (int ii = 0; ii < updated.Rows.Count; ii++)
            {
                var cmd = cnn.CreateCommand();
                cmd.CommandText =
                    @"update ProductCategories set
    name = @p_name,
    description = @p_description,
    UpdatedAt = getdate()
where id = @p_id
";
                cmd.Parameters.AddWithValue("p_id", updated.Rows[ii]["id"]);
                cmd.Parameters.AddWithValue("p_name", updated.Rows[ii]["name"]);
                cmd.Parameters.AddWithValue("p_description", updated.Rows[ii]["description"]);
                cmd.ExecuteNonQuery();
            }
            return "OK";
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category != null)
            {
                _context.ProductCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ProductCategory> GetByIdAsync(int id)
        {
            return await _context.ProductCategories
                .Select(pc => new ProductCategory
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    Description = pc.Description,
                    CreatedAt = pc.CreatedAt,
                    UpdatedAt = pc.UpdatedAt
                })
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }
        public async Task<IEnumerable<ProductCategory>> GetAllAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }
    }
}
