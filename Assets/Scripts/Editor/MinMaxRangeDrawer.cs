/* MinMaxRangeDrawer.cs
* by Eddie Cameron – For the public domain
*   edited by Daniel Riissanen (09.04.2019)
* ———————————————————–
* — EDITOR SCRIPT : Place in a subfolder named ‘Editor’ —
* ———————————————————–
* Renders a MinMaxRange field with a MinMaxRangeAttribute as a slider in the inspector
* Can slide either end of the slider to set ends of range
* Can slide whole slider to move whole range
* Can enter exact range values into the From: and To: inspector fields
*
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(MinMaxRangeAttribute))]
public class MinMaxRangeDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 16;
    }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Now draw the property as a Slider or an IntSlider based on whether it’s a float or integer.
        if (property.type != "MinMaxRange")
        {
            Debug.LogWarning("Use only with MinMaxRange type");
            return;
        }

        var range = attribute as MinMaxRangeAttribute;
        var minValue = property.FindPropertyRelative("rangeStart");
        var maxValue = property.FindPropertyRelative("rangeEnd");
        var newMin = minValue.floatValue;
        var newMax = maxValue.floatValue;

        var xPos = position.x;
        var yPos = position.y;
        var wPos = position.width;
        var hPos = position.height;
        var xDiv = wPos * 0.33f; // three columns
        var yDiv = hPos * 0.5f; // two rows

        createLabel(xPos, yPos, xDiv, yDiv, label);
        createLabel(xPos, yPos + yDiv, wPos, yDiv, range.minLimit);
        createLabel(xPos + wPos - 18f, yPos + yDiv, wPos, yDiv, range.maxLimit);

        EditorGUI.MinMaxSlider(
            new Rect(xPos + 24f, yPos + yDiv, wPos - 48f, yDiv),
            ref newMin, ref newMax, range.minLimit, range.maxLimit
        );

        createLabel(xPos + xDiv, yPos, xDiv, yDiv, "From: ");
        newMin = Mathf.Clamp(
            createFloat(xPos + xDiv + 40, yPos, xDiv - 40, yDiv, newMin),
            range.minLimit,
            newMax
        );

        createLabel(xPos + xDiv * 2f, yPos, xDiv, yDiv, "To: ");
        newMax = Mathf.Clamp(
            createFloat(xPos + xDiv * 2f + 24, yPos, xDiv - 24, yDiv, newMax),
            newMin,
            range.maxLimit
        );

        minValue.floatValue = newMin;
        maxValue.floatValue = newMax;
    }

    private void createLabel(float x, float y, float width, float height, string label)
    {
        EditorGUI.LabelField(new Rect(x, y, width, height), label);
    }

    private void createLabel(float x, float y, float width, float height, float value)
    {
        EditorGUI.LabelField(new Rect(x, y, width, height), value.ToString("0.##"));
    }

    private void createLabel(float x, float y, float width, float height, GUIContent content)
    {
        EditorGUI.LabelField(new Rect(x, y, width, height), content);
    }

    private float createFloat(float x, float y, float width, float height, float value)
    {
        return EditorGUI.FloatField(new Rect(x, y, width, height), value);
    }
}