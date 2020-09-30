using System;
using CoffeeMakerApi;

namespace CoffeeMaker
{
    public class BoilerEventArgs : EventArgs
    {
        public bool IsEmpty { get; set; }
    }

    public class Boiler
    {
        private readonly ICoffeeMakerApi _api;
        private bool _isActive;
         
        /// <summary>
        /// I find it confusing that the api uses Get/SetBoiler for both
        /// setting the heater to active/inactive,
        /// and determining if the sensor detects water in the boiler,
        /// so wrapping this with something that does not have a confusing name
        /// </summary>
        private bool IsEmpty => _api.GetBoiler() == false;

        public Boiler(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public event EventHandler<BoilerEventArgs> Activated;
        public event EventHandler<BoilerEventArgs> Deactivated;

        public void OnButtonChanged(object sender, ButtonEventArgs e)
        {
            if (e.Active) Activate();
        }


        public void Activate()
        {
            if(_isActive) throw new Exception("Can't activate boiler, already active!");

            _api.SetBoiler(true);
            _isActive = true;

            Activated?.Invoke(this, new BoilerEventArgs
            {
                IsEmpty = IsEmpty,
            });
        }

        public void DeActivate()
        {
            if (_isActive == false) throw new Exception("Can't deactivate boiler, already inactive!");

            _api.SetBoiler(false);
            _isActive = false;

            Deactivated?.Invoke(this, new BoilerEventArgs
            {
                IsEmpty = IsEmpty,
            });
        }
    }
}