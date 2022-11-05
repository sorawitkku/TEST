using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //damage struc
    public int[] damagePoint = {1, 4, 10};
    public float[] pushForce = { 2.0f, 4.0f, 8.0f };

    //upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spritRenderer;

    //swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    private void Awake()
    {
        spritRenderer = GetComponent<SpriteRenderer>(); 
    }

    protected override void Start()
    {
        base.Start();
        spritRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lastSwing = Time.time;
            Swing();
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if(coll.name != "P'to")
            {

                //create a new damage object, then we will send it to fight we hits
                Damage dmg = new Damage
                {
                    damageAmounts = damagePoint[weaponLevel],
                    origin = transform.position,
                    pushForce = pushForce[weaponLevel]
                };

                coll.SendMessage("ReceiveDamage", dmg);
          
            }

        }
     
    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spritRenderer.sprite = GameManager.instance.weaponSprite[weaponLevel];
        if(weaponLevel == GameManager.instance.weaponSprite.Count)
        {
            weaponLevel = GameManager.instance.weaponSprite.Count;
        }


    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spritRenderer.sprite = GameManager.instance.weaponSprite[weaponLevel];
    }
}
