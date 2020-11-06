using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public CharacterStats_SO characterDefinition = null;
	public CharacterStats_SO characterDefinition_Template;

	void Awake()
	{
		if (characterDefinition_Template != null)
			characterDefinition = Instantiate(characterDefinition_Template);
	}

	#region Stat Increasers
	public void ApplyHealth(int healthAmount)
	{
		characterDefinition.ApplyHealth(healthAmount);
	}
	public void ApplyStamina(int staminaAmount)
	{
		characterDefinition.ApplyStamina(staminaAmount);
	}

	public void ApplyEnergy(int energyAmount)
	{
		characterDefinition.ApplyEnergy(energyAmount);
	}

	public void ApplyEXP(int experienceAmount)
	{
		characterDefinition.ApplyEXP(experienceAmount);
	}

	#endregion

	#region Stat Reducers
	public void TakeDamage(float amount)
	{
		characterDefinition.TakeDamage(amount);
	}

	public void TakeEnergy(int amount)
	{
		characterDefinition.TakeEnergy(amount);
	}

	public void TakeStamina(int amount)
	{
		characterDefinition.TakeStamina(amount);
	}
	#endregion

	#region Reporters
	public float GetHealth() { return characterDefinition.currentHealth; }
	public int GetMaxHealth() { return characterDefinition.maxHealth; }
	public float GetEnergy() { return characterDefinition.currentEnergy; }
	public int GetMaxEnergy() { return characterDefinition.maxEnergy; }
	public float GetStamina() { return characterDefinition.currentStamina; }
	public int GetMaxStamina() { return characterDefinition.maxStamina; }
	public int GetDamage() { return characterDefinition.currentDamage; }
	public int GetBaseDamage() { return characterDefinition.baseDamage; }
	public int GetDefense() { return characterDefinition.currentDefense; }
	public int GetBaseDefense() { return characterDefinition.baseDefense; }
	public int GetSpeed() { return characterDefinition.currentSpeed; }
	public int GetMaxSpeed() { return characterDefinition.maxSpeed; }
	public int GetExperience() { return characterDefinition.currentExperience; }
	public int GetRequiredExp() { return characterDefinition.requiredExperience; }
	public int GetLevel() { return characterDefinition.currentLevel; }
    #endregion
}
