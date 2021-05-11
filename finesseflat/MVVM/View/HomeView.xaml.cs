using System.IO;
using System.Windows.Controls;
using static Newtonsoft.Json.JsonConvert;

namespace finesseflat.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            var json = File.ReadAllText(@"C:\finesse\settings.json");
            dynamic jsonObj = DeserializeObject(json);
            this.Username.Text = jsonObj["Username"];
            this.Extension.Text = jsonObj["Extension"];
            this.UID.Text = jsonObj["UID"];
        }
    }
}
