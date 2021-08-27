using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            // constructor yaptık 
            _cars = new List<Car>
            {

                new Car { CarId = 1, BrandId = 101, ColorId = 201, DailyPrice = 100, Description = "düşük segment"  },
                new Car { CarId = 2, BrandId = 102, ColorId = 202, DailyPrice = 200, Description = "orta segment"},
                new Car { CarId = 3, BrandId = 103, ColorId = 203, DailyPrice = 500, Description = "yüksek segment"},
                new Car { CarId = 4, BrandId = 104, ColorId = 204, DailyPrice = 1000, Description = "spor segment"},
                new Car { CarId = 5, BrandId = 105, ColorId = 205, DailyPrice = 2000, Description = "ultra lüx segment"},

        };

       
    }



        public void Add(Car car)
        {
            _cars.Add(car);
            // burdaki Add ICarDal  dan referans alınıyor ve çalıştırılıyor

            // business tan buraya gönderilen car ı _cars veritabanına ekler

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);

        }
        public void Update(Car car)
        {
            // burdaki car parametresi bizim business katmanında vereceğimiz araba objesidir. bu objenin özellikleri farklı verilip veritabanında güncellenmes istenir. 
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }

        public List<Car> GetAll()
        {
            return _cars;

        }


        public List<Car> GetAllByIdCar(int carid)
        {
            return _cars.Where(c => c.CarId == carid).ToList();

        }

       
    }
}
