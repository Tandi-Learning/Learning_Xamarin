using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Monday
{
    public partial class MainPage : ContentPage
    {
        private int numberOfWeeksAfterBirthStart = 50;
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weeks.txt");

        public MainPage()
        {
            InitializeComponent();
            InitializeCounter();
        }

        private void InitializeCounter()
        {
            int weeksAfterBirth = GetWeeksAfterBirth();

            NumberOfWeeks.Text = weeksAfterBirth.ToString();

            for (var week = 0; week < weeksAfterBirth; week++)
            {
                AddGridImage(week);
            }
        }

        private void AddGridImage(int week)
        {
            Image imageButterfly = new Image
            {
                Source = "butterfly.png"
            };

            Label label = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                Text = (week + 1).ToString(),
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

            ImageFlex.Children.Add(gridImage);
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

        private int GetWeeksAfterBirth()
        {
            string result = "";
            try
            {
                result = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                result = numberOfWeeksAfterBirthStart.ToString();
                File.WriteAllText(fileName, result);
            }
            bool parseOK = Int32.TryParse(result, out int parseResult);

            return parseOK ? parseResult : 0;
        }

        void Increment_Clicked(System.Object sender, System.EventArgs e)
        {
            int weeksAfterBirth = GetWeeksAfterBirth();
            AddGridImage(weeksAfterBirth);
            weeksAfterBirth++;
            NumberOfWeeks.Text = weeksAfterBirth.ToString();
            File.WriteAllText(fileName, weeksAfterBirth.ToString());
        }

        void Decrement_Clicked(System.Object sender, System.EventArgs e)
        {
            int weeksAfterBirth = GetWeeksAfterBirth();
            if (weeksAfterBirth == 0) return;
            RemoveGridImage(weeksAfterBirth);
            weeksAfterBirth--;
            NumberOfWeeks.Text = weeksAfterBirth.ToString(); ;
            File.WriteAllText(fileName, weeksAfterBirth.ToString());
        }
    }
}
