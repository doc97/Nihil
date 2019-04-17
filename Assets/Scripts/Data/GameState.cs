using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{

    private static WeaponData[] weapons;
    private static CharacterData characterData;
    private static CharacterResources resources;

    static GameState()
    {
        weapons = new WeaponData[]
        {
            new WeaponData("Pistol", 2)
        };
        characterData = new CharacterData(100, 5, weapons[0]);
        resources = new CharacterResources(0);
    }

    public static void IncrementHealth(uint delta = 1)
    {
        characterData.Health += delta;
    }

    public static void DecrementHealth(uint delta = 1)
    {
        characterData.Health -= delta;
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

    public static void IncrementEnergy(uint delta = 1)
    {
        characterData.Energy += delta;
    }

    public static void DecrementEnergy(uint delta = 1)
    {
        characterData.Energy -= delta;
    }

    public static void SetEnergy(uint energy)
    {
        characterData.Energy = energy;
    }

    public static uint GetEnergy()
    {
        return characterData.Energy;
    }

    public static int GetDamage()
    {
        return characterData.Weapon.damage;
    }

    public static void IncrementScrap(uint delta = 1)
    {
        resources.Scrap += delta;
    }

    public static void DecrementScrap(uint delta = 1)
    {
        resources.Scrap -= delta;
    }

    public static void SetScrap(uint scrap)
    {
        resources.Scrap = scrap;
    }
    public static uint GetScrap()
    {
        return resources.Scrap;
    }
}