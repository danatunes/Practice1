using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Car;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

			private List<Car> carList;

			public CarController()
			{

				carList = new List<Car>(){
	new Car(){Price = 10000 , CarCategory="LUXURY",CarName="S-CLASS"},
	new Car(){Price = 9000 , CarCategory="SPORTCAR",CarName="TESLA ROADSTER"},
	new Car(){Price = 20000 , CarCategory="SUPERCAR",CarName="MCLAREN 720S"},
	new Car(){Price = 1000 , CarCategory="TRUCK",CarName="COLORADO"},
	new Car(){Price = 10000 , CarCategory="LUXURY",CarName="ROLLS ROYCE"},
	new Car(){Price = 1000 , CarCategory="HATCHBACK",CarName="Ford Focus"},
	new Car(){Price = 100000 , CarCategory="LUXURY",CarName="MAYBACH"},
	new Car(){Price = 9000 , CarCategory="SPORTCAR",CarName="porsche 911"},
	new Car(){Price = 20000 , CarCategory="SUPERCAR",CarName="Hennessey Performance "},
	new Car(){Price = 1000 , CarCategory="TRUCK",CarName="FORD F-150"},
	new Car(){Price = 10000 , CarCategory="LUXURY",CarName="BMW Alpina XB7"},
	new Car(){Price = 4000 , CarCategory="HATCHBACK",CarName="Volkswagen Golf"},
	}
			}

			[HttpGet]
			public List<Car> getAllCars()
			{
				return carList;
			}

			[HttpGet("AscendingPrice")]
			public List<Car> AscendingPrice()
			{

				return var orderByAscendingPrice = from c in carList
												   orderby c.Price
												   select c;

			}

			[HttpGet("DescendingPrice")]
			public List<Car> DescendingPrice()
			{

				 var studentsInDescOrder = carList.OrderByDescending(s => s.Price);
			}

			[HttpGet("SearchCarByCategory/{name}")]
			public List<Car> SearchCarByCategory(string name)
			{

			return carList.Where(car => car.CarCategory.ToLower() == name.ToLower()).ToList();
		}

			[HttpGet("name/{name}")]
			public List<Car> getCarWithName(string name)
			{
				return carList.Where(car => car.CarName.ToLower() == name.ToLower()).ToList();
			}

			[HttpGet("WritePrice/{price}")]
			public List<Car> getCheapCars(int price)
			{
				return carList.Where(car => car.Price <= price).ToList();
			}

		}

	}
}
}
