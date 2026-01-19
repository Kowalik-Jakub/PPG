using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public PlayerStats stats;

    public Slider hpBar;
    public Slider staminaBar;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI moneyText;


    void Start()
    {
        hpBar.maxValue = stats.maxHealth;
        staminaBar.maxValue = stats.maxStamina;
    }

    void Update()
    {
        hpBar.value = stats.health;
        staminaBar.value = stats.stamina;
        ammoText.text = stats.ammo + " / " + stats.maxAmmo;
        moneyText.text = "$ " + stats.money;
    }
}
