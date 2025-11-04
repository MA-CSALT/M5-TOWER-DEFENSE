using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;
    [SerializeField] private float shootInterval = 1f;
    [SerializeField] private float nearestDistance = 200f;

    [SerializeField] private float TimePassed = 0f;
    


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootInterval);
        while (true) 
        {
            if(target!=null)
            {



            GameObject projectileGameObject = Instantiate(projectilePrefab);
            projectileGameObject.transform.position = transform.position;
            Projectile projectile = projectileGameObject.GetComponent<Projectile>();
            //Debug.Log("shoot " + target);
            projectile.target = target;
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }
    void Start()
    {
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        TimePassed += Time.deltaTime;
        if (TimePassed > 2f)
        {
            nearestDistance = 40f;
            TimePassed = 0f;
        }

        // Debug.Log("shoot  fetch target");
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].IsDestroyed() == false)
            {
                float distance = Vector3.Distance(transform.position, targets[i].transform.position);
                if (distance < nearestDistance)
                {
                    target = targets[i].transform;
                    nearestDistance = distance;

                    //Debug.Log("current target " + targets[i].name + " " + targets[i]);
                }
                else
                {
                    targets = null;
                    return;
                }
            }

        }
        
    }
}
