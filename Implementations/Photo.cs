using data.entities;
using interfaces;
using Microsoft.EntityFrameworkCore;
using pfSOA.data;

namespace Implementations;

public class Photo : IPhoto
{
    private readonly DataContext _context;

    public Photo(DataContext context)
    {
        _context = context;
    }

    public async Task<int> AddPhoto(Class_Photo p)
    {
        _context.Add(p);
        int help;
        if (await SaveAll())
        {
            help = 1;
        }
        else
        {
            help = 2;
        }
        return help;
    }

    public async Task<int> DeletePhoto(int id)
    {
         var p = await _context.Photos.FirstOrDefaultAsync(u => u.Id == id);
        if (p != null)
        {
            _context.Remove(p);
            if (await SaveAll())
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        return 0;
    }
       

    public async Task<List<Class_Photo>> GetPhotos(int id)
    {
        var list = new List<Class_Photo>();
        var help = _context.Photos.AsQueryable();

        help = help.Where(u => u.ProcedureId == id);
        list = help.ToList();

        return list;
    }

    public async Task<bool> PhotosAvailable(int id)
    {
        var ret = false;
        await Task.Run(() =>
        {
            var help = _context
                .Photos.OrderByDescending(u => u.ProcedureId == id)
                .Where(u => u.ProcedureId == id)
                .AsQueryable()
                .ToList();

            if (help.Count > 0)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
        });

        return ret;
    }

    public async Task<bool> SaveAll()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
