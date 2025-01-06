using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.Windows;

public class FixedJoystick : Joystick
{
    // New property to control movement
    public bool CanMove { get; set; } = true;

    // Override the OnDrag method to restrict movement if CanMove is false
    public override void OnDrag(PointerEventData eventData)
    {
        if (!CanMove)
        {
            // Stop input when CanMove is false
            input = Vector2.zero;
            handle.anchoredPosition = Vector2.zero;
            return;
        }

        // Call base implementation for normal functionality
        base.OnDrag(eventData);
    }

    // Override OnPointerDown to respect the CanMove flag
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!CanMove)
            return;

        base.OnPointerDown(eventData);
    }
}