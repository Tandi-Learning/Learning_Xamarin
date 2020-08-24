using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;

namespace Monday
{
    public partial class MainPage : ContentPage
    {
        private int COL_MAX = 6;
        private int numberOfWeeksAfterBirthStart = 50;
        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "weeks.txt");


        public MainPage()
        {
            InitializeComponent();
            InitializeCounter();
        }

        private void InitializeCounter()
        {
            for (int col = 0; col < COL_MAX; col++)
            {
                ImageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            int weeksAfterBirth = GetWeeksAfterBirth();
            (int rowCount, int colCount) = GetRowCol(weeksAfterBirth);

            NumberOfWeeks.Text = weeksAfterBirth.ToString();

            for(var count = 0; count < weeksAfterBirth; count++)
            {
                AddGridImage(count);
            }
        }

        private void AddRow()
        {
            ImageGrid.RowDefinitions.Add(new RowDefinition { Height = 50 });
        }

        private void RemoveRow()
        {

        }

        private void AddGridImage(int weeksAfterBirth)
        {
            (int row, int col) = GetRowCol(weeksAfterBirth);

            if (col == 0)
                AddRow();

            Image imageButterfly = new Image
            {
                Source = "butterfly.png",
                //WidthRequest = 60,
            };

            Label label = new Label
            {
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                Text = (weeksAfterBirth + 1).ToString(),
                TextColor = Color.White,
                VerticalTextAlignment = TextAlignment.Start,
                HorizontalTextAlignment = TextAlignment.Start,
            };
            Grid gridImage = new Grid();
            gridImage.Children.Add(imageButterfly);
            gridImage.Children.Add(label);

            ImageGrid.Children.Add(gridImage, col, row);
        }

        private void RemoveGridImage(int weeksAfterBirth)
        {
            (int row, int col) = GetRowCol(weeksAfterBirth);

            ImageGrid.Children.Remove(ImageGrid.Children.Last());

            if (col == 1)
                ImageGrid.RowDefinitions.RemoveAt(ImageGrid.RowDefinitions.Count - 1);
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

        private (int, int) GetRowCol(int weeksAfterBirth)
        {
            if (weeksAfterBirth == 0) return (0, 0);

            int row = weeksAfterBirth / COL_MAX;
            int col = weeksAfterBirth % COL_MAX;

            return (row, col);
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
