using System;
using System.Collections.Generic;
using System.Linq;

public interface ILoader<TKey>
{
    TKey DataKey { get; }
}

[Serializable]
public class Wrapper<TKey, TDataClass> where TDataClass : ILoader<TKey>
{
    public TDataClass[] dataList;

    public Dictionary<TKey, TDataClass> ToDictionary()
    {
        var dict = dataList.ToDictionary(item => item.DataKey);
        return dict;
    }
}