



namespace QuanLySinhVien.Data.Infrastructure
{
    public class DbFactory:Disposable,IDbFactory
    {
        private QuanLySinhVienDbContext dbContext;

        public QuanLySinhVienDbContext Init()
        {
            return dbContext ?? (dbContext = new QuanLySinhVienDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
