public interface IHealth
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get;}
    public void GetDamage(float value);
    public void GetHealing(float value);
}
