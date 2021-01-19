using System;

namespace FinalEve
{
  public class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service() { Oilchange = "Change the oil pls" };
            Car car = new Car();
            var serviceCar = new ServiceCar();
            serviceCar.OilService += car.OnService;
            serviceCar.Change(service);
        }
    }
    public class ServiceEventArgs : EventArgs
    {
        public Service service { get; set; }
    }

    public class ServiceCar
    {
        public event EventHandler<ServiceEventArgs> OilService;
        public void Change(Service oil)
        {
            Console.WriteLine("Oil change is due");
            OnService(oil);
        }
        protected virtual void OnService(Service oil)
        {
            if (OilService != null)
                OilService(this, new ServiceEventArgs() { service = oil });
        }
    }
    public class Service
    {
        public string Oilchange { get; set; }
    }
    public class Car
    {
        public void OnService(object source, ServiceEventArgs e)
        {
            Console.WriteLine("Car Sercice:" + e. service.Oilchange);
        }
    }

}
