using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float HP = 100f;
    void Start()
    {
      //  Projectile.DamageEnemy += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Projectile")
        {
            HP -= 25f;
            if (HP <= 0)
            {
                other.gameObject.GetComponent<Projectile>().target = null;
                //Debug.Log("destroying enemy" + gameObject + " " +gameObject.name + " by "+ other.gameObject.name);
                //gameObject.tag = "Untagged";
                Destroy(gameObject);
            }
            if (gameObject == null)
            {
                return;
            }
        }
    }
}
