using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{

    public float playerHealth;
    [SerializeField] private Text healthText; //serialized makes it public to inspector



    public void Start()
    {
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        healthText.text = playerHealth.ToString("100");
    }
}
