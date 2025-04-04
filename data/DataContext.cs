using data.entities;
using Microsoft.EntityFrameworkCore;

namespace pfSOA.data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options){}
    
       public DbSet<Class_Photo> Photos { get; set; }
    
}
