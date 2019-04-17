using System;
using UnityEngine;
using UnityEngine.UI;

public class Level1UIBinding : UIBinding
{
    private Func<object, object> convertHealth = value => "Health: " + value;
    private Func<object, object> convertEnergy = value => "Energy: " + value;
    private Func<object, object> convertScrap = value => "Scrap: " + value;

    protected override void InitializeElements()
    {
        Text health = transform.Find("Health").GetComponent<Text>();
        health.text = (string) convertHealth(GameState.GetHealth());

        Text energy = transform.Find("Energy").GetComponent<Text>();
        energy.text = (string) convertEnergy(GameState.GetEnergy());

        Text scrap = transform.Find("Scrap").GetComponent<Text>();
        scrap.text = (string) convertScrap(GameState.GetScrap());
    }

    protected override BindingConfig[] GetConfigs()
    {
        return new BindingConfig[]
        {
            new BindingConfig(UIMessage.UpdateHealth, "Health", "Text", convertHealth),
            new BindingConfig(UIMessage.UpdateEnergy, "Energy", "Text", convertEnergy),
            new BindingConfig(UIMessage.UpdateScrap, "Scrap", "Text", convertScrap),
        };
    }
}