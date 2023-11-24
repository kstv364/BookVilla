using BookVilla.Application.Common.Interfaces;
using BookVilla.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookVilla.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IVillaRepository Villa { get; private set; }

        public IVillaNumberRepository VillaNumber { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Villa = new VillaRepository(_db);
            VillaNumber = new VillaNumberRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
