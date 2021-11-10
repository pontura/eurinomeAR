using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SportsIntro : MonoBehaviour
{

    public CharacterAnims characterAnims;

    private void OnEnable()
    {
        characterAnims.SetSpeed(1);
    }
}
