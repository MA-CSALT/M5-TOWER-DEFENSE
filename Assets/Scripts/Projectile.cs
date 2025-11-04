using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed = 10;
  //  public static event Action DamageEnemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null || target.gameObject.IsDestroyed())
        {
            //Debug.Log("destroying projectile " + gameObject + " ");// target.gameObject.name);
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
            return;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") 
        {
            //DamageEnemy?.Invoke();
            //Debug.Log("destroying projectile " + gameObject + " ");// + target.gameObject.name);
            Destroy(gameObject);
        }


    }
}
