using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public static Dictionary<long, PcDataModel> mPcDataDict;
    public static Dictionary<long, NpcDataModel> mNpcDataDict;
    public static Dictionary<long, WeaponDataModel> mWeaponDataDict;

    public void Init()
    {
        mPcDataDict = LoadJson<long, PcDataModel>("PcData.json").ToDictionary();
        mNpcDataDict = LoadJson<long, NpcDataModel>("NpcData.json").ToDictionary();
        mWeaponDataDict = LoadJson<long, WeaponDataModel>("WeaponData.json").ToDictionary();
    }

    private Wrapper<TKey, TDataClass> LoadJson<TKey, TDataClass>(string path) where TDataClass : ILoader<TKey>
    {
        var textAsset = Managers.Resource.Load<TextAsset>($"{path}");

        var dataWrapper = JsonUtility.FromJson<Wrapper<TKey, TDataClass>>(textAsset.text);
        return dataWrapper;
    }
}