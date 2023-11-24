using BookVilla.Application.Common.Interfaces;
using BookVilla.Domain.Entities;
using BookVilla.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookVilla.Infrastructure.Repository
{
    public class VillaRepository :Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Villa entity)
        {
            _db.Villas.Update(entity);
        }
    }
}