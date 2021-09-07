using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sports : MonoBehaviour
{
    public states state;

    public StatLine[] lines;
    public CharacterAnims characterAnims;
    public float desaceleration;
    public float aceleration;
    public float speed;
    public float maxSpeed = 3;
    public float maxRealSpeed = 35;
    public float initTime;
    public enum states
    {
        IDLE,
        PLAYING,
        GAME_OVER
    }
    void Start()
    {
        InitPlaying();
        lines[0].Init("Velovidad", 0);
        lines[1].Init("Resistencia", 1);
        lines[2].Init("Ritmo Cardíaco", 0);
        lines[3].Init("Pulso", 0);
        initTime = Time.time;
    }
    void OnEnable()
    {
        Events.OnJoystickPressed += OnJoystickPressed;
        Events.ShowJoystick(true);
    }
    private void OnDisable()
    {
        Events.OnJoystickPressed -= OnJoystickPressed;
        Events.ShowJoystick(false);
    }
    public void Init()
    {
        InitPlaying();
    }
    void InitPlaying()
    {
        state = states.PLAYING;
    }
    void OnJoystickPressed()
    {
        speed += aceleration;
    }
    public void OnGameOver()
    {
        state = states.GAME_OVER;
    }
    private void Update()
    {
        speed -= desaceleration * Time.deltaTime;
        if (speed < 0)
            speed = 0;
        else if (speed > maxSpeed)
            speed = maxSpeed;

        characterAnims.SetSpeed(speed);

        SetSpeed();
        SetResistencia();
    }
    float normalizedSpeed = 1;
    void SetSpeed()
    {
        normalizedSpeed = speed / maxSpeed;
        string fieldValue = ((int)(maxRealSpeed * normalizedSpeed)).ToString() + "km/h";
        lines[0].SetValue(fieldValue, normalizedSpeed);
    }
    public float resistenciaValue;
    public float resistencia = 1;
    public float resistencia_Speed = 2;
    float timeToResistencia = 30;
    void SetResistencia()
    {
        resistencia = (Time.time - initTime) / (timeToResistencia);
        initTime += Time.deltaTime * (1-normalizedSpeed) * resistencia_Speed;
        if (resistencia > 1) resistencia = 1;
        else if (resistencia < 0) resistencia = 0;
        lines[1].SetValue("", 1-resistencia);
    }
}
