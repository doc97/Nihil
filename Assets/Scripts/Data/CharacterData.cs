public class CharacterData
{
    public uint Health { get; set; }
    public uint Energy { get; set; }
    public WeaponData Weapon { get; set; }

    public CharacterData(uint health, uint energy, WeaponData weapon)
    {
        this.Health = health;
        this.Energy = energy;
        this.Weapon = weapon;
    }
}