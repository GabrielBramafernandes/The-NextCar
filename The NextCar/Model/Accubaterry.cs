namespace The_NextCar.Model
{
    class Accubaterry
    {
        private int voltage;
        private bool stateOn = false;

        public Accubaterry(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.stateOn = true;
        }
        public void turnoff()
        {
            this.stateOn = false;
        }
        public bool isOn()
        {
            return this.stateOn;
        }
    }
}
