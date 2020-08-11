using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField]
    TextMeshProUGUI killCounter_TMP;
    [HideInInspector]
    public int killCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateKillCounterUI()
    {
        killCounter_TMP.text = killCount.ToString();
    }
}
