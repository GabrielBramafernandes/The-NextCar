# The NextCar
    dimana aplikasi ini menerapkan konsep MVC, dimanainteraksi manusia dengan mobil di jembatan oleh perangkat canggih, bukan tombol fisik melainkan layar sentuh atau bahkan voice command.
# Penjelasan Code
    => kegunaan DoorController.cs
    => kegunaan Model Door.cs
    => kegunaan Interface OnDoorChanged
    => kegunaan DoorController.cs
# DoorController.cs
 
=> DoorController.cs berfungsi sebagai door Closed atau Locked.
```csharp
namespace The_NextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDooorChanged callbackOnDoorChanged;

        public DoorController(OnDooorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
```
# Door.cs
=> Door.cs nantinya berfungsi ketika pintu masih tertutup(closed) maka mobil bisa di start engine, sedangkan ketika pintu mobil masih terbuka (open) maka mobil belum bisa di start engine.
```csharp
namespace TheNextCar.Model
{
    class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
```
# OnDoorChanged
=> OnDoorChanged yaitu berfungsi pewarisan, dimana ketika ketika pintu tertutup makan keluar tampilan atau message ClOSED dan seterusnya.
```csharp 
public DoorController(OnDoorChanged callbackOnDoorchanged)
        {
            this.callbackOnDoorchanged = callbackOnDoorchanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("CLOSED", "door closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("OPENED", "door opened");
        }
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("LOCKED", "door locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("UNLOCKED", "ddoor unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void OnLockDoorStateChanged(string value, string message);

        void OnDoorOpenStateChanged(string value, string message);
    }
}
```

