using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Scarly
{
    public partial class MainPage : ContentPage
    {
        private int monthSeed = 12;
        private DateTime anniversaryDate = new DateTime(2019, 8, 12, 16, 33, 0);
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "months.txt");

        public MainPage()
        {
            InitializeComponent();
            InitializeCounter();
        }

        private void InitializeCounter()
        {
            var timeElapsed = DateTime.Now - anniversaryDate;

            var totalDays = timeElapsed.TotalDays;
            var totalYears = Math.Truncate(totalDays / 365);
            var totalMonths = Math.Truncate((totalDays % 365) / 30);
            var remainingDays = Math.Truncate((totalDays % 365) % 30);

            int monthCounter = GetMonthAfterBirth();

            var now = DateTime.Now;

            LocalDate birthDate = new LocalDate(2019, 8, 12);
            LocalDate today = new LocalDate(now.Year, now.Month, now.Day);
            Period age = Period.Between(birthDate, today);

            TimeElapsed.Text = $"{age.Years} years {age.Months} months {age.Days} days";

            for (var month = 0; month < monthCounter; month++)
            {
                AddGridImage(month);
            }
        }

        private void AddGridImage(int monthCount)
        {
            Image imageButterfly = new Image
            {
                Source = (monthCount % 12 == 0) ? "butterfly_1.png" : "butterfly.png"
            };
            Label label = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                Text = (monthCount == 0 ? "S" : monthCount.ToString()),
                TextColor = Color.White,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Start,
            };
            Grid gridImage = new Grid
            {
                WidthRequest = GetImageWidth(),
                HeightRequest = GetImageWidth(),
                Margin = GetImageWidth() / 17,
            };
            gridImage.Children.Add(imageButterfly);
            gridImage.Children.Add(label);
            gridImage.ClassId = monthCount.ToString();

            var tap = new TapGestureRecognizer();
            tap.Tapped += gridImageTapped;
            gridImage.GestureRecognizers.Add(tap);

            ImageFlex.Children.Add(gridImage);
        }

        private async void gridImageTapped(object sender, EventArgs e)
        {
            var index = Int32.Parse(((Grid)sender).ClassId);
            var title = index == 0 ? "Scarlet was born" :
                (index % 12 == 0) ? $"Happy Birthday #{index / 12}" : $"Happy Monthly Anniversary #{index}";
            await DisplayAlert(title, anniversaryDate.AddMonths(index).ToString("ddd, MMM dd, yyyy hh:mm tt"), "Close");
        }

        private void RemoveGridImage(int weeksAfterBirth)
        {
            var count = ImageFlex.Children.Count;
            if (count > 0)
                ImageFlex.Children.RemoveAt(count - 1);
        }

        private double GetImageWidth()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            return (mainDisplayInfo.Width / mainDisplayInfo.Density) / 7;
        }

        private int GetMonthAfterBirth()
        {
            string result = "";
            try
            {
                result = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                result = monthSeed.ToString();
                File.WriteAllText(fileName, result);
            }
            bool parseOK = Int32.TryParse(result, out int parseResult);

            return parseOK ? parseResult : 0;
        }

        void Increment_Clicked(System.Object sender, System.EventArgs e)
        {
            int monthsAfterBirth = GetMonthAfterBirth();
            AddGridImage(monthsAfterBirth);
            monthsAfterBirth++;
            //NumberOfWeeks.Text = monthsAfterBirth.ToString();
            File.WriteAllText(fileName, monthsAfterBirth.ToString());
        }

        void Decrement_Clicked(System.Object sender, System.EventArgs e)
        {
            int monthsAfterBirth = GetMonthAfterBirth();
            if (monthsAfterBirth == 0) return;
            RemoveGridImage(monthsAfterBirth);
            monthsAfterBirth--;
            //NumberOfWeeks.Text = monthsAfterBirth.ToString();
            File.WriteAllText(fileName, monthsAfterBirth.ToString());
        }
    }    
}
