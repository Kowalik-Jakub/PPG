using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameOverUI gameOverUI;
    public int money = 100;

    public int maxHealth = 100;
    public int health = 100;

    public int maxAmmo = 5;
    public int ammo = 5;

    public float maxStamina = 5f;
    public float stamina = 5f;

    public float staminaRegenRate = 1f;
    public float staminaSprintDrain = 3.2f;

    void Update()
    {
        if (stamina < maxStamina)
            stamina += staminaRegenRate * Time.deltaTime;

        stamina = Mathf.Clamp(stamina, 0, maxStamina);
    }

    public bool TryConsumeStamina(float amount)
    {
        if (stamina < amount)
            return false;

        stamina -= amount;
        return true;
    }

    public bool TryConsumeAmmo(int amount)
    {
        if (ammo < amount)
            return false;

        ammo -= amount;
        return true;
    }

    public void AddAmmo(int amount)
    {
        ammo = Mathf.Clamp(ammo + amount, 0, maxAmmo);
    }

    public void AddHealth(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public bool SpendMoney(int amount)
    {
        if (money < amount) return false;
        money -= amount;
        return true;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }
}
