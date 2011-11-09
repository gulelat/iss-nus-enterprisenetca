using System.Linq;

namespace TA.DAL
{
    public interface IPackage
    {
        IQueryable<Package> FindAllPackages();
        Package GetPackage(int packageId);
        void AddPackage(Package package);
        void UpatePackage(Package package);
        void DeletePackage(Package package);
    }

    public class PackageDAL : ObjectDAO, IPackage
    {
        public IQueryable<Package> FindAllPackages()
        {
            return TAEntities.Packages;
        }

        public Package GetPackage(int packageId)
        {
            return TAEntities.Packages.SingleOrDefault(m => m.Code == packageId);
        }

        public void AddPackage(Package package)
        {
            TAEntities.Packages.AddObject(package);
            Save();
        }

        public void UpatePackage(Package package)
        {
            TAEntities.Packages.ApplyCurrentValues(package);
            Save();
        }

        public void DeletePackage(Package package)
        {
            TAEntities.Packages.DeleteObject(package);
            Save();
        }
    }
}
