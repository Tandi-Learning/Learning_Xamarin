using Android.Content;
using ExpensesApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(CustomProgressBarRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public CustomProgressBarRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            string hexColor = e.NewElement.Progress switch
            {
                < 0.3 => "#008DD5",
                < 0.5 => "#2D76BA",
                < 0.7 => "#5A5F9F",
                < 0.9 => "#B3316A",
                _ => "#E01A4F"
            };

            Control.ProgressDrawable.SetTint(Color.FromHex(hexColor).ToAndroid());

            Control.ScaleY = 4.0f;
        }
    }
}