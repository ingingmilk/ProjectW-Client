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

        try
        {
            var pcDataDict = LoadJson<long, PcDataModel>("PcData.json").ToDictionary();
            var npcDataDict = LoadJson<long, NpcDataModel>("NpcData.json").ToDictionary();
            var weaponDataDict = LoadJson<long, WeaponDataModel>("WeaponData.json").ToDictionary();

            var stageDataDict = LoadJson<long, StageDataModel>("StageData.json").ToDictionary();
            var npcSpawnDataDict = LoadJson<long, NpcSpawnModel>("NpcSpawnData.json").ToDictionary();

            mGameDataDict[typeof(PcDataModel)] = pcDataDict;
            mGameDataDict[typeof(NpcDataModel)] = npcDataDict;
            mGameDataDict[typeof(WeaponDataModel)] = weaponDataDict;
            mGameDataDict[typeof(StageDataModel)] = stageDataDict;
            mGameDataDict[typeof(NpcSpawnModel)] = npcSpawnDataDict;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return;
        }

        Debug.Log("[Complete] DataManager Load");
    }

    private Wrapper<TKey, TDataClass> LoadJson<TKey, TDataClass>(string path) where TDataClass : IDataLoader<TKey>, IGameData
    {
        try
        {
            var textAsset = Managers.Resource.Load<TextAsset>($"{path}");

            var dataWrapper = JsonUtility.FromJson<Wrapper<TKey, TDataClass>>(textAsset.text);
            return dataWrapper;
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }

    public T GetByTemplateId<T>(long templateID)
    {
        System.Type type = typeof(T);

        if (!mGameDataDict.TryGetValue(type, out var dataDict))
        {
            return default;
        }

        if (!dataDict.TryGetValue(templateID, out var data))
        {
            return default;
        }

        return (T)data;
    }

    public IGameData GetData<T>(long templateID) where T : BaseController, IGameData
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
}
