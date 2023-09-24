using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;



public class DataManager
{
    public static Dictionary<long, PcDataModel> mPcDataDict;

    public void Init()
    {
        mPcDataDict = LoadJson<long, PcDataModel>("Pc.json").ToDictionary();

        //PlayerDic = LoadJson<Data.PlayerDataLoader, int, Data.PlayerData>("PlayerData.json").MakeDict();
        //PlayerDic = LoadXml<Data.PlayerDataLoader, int, Data.PlayerData>("PlayerData.xml").MakeDict();
    }

    private Wrapper<TKey, TDataClass> LoadJson<TKey, TDataClass>(string path) where TDataClass : ILoader<TKey>
    {
        var textAsset = Managers.Resource.Load<TextAsset>($"{path}");

        var dataWrapper = JsonUtility.FromJson<Wrapper<TKey, TDataClass>>(textAsset.text);
        return dataWrapper;
    }

    [Serializable]
    public class DataContainer
    {
        public PcDataModelEx[] dataList;
    }

    public void DeserializeAndCreateDictionary(string path)
    {
        var textAsset = Managers.Resource.Load<TextAsset>($"{path}");

        // 수정된 JSON 데이터를 담는 클래스를 생성합니다.
        

        // JSON 데이터를 역직렬화할 때 DataContainer 클래스를 사용합니다.
        var container = JsonUtility.FromJson<DataContainer>(textAsset.text);
        var dataArray = container.dataList;
        // 이후로는 데이터 처리를 진행합니다.
    }


}