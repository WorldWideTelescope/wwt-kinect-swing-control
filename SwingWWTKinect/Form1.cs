// Written by Jonathan Fay
// Portions taken from WorldWide Telescope Kinect control circa 2012 & Kinect Samples for Kinect One


using KincetControl;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WwtDataUtils;

namespace SwingWWTKinect
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Map depth range to byte range
        /// </summary>
        private const int MapDepthToByte = 8000 / 256;

        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor kinectSensor = null;

        /// <summary>
        /// Reader for depth frames
        /// </summary>
        private DepthFrameReader depthFrameReader = null;

        /// <summary>
        /// Description of the data contained in the depth frame
        /// </summary>
        private FrameDescription depthFrameDescription = null;

        /// <summary>
        /// Bitmap to display
        /// </summary>
        private Bitmap depthBitmap = null;

        /// <summary>
        /// Intermediate storage for frame data converted to color
        /// </summary>
        private byte[] depthPixels = null;

        /// <summary>
        /// Current status text to display
        /// </summary>
        private string statusText = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // get the kinectSensor object
            this.kinectSensor = KinectSensor.GetDefault();

            // open the reader for the depth frames
            this.depthFrameReader = this.kinectSensor.DepthFrameSource.OpenReader();

            // wire handler for frame arrival
            this.depthFrameReader.FrameArrived += this.Reader_FrameArrived;

            // get FrameDescription from DepthFrameSource
            this.depthFrameDescription = this.kinectSensor.DepthFrameSource.FrameDescription;

            // allocate space to put the pixels being received and converted
            this.depthPixels = new byte[this.depthFrameDescription.Width * this.depthFrameDescription.Height];

            // create the bitmap to display
            this.depthBitmap = new Bitmap(this.depthFrameDescription.Width, this.depthFrameDescription.Height);

            // set IsAvailableChanged event notifier
            this.kinectSensor.IsAvailableChanged += this.Sensor_IsAvailableChanged;

            // open the sensor
            this.kinectSensor.Open();

            // set the status text
            statusText = this.kinectSensor.IsAvailable ? "Running" : "No Sensor";
            pictureBox1.Image = depthBitmap;
            reverse.Checked = Properties.Settings.Default.ReverseSensor;
            topSliceEdit.Text = Properties.Settings.Default.TopSlice.ToString();
            BottomSliceEdit.Text = Properties.Settings.Default.BottomSlice.ToString();
            Amplitude.Value = (int)Properties.Settings.Default.Amplitude;
            rope = Properties.Settings.Default.RopeDepth;
            IgnoreCerts();
        }


        private void IgnoreCerts()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.depthFrameReader != null)
            {
                // DepthFrameReader is IDisposable
                this.depthFrameReader.Dispose();
                this.depthFrameReader = null;
            }

            if (this.kinectSensor != null)
            {
                this.kinectSensor.Close();
                this.kinectSensor = null;
            }

            Properties.Settings.Default.Save();
        }

        private void Reader_FrameArrived(object sender, DepthFrameArrivedEventArgs e)
        {
            bool depthFrameProcessed = false;

            using (DepthFrame depthFrame = e.FrameReference.AcquireFrame())
            {
                if (depthFrame != null)
                {
                    // the fastest way to process the body index data is to directly access 
                    // the underlying buffer
                    using (Microsoft.Kinect.KinectBuffer depthBuffer = depthFrame.LockImageBuffer())
                    {
                        // verify data and write the color data to the display bitmap
                        if (((this.depthFrameDescription.Width * this.depthFrameDescription.Height) == (depthBuffer.Size / this.depthFrameDescription.BytesPerPixel)) &&
                            (this.depthFrameDescription.Width == this.depthBitmap.Width) && (this.depthFrameDescription.Height == this.depthBitmap.Height))
                        {
                            // Note: In order to see the full range of depth (including the less reliable far field depth)
                            // we are setting maxDepth to the extreme potential depth threshold
                            ushort maxDepth = ushort.MaxValue;

                            // If you wish to filter by reliable depth distance, uncomment the following line:
                            //// maxDepth = depthFrame.DepthMaxReliableDistance

                            this.ProcessDepthFrameData(depthBuffer.UnderlyingBuffer, depthBuffer.Size, depthFrame.DepthMinReliableDistance, maxDepth);
                            depthFrameProcessed = true;
                        }
                    }
                }
            }

            if (depthFrameProcessed)
            {
                this.RenderDepthPixels();
            }
        }

        /// <summary>
        /// Directly accesses the underlying image buffer of the DepthFrame to 
        /// create a displayable bitmap.
        /// This function requires the /unsafe compiler option as we make use of direct
        /// access to the native memory pointed to by the depthFrameData pointer.
        /// </summary>
        /// <param name="depthFrameData">Pointer to the DepthFrame image data</param>
        /// <param name="depthFrameDataSize">Size of the DepthFrame image data</param>
        /// <param name="minDepth">The minimum reliable depth value for the frame</param>
        /// <param name="maxDepth">The maximum reliable depth value for the frame</param>
        private unsafe void ProcessDepthFrameData(IntPtr depthFrameData, uint depthFrameDataSize, ushort minDepth, ushort maxDepth)
        {
            // depth frame data is a 16 bit value
            ushort* frameData = (ushort*)depthFrameData;

            FillBitmap(frameData, minDepth, maxDepth, depthBitmap);
            if (Preview.Checked)
            {
                Refresh();
            }
            //// convert depth to a visual representation
            //for (int i = 0; i < (int)(depthFrameDataSize / this.depthFrameDescription.BytesPerPixel); ++i)
            //{
            //    // Get the depth for this pixel
            //    ushort depth = frameData[i];

            //    // To convert to a byte, we're mapping the depth value to the byte range.
            //    // Values outside the reliable depth range are mapped to 0 (black).
            //    this.depthPixels[i] = (byte)(depth >= minDepth && depth <= maxDepth ? (depth / MapDepthToByte) : 0);
            //}
        }

        /// <summary>
        /// Renders color pixels into the writeableBitmap.
        /// </summary>
        private void RenderDepthPixels()
        {

        }

        int rope = 750;
        Point RopePixel = new Point(0, 0);
        bool pickRope = false;
        private unsafe void FillBitmap(ushort* data, double min, double max, Bitmap bmp)
        {
            double factor = max - min;
            int width = bmp.Width;
            int height = bmp.Height;
            int stride = width;

            int topPixelCount = 0;
            int bottomPixelCount = 0;
            int topPixelTotal = 0;
            int bottomPixelTotal = 0;

            int topSlice = Properties.Settings.Default.TopSlice;
            int bottomSlice = Properties.Settings.Default.BottomSlice;

            List<int> topPoints = new List<int>();
            List<int> bottomPoints = new List<int>();


            FastBitmap fastBmp = new FastBitmap(bmp);

            fastBmp.LockBitmap();
            unsafe
            {
                int xAdjusted;
                for (int y = 0; y < height; y++)
                {
                    // int indexY = y * Width;
                    PixelData* pData = fastBmp[0, y];
                    for (int x = 0; x < width; x++)
                    {
                        xAdjusted = x;
                        int dataValue = data[xAdjusted + y * stride];

                        if (pickRope && x == RopePixel.X && RopePixel.Y == y)
                        {
                            rope = dataValue;
                            Properties.Settings.Default.RopeDepth = rope;
                            pickRope = false;
                        }


                        if (dataValue == 0)
                        {
                            dataValue = (int)max;
                        }

                        if (dataValue > 4000)
                        {
                            dataValue = 4000;
                        }




                        byte val = (byte)(255 - Math.Min(255, Math.Max(0, (int)((double)(dataValue - min) / factor * 255))));

                        if (dataValue > (rope - 300) && dataValue < (rope + 300))
                        {
                            *pData++ = new PixelData(255, 0, 0, 255);

                            if (y > bottomSlice - 9 && y < bottomSlice + 9)
                            {
                                bottomPoints.Add(x);
                                bottomPixelCount++;
                                bottomPixelTotal += x;
                            }

                            if (y > topSlice - 9 && y < topSlice + 9)
                            {
                                topPoints.Add(x);
                                topPixelCount++;
                                topPixelTotal += x;
                            }
                        }
                        else
                        {
                            if (y == bottomSlice)
                            {
                                *pData++ = new PixelData(0, 255, 0, 255);
                            }
                            else if (y == topSlice)
                            {
                                *pData++ = new PixelData(0, 0, 255, 255);
                            }
                            else
                            {
                                *pData++ = new PixelData(val, val, val, 255);
                            }
                        }
                    }
                }
            }

            double topT = (double)topPixelTotal / (double)topPixelCount;
            double bottomT = (double)bottomPixelTotal / (double)bottomPixelCount;

          

            // Now do it again and reject outliers
            // loop 3 times with a narrower windows until we converge on inlyers

            for (int dist = 128; dist > 8; dist /= 2)
            {
                topPixelCount = 0;
                bottomPixelCount = 0;
                topPixelTotal = 0;
                bottomPixelTotal = 0;

                foreach (int x in topPoints)
                {
                    if (Math.Abs(x - topT) < dist)
                    {
                        topPixelTotal += x;
                        topPixelCount++;
                    }
                }

                foreach (int x in bottomPoints)
                {
                    if (Math.Abs(x - bottomT) < dist)
                    {
                        bottomPixelTotal += x;
                        bottomPixelCount++;
                    }
                }
                double topF = (double)topPixelTotal / (double)topPixelCount;
                double bottomF = (double)bottomPixelTotal / (double)bottomPixelCount;
            }

            double top = (double)topPixelTotal / (double)topPixelCount;
            double bottom = (double)bottomPixelTotal / (double)bottomPixelCount;


            double xp = bottom - top;
            double yp = Properties.Settings.Default.BottomSlice - Properties.Settings.Default.TopSlice;

            double angle = Math.Atan2(yp, xp) / Math.PI * 180;

            if (!double.IsNaN(angle))
            {
                lastAngle = (lastAngle * 2 + angle) / 3;

                float amp = (Properties.Settings.Default.Amplitude) / 20;

                NetControl.SendCommand((( lastAngle - 90) * (Properties.Settings.Default.ReverseSensor ? -amp : amp)).ToString() + ", DistanceOffset");

                if (Math.Abs(lastAngle - 90) > 10)
                {
                    lastSwing = DateTime.Now;
                    if (lightsOn)
                    {
                        this.Invoke((MethodInvoker)delegate { LightsOff(); });
                    }
                }

                if ((DateTime.Now - lastSwing).TotalMilliseconds > Properties.Settings.Default.AutoLightsTimeout)
                {
                    if (!lightsOn)
                    {
                        this.Invoke((MethodInvoker)delegate { LightsOn(); });
                    }
                }
            }

            AngleDisplay.Invoke((MethodInvoker)delegate { this.AngleDisplay.Text = "Angle: " + angle.ToString(); }); 
            fastBmp.UnlockBitmap();

           

        }

        bool lightsOn = false;
        DateTime lastSwing = DateTime.Now;

        double lastAngle = 90; 
        /// <summary>
        /// Handles the event which the sensor becomes unavailable (E.g. paused, closed, unplugged).
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Sensor_IsAvailableChanged(object sender, IsAvailableChangedEventArgs e)
        {
            // on failure, set the status text
            statusText = this.kinectSensor.IsAvailable ? "Running" : "Sensor not available";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectingRope)
            {
                pickRope = true;
                SelectRope.Checked = false;

                RopePixel = new Point(e.X, e.Y);
            }
        }

        private void reverse_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ReverseSensor = reverse.Checked;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BottomSliceEdit_TextChanged(object sender, EventArgs e)
        {
            int bottom = 0;

            if (int.TryParse(BottomSliceEdit.Text, out bottom))
            {
                Properties.Settings.Default.BottomSlice = bottom;
            }
        }

        private void topSliceEdit_TextChanged(object sender, EventArgs e)
        {
            int top = 0;

            if (int.TryParse(this.topSliceEdit.Text, out top))
            {
                Properties.Settings.Default.TopSlice = top;
            }
        }

        private void Preview_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Aplitude_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Amplitude = Amplitude.Value;
        }

        bool selectingRope = false;
        private void SelectRope_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectRope.Checked)
            {
                selectingRope = true;
            }
            else
            {
                selectingRope = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LightsOn();

        }

        private void LightsOn()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LightOnUrl))
                {

                    WebClient client = new WebClient();
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(Properties.Settings.Default.LoginUsername, Properties.Settings.Default.LoginPassword);

                    client.DownloadString(Properties.Settings.Default.LightOnUrl);
                }
            }
            catch
            {

            }
            lightsOn = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LightsOff();

        }

        private void LightsOff()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LightOffUrl))
                {
                    WebClient client = new WebClient();
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(Properties.Settings.Default.LoginUsername, Properties.Settings.Default.LoginPassword);

                    client.DownloadString(Properties.Settings.Default.LightOffUrl);
                }
            }
            catch
            {

            }
            lightsOn = false;
        }

        private void LightingSettings_Click(object sender, EventArgs e)
        {
            LightsForm lights = new LightsForm();
            lights.ShowDialog();
        }
    }
}
