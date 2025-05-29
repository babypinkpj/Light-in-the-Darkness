using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageBar : MonoBehaviour
{
    public Slider damageSlider;
    public PlayerController playerController;

    void Start()
    {
        if (damageSlider != null && playerController != null)
        {
            damageSlider.onValueChanged.AddListener(UpdateDamage);
            damageSlider.value = PlayerStats.attackDamage; // เริ่มต้นเท่าค่าใน player
        }
    }

    void UpdateDamage(float newValue)
    {
        PlayerStats.attackDamage = Mathf.RoundToInt(newValue);
        Debug.Log("New Player Damage: " + PlayerStats.attackDamage);
    }
    
    void Update()
{
    if (damageSlider != null && playerController != null)
    {
        if (damageSlider.value != PlayerStats.attackDamage)
        {
            damageSlider.value = PlayerStats.attackDamage;
        }
    }
}

}
