using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSlot : MonoBehaviour, IDropHandler
{
    [Header("DragSettings")]
    [SerializeField] private WeaponDrag weaponDragReference;
    [Header("TransformSettings")]
    [SerializeField] private Transform playerSlotTransf;
    [SerializeField] private Transform outsideTransf;
    //[Header("ShopSettings")]
    private PlayerCoin pCoin;

    void Start()
    {
        pCoin = FindObjectOfType<PlayerCoin>();
    }
    public void OnDrop(PointerEventData eventData)//
    {
        GameObject dropped = eventData.pointerDrag;
        WeaponDrag weap = dropped.GetComponent<WeaponDrag>();
        if(weap.IsBought == false)//Se ela ainda nao foi comprada...
        {
            BuyWeapon(weap.CostOfWeapon);
            weap.IsBought = true;
        }
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
    void BuyWeapon(int price)
    {
        pCoin.SetCoins(price, -1);
        
    }
    void SetNewParent(Transform thisTransf, Transform newParent)
    {
        thisTransf.SetParent(newParent);
        thisTransf.localPosition = Vector3.zero;
    }
}
