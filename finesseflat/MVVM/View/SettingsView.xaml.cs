using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using static finesseflat.MVVM.ViewModel.MainViewModel;
using static Newtonsoft.Json.JsonConvert;

namespace finesseflat.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void ApplyConfig_OnClick(object sender, RoutedEventArgs e)
        {

            var json = File.ReadAllText(@"C:\finesse\settings.json");
            dynamic jsonObj1 = DeserializeObject(json) ?? throw new ArgumentNullException(nameof(sender));

            if (this.UsernameSetting.Text != "")
            {
                jsonObj1["Username"] = this.UsernameSetting.Text;
                MessageBox.Show(this.UsernameSetting.Text);
            }
            if (this.ExtensionSetting.Text != "")
            {
                jsonObj1["Extension"] = this.ExtensionSetting.Text;
                MessageBox.Show(this.ExtensionSetting.Text);
            }
            if (this.UIDSetting.Text != "")
            {
                jsonObj1["UID"] = this.UIDSetting.Text;
                MessageBox.Show(this.UIDSetting.Text);
            }
            string output = JsonConvert.SerializeObject(jsonObj1, Formatting.Indented);
            if (output != null)
            {
                MessageBox.Show(output);
                File.WriteAllText(@"C:\finesse\settings.json", output);
            }

        }
    }

}
