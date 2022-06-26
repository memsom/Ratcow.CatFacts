using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Windows.Input;
using CatFacts.Services;
using CatFacts.Models;
using Xamarin.Forms;

namespace CatFacts.ViewModels
{
    // this is necessary because the Xamarin Forms Command differs from the Maui one and this makes it possible to
    // use a common base without that getting in the way.
    public class MainPageViewModel : MainPageViewModelBase
    {
        public MainPageViewModel(ICatFactsService catFactsService) : base(catFactsService)
        {
            RefreshCommand = new Command(Refresh);
        }
    }
}
