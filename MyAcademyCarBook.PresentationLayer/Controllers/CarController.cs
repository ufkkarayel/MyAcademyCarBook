﻿using Microsoft.AspNetCore.Mvc;
using MyAcademyCarBook.BusinessLayer.Abstract;

namespace MyAcademyCarBook.PresentationLayer.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarDetailService _carDetailService;
        public CarController(ICarService carService, ICarDetailService carDetailService)
        {
            _carService = carService;
            _carDetailService = carDetailService;
        }

        public IActionResult Index()
        {
            var values =_carService.TGetListAll();
            return View(values);
        }
        public IActionResult Index2() 
        {
            var values=_carService.TGetAllCarsWithBrands();
            return View(values);
        }
        public IActionResult CarList() 
        {
            ViewBag.title1 = "Araç Listesi";
            ViewBag.title2 = "Sizin için Araç Listemiz";
            var values = _carService.TGetAllCarsWithBrands();
            return View(values);
        }
        public IActionResult CarDetail(int id)
        {
            ViewBag.title1 = "Araç Detayları";
            ViewBag.title2 = "Son Araç Detayları";
            ViewBag.i = id;
            var value = _carDetailService.IGetCarDetailByCarID(id);
            ViewBag.v = value.Description;
            return View();
        }
    }
}
