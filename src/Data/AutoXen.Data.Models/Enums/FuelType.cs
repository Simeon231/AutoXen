// TODO: Change namespace to all enums

namespace AutoXen.Data.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum FuelType
    {
        Unknown = 0,
        [Display(Name = "Electic gasoline")]
        ElectricGasoline = 1,
        Gasoline = 2,
        Diesel = 3,
        Gas = 4,
        Methane = 5,
        [Display(Name = "Gasoline gas")]
        GasolineGas = 6,
        [Display(Name = "Gasoline methane")]
        GasolineMethane = 7,
        Electric = 8,
    }
}
