using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnims : MonoBehaviour
{
    public float fade = 0.1f;
    public Animation anim;
    int lastSpeedID = -1;

    public void SetSpeed(float speed)
    {
        int newSpeed = 0;
        if (speed == 0)
            newSpeed = 0;
        else if (speed < 1)
            newSpeed = 1;
        else if (speed < 2)
            newSpeed = 2;
        else
            newSpeed = 3;

        if (newSpeed == lastSpeedID)
            return;
        lastSpeedID = newSpeed;
        switch(lastSpeedID)
        {
            case 0:
                anim.CrossFade("Idle", fade);break;
            case 1:
                anim.CrossFade("Walking", fade); break;
            case 2:
                anim.CrossFade("Jogging", fade); break;
            case 3:
                anim.CrossFade("Running", fade); break;
        }
    }
}
