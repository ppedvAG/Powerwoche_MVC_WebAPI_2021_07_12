using System;

namespace DependencyInversionSample
{

    #region BadCode
    //Nachteile
    //1.) Erweiterungen von Car, geht nur über Vererbung 

    public class BadCar //Programmierer A:  Dauer 5 Tage
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class BadCarService //Programmierer B: Dauer 3 Tage
    {
        public void Repair (BadCar car) //<- Müssen auf fertige Implementierung von Car warten.
        {
            //Repariert Car
        }
    }
    #endregion


    public interface ICar
    {
        int Id { get; set; }
        string Marke { get; set; }
        string Model { get; set; }
        DateTime ConstructionYear { get; set; }
    }

    public interface IMockCar : ICar
    {

    }

    public interface ICarService
    {
        void RepairCar(ICar car);
    }

    public class Car : ICar // 5 Tage
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Model { get; set; }
        public DateTime ConstructionYear { get; set; }
    }

    public class CarService : ICarService // 3Tagen 
    {
        public void RepairCar(ICar car)
        {
            //Repair Car
        }
    }

    public class MockCar : IMockCar // 5 Tage
    {
        public int Id { get; set; } = 1;
        public string Marke { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public DateTime ConstructionYear { get; set; } = DateTime.Now;
    }

    public class MyProgramm
    {
        public void MySampleMain()
        {
            ICarService carService = new CarService();
            carService.RepairCar(new MockCar()); //Test-Objekt mit festen Werten
            carService.RepairCar(new Car()); //Produktives Object 
        }
    }
}
