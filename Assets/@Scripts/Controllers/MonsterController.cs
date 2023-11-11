using System.Collections;
using UnityEngine;

public class MonsterController : CreatureController
{
    private Coroutine _coDotDamage;
    private NpcDataModel _npcData;

    public override bool Init()
    {
        if (base.Init())
        {
            return false;
        }

        ObjectType = Define.ObjectType.Monster;

        return true;
    }

    public override bool SetGameData(IGameData gameData)
    {
        _npcData = gameData as NpcDataModel;
        return _npcData != null;
    }

    private void FixedUpdate()
    {
        var pc = Managers.Object.Player;
        if (pc == null)
        {
            return;
        }

        var dir = pc.transform.position - transform.position;
        var newPos = transform.position + dir.normalized * Time.deltaTime * _speed;

        GetComponent<Rigidbody2D>().MovePosition(newPos);
        GetComponent<SpriteRenderer>().flipX = dir.x > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var pcTarget = collision.gameObject.GetComponent<PlayerController>();
        if (pcTarget == null)
        {
            return;
        }

        if (_coDotDamage != null)
        {
            StopCoroutine(_coDotDamage);
        }

        _coDotDamage = StartCoroutine(CoStartDotDamage(pcTarget));
    }

    public IEnumerator CoStartDotDamage(PlayerController pcTarget)
    {
        while (true)
        {
            pcTarget.OnDamaged(this, 2);

            yield return new WaitForSeconds(0.1f);
        }
    }

    protected override void OnDead()
    {
        base.OnDead();
        if (_coDotDamage != null)
        {
            StopCoroutine(_coDotDamage);
        }

        _coDotDamage = null;

        Managers.Object.Despawn(this);
    }
}

