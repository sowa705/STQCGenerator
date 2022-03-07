using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
            LoadSettings();
        }

        void SaveSettings() {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\STQCGenerator");

            key.SetValue("Format", formatBox.Text);
            key.SetValue("Input", inputBox.Text);
            key.Close();
        }

        void LoadSettings()
        {
            if (Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STQCGenerator")==null)
            {
                Reset();
                SaveSettings();
                return;
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\STQCGenerator");

            formatBox.Text = (string) key.GetValue("Format");
            inputBox.Text = (string) key.GetValue("Input");
            key.Close();

            Update();
        }

        async Task PlayOutput(bool record,string filename=null)
        {
            string sequence;
            try
            {
                sequence = STQC.GenerateOutput(formatBox.Text, inputBox.Text)+"_";
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return;
            }
            
            playButton.IsEnabled = false;
            saveButton.IsEnabled = false;
            var sound = new SineWaveProvider();
            sound.sequence = "_"+sequence+"_";
            float totallen = sound.TotalLength();
            using (var recorder=new WaveRecorder(new SampleToWaveProvider( sound),record,filename))
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
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new();
            saveFileDialog1.FileName = $"stqc ({formatBox.Text.Replace(' ',',')}) {inputBox.Text.Replace(' ',',')}.wav";
            saveFileDialog1.Filter = "Wav files (*.wav)|*.wav";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PlayOutput(true, saveFileDialog1.FileName);
            }
        }

        void Reset()
        {
            inputBox.Text = "123 1234";
            formatBox.Text = "7 8";
            SaveSettings();
            Update();
        }

        private void Reset_click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }
    }
}
