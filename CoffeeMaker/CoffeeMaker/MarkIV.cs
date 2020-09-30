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

            var plateStatus = api.GetPlate();
            warmer.OnPlateChanged(this, new PlateEventArgs{Status = (PlateStatus) plateStatus});
            valve.OnPlateChanged(this, new PlateEventArgs { Status = (PlateStatus)plateStatus });
            boiler.BoilerChanged +=valve.OnBoilerChanged;
            boiler.Trigger();
        }
    }

}
