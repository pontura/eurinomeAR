using UnityEngine;
using System.Collections;

public static class Events
{
    public static System.Action ResetApp = delegate { };
    public static System.Action<bool> ShowJoystick = delegate { };
    public static System.Action OnJoystickPressed = delegate { };
    public static System.Action<TipController.types,  string, bool> OnTip = delegate { };
    public static System.Action<TipController.types,  string, int> OnTipTimout = delegate { };

    public static System.Action<AudioClip[]> PlaySpecificSoundInArray = delegate { };
    public static System.Action<AudioClip> PlaySpecificSound = delegate { };
    public static System.Action<string, string, bool> PlaySound = delegate { };
    public static System.Action<string, float> ChangeVolume = delegate { };

}
   
