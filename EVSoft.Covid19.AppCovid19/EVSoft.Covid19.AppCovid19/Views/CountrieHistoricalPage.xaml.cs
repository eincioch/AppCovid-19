﻿using EVSoft.Covid19.AppCovid19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVSoft.Covid19.AppCovid19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountrieHistoricalPage : ContentPage
    {
        public CountrieHistoricalPage(CountrieHistoricalViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}