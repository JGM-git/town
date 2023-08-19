using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    /// <summary>
    /// CLASS FOR WEATHER
    /// </summary>
    [System.Serializable]
    public class WeatherData
    {
        public string name;
        public Sprite icon;
        public ParticleSystem weatherEffect;
        public AudioClip soundEffect;
    }
    
    /// <summary>
    /// SYSTEM VARIABLES
    /// </summary>
    public List<WeatherData> weathers = new List<WeatherData>();

    public WeatherData currentWeather;
    private MainSystem mainSystem;
    private UIManager uiManager;
    private WeatherEffect weatherEffect;

    /// <summary>
    /// EVENT FUNCTIONS
    /// </summary>
    void Start()
    {
        mainSystem = FindObjectOfType<MainSystem>();
        uiManager = FindObjectOfType<UIManager>();
        weatherEffect = FindObjectOfType<WeatherEffect>();
        PlayerWeather(weathers[0]);
    }

    /// <summary>
    /// CUSTOM FUNCTIONS
    /// </summary>

    public void PlayerWeather(WeatherData target)
    {
        uiManager.ChangeWeatherIcon(target.icon);
        if(target.weatherEffect != null) weatherEffect.PlayParticle(target.weatherEffect);
        if(target.soundEffect != null) weatherEffect.PlayAudio(target.soundEffect);
    }
    
    public void ChangeWeather(WeatherData target)
    {
        currentWeather = target;
    }
}
