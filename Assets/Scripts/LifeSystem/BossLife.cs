using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : LifeSystem
{
    [Header("BossSettings")]
    //[SerializeField] private GameObject weaponDropped;
    [SerializeField] private GameObject damageText;

   /*
    void DropWeapon()
    {
        if (weaponDropped != null)
        {
            Instantiate(weaponDropped, transform.position, transform.rotation);
        }
    }
    */
    public override void OnDamage(int dmg)
    {
        base.OnDamage(dmg);
        if (damageText != null)
        {
            string dano = dmg.ToString();
            var damage = Instantiate(damageText, transform.position, Quaternion.identity);
            damage.SendMessage("SetText", dano);
        }
        if (currentLife <= 0)
        {
            
            //DropWeapon();
            Destroy(gameObject);
        }

    }
}
