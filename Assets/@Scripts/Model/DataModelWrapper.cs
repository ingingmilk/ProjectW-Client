using System;
using System.Collections.Generic;
using System.Linq;

public interface IDataLoader<TKey>
{
    TKey DataKey { get; }
}

public interface IGameData
{
    public string PrefabStringKey { get; }
}

public abstract class BaseGameData<TKey> : IDataLoader<TKey>, IGameData
{
    public TKey DataKey => TemplateId;
    public string PrefabStringKey => PrefabName;

    public TKey TemplateId;
    public string PrefabName;
}

[Serializable]
public class Wrapper<TKey, TDataClass> where TDataClass : IDataLoader<TKey>
{
    public TDataClass[] dataList;

    public Dictionary<TKey, IGameData> ToDictionary()
    {
        var dict = dataList.ToDictionary(item => item.DataKey, item => (IGameData)item);
        return dict;
    }
}