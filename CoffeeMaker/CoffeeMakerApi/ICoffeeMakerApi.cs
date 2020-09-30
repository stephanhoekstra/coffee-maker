using System;

namespace CoffeeMakerApi
{
    public interface ICoffeeMakerApi
    {
        void SetBoiler(bool value);
        void SetWarmer(bool value);
        void SetValve(bool value);
        void SetLight(bool value);

        bool GetBoiler();
        int GetPlate();
        bool GetButton();
    }
}
