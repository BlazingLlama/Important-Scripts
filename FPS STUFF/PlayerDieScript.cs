using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieScript : MonoBehaviour
{

   //MADE BY BLAZINGLLAMA
   //USED TO TAKE DAMAGE FROM ANY KIND OF PROJECTILE JUST SET THE BULLET/PROJECTILE AS A THE BULLET TAG OR MAKE YOUR OWN TAG AND CHANGE THE BULLET TAG TO IT ON LINE 47
   //NEEDS TO BE PAIRED WITH DAMAGEAMOUNT.CS PLACE DAMAGEAMOUNT.CS IN THE BULLET/PROJECTILE PREFAB AND SET THE DAMAGE
   //ALSO HAS RESPAWN, RESPAWN TIME, AND OTHER RESPAWN STUFF
   
   //NEED HELP SETTING UP? MY DISCORD: BlazingLlama#2782

    public float Health = 100f;
    [SerializeField] private GameObject PlayerDie;
    [SerializeField] private GameObject DeadCam;
    [SerializeField] private GameObject DeadCamControl;
    [SerializeField] private GameObject PlayerCam;
    [SerializeField] private float RespawnTime;
    [SerializeField] private Transform[] RespawnPoints;

 
    bool isDead;
    float Damage;
    private Transform RespawnPosition;
    private Transform AvaivableRespawns;
    public MonoBehaviour[] MoveScripts;


    void Start()
    {
        NewRespawn();

        respawn();


        DeadCam.SetActive(false);
        DeadCamControl.SetActive(false);
    }
         
    

    void Update()
    {
        NewRespawn();
    }

   void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Bullet")
        {
            
            
            Damage = colInfo.collider.transform.GetComponent<DamageAmount>().BulletDamage;
            

            TakeDamage();
        }
    }

   

    public void TakeDamage()
    {
        Health -= Damage;

        if (Health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        foreach (MonoBehaviour script in MoveScripts)
        {
            script.enabled = false;
        }

        
        PlayerCam.SetActive(false);
        DeadCam.SetActive(true);
        DeadCamControl.SetActive(true);

        Invoke ("respawn", RespawnTime);
    }


    void NewRespawn()
    {
        RespawnPosition = RespawnPoints[Random.Range(0, RespawnPoints.Length)];
        
    }
      
    

    void respawn()
    {
        transform.position = RespawnPosition.position;       

        Health = 100f;

        foreach (MonoBehaviour script in MoveScripts)
        {
            script.enabled = true;
        }


        PlayerCam.SetActive(true); 
        DeadCam.SetActive(false);
        DeadCamControl.SetActive(false);
    }
}
