using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {

       ICarDal _carDal;

        public CarManager(ICarDal ıcarDal)
        {
            _carDal = ıcarDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
        }

       

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }


        // business ın bildiği tek şey ICarDal'dır.

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(b => b.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);

        }

        
    }
}
