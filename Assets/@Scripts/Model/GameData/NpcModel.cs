public class NpcDataModel : ILoader<long>
{
    public long DataKey => TemplateId;

    public long TemplateId { get; set; }
    public string PrefabName { get; set; }
    public int Level { get; set; }
    public long MaxExp { get; set; }
    public long MaxHp { get; set; }
    public float Attack { get; set; }
}
