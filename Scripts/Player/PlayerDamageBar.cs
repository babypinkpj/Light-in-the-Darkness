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
            damageSlider.value = playerController.attackDamage; // เริ่มต้นเท่าค่าใน player
        }
    }

    void UpdateDamage(float newValue)
    {
        playerController.attackDamage = Mathf.RoundToInt(newValue);
        Debug.Log("New Player Damage: " + playerController.attackDamage);
    }
    
    void Update()
{
    if (damageSlider != null && playerController != null)
    {
        if (damageSlider.value != playerController.attackDamage)
        {
            damageSlider.value = playerController.attackDamage;
        }
    }
}

}
