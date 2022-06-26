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

namespace CatFacts.ViewModels
{
    public class MainPageViewModelBase : ViewModelBase
    {
        public MainPageViewModelBase(ICatFactsService catFactsService)
        {
            this.catFactsService = catFactsService ?? throw new ArgumentNullException(nameof(catFactsService));

            // get the initial fact...
            Refresh(null);
        }

        string fact = "No fact, hit 'New'";
        public string Fact
        {
            get => fact;
            private set => SetField(ref fact, value);
        }

        string image = string.Empty;
        public string Image
        {
            get => image;
            private set => SetField(ref image, value);
        }

        public ICommand RefreshCommand { get; protected set; }

        ICatFactsService catFactsService { get; }

        public async void Refresh(object sender)
        {

            // get the fact
            if(await catFactsService.GetFact() is CatFact fact)
            {
                Fact = fact.Fact;

                // get an image if the fact resolved
                if (await catFactsService.GetImage() is CatImage image)
                {
                    Image = image.Url;
                }
                else if (await catFactsService.GetAltImage() is CatImage alt)
                {
                    Image = alt.Url;
                }
            }
        }
    }
}
