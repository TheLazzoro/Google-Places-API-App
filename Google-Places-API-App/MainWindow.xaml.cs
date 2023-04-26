using GooglePlaces.API;
using GooglePlacesAPI.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
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

namespace Google_Places_API_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtAPIKey_TextChanged(object sender, TextChangedEventArgs e)
        {
            API_Info.Key = txtAPIKey.Text;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var placeDetails = PlaceDetails.GetPlaceDetails(txtSearch.Text);

            ClearContentText();
            InsertContentLine("Status: " + placeDetails.status);
            if (placeDetails.result == null)
            {
                txtBlock.Text = "Status: " + placeDetails.status;
                return;
            }

            InsertContentLine("Name: " + placeDetails.result.name);
            InsertContentLine("Address: " + placeDetails.result.formatted_address);
            InsertContentLine("Rating: " + placeDetails.result.rating);

            if (placeDetails.result.opening_hours != null && placeDetails.result.opening_hours.weekday_text != null)
            {
                InsertContentLine("Opening Hours: ");
                for (int i = 0; i < placeDetails.result.opening_hours.weekday_text.Count; i++)
                {
                    string weekdayText = placeDetails.result.opening_hours.weekday_text[i];
                    InsertContentLine("    " + weekdayText);
                }
            }
        }

        private void InsertContentLine(string text)
        {
            txtBlock.Text += text + Environment.NewLine;
        }

        private void ClearContentText()
        {
            txtBlock.Text = string.Empty;
        }
    }
}
