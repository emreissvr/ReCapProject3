using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public void Update(Color entity)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();


            }


        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapDBContext context = new ReCapDBContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

    }
}
