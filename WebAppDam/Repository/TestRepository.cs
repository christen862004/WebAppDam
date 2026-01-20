namespace WebAppDam.Repository
{
    public class TestRepository : ITestRepository
    {
        public string Id { get; set; }
        public TestRepository()
        {
            Id = Guid.NewGuid().ToString();//unqiue
        }
    }
}
