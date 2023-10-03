using System;

[Serializable]
public class WeaponDataModel : BaseGameData<long>
{
    public int Level;
    public long MaxExp;
    public long MaxHp;
    public float Attack;
}
