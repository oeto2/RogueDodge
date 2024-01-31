using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerTransform.GetComponent<PlayerStats>().PlayerDamaged(damage);
            gameObject.SetActive(false);
           
        }
    }
}
