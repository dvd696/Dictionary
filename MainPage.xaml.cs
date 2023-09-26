using CustomDictionary.CoreLayer.Repositories.Managers;
using CustomDictionary.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CustomDictionary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        UnitOfWork uow = new UnitOfWork();
        double width;
        public MainPage()
        {
            this.InitializeComponent();
            RefreshData();
            width = lst.Width;
        }

        private void txtSearch_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            RefreshData(txtSearch.Text);
        }

        private async void lst_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var word = lst.SelectedItem as Word;

            if (word != null)
            {
                WordDialog wrd = new WordDialog(word, uow);
                await wrd.ShowAsync();
                RefreshData();
            }
        }

        private async void btnAddWord_Click(object sender, RoutedEventArgs e)
        {
            AddWordDialog wrd = new AddWordDialog(uow);
            await wrd.ShowAsync();
            RefreshData();
        }

        private void RefreshData(string search="")
        {
            lst.ItemsSource = uow.WordRepository.GetWordBySearch(search);
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
    }
}
