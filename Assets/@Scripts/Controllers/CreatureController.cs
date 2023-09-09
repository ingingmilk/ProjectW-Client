public class CreatureController : BaseController
{
    protected float _speed = 1.0f;

    public int Hp { get; set; } = 100;
    public int MaxHp { get; set; } = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void OnDamaged(BaseController attacker, int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {

    }
}
