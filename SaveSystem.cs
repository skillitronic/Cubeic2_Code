using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
public class SaveSystem : MonoBehaviour
{
    public int localCoin, localSavedScene;
    [Range(0, 5)] public int localButtonCounter;
    public bool localLangSwitched,localMusicSwitched, localSoundSwitched;
    public bool[] localIsBackPackBuyed;
    public void Awake()
    {
        LoadLvlData();

        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            localSavedScene = SceneManager.GetActiveScene().buildIndex;
            LoadShopData();
            LoadCoinData();
            LoadLanguageData();
            LoadMusicSoundData();
        }
    }
    public void SaveLvlData()
    {
        localSavedScene++;
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavesLvl.bin";
        FileStream fs = new FileStream(path, FileMode.Create);
        SaveSystemData data = new SaveSystemData();
        data.savedScene = localSavedScene;
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadLvlData()
    {
        string path = Application.persistentDataPath + "/SavesLvl.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveSystemData data = (SaveSystemData)bf.Deserialize(fs);
            localSavedScene = data.savedScene;
            fs.Close();
        }
    }
    public void SaveCoinData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavesCoin.bin";
        FileStream fs = new FileStream(path, FileMode.Create);
        SaveSystemData data = new SaveSystemData();
        data.coin = localCoin;
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadCoinData()
    {
        string path = Application.persistentDataPath + "/SavesCoin.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveSystemData data = (SaveSystemData)bf.Deserialize(fs);
            localCoin = data.coin;
            fs.Close();
        }
    }
    public void SaveLanguageData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SavesLanguage.bin";
        FileStream fs = new FileStream(path, FileMode.Create);
        SaveSystemData data = new SaveSystemData();
        data.LangSwitched = localLangSwitched;
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadLanguageData()
    {
        string path = Application.persistentDataPath + "/SavesLanguage.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveSystemData data = (SaveSystemData)bf.Deserialize(fs);
            localLangSwitched = data.LangSwitched;
            fs.Close();
        }
    }
    public void SaveShopData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveShop.bin";
        FileStream fs = new FileStream(path, FileMode.Create);
        SaveSystemData data = new SaveSystemData();
        data.isBackPackBuyed = localIsBackPackBuyed;
        data.buttonCounter = localButtonCounter;
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadShopData()
    {
        string path = Application.persistentDataPath + "/SaveShop.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveSystemData data = (SaveSystemData)bf.Deserialize(fs);
            localIsBackPackBuyed = data.isBackPackBuyed;
            localButtonCounter = data.buttonCounter;
            fs.Close();
        }
    }
    public void SaveMusicSoundData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveShop.bin";
        FileStream fs = new FileStream(path, FileMode.Create);
        SaveSystemData data = new SaveSystemData();
        data.MusicSwitched = localMusicSwitched;
        data.SoundSwitched = localSoundSwitched;
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void LoadMusicSoundData()
    {
        string path = Application.persistentDataPath + "/SaveShop.bin";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);
            SaveSystemData data = (SaveSystemData)bf.Deserialize(fs);
            localMusicSwitched = data.MusicSwitched;
            localSoundSwitched = data.SoundSwitched;
            fs.Close();
        }
    }
}
[System.Serializable]
public class SaveSystemData
{
    public int coin, savedScene,buttonCounter;
    public bool LangSwitched, MusicSwitched, SoundSwitched;
    public bool[] isBackPackBuyed;
}