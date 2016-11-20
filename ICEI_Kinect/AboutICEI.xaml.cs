using System.Windows;
using System.Windows.Data;
//KINECT
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

namespace ICEI_Kinect
{
    /// <summary>
    /// Interaction logic for AboutICEI.xaml
    /// </summary>
    public partial class AboutICEI : Window
    {
        private readonly KinectSensorChooser sensorChooser;

        public AboutICEI(KinectSensorChooser chooser)
        {
            InitializeComponent();

            // initialize the sensor chooser and UI
            sensorChooser = chooser;
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);
        }

        private void KinectCircleButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow(sensorChooser);
            mainwindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }
    }
}
