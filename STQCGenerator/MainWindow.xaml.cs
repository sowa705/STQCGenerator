using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
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

namespace STQCGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                var item = new ComboBoxItem();
                item.Content =$"({n}) {caps.ProductName}";
                deviceCombo.Items.Add(item);
            }
            deviceCombo.SelectedIndex = 0;
            Update();
        }
        async Task PlayOutput(bool record)
        {
            string sequence;
            try
            {
                sequence = STQC.GenerateOutput(formatBox.Text, inputBox.Text)+"__";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
            
            playButton.IsEnabled = false;
            saveButton.IsEnabled = false;
            var sound = new SineWaveProvider();
            sound.sequence = "_"+sequence+"_";
            float totallen = sound.TotalLength();
            using (var recorder=new WaveRecorder(new SampleToWaveProvider( sound),record,"test.wav"))
            {
                using (var wo = new WaveOut() { DeviceNumber= deviceCombo.SelectedIndex -1})
                {
                    wo.Init(recorder);
                    wo.Play();
                    await Task.Delay((int)totallen*1000);
                }
            }
            playButton.IsEnabled = true;
            saveButton.IsEnabled = true;
        }
        void Update()
        {
            if (outputBox==null)
            {
                return;
            }
            try
            {
                var output=STQC.GenerateOutput(formatBox.Text,inputBox.Text);
                outputBox.Text = output;
            }
            catch (Exception e)
            {
                outputBox.Text = e.Message;
            }
        }
        private void AboutMenu_click(object sender, RoutedEventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void inputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void formatChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            PlayOutput(false);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            PlayOutput(true);
        }
    }
}
