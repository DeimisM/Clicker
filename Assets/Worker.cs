using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Worker : MonoBehaviour
{
    public string name;

    public int count;
    public int cost;
    public int cps = 1;

    public TMP_Text countText;
    public TMP_Text priceText;

    public Button button;

    private void Start()
    {
        Load();
        InvokeRepeating("Work", 1f, 1f);

        countText.text = count.ToString();
        priceText.text = "price:" + cost;
    }

    private void Update()
    {
        var canBuy = GameManager.clicks >= cost;

        button.interactable = canBuy;
    }

    public void Buy()
    {
        if (GameManager.clicks < cost) return;

        count++;
        GameManager.clicks -= cost;
        cost = (int)(cost * 1.2f);

        countText.text = count.ToString();
        priceText.text = "price:" + cost;

        Save();
    }

    void Work()
    {
        GameManager.clicks += count * cps;
    }

    void Save()
    {
        PlayerPrefs.SetInt(name + "count", count);
        PlayerPrefs.SetInt(name + "cost", cost);
    }

    void Load()
    {
        count = PlayerPrefs.GetInt(name + "count");
        cost = PlayerPrefs.GetInt(name + "cost", cost);       // default value antras
    }
}
