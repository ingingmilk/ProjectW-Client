using System;

[Serializable]
public class NpcDataModel : ILoader<long>
{
    public long DataKey => TemplateId;
    public long TemplateId;
    public string PrefabName;
    public int Level;
    public long MaxExp;
    public long MaxHp;
    public float Attack;
}