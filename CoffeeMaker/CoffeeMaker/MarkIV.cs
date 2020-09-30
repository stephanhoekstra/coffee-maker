using System;
using CoffeeMakerApi;

namespace CoffeeMaker
{

    public class MarkIV
    {
        private readonly ICoffeeMakerApi _api;

        public MarkIV(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void Start()
        {
            _api.SetBoiler(true);
            
            _api.SetValve(!_api.GetBoiler());  //release pressure when boiler is empty
        }
    }
}
