using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Combat/Stats")]
public class CharacterStats_SO : ScriptableObject
{
    #region Fields
    public bool isPlayer;

    public int maxHealth;
    public float currentHealth;

    public int maxStamina;
    public float currentStamina;

    public int maxEnergy;
    public float currentEnergy;

    public int baseDamage;
    public int currentDamage;

    public int baseDefense;
    public int currentDefense;

    public int maxSpeed;
    public int currentSpeed;

    public int currentExperience;
    public int requiredExperience;

    public int currentLevel;
    #endregion

    #region Stat Increasers
    public void ApplyHealth(int healthAmount)
    {
        if ((currentHealth + healthAmount) > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += healthAmount;
    }

    public void ApplyStamina(int staminaAmount)
    {
        if ((currentStamina + staminaAmount) > maxStamina)
            currentStamina = maxStamina;
        else
            currentStamina += staminaAmount;
    }

    public void ApplyEnergy(int energyAmount)
    {
        if ((currentEnergy + energyAmount) > maxEnergy)
            currentEnergy = maxEnergy;
        else
            currentEnergy += energyAmount;
    }

    public void ApplyEXP(int experienceAmount)
    {
        if ((currentExperience + experienceAmount) > requiredExperience)
            LevelUp();
        else
            currentExperience += experienceAmount;
    }
    #endregion

    #region Stat Reducers
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Death();
    }

    public void TakeStamina(int staminaAmount)
    {
        currentStamina -= staminaAmount;

        if (currentStamina <= 0)
            currentStamina = 0;
    }

    public void TakeEnergy(int energyAmount)
    {
        currentEnergy -= energyAmount;

        if (currentEnergy <= 0)
            currentEnergy = 0;
    }
    #endregion

    #region Level Up and Death
    public void LevelUp()
    {
        #region Increasing Stats
        maxHealth += maxHealth / 2;
        maxStamina += maxStamina / 2;
        maxEnergy += maxEnergy / 2;
        baseDamage += baseDamage / 2;
        baseDefense += baseDefense / 2;
        requiredExperience += requiredExperience / 2;
        currentLevel++;
        #endregion

        #region Setting Stats
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentEnergy = maxEnergy;
        currentDamage = baseDamage;
        currentDefense = baseDefense;
        currentExperience = 0;
        #endregion
    }

    public void Death()
    {

    }
    #endregion
}
