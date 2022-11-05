using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //Public field
    public int hitpoint = 10;
    public int maxHitpoints = 10;
    public float pushRecoverySpeed = 0.2f;

    //Immunity
    protected float immuneTime = 1f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //All fighters can receive damage //die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmounts;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            
            GameManager.instance.ShowText(dmg.damageAmounts.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }

        }
    }
    protected virtual void Death()
    {

    }
    
}
