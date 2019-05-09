using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIBinding : MonoBehaviour
{
    private Dictionary<UIMessage, BindingInfo> bindings;
    private BindingConfig[] configs;

    protected abstract BindingConfig[] GetConfigs();
    protected abstract void InitializeElements();

    void OnEnable()
    {
        configs = GetConfigs();
        bindings = new Dictionary<UIMessage, BindingInfo>();
        RegisterElementBindings(configs);
        InitializeElements();
    }

    void OnDisable()
    {
        UnregisterElementBindings(configs);
    }

    private void RegisterElementBindings(BindingConfig[] elements)
    {
        foreach (BindingConfig config in elements)
        {
            Transform child = transform.Find(config.objectName);
            bindings[config.message] = new BindingInfo(child, config.converter);
            UIMessages.Subscribe(config.message, GetHandler(config.componentType));
        }
    }

    private void UnregisterElementBindings(BindingConfig[] elements)
    {
        foreach (BindingConfig config in elements)
        {
            UIMessages.Unsubscribe(config.message, GetHandler(config.componentType));
            bindings.Remove(config.message);
        }
    }

    private Action<UIMessage, object> GetHandler(string type)
    {
        switch (type)
        {
            case "Text":
                return HandleTextUpdate;
            default:
                return (msg, data) => {};
        }
    }

    private void HandleTextUpdate(UIMessage message, object data)
    {
        BindingInfo info = bindings[message];
        Transform child = info.transform;
        Text component = child.GetComponent<Text>();
        component.text = (string) info.converter.Invoke(data);
    }

    protected struct BindingConfig
    {
        public UIMessage message;
        public string objectName;
        public string componentType;
        public Func<object, object> converter;

        public BindingConfig(UIMessage message, string objectName, string componentType,
                             Func<object, object> converter)
        {
            this.message = message;
            this.objectName = objectName;
            this.componentType = componentType;
            this.converter = converter;
        }
    }

    private struct BindingInfo
    {
        public Transform transform;
        public Func<object, object> converter;

        public BindingInfo(Transform transform, Func<object, object> converter)
        {
            this.transform = transform;
            this.converter = converter;
        }
    }
}
