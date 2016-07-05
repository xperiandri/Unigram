﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Unigram.Core.Dependency;
using Unigram.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Unigram.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DialogSharedMediaPage : Page
    {
        public DialogSharedMediaViewModel ViewModel => DataContext as DialogSharedMediaViewModel;

        public DialogSharedMediaPage()
        {
            InitializeComponent();
            this.SizeChanged += DialogSharedMediaPage_SizeChanged;
            DataContext = UnigramContainer.Instance.ResolverType<DialogSharedMediaViewModel>();
        }

        private void DialogSharedMediaPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.UpdateLayout();
         }
    }
}