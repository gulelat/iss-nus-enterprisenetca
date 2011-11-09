using System;

namespace TA.DAL
{
    public abstract class ObjectDAO : IDisposable
    {
        protected TourAgencyModelContainer TAEntities = null;
        protected ObjectDAO()
        {
            TAEntities = SessionFactory.buildIfNeeded();
        }

        protected void Save()
        {
            TAEntities.SaveChanges();
        }

        public void Dispose()
        {
            SessionFactory.CloseFactory();
        }
    }
}
