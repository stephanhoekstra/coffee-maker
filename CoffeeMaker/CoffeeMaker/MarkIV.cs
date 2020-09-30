using System;
using CoffeeMakerApi;

namespace CoffeeMaker
{

    public class MarkIV
    {
        private ICoffeeMakerApi _api;
        private readonly ICoffeeMakerApi _api;

        public MarkIV(ICoffeeMakerApi api)
        {
            _api = api;
        }

        public void MakeCoffee()
        {
            throw new System.NotImplementedException();

        public void Start()
        {
            _api.SetBoiler(true);

        }
    }

}
