using System;
using Microsoft.Kinect.Toolkit.Controls;
using System.Windows.Threading;
using System.Windows;
using System.ComponentModel;

namespace ICEI_Kinect
{
    internal class KinectHandControl : KinectButtonBase
    {
        /// <summary>
        /// IsHandPointerOver dependency property for use in the control template triggers
        /// </summary>
        public static readonly DependencyProperty IsHandPointerOverProperty = DependencyProperty.Register(
            "IsHandPointerOver", typeof(bool), typeof(KinectHandControl), new PropertyMetadata(false));

        // Trigger a click 60 times per second
        private const int ButtonRepeatIntervalMilliseconds = 1000 / 60;

        /// <summary>
        /// Boolean value to tell us if the control is being displayed in the Visual Studio designer
        /// </summary>
        private static readonly bool IsInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());

        /// <summary>
        /// Timer to handle triggering the click events
        /// </summary>
        private readonly DispatcherTimer repeatTimer;

        private HandPointer activeHandpointer;

        public KinectHandControl()
        {
            if (!IsInDesignMode)
            {
                this.InitializeKinectHandControl();
                this.repeatTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(ButtonRepeatIntervalMilliseconds) };
                this.repeatTimer.Tick += this.RepeatTimerTick;
            }
        }   

        /// <summary>
        /// Boolean value that returns true if a mouse or hand pointer is over this button
        /// </summary>
        public bool IsHandPointerOver
        {
            get
            {
                return (bool)this.GetValue(IsHandPointerOverProperty);
            }

            set
            {
                this.SetValue(IsHandPointerOverProperty, value);
            }
        }

        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.IsHandPointerOver = true;
            this.repeatTimer.Start();
        }

        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.IsHandPointerOver = false;
            this.repeatTimer.Stop();
        }

        private void InitializeKinectHandControl()
        {
            KinectRegion.AddHandPointerEnterHandler(this, this.OnHandPointerEnter);
            KinectRegion.AddHandPointerLeaveHandler(this, this.OnHandPointerLeave);
        }

        private void RepeatTimerTick(object sender, EventArgs e)
        {
            this.OnClick();
        }

        private void OnHandPointerEnter(object sender, HandPointerEventArgs e)
        {
            if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser)
            {
                return;
            }

            this.activeHandpointer = e.HandPointer;
            this.IsHandPointerOver = true;
            this.repeatTimer.Start();
        }

        private void OnHandPointerLeave(object sender, HandPointerEventArgs e)
        {
            if (this.activeHandpointer != e.HandPointer)
            {
                return;
            }

            this.activeHandpointer = null;
            this.IsHandPointerOver = false;
            this.repeatTimer.Stop();
        }
    }
}

