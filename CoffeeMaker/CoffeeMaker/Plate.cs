using System;
using CoffeeMakerApi;

namespace CoffeeMaker
{
    public class Plate
    {
        private readonly ICoffeeMakerApi _api;

        public Plate(ICoffeeMakerApi api)
        {
            _api = api;
        }


        public event EventHandler<PlateEventArgs> Platechanged;

        public void Change(PlateStatus status)
        {
            Platechanged?.Invoke(this, new PlateEventArgs {Status = status});
        }
    }

    public class PlateEventArgs : EventArgs
    {
        public PlateStatus Status { get; set; }
    }

    public enum PlateStatus
    {
        NoPot = 1,
        EmptyPot = 2,
        NonEmptyPot = 3
    }
}