using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class weapon : Colliable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;
    // action swing
    private float cooldown = 0.5f;
    private float lastSwing;
    protected override void Start()

    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;
            // create a new damage object , then we'll send it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
    private void Swing()
    {
        Debug.Log("Swing");
    }
}
