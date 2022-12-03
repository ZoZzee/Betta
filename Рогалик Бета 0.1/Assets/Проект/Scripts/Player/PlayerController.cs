using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float playerHP = 100f;
    public static float hpController;

    private float distansHolyWaterPos;
    //private float distansEnemy;
    private int holyWater;
    private int NmberHolyWater;

    private float time;

    private BottleHeal myBottle;

    public GameObject Enemy;
    public GameObject Friend;
    public GameObject HolyW;


    public void Awake()
    {
        playerHP = 100f;
        NmberHolyWater = 1;
        BafHP();
        myBottle = GameObject.Find("HolyWater").GetComponent<BottleHeal>(); // ();
        //InvokeRepeating("DangerZone",1f,0.2f);
    }

    public void BafHP()
    {
        hpController = playerHP;
        Debug.Log(hpController);
    }

    public void HPController()
    {
        playerHP = playerHP > hpController ? hpController : playerHP;
    }

    void ColliderZone()
    {
        if (NmberHolyWater > 0)
        {
            Vector3 playerPos = transform.position;
            Vector3 holyWaterPos = HolyW.transform.position;
            //Vector3 friendPos = Friend.transform.position;
            //distansEnemy = Vector3.Distance(enemyPos, playerPos);
            distansHolyWaterPos = Vector3.Distance(holyWaterPos, playerPos);
            

            if (distansHolyWaterPos <= 3)
            {
                
                int number = holyWater < 3 ? 1 : 0;
                holyWater += number;
                Debug.Log("HolyWater = " + holyWater);
                //Destroy(HolyW.gameObject);
                myBottle.BottleActive();
                NmberHolyWater--;
                
            }
            /*if (distansEnemy <= 5)
            {
                float hp = playerHP <= 100 ? -2f : 0f;
                playerHP += hp;
                //Debug.Log("HP = " + playerHP);
            }
            Debug.Log("HP = " + playerHP);*/
        }
        
    }

    public void HpApdate (float numer , bool damageHp, float damage)
    {
        switch (numer)
        {
            case 1:
                if (playerHP > 0)
                {
                    if (damageHp == true)
                    {
                        float hp = playerHP > 0 ? damage : 0f;
                        playerHP += hp;
                        HPController();
                        Debug.Log("HP = " + playerHP);
                    }
                    if (damageHp == false)
                    {
                        float hp = playerHP > 1 ? damage : 0f;
                        playerHP += hp;
                        HPController();
                        Debug.Log("HP = " + playerHP);
                        
                    }
                }
                else
                {
                    Debug.Log("You are dead");
                }
                break;
            case 2:
                if (playerHP > 0)
                {
                    Debug.Log("HP = " + playerHP);

                    if (holyWater >= 1 && time == 0)
                    {   
                        
                        playerHP += damage;
                        holyWater-=1;
                        HPController();
                        Debug.Log("HP = " + playerHP);
                        myBottle.BottleActive();
                    }
                }
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Friend"))
        {
            bool friend = true;
            HpApdate(1, friend, 10f);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            bool enemy = false;
            HpApdate(1, enemy, -10f);
        }
        if (collision.gameObject.CompareTag("BottleHeal"))
        {
            int number = holyWater < 3 ? 1 : 0;
            holyWater += number;
            Debug.Log("HolyWater = " + holyWater);
            Destroy(HolyW.gameObject);
            NmberHolyWater--;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("BottleHeal"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NmberHolyWater++;
                myBottle.BottleActive();
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Friend"))
        {
            bool friend = true;
            HpApdate(1, friend, 5f);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            bool enemy = false;
            HpApdate(1, enemy, -5f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ColliderZone();

        }

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bool friend = true;
            HpApdate(2, friend, 15f);
        }

    }
}
