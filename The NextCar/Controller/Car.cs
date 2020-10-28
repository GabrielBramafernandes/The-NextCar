using System;
using System.Collections.Generic;
using System.Text;

namespace The_NextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubaterryController accubaterryController;
        private oncarEngineStateChanged callback;

        public Car(DoorController doorController, AccubaterryController accubaterryController, oncarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubaterryController = accubaterryController;
            this.callback = callback;
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }

        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        private bool powerIsReady()
        {
            return this.accubaterryController.accubatteryIsOn();
        }

        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "doorIsClosed the door");
                return;
            }
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }

            if(!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power available");
                return;
            }
            this.callback.onCarEngineStateChanged("STARTED", "Engine started");
        }

        public void toogleTheLockDoorButton()
        {

            if (doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }

        public void toogleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void tooglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubaterryController.turnOn();
            }
            else
            {
                this.accubaterryController.turnoff();
            }
        }
    }
    interface oncarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
