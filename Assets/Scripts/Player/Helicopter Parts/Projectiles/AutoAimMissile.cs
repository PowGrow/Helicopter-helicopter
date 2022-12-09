using UnityEngine;

public class AutoAimMissile : Projectile
{
    private GameObject _target;

    public GameObject Target
    {
        get { return _target; }
    }

    private void Update()
    {
        //Moving forward if target is null
        if(_target == null)
        {
            transform.Translate(0, speed * SpeedModificator * Time.deltaTime, 0);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _target.transform.position, speed * SpeedModificator * Time.deltaTime);
            transform.up = _target.transform.position - transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHealth collisionHealth = collision.transform.GetComponent<IHealth>();
        collisionHealth.GetDamage((damage * DamageMultiplier) * DamageModificator);
        Destroy(this.gameObject);
    }

    //Method to call by aim assist to set target
    public void SetAimTarget(GameObject target)
    {
        _target = target;
    }
}
