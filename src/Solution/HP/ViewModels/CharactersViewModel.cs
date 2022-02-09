using HP.Models;
using HP.Services;
using Microsoft.AppCenter.Analytics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HP.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; }

        private readonly IHPService<Character> _hpService;


        public CharactersViewModel(IHPService<Character> hpService)
        {
            Characters = new ObservableCollection<Character>();
            _hpService = hpService;
            LoadData();
        }


        private async void LoadData()
        {
            Characters.Clear();
            var characters = await _hpService.GetAll();
            foreach (Character character in characters)
            {
                this.Characters.Add(character);
            }
        }



        private Character _characterSelected;
        public Character CharacterSelected
        {
            get => _characterSelected;
            set
            {
                _characterSelected = value;

                Analytics.TrackEvent(nameof(CharactersViewModel), 
                    new Dictionary<string, string> { 
                        { "Casa selecionada", (string.IsNullOrEmpty(_characterSelected.House) ? "deconhecido" : _characterSelected.House) } 
                    });

                SelectHouseColor(_characterSelected.House);
                NotifyPropertyChanged("CharacterSelected");
            }
        }

        private string _houseColor;
        public string HouseColor
        {
            get => _houseColor;
            set
            {
                _houseColor = value;                
                NotifyPropertyChanged("HouseColor");
            }
        }
        private void SelectHouseColor(string house)
        {
            if (!string.IsNullOrEmpty(house))
            {
                if ("Gryffindor".Equals(house))
                {
                    HouseColor = "Red";
                }
                if ("Slytherin".Equals(house))
                {
                    HouseColor = "Green";
                }
                if ("Ravenclaw".Equals(house))
                {
                    HouseColor = "Blue";
                }
                if ("Hufflepuff".Equals(house))
                {
                    HouseColor = "Yellow";
                }

                return;
            }

            HouseColor = "Gray";
        }
    }
}
