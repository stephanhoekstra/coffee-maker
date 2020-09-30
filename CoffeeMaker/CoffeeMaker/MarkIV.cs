using CoffeeMakerApi;

namespace CoffeeMaker
{

    public class MarkIV
    {
        public MarkIV(ICoffeeMakerApi api)
        {
            var valve = new Valve(api);
            var boiler = new Boiler(api);
            var warmer = new Warmer(api);
            
            warmer.OnPlateChanged(this, new PlateEventArgs{Status = (PlateStatus) api.GetPlate()});
            boiler.BoilerChanged +=valve.OnBoilerChanged;
            boiler.Trigger();
        }
    }

}
