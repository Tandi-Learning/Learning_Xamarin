using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKeeper.Models;
using NoteKeeper.ViewModels;
using System.Collections.Generic;
using NoteKeeper.Services;
using System.Threading.Tasks;

namespace NoteKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        Boolean isNewPage = true;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            BindingContext = this.viewModel;
            isNewPage = false;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new ItemDetailViewModel();
            BindingContext = viewModel;
        }

        void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            if (isNewPage)
                MessagingCenter.Send(this, "SaveNote", viewModel.Note);
            else
                MessagingCenter.Send(this, "EditNote", viewModel.Note);

            Navigation.PopModalAsync();
        }
    }
}