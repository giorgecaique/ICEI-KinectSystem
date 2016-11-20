using System.Windows;
using System.Windows.Data;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

namespace ICEI_Kinect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly KinectSensorChooser sensorChooser;
        private const double ScrollErrorMargin = 0.001;
        private const int PixelScrollByAmount = 20;
        
        public MainWindow()
        {
            InitializeComponent();

            // initialize the sensor chooser and UI
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += KinectChange.SensorChooserOnKinectChanged;
            this.sensorChooserUi.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);
        }

        public MainWindow(KinectSensorChooser chooser)
        {
            InitializeComponent();

            // initialize the sensor chooser and UI
            //this.sensorChooser = new KinectSensorChooser();
            sensorChooser = chooser;
            var regionSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.kinectRegion, KinectRegion.KinectSensorProperty, regionSensorBinding);
        }
        
        private void AboutICEI_Button_Click(object sender, RoutedEventArgs e)
        {
            AboutICEI abouticei = new AboutICEI(sensorChooser);
            abouticei.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void CC_Button_Click(object sender, RoutedEventArgs e)
        {
            CC_Window ccWindow = new CC_Window(sensorChooser);
            ccWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
            
        }

        private void Physics_Button_Click(object sender, RoutedEventArgs e)
        {
            Physics_Window physicsWindow = new Physics_Window(sensorChooser);
            physicsWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void ES_Button_Click(object sender, RoutedEventArgs e)
        {
            ES_Window esWindow = new ES_Window(sensorChooser);
            esWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void SI_Button_Click(object sender, RoutedEventArgs e)
        {
            SI_Window siWindow = new SI_Window(sensorChooser);
            siWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void EC_Button_Click(object sender, RoutedEventArgs e)
        {
            EC_Window ecWindow = new EC_Window(sensorChooser);
            ecWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void Math_Button_Click(object sender, RoutedEventArgs e)
        {
            Math_Window mathWindow = new Math_Window(sensorChooser);
            mathWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void JD_Button_Click(object sender, RoutedEventArgs e)
        {
            JD_Window jdWindow = new JD_Window(sensorChooser);
            jdWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void MIC_Button_Click(object sender, RoutedEventArgs e)
        {
            Mic_Window micWindow = new Mic_Window(sensorChooser);
            micWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void DS_Button_Click(object sender, RoutedEventArgs e)
        {
            DreamSpark_Window dreamsparkWindow = new DreamSpark_Window(sensorChooser);
            dreamsparkWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }

        private void Partner_Button_Click(object sender, RoutedEventArgs e)
        {
            Partners_Window partnersWindow = new Partners_Window(sensorChooser);
            partnersWindow.Show();
            BindingOperations.ClearBinding(this.kinectRegion, KinectRegion.KinectSensorProperty);
            this.Close();
        }
    }
}
