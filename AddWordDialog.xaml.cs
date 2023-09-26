﻿using CustomDictionary.CoreLayer.Repositories.Managers;
using CustomDictionary.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CustomDictionary
{
    public sealed partial class AddWordDialog : ContentDialog
    {
        UnitOfWork uow;
        public AddWordDialog(UnitOfWork uow)
        {
            this.InitializeComponent();
            this.uow = uow;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(CheckValidate())
            {
                Word word = new Word();
                word.Content = txtWord.Text;
                word.Translates = txtTranslate.Text;
                uow.WordRepository.AddWord(word);
                uow.Save();
            }
        }

        private bool CheckValidate()
        {
            if (string.IsNullOrEmpty(txtWord.Text))
                return false;
            if (string.IsNullOrEmpty(txtTranslate.Text))
                return false;

            return true;
        }
    }
}
