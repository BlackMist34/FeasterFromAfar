using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Attacks
    public Attack_SO baseAttack;
    public AOE_SO aoe;
    public Projectile_SO projectile;
    #endregion

    #region Cooldowns Animations
    public GameObject abilityOneUI;
    public GameObject abilityTwoUI;
    public GameObject abilityThreeUI;

    private AbilityOneCooldown abilityOC;
    private AbilityTwoCooldown abilityTC;
    private AbilityThreeCooldown abilityThC;
    #endregion

    #region Cooldown Timers
    private float timeOfLastAOE;
    private float timeOfLastProjectile;
    private float timeOfLastTimeShift;
    #endregion

    #region Components
    private Transform playerPos;
    private Transform AOEPos;
    private Transform projectilePos;
    private GameObject projectileStartPos;
    private CharacterStats stats;
    private Animator anim;
    #endregion

    private bool isBerserk = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerPos = GetComponent<Transform>();
        stats = GetComponent<CharacterStats>();

        AOEPos = playerPos.GetChild(3).gameObject.transform;
        projectilePos = playerPos.GetChild(4).gameObject.transform;
        projectileStartPos = playerPos.GetChild(5).gameObject;

        abilityOC = abilityOneUI.GetComponent<AbilityOneCooldown>();
        abilityTC = abilityTwoUI.GetComponent<AbilityTwoCooldown>();
        abilityThC = abilityThreeUI.GetComponent<AbilityThreeCooldown>();
    }

    private void Start()
    {
        timeOfLastAOE = float.MinValue;
        timeOfLastProjectile = float.MinValue;
        timeOfLastTimeShift = float.MinValue;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && stats.GetStamina() >= 3)
        {
            StartCoroutine("BaseAttack");
            stats.TakeStamina(3);
        }

        #region Abilities
        float timeSinceLastAOE = Time.time - timeOfLastAOE;
        float timeSinceLastProjectile = Time.time - timeOfLastProjectile;
        float timeSinceLastTimeShift = Time.time - timeOfLastTimeShift;

        if (Input.GetKeyDown(KeyCode.Q) && stats.GetEnergy() >= aoe.cost && !(timeSinceLastAOE < aoe.cooldown))
        {
            abilityOC.Cooldown();
            aoe.Fire(gameObject, AOEPos.position, 11);
            stats.TakeEnergy(aoe.cost);
            timeOfLastAOE = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.E) && stats.GetEnergy() >= projectile.cost && !(timeSinceLastProjectile < projectile.cooldown))
        {
            abilityTC.Cooldown();
            projectile.CastEldritch(gameObject, projectileStartPos, projectilePos.position, 11);
            stats.TakeEnergy(projectile.cost);
            timeOfLastProjectile = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.R) && stats.GetEnergy() >= 500 && !(timeSinceLastTimeShift < 60))
        {
            abilityThC.Cooldown();
            StartCoroutine("Berserk");
            stats.TakeEnergy(500);
            timeOfLastTimeShift = Time.time;
        }
        #endregion
    }

    IEnumerator BaseAttack()
    {
        anim.SetBool("isAttacking", true);

        yield return new WaitForSeconds(.5f);

        anim.SetBool("isAttacking", false);
    }

    IEnumerator Berserk()
    {
        isBerserk = true;

        baseAttack.maxDamage *= 2; 
        baseAttack.minDamage *= 2;

        aoe.maxDamage *= 2;
        aoe.minDamage *= 2;

        projectile.maxDamage *= 2;
        projectile.minDamage *= 2;
        
        yield return new WaitForSecondsRealtime(60f);

        baseAttack.maxDamage /= 2;
        baseAttack.minDamage /= 2;

        aoe.maxDamage /= 2;
        aoe.minDamage /= 2;

        projectile.maxDamage /= 2;
        projectile.minDamage /= 2;

        isBerserk = false;
    }

    public bool GetBerserk()
    {
        return isBerserk;
    }
}
