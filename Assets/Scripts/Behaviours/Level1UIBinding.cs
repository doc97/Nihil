using System;
using UnityEngine;
using UnityEngine.UI;

public class Level1UIBinding : UIBinding
{
    private Func<object, object> convertHealth = value => "Health: " + value;
    private Func<object, object> convertEnergy = value => "Energy: " + value;

    protected override void InitializeElements()
    {
        Text health = transform.Find("Health").GetComponent<Text>();
        health.text = (string) convertHealth(GameState.GetHealth());

        Text energy = transform.Find("Energy").GetComponent<Text>();
        energy.text = (string) convertEnergy(GameState.GetEnergy());
    }

    protected override BindingConfig[] GetConfigs()
    {
        return new BindingConfig[]
        {
            new BindingConfig(UIMessage.UpdateHealth, "Health", "Text", convertHealth),
            new BindingConfig(UIMessage.UpdateHealth, "Energy", "Text", convertEnergy),
        };
    }
}