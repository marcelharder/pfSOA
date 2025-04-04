using data.entities;

namespace interfaces;

    public interface IPhoto
    {
        Task<bool> PhotosAvailable(int id);
        Task<List<Class_Photo>> GetPhotos(int id);
        Task<int> AddPhoto(Class_Photo p);
        Task<int> DeletePhoto(int id);
        Task<bool> SaveAll();
       
    }
    