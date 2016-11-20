using System.Windows;
using System.Windows.Data;
//KINECT
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

namespace ICEI_Kinect
{
    /// <summary>
    /// Interaction logic for CC_Window.xaml
    /// </summary>
    public partial class CC_Window : Window
    {
        private readonly KinectSensorChooser sensorChooser;

        public CC_Window(KinectSensorChooser chooser)
        {
            InitializeComponent();

            // initialize the sensor chooser and UI
            this.sensorChooser = new KinectSensorChooser();
            sensorChooser = chooser;
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);
        }

        private void KinectCircleButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(sensorChooser);
            mainwindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Hide();
        }
    }
}
