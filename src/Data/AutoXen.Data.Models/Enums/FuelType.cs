namespace AutoXen.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum FuelType
    {
        [Display(Name = "Unknown")]
        Unknown = 0,
        [Display(Name = "Gasoline")]
        Gasoline = 1,
        [Display(Name = "Diesel")]
        Diesel = 2,
        [Display(Name = "Gas")]
        Gas = 3,
        [Display(Name = "Electric")]
        Electric = 4,
        [Display(Name = "Methane")]
        Methane = 5,
        [Display(Name = "ElecticGasoline")]
        ElectricGasoline = 6,
        [Display(Name = "GasolineGas")]
        GasolineGas = 7,
        [Display(Name = "GasolineMethane")]
        GasolineMethane = 8,
    }
}
