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

        public event EventHandler<BoilerEventArgs> BoilerChanged;

        public void OnButtonChanged(object sender, ButtonEventArgs e)
        {
            if(e.Active == false) return;
            
            _api.SetBoiler(true);
            BoilerChanged?.Invoke(this, new BoilerEventArgs {IsEmpty = IsEmpty});
        }
        
    }
}