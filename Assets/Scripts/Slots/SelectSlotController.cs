using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSlotController : MonoBehaviour
{
    [SerializeField] private SelectSlot[] allSlots;
    private WeaponDrag[] allWeapons = new WeaponDrag[3];
    void Start()
    {
        for(int i = 0; i < allSlots.Length; i++)
        {
            if (allSlots[i].WeaponDragReference)
                allWeapons[i] = allSlots[i].WeaponDragReference;
        }
    }

    // Update is called once per frame
    public void OnChangeWeaponDrag(WeaponDrag w)
    {
        /*
        for(int i = 0; i < allWeapons.Length; i++)
        {
            if(allWeapons[i] != null && allWeapons[i] == w)
            {
                allSlots[i].WeaponDragReference = null;
            }
        }
        */
        for(int i = 0; i < allSlots.Length; i++)
        {
            if(allSlots[i] != null && allSlots[i].WeaponDragReference == w)
            {
                allSlots[i].WeaponDragReference = null;
            }
        }
    }
}
