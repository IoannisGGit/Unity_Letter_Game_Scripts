using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordGenerator : MonoBehaviour
{
    private TMP_Text textComponent;
    public static string[] wordsPool = 
        { "HELLOO", "POTATO", "PINEAPPLE","APPLE", "ORANGE",
        "KIWI","LONG","WOBBLE","MEME","LEMON","YIELD","ZEBRA","RIFT","SURF","SUPER","CLOCK","BOMB","BATTERY",
        "BEAST","COLOR","PEAK","FRUIT","ZEN","ZOO","STRENGTH","SMART","SLOW","SHIFT","SPELL","SNOW","APE","TREND"};

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
        textComponent.text = generateWord();
    }

    public static string generateWord()
    {
        int randomIndex = (int)Random.Range(0,wordsPool.Length);
        return wordsPool[randomIndex];
    }
}
