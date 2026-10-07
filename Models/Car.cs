using System.ComponentModel.DataAnnotations;

namespace wt_lab4_4mvc_kleshchenok.Models;

public class Car
{
    [Display(Name = "Идентификатор")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Укажите марку")]
    [Display(Name = "Марка")]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Укажите модель")]
    [Display(Name = "Модель")]
    public string Model { get; set; } = string.Empty;

    [Range(1950, 2100, ErrorMessage = "Год должен быть в диапазоне 1950-2100")]
    [Display(Name = "Год выпуска")]
    public int Year { get; set; }

    [Range(0.01, 1000000, ErrorMessage = "Цена должна быть положительной")]
    [Display(Name = "Цена за сутки")]
    public decimal PricePerDay { get; set; }

    [Display(Name = "Доступен")]
    public bool IsAvailable { get; set; }
}