using CoffeeMakerApi;

namespace CoffeeMakerTests
{
    public class CofeeMakerApiStub:ICoffeeMakerApi
    {
        public bool Boiler { get; private set; }
        public bool Warmer { get; private set; }
        public bool Valve { get; private set; }
        public bool Light { get; set; }
        public int Plate { get; set; }
        public bool Button { get; set; }

        public void SetBoiler(bool value)
        {
            Boiler = value;
        }

        public void SetWarmer(bool value)
        {
            Warmer = value;
        }

        public void SetValve(bool value)
        {
            Valve = value;
        }

        public void SetLight(bool value)
        {
            Light = value;
        }

        public bool GetBoiler()
        {
            return Boiler;
        }

        public int GetPlate()
        {
            return Plate;
        }

        public bool GetButton()
        {
            return Button;
        }

    }
}