
using Core_EFApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_EFApi.Services
{
    public class DepartmentService : IService<Department, int>
    {
        CompanyContext ctx;

        public DepartmentService(CompanyContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Department> IService<Department, int>.CreateAsync(Department entity)
        {
            var result = await ctx.Departments.AddAsync(entity);
            
            await ctx.SaveChangesAsync();
            return result.Entity;
        }

        async Task IService<Department, int>.DeleteAsync(int id)
        {
             var record = await ctx.Departments.FindAsync(id);
             if(record == null)
                return;
             ctx.Departments.Remove(record);
             await ctx.SaveChangesAsync();
        }

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
        {
            return await ctx.Departments.ToListAsync();
        }

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            return await ctx.Departments.FindAsync(id); 
        }

        async Task<Department> IService<Department, int>.UpdateAsync(int id, Department entity)
        {
            var record = await ctx.Departments.FindAsync(id);
            if (record == null)
                return null;
            record.DeptName = entity.DeptName;
            record.Capacity = entity.Capacity;
            record.Location = entity.Location;
            await ctx.SaveChangesAsync();
            return record;
        }
    }
}
