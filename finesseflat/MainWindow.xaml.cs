using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using finesseflat.MVVM.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using finesseflat;
using MessageBox = System.Windows.MessageBox;

namespace finesseflat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (!(File.Exists(@"C:\Finesse\settings.json")))
            {
                if (!(Directory.Exists(@"C:\Finesse\")))
                {
                    Directory.CreateDirectory(@"C:\Finesse\");
                    //File.Create(@"C:\Finesse\settings.json");
                    JObject newSettings = new JObject(
                        new JProperty("Username", "null"),
                        new JProperty("Extension", 0),
                        new JProperty("UID", 0)
                    );
                    File.WriteAllText(@"C:\Finesse\settings.json", newSettings.ToString());
                    MessageBox.Show("Configure Settings First!");
                }
                else
                {
                    //File.Create(@"C:\Finesse\settings.json");
                    JObject newSettings = new JObject(
                        new JProperty("Username", "null"),
                        new JProperty("Extension", 0),
                        new JProperty("UID", 0)
                    );
                    File.WriteAllText(@"C:\Finesse\settings.json", newSettings.ToString());
                    MessageBox.Show("Configure Settings First!");
                }
            }
            InitializeComponent();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void StatusComboBox_OnDropDownClosed(object sender, EventArgs e)
        {
            if (this.StatusComboBox.Text != "")
            {
                MessageBox.Show(this.StatusComboBox.Text);
            }
        }
    }
}
