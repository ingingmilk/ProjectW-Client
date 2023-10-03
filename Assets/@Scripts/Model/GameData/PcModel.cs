using System;

[Serializable]
public class PcDataModel : BaseGameData<long>
{
    public int Level;
    public long MaxExp;
    public long MaxHp;
    public float Attack;
}


