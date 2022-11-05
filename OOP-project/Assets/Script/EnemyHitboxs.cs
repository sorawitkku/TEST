using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitboxs : Collidable
{
    //Damage
    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "P'to")
        {
            //create a new damage object, then we will send it to fight we hits
            Damage dmg = new Damage
            {
                damageAmounts = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
