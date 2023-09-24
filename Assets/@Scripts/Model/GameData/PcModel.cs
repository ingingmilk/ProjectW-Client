using System;

[Serializable]
public class PcDataModel : ILoader<long>
{
    public long DataKey => TemplateId;
    public long TemplateId;
    public string PrefabName;
    public int Level;
    public long MaxExp;
    public long MaxHp;
    public float Attack;
}

[Serializable]
public class PcDataModelEx
{
    public long TemplateId;
    public string PrefabName;
    public int Level;
    public long MaxExp;
    public long MaxHp;
    public float Attack;
}   

