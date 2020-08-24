using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Monday
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public int numberOfWeeksAfterBirth { get; set; }

        public MainPageViewModel()
        {
            try
            {
                int initializeCount = 14;
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "WeeksAfterBirth.txt");
                File.WriteAllText(fileName, initializeCount.ToString());
                bool parseOK = Int32.TryParse(File.ReadAllText(fileName), out int parseResult);
                numberOfWeeksAfterBirth = parseOK ? parseResult : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
