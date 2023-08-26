using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Setting
{
    public General general;
    public Audio audio;
    public Control control;

    [Serializable]
    public class General
    {
        public string resolution;
        public string screen;
        public string language;
    }
    
    [Serializable]
    public class Audio
    {
        public float master;
        public float bgm;
        public float effect;
    }
    
    [Serializable]
    public class Control
    {
        public float sensitivity;
        public string sprint;
        public string interact;
        public string info;
        public string quest;
        public string belongings;
    }

    public Setting()
    {
        this.general = new General()
        {
            resolution = "1920*1080",
            screen = "FullScreen",
            language = "en-US"
        };
        this.audio = new Audio()
        {
            master = 1f,
            bgm = 1f,
            effect = 1f
        };
        this.control = new Control()
        {
            sensitivity = 1f,
            sprint = "LeftShift",
            interact = "F",
            info = "S",
            quest = "Q",
            belongings = "E"
        };
    }
}
