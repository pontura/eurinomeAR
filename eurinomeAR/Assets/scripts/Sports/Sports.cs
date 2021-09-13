using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sports : MonoBehaviour
{
    public states state;
    public Vector2 bestSpeed;
    public StatLine[] lines;
    public CharacterAnims characterAnims;
    public float desaceleration;
    public float aceleration;
    public float speed = 1.5f;
    public float maxSpeed = 3;
    public float maxRealSpeed = 35;
    public float initTime;
    public float rotationSpeed = 10;
    public Text distanceField;
    public Image progressbar;
    float progressValue;
    public float progressSpeedValue = 1;
    public int speedReal = 0;
    public Animation anim;

    public Color okColor;
    public Color wrongColor;
    public Color activeColor;

    public enum states
    {
        IDLE,
        PLAYING,
        GAME_OVER
    }
    void Start()
    {
        InitPlaying();
        lines[0].Init("Velocidad", 0);
        lines[1].Init("Resistencia", 1);
        lines[2].Init("Ritmo Cardíaco", 0);
      //  lines[3].Init("Pulso", 0);
        initTime = Time.time;
    }
    void OnEnable()
    {
        Events.PlaySound("common", "breath0", true);
        Events.OnJoystickPressed += OnJoystickPressed;
        Events.ShowJoystick(true);
        SetRotation(0);
        characterAnims.SetSpeed(0);
        Events.OnTip(TipController.types.PLAY_BUTTON, GamesManager.Instance.texts.GetText("PLAY_BUTTON_SPORTS"), true);
        Events.PlaySound("music", "music_sports", true);
    }
    private void OnDisable()
    {
        Events.OnTip(TipController.types.PLAY_BUTTON, "", false);
        Events.OnJoystickPressed -= OnJoystickPressed;
        Events.ShowJoystick(false);
        Events.PlaySound("music", "", true);
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
        Events.OnTip(TipController.types.PLAY_BUTTON, "", false);
        speed += aceleration;
        anim.Play();
    }
    public void OnGameOver()
    {
        state = states.GAME_OVER;
    }
    private void Update()
    {
        if (speedReal > bestSpeed.x && speedReal < bestSpeed.y)
        {
            progressValue += progressSpeedValue * Time.deltaTime;
            activeColor = okColor;
        }
        else
        {
            activeColor = wrongColor;
            progressValue -= progressSpeedValue * Time.deltaTime;
        }
        if (progressValue < 0)
            progressValue = 0;
        else if (progressValue > 1)
            progressValue = 1;

        progressbar.color = activeColor;
        progressbar.fillAmount = progressValue;

        speed -= desaceleration * Time.deltaTime;
        if (speed < 0)
            speed = 0;
        else if (speed > maxSpeed)
            speed = maxSpeed;

        SetRotation();

        characterAnims.SetSpeed(speed);
        SetBreath();
        SetSpeed();
        SetResistencia();
        SetRitmo();
        SetDistance();
    }
    float normalizedSpeed = 1;
    void SetSpeed()
    {
        normalizedSpeed = speed / maxSpeed;
        speedReal = (int)(maxRealSpeed * normalizedSpeed);
        string fieldValue = speedReal.ToString() + "km/h";
        lines[0].SetValue(fieldValue, normalizedSpeed,  activeColor);

    }
    public float resistenciaValue;
    public float resistencia = 1;
    public float resistencia_Speed = 2;
    public float timeToResistencia = 30;
    void SetResistencia()
    {
        resistencia = (Time.time - initTime) / (timeToResistencia);
        initTime += Time.deltaTime * (1-normalizedSpeed) * resistencia_Speed;
        if (resistencia > 1) resistencia = 1;
        else if (resistencia < 0) resistencia = 0;
        lines[1].SetValue("", 1-resistencia, Color.black);
    }
    void SetRotation()
    {
        float x = GamesManager.Instance.analogicKnob.NormalizedAxis.x;
        if (x == 0) return;
        x *= rotationSpeed * Time.deltaTime;
        SetRotation(x);
    }
    void SetRotation(float _x)
    {
        transform.Rotate(-Vector3.forward * _x);
        characterAnims.transform.Rotate(Vector3.up * _x);
    }
    int min_ritmo = 60;
    int max_ritmo = 100;
    float ritmo_c = 0.2f;
    void SetRitmo()
    {
        float v = 0.1f + (normalizedSpeed / 2);
        if (v > 0.9f) v = 0.9f;
        ritmo_c = Mathf.Lerp(ritmo_c, v, 0.001f);      
        float ritmo = (ritmo_c * 40) + 60;
        string fieldValue = ((int)(ritmo)).ToString() + "pp/m";
        lines[2].SetValue(fieldValue, ritmo_c, Color.black);
    }
    float dist = 0;
    public float distFactor = 0.25f;
    void SetDistance()
    {
        dist += speed * distFactor;
        distanceField.text = (int)dist + "m";
    }

    int breathID = -1;
    int lastBreath;
    float lastChange = 0;
    void SetBreath()
    {
        lastChange += Time.deltaTime;
        if (lastChange < 2) return;
        if (speedReal > bestSpeed.x && speedReal < bestSpeed.y)
        {
            breathID = 1;
        }
        else if (speedReal > bestSpeed.y)
        {
            breathID = 2;
        }
        else if (speedReal < bestSpeed.x)
        {
            breathID = 0;
        }
        else if(speedReal == 0)
            breathID = -1;

        if (lastBreath == breathID)
            return;
        lastChange = 0;
        lastBreath = breathID;
        if (breathID == -1)
            Events.PlaySound("common", "", false);
        else
            Events.PlaySound("common", "breath" + breathID, true);
    }
}
