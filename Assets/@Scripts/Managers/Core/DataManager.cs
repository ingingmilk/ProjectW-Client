using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager
{
    public Dictionary<long, PcDataModel> mPcDataDict;
    public Dictionary<long, NpcDataModel> mNpcDataDict;
    public Dictionary<long, WeaponDataModel> mWeaponDataDict;

    public Dictionary<Type, Dictionary<long, IGameData>> mGameDataDict = new();

    public void Init()
    {
        mGameDataDict.Clear();

        var pcDataDict = LoadJson<long, PcDataModel>("PcData.json").ToDictionary();
        var npcDataDict = LoadJson<long, NpcDataModel>("NpcData.json").ToDictionary();
        var weaponDataDict = LoadJson<long, WeaponDataModel>("WeaponData.json").ToDictionary();

        mGameDataDict[typeof(PcDataModel)] = pcDataDict;
        mGameDataDict[typeof(NpcDataModel)] = npcDataDict;
        mGameDataDict[typeof(WeaponDataModel)] = weaponDataDict;
    }

    private Wrapper<TKey, TDataClass> LoadJson<TKey, TDataClass>(string path) where TDataClass : IDataLoader<TKey>, IGameData
    {
        var textAsset = Managers.Resource.Load<TextAsset>($"{path}");

        var dataWrapper = JsonUtility.FromJson<Wrapper<TKey, TDataClass>>(textAsset.text);
        return dataWrapper;
    }

    public IGameData Get<T>(long templateID) where T : BaseController, IGameData
    {
        System.Type type = typeof(T);

        if (!mGameDataDict.TryGetValue(type, out var dataDict))
        {
            return null;
        }

        if (!dataDict.TryGetValue(templateID, out var data))
        {
            return null;
        }

        return data;
    }

    public IGameData GetData<T>(long templateID) where T : BaseController
    {
        System.Type type = typeof(T);

        if (!mGameDataDict.TryGetValue(type, out var dataDict))
        {
            return null;
        }

        if (!dataDict.TryGetValue(templateID, out var data))
        {
            return null;
        }

        return data;
    }

    private bool GetNpcGameData(long templateID, out NpcDataModel npcGameData)
    {
        return mNpcDataDict.TryGetValue(templateID, out npcGameData);
    }

    private bool GetPcGameData(long templateID, out PcDataModel pcGameData)
    {
        return mPcDataDict.TryGetValue(templateID, out pcGameData);
    }

    private bool GetWeaponGameData(long templateID, out WeaponDataModel weaponGameData)
    {
        return mWeaponDataDict.TryGetValue(templateID, out weaponGameData);
    }
}
