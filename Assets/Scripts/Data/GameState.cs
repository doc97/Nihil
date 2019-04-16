using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{

    private static WeaponData[] weapons;
    private static CharacterData characterData;

    static GameState()
    {
        weapons = new WeaponData[]
        {
            new WeaponData("Pistol", 2)
        };
        characterData = new CharacterData(100, 5, weapons[0]);
    }

    public static void IncrementHealth(uint delta = 1)
    {
        SetHealth(characterData.Health + delta);
    }

    public static void DecrementHealth(uint delta = 1)
    {
        SetHealth(characterData.Health - delta);
    }

    public static void SetHealth(uint health)
    {
        characterData.Health = health;
        UIMessages.Notify(UIMessage.UpdateHealth, health);
    }

    public static uint GetHealth()
    {
        return characterData.Health;
    }

    public static uint GetEnergy()
    {
        return characterData.Energy;
    }

    public static int GetDamage()
    {
        return characterData.Weapon.damage;
    }
}