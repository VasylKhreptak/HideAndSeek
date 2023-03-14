using UnityEngine;

namespace Data
{
    public class PlayerDataProvider : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private PlayerData _defaultPlayerData;

        private PlayerData _data;
        public PlayerData Data => _data;

        private const string PLAYER_DATA_KEY = "PlayerData";

        #region MonoBehaviour

        private void Awake()
        {
            _data = LoadData(_defaultPlayerData);
        }

        private void OnDestroy()
        {
            SaveData(_data);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            SaveData(_data);
        }

        #endregion

        private PlayerData LoadData(PlayerData defaultData)
        {
            string data = PlayerPrefs.GetString(PLAYER_DATA_KEY, string.Empty);

            if (data == string.Empty)
            {
                return defaultData;
            }

            Debug.Log("Loaded");
            
            return JsonUtility.FromJson<PlayerData>(data);
        }

        private void SaveData(PlayerData playerData)
        {
            PlayerPrefs.SetString(PLAYER_DATA_KEY, JsonUtility.ToJson(playerData));
            
            Debug.Log("Saved");
        }
    }
}
