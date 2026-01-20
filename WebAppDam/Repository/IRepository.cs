namespace WebAppDam.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T Obj);
        void Edit(T Obj);
        void Delete(int id);
        int Save();
    }
}
