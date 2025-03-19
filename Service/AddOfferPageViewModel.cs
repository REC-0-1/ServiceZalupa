using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ZXing.Net.Maui;
using System.Threading.Tasks;

namespace Service
{
    public partial class AddOfferPageViewModel : ObservableObject, IQueryAttributable
    {
        private readonly MainPageViewModel _mainPageViewModel;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string number;

        [ObservableProperty]
        private string mark;

        [ObservableProperty]
        private int partnumber;

        [ObservableProperty]
        private int price;

        [ObservableProperty]
        private bool approved;

        public AddOfferPageViewModel(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("Id"))
            {
                var id = int.Parse(query["Id"].ToString());
                LoadOfferCommand.Execute(id);
            }
        }

        [RelayCommand]
        private async Task ScanQrCode()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                // Обработка данных из QR-кода
                var offerData = result.Text.Split(';');
                if (offerData.Length == 6)
                {
                    Name = offerData[0].Split(':')[1];
                    Number = offerData[1].Split(':')[1];
                    Mark = offerData[2].Split(':')[1];
                    Partnumber = int.Parse(offerData[3].Split(':')[1]);
                    Price = int.Parse(offerData[4].Split(':')[1]);
                    Approved = bool.Parse(offerData[5].Split(':')[1]);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Ошибка", "Некорректный QR-код", "OK");
                }
            }
        }

        [RelayCommand]
        private async Task LoadOffer(int id)
        {
            var offer = _mainPageViewModel.Offers.FirstOrDefault(o => o.Id == id);
            if (offer != null)
            {
                Id = offer.Id;
                Name = offer.Name;
                Number = offer.number;
                Mark = offer.Mark;
                Partnumber = offer.partnumber;
                Price = offer.price;
                Approved = offer.Approved;
            }
        }

        [RelayCommand]
        private async Task SaveOffer()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Number) || string.IsNullOrWhiteSpace(Mark))
            {
                await Shell.Current.DisplayAlert("Ошибка", "Заполните все поля", "OK");
                return;
            }

            var offer = new Offers
            {
                Id = Id == 0 ? (_mainPageViewModel.Offers.Any() ? _mainPageViewModel.Offers.Max(o => o.Id) + 1 : 1) : Id,
                Name = Name,
                number = Number,
                Mark = Mark,
                partnumber = Partnumber,
                price = Price,
                Approved = Approved
            };

            if (Id == 0)
            {
                _mainPageViewModel.AddOffer(offer);
            }
            else
            {
                _mainPageViewModel.UpdateOffer(offer);
            }

            ClearFields();
            await Shell.Current.GoToAsync("///MainPage");
        }

        [RelayCommand]
        private void ClearFields()
        {
            Name = string.Empty;
            Number = string.Empty;
            Mark = string.Empty;
            Partnumber = 0;
            Price = 0;
            Approved = false;
            Id = 0;
        }
    }
}