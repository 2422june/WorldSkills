using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ActorBase
{
    [SerializeField]
    private GameObject _trails;

    [SerializeField]
    private int _bulletIndex;

    [SerializeField]
    private List<GameObject> _bullets;

    protected override void Init()
    {
        base.Init();
        Init(50, 100, 30, 0.5f);
        BulletSetting(Vector3.zero);

        _trails = transform.Find("Trails").gameObject;

        for(_bulletIndex = 0; _bulletIndex < 30; _bulletIndex++)
        {
            _bullets.Add(Instantiate(_bullet.gameObject, _bullet.position, _bullet.rotation));
            _bullets[_bulletIndex].SetActive(false);
            _bullets[_bulletIndex].GetComponent<PlayerBulletController>().Init(_damage, _bulletDir, 95);
        }
        _bullet.gameObject.SetActive(false);
        _bulletIndex = 0;
    }

    void Update()
    {
        _attackTimer += Time.deltaTime;

        _moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.z = Input.GetAxisRaw("Vertical");

        Move();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    protected override void Move()
    {
        /*if (IsOverMapXLine())
            _moveDir.x = 0;
        if (IsOverMapZLine())
            _moveDir.z = 0;*/

        _trails.SetActive(_moveDir.z != -1);

        transform.rotation = Quaternion.Euler(Vector3.back * _moveDir.x * 40);
        transform.position += _moveDir.normalized * _moveSpeed * Time.deltaTime;
    }
    protected override bool IsOverMapXLine()
    {
        return base.IsOverMapXLine();
    }

    protected override bool IsOverMapZLine()
    {
        return base.IsOverMapZLine();
    }

    public override void GetDamage(int damage)
    {
        _hp -= damage;
        _hpBar.value = _hp;
        if (_hp <= 0)
        {
            Die();
        }
    }

    protected override void Attack()
    {
        if(_attackTime <= _attackTimer)
        {
            _attackTimer = 0;
            if (_bullets[_bulletIndex].activeSelf)
            {
                return;
            }
            _bullets[_bulletIndex].GetComponent<PlayerBulletController>().Shot(_bullet.position);

            _bulletIndex = (_bulletIndex + 1) % 30;
        }
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            GetDamage(other.GetComponent<EnemyBase>().GetDamage());
            ExplosionManager.Instance.CreateExplosion(transform.position);
            Destroy(other.gameObject);
        }
    }
}
