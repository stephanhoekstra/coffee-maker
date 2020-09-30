using System;

namespace CoffeeMaker
{
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