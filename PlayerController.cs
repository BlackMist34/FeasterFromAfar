using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Public Fields
    public GameObject cam;
    public float staminaRegen = 1f;
    public float healthRegen = 1f;
    public float energyRegen = 1f;
    #endregion

    private float rotY;
    private GameObject timeManager;

    #region Components
    private Animator anim;
    private CharacterStats stats;
    private CinemachineFreeLook camThirdP;
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        stats = GetComponent<CharacterStats>();
        camThirdP = cam.GetComponent<CinemachineFreeLook>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager");
    }

    private void Start()
    {
        #region Initate Regeneration
        InvokeRepeating("HealthRegen", 0, healthRegen);
        InvokeRepeating("StaminaRegen", 0, staminaRegen);
        InvokeRepeating("EnergyRegen", 0, energyRegen);
        #endregion

        #region Initiate Stats
        stats.characterDefinition.maxHealth = 500;
        stats.characterDefinition.maxStamina = 200;
        stats.characterDefinition.maxEnergy = 750;
        stats.characterDefinition.baseDamage = 10;
        stats.characterDefinition.baseDefense = 10;
        stats.characterDefinition.maxSpeed = 20;

        stats.characterDefinition.currentHealth = stats.GetMaxHealth();
        stats.characterDefinition.currentStamina = stats.GetMaxStamina();
        stats.characterDefinition.currentEnergy = stats.GetMaxEnergy();
        stats.characterDefinition.currentDamage = stats.GetBaseDamage();
        stats.characterDefinition.currentDefense = stats.GetBaseDefense();
        stats.characterDefinition.currentSpeed = stats.GetMaxSpeed();
        stats.characterDefinition.currentExperience = 0;
        stats.characterDefinition.requiredExperience = 500;
        stats.characterDefinition.currentLevel = 1;
        #endregion

        timeManager.GetComponent<TimeManager>().SetStartTime(Time.time);
    }

    void Update()
    {
        #region PlayerMovement

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * stats.characterDefinition.maxSpeed * Time.deltaTime);

        #endregion

        #region CameraMovement

        //the * sensitivity * Time.deltaTime is up here because it can't be applied to Quaternions
        rotY += Input.GetAxis("Mouse X") * camThirdP.m_XAxis.m_MaxSpeed * Time.deltaTime;
        Cursor.lockState = CursorLockMode.Locked;
        transform.rotation = Quaternion.Euler(0f, rotY, 0f);

        #endregion
    }

    #region Regeneration
    public void HealthRegen()
    {
        stats.ApplyHealth(stats.GetMaxHealth()/100);
    }
    public void StaminaRegen()
    {
        stats.ApplyStamina(stats.GetMaxStamina() / 100);
    }
    public void EnergyRegen()
    {
        stats.ApplyEnergy(stats.GetMaxEnergy() / 100);
    }
    #endregion
}