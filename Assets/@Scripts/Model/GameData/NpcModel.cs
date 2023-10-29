using System;

[Serializable]
public class NpcDataModel : BaseGameData<long>
{
    public int NpcId;
    public int Level;
    public long MaxExp;
    public long MaxHp;
    public float Attack;
}
