using UnityEngine;

public interface IShooter
{
    private float _shootingInterval
    {
        get
        {
            return _shootingInterval;
        }
        set
        {
            _shootingInterval = value;
        }
    }
    public void Fire();
}
