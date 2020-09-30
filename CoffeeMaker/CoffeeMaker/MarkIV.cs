using CoffeeMakerApi;

namespace CoffeeMaker
{

    public class MarkIV
    {
        public MarkIV(ICoffeeMakerApi api, Boiler boiler, Plate plate)
        {
            var valve = new Valve(api);
            var warmer = new Warmer(api);
            var light = new Light(api);
            var plateStatus = api.GetPlate();
            
            
            boiler.Deactivated += light.OnDeactivated;
            plate.Platechanged += light.OnPlateChanged;

            warmer.OnPlateChanged(this, new PlateEventArgs { Status = (PlateStatus)plateStatus });
            valve.OnPlateChanged(this, new PlateEventArgs { Status = (PlateStatus)plateStatus });
            boiler.OnButtonChanged(this, new ButtonEventArgs { Active = api.GetButton() });

        }
    }

}
