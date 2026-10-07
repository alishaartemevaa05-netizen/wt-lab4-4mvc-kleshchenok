using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_kleshchenok.Models;

namespace wt_lab4_4mvc_kleshchenok.Controllers;

public class CarController : Controller
{
    
    private static readonly List<Car> _cars = new()
    {
        new Car { Id = 1, Brand = "Toyota", Model = "Camry",
                  Year = 2022, PricePerDay = 200, IsAvailable = true },
        new Car { Id = 2, Brand = "BMW", Model = "X5",
                  Year = 2023, PricePerDay = 500, IsAvailable = true },
        new Car { Id = 3, Brand = "Kia", Model = "Rio",
                  Year = 2020, PricePerDay = 400, IsAvailable = false },
        new Car { Id = 4, Brand = "Tesla", Model = "Model 3",
                  Year = 2023, PricePerDay = 300, IsAvailable = true },
        new Car { Id = 5, Brand = "Nissan", Model = "Leaf",
                  Year = 2022, PricePerDay = 570, IsAvailable = true }
    };

    private static int _nextId = 6;

    // GET: /Car
    public IActionResult Index()
    {
        return View(_cars);
    }

    // GET: /Car/Details/2
    public IActionResult Details(int id)
    {
        var car = _cars.FirstOrDefault(c => c.Id == id);
        if (car == null) return NotFound();
        return View(car);
    }

    // GET: /Car/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Car/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Car car)
    {
        if (!ModelState.IsValid)
        {
            return View(car);   
        }

        car.Id = _nextId++;
        _cars.Add(car);
        return RedirectToAction(nameof(Index));
    }

    // GET: /Car/Edit/2
    public IActionResult Edit(int id)
    {
        var car = _cars.FirstOrDefault(c => c.Id == id);
        if (car == null) return NotFound();
        return View(car);
    }

    // POST: /Car/Edit/2
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Car car)
    {
        if (!ModelState.IsValid)
        {
            return View(car);
        }

        var existing = _cars.FirstOrDefault(c => c.Id == car.Id);
        if (existing == null) return NotFound();

        existing.Brand = car.Brand;
        existing.Model = car.Model;
        existing.Year = car.Year;
        existing.PricePerDay = car.PricePerDay;
        existing.IsAvailable = car.IsAvailable;

        return RedirectToAction(nameof(Index));
    }

    // POST: /Car/Delete/2
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var car = _cars.FirstOrDefault(c => c.Id == id);
        if (car != null) _cars.Remove(car);
        return RedirectToAction(nameof(Index));
    }
}