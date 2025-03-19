using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;

namespace Service
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Offers> offers;

        private List<Offers> _allOffers;
        public MainPageViewModel()
        {
            Offers = new ObservableCollection<Offers>();
            _allOffers = new List<Offers>();
            LoadOffers();
        }

        public void LoadOffers()
        {
            OnPropertyChanged(nameof(Offers));
        }


        public void FilterOffers(bool showApprovedOnly)
        {
            // Очищаем текущую коллекцию
            Offers.Clear();

            // Добавляем отфильтрованные записи
            var filteredOffers = showApprovedOnly
                ? _allOffers.Where(o => o.Approved).ToList()
                : _allOffers;

            foreach (var offer in filteredOffers)
            {
                Offers.Add(offer);
            }
        }

        public void UpdateOffer(Offers offer)
        {
            var existingOffer = Offers.FirstOrDefault(o => o.Id == offer.Id);
            if (existingOffer != null)
            {
                existingOffer.Name = offer.Name;
                existingOffer.number = offer.number;
                existingOffer.Mark = offer.Mark;
                existingOffer.partnumber = offer.partnumber;
                existingOffer.price = offer.price;
                existingOffer.Approved = offer.Approved;
            }
        }



        [RelayCommand]
        private async Task GoToAddOfferPage()
        {
            try
            {
                await Shell.Current.GoToAsync("///AddOfferPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка", $"Не удалось перейти на страницу: {ex.Message}", "OK");
            }
        }
        public void AddOffer(Offers offer)
        {
            Offers.Add(offer);
            OnPropertyChanged(nameof(Offers));
        }
        [RelayCommand]
        private async Task EditOffer(Offers offer)
        {
            if (offer == null)
                return;

            // Переходим на страницу редактирования, передавая выбранное предложение
            await Shell.Current.GoToAsync($"///AddOfferPage?Id={offer.Id}");
        }
        [RelayCommand]
        private void DeleteOffer(Offers offer)
        {
            if (offer != null)
            {
                Offers.Remove(offer);
            }
        }
    }
}