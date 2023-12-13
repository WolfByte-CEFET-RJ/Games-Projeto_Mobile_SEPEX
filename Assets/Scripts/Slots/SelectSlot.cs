using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private WeaponDrag weaponDragReference;
    [SerializeField] private Transform playerSlotTransf;
    [SerializeField] private Transform outsideTransf;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        WeaponDrag weap = dropped.GetComponent<WeaponDrag>();
        weap.ParentTransf = transform;
        if (!weaponDragReference)//Se o slot esta vazio
        {
            weaponDragReference = weap;

            SetNewParent(weaponDragReference.WeaponReference, playerSlotTransf);
        }
        else
        {
            SetNewParent(weaponDragReference.WeaponReference, outsideTransf);

            SetNewParent(weaponDragReference.transform, weaponDragReference.InitialParent);

            weaponDragReference = weap;
            SetNewParent(weaponDragReference.WeaponReference, playerSlotTransf);
        }
        
    }

    void SetNewParent(Transform thisTransf, Transform newParent)
    {
        thisTransf.SetParent(newParent);
        thisTransf.localPosition = Vector3.zero;
    }
}
