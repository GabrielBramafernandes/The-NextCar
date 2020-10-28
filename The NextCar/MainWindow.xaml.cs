using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_NextCar.Controller;

namespace The_NextCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , OnPowerChanged, OnDooorChanged, oncarEngineStateChanged
    {
        private Car nextcar;

        public MainWindow()
        {
            InitializeComponent();

            AccubaterryController accubaterryController = new AccubaterryController(this);
            DoorController doorController = new DoorController(this);

            nextcar = new Car(doorController, accubaterryController, this);
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.startEngine();
        }

        private void OnDoorOpenbuttonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toogleTheOpenDoorButton();
        }

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toogleTheLockDoorButton();
        }

        private void OnAccButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.tooglePowerButton();
        }

        public void onPowerChangedStatus(string value, string message)
        {
            AccuState.Content = message;
            AccuButton.Content = value;
        }

        public void onLockDoorStateChanged(string value, string message)
        {
            LockDoorState.Content = message;
            LockDoorButton.Content = value;
        }

        public void onDoorOpenStateChanged(string value, string message)
        {
            DoorOpenState.Content = message;
            DoorOpenButton.Content = value;
        }

        public void onCarEngineStateChanged(string value, string message)
        {
            status.Content = message;
            startButton.Content = value;
        }
    }
}
