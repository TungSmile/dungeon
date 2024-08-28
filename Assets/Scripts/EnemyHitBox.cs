using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collectable
{
    // damage
    public int damage=1;
    public float pushForce=5 ;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            // Create a nwa damage obj , before sending it o the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
