using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Chess_Tricks.Resources;
using Microsoft.Phone.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace Chess_Tricks
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            bool load_def = false;
            InitializeComponent();
            String str = "0";
            int num;
            bool stat = false;
            IsolatedStorageFile myspace = IsolatedStorageFile.GetUserStoreForApplication();
            String tem = "a";
            try
            {
                using (var isoFileStream = new IsolatedStorageFileStream("number.txt", FileMode.Open, myspace))
                {
                    using (var isoFileReader = new StreamReader(isoFileStream))
                    {
                        str = isoFileReader.ReadToEnd();
                        String[] temp = str.Split('.');
                        num = Convert.ToInt32(temp[0]);
                        if (temp[1].Equals("1"))
                            stat = true;
                        tem = temp[1];
                    }
                }

            }
            catch
            {
                num = 0;
            }
            if (num == 0)
                load_def = true;
            if (!stat)
                if (num % 3 == 0 && num != 0)
                {
                    MessageBoxResult res = MessageBox.Show("You have used Chess Tricks " + num + " times. Please Rate and Review us to help us improve.", "Chess Tricks", MessageBoxButton.OKCancel);
                    if (res == MessageBoxResult.OK)
                    {
                        MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
                        marketplaceReviewTask.Show();
                        stat = true;
                    }
                    else if (res == MessageBoxResult.Cancel && num == 3)
                    {
                        MessageBoxResult res1 = MessageBox.Show("Do you want to send feedback?", "Chess Tricks", MessageBoxButton.OKCancel);
                        if (res1 == MessageBoxResult.OK)
                        {
                            EmailComposeTask emailTask = new EmailComposeTask();
                            emailTask.Subject = "Feedback for app: Chess Tricks";
                            emailTask.To = "amitnitrite005@outlook.com";
                            emailTask.Show();
                        }
                    }


                }
            num++;
            String write;
            if (stat)
                write = num + ".1";
            else
                write = num + ".0";
            using (var isoFileStream = new IsolatedStorageFileStream("number.txt", FileMode.OpenOrCreate, myspace))
            {
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    isoFileWriter.WriteLine(write);
                }
            }
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void livetile3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PanoramaPage1.xaml", UriKind.Relative));
        }

        private void liveTilePhotos_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PIeces.xaml", UriKind.Relative));
        }

        private void livetile1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/History1.xaml", UriKind.Relative));
        }

        private void livetile2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/descriptin.xaml", UriKind.Relative));
        }

        private void livetileImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Chamions.xaml", UriKind.Relative));
        }

     
      

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}