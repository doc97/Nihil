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
        UIMessages.Notify(UIMessage.UpdateHealth, characterData.Health);
    }

    public static void DecrementHealth(uint delta = 1)
    {
        characterData.Health -= delta;
        UIMessages.Notify(UIMessage.UpdateHealth, characterData.Health);
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
        UIMessages.Notify(UIMessage.UpdateEnergy, characterData.Energy);
    }

    public static void DecrementEnergy(uint delta = 1)
    {
        characterData.Energy -= delta;
        UIMessages.Notify(UIMessage.UpdateEnergy, characterData.Energy);
    }

    public static void SetEnergy(uint energy)
    {
        characterData.Energy = energy;
        UIMessages.Notify(UIMessage.UpdateEnergy, characterData.Energy);
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
        UIMessages.Notify(UIMessage.UpdateScrap, resources.Scrap);
    }

    public static void DecrementScrap(uint delta = 1)
    {
        resources.Scrap -= delta;
        UIMessages.Notify(UIMessage.UpdateScrap, resources.Scrap);
    }

    public static void SetScrap(uint scrap)
    {
        resources.Scrap = scrap;
        UIMessages.Notify(UIMessage.UpdateScrap, resources.Scrap);
    }
    public static uint GetScrap()
    {
        return resources.Scrap;
    }
}