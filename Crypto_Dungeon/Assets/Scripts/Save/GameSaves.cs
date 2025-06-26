using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Market.Items;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Save
{
    public class GameSaves
    {
        private const string DEFAULT_IP_ADDRESS = "127.0.0.1";
        private const string DEFAULT_IP_PORT = "8000";

        private string _address;
        public string IP_Address
        {
            get => _address ?? DEFAULT_IP_ADDRESS;
            set
            {
                if (DataValidator.IsIPAddressValid(value))
                    _address = value;
                else
                {
                    _address = Instance?.IP_Address ?? DEFAULT_IP_ADDRESS;
                    SetErrorState("IP address is in incorrect format. Please change the value");
                }
            }
        }

        private string _port;
        public string IP_Port
        {
            get => _port ?? DEFAULT_IP_PORT;
            set
            {
                if (DataValidator.IsIPPortValid(value))
                    _port = value;
                else
                {
                    _port = Instance?.IP_Port ?? DEFAULT_IP_PORT;
                    SetErrorState("IP port is in incorrect format. Please change the value");
                }
            }
        }

        public static CipherType PresentedCipher
        {
            get => (CipherType)PlayerPrefs.GetInt("PresentedCipher", 0);
            set => PlayerPrefs.SetInt("PresentedCipher", (int)value);
        }

        public Localization Localization;

        private List<PlayerScriptableObject> _players;
        public List<PlayerScriptableObject> Players
        {
            get => _players?.ToList();
            private set => _players = value;
        }

        public int GetHpByPlayerName(string nickname) => _players.Where(p => p.Nickname == nickname).First().Hp;

        public float Balance {  get; set; }
        public bool IsError { get; private set; }
        public string ErrorMessage { get; private set; }

        private GameSaves() { }
        private static GameSaves _instance;
        public static GameSaves Instance
        {
            get
            {
                if (_instance == null)
                    _instance = GetLatestSave() ?? new GameSaves();

                return _instance;
            }
            set => _instance = value;
        }

        public List<ItemScriptableObject> SavedItems { get; set; }

        public List<ItemPickupLimitModel> ItemsPickupLimits { get; set; } = new List<ItemPickupLimitModel>();



        public void AddPickupItem(ItemPickupLimit item) => ItemsPickupLimits.Add(
            new ItemPickupLimitModel
            {
                Name = item.ItemName,
                Limit = item.LimitCount
            });

        public void RemovePickupItem(ItemPickupLimitModel item) => ItemsPickupLimits.Remove(item);

        public static GameSaves GetLatestSave()
        {
            SavesSerializer.TryLoad(Paths.SAVES_FILENAME, out GameSaves save);

            return save;
        }

        public void Save() => SavesSerializer.Save(this, Paths.SAVES_FILENAME);

        public void ResetError()
        {
            IsError = false;
            ErrorMessage = "";
        }

        private void SetErrorState(string message)
        {
            IsError = true;
            ErrorMessage = message;
        }
    }
}
