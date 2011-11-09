using System.Linq;
using TA.DAL;

namespace TA.BLL
{
    public class PackageBLL
    {
        IPackage _package = null;
        public PackageBLL()
        {
            _package = DataAccessFactory.Instance.Package;
        }

        public IQueryable<Package> FindAllPackages()
        {
            return _package.FindAllPackages();
        }

        public Package GetPackage(int packageId)
        {
            return _package.GetPackage(packageId);
        }

        public void AddPackage(Package package)
        {
            _package.AddPackage(package);
        }

        public void UpdatePackage(Package package)
        {
            _package.UpatePackage(package);
        }

        public void DeletePackage(Package package)
        {
            _package.DeletePackage(package);
        }
    }
}
