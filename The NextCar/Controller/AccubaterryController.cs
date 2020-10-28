using System;
using System.Collections.Generic;
using System.Text;
using The_NextCar.Model;

namespace The_NextCar.Controller
{
    class AccubaterryController
    {
        private Accubaterry accubaterry;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubaterryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubaterry = new Accubaterry(12);
        }
        public void turnOn()
        {
            this.accubaterry.turnOn();
            this.callbackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        }
        public void turnoff()
        {
            this.accubaterry.turnoff();
            this.callbackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");
        }
        public bool accubatteryIsOn()
        {
            return this.accubaterry.isOn();
        }


    }

    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
