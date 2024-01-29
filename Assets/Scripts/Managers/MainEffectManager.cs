using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEffectManager : MonoBehaviour
{
    public static MainEffectManager Instance;

    [SerializeField] AudioClip PlayerSwordAtkSound;
    [SerializeField] AudioClip PlayerBowAtkSound;
    [SerializeField] AudioClip PlayerStaffAtkSound;
    [SerializeField] AudioClip PlayerHitSound;
    [SerializeField] AudioClip PlayerDeadSound;

    [SerializeField] AudioClip MonsterAtkSound;
    [SerializeField] AudioClip MonsterHitSound;
    [SerializeField] AudioClip MonsterDeadSound;

    AudioSource EffectAudioSource;

    private bool isPlayerDead;

    private void Awake()
    {
        Instance = this;
        EffectAudioSource = this.gameObject.GetComponent<AudioSource>();
    }


    #region Player Effect Sounds
    public void PlayPlayerAtkSound()
    {
        PlayerStats playerStatsScript = GameManager.Instance.player.GetComponent<PlayerStats>();

        if (!playerStatsScript.isDead)
        {
            WEAPONTYPE eWeaponType = playerStatsScript.eEquipWeaponType;

            switch (eWeaponType)
            {
                case WEAPONTYPE.SWORD:
                    EffectAudioSource.PlayOneShot(PlayerSwordAtkSound);
                    break;

                case WEAPONTYPE.STAFF:
                    EffectAudioSource.PlayOneShot(PlayerStaffAtkSound);
                    break;

                case WEAPONTYPE.BOW:
                    EffectAudioSource.PlayOneShot(PlayerBowAtkSound);
                    break;
            }
        }
    }

    public void PlayPlayerHitSound()
    {
        PlayerStats playerStatsScript = GameManager.Instance.player.GetComponent<PlayerStats>();

        if (!playerStatsScript.isDead)
            EffectAudioSource.PlayOneShot(PlayerHitSound);
    }
    public void PlayPlayerDeadSound()
    {
        if (!isPlayerDead)
        {
            EffectAudioSource.PlayOneShot(PlayerDeadSound);
            isPlayerDead = true;
        }
    }
    #endregion


    #region Monster Effect Sounds
    public void PlayMonsterHitSound() => EffectAudioSource.PlayOneShot(MonsterHitSound);
    public void PlayMonsterAtkSound() => EffectAudioSource.PlayOneShot(MonsterAtkSound);
    public void PlayMonsterDeadSound() => EffectAudioSource.PlayOneShot(MonsterDeadSound);
    #endregion
}
