using System;

namespace Observer
{
    public class TemperatureReporter : IObserver
    {
        private bool first = true;
        private Temperature last;
        private TemperatureMonitor provider;

        public virtual void Subscribe(TemperatureMonitor provider)
        {
            this.provider = provider;
            this.provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            this.provider.Unsubscribe(this);
        }

        public virtual void Update()
        {
            Console.WriteLine($"The temperature is {provider.Current.Degrees}°C at {provider.Current.Date:g}");
            if (first)
            {
                last = provider.Current;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {provider.Current.Degrees - last.Degrees}° in " +
                    $"{provider.Current.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}