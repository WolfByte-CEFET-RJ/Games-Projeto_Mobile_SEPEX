using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private WeaponDrag weaponDragReference;//Não precisava de visualizacao no inspector, so estou fazendo isso por testes
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
            
            weaponDragReference.WeaponReference.SetParent(playerSlotTransf);
            weaponDragReference.WeaponReference.localPosition = Vector3.zero;
        }
        else
        {
            weaponDragReference.WeaponReference.SetParent(outsideTransf);
            weaponDragReference.WeaponReference.localPosition = Vector3.zero;

            weaponDragReference.transform.SetParent(weaponDragReference.InitialParent);
            weaponDragReference.transform.localPosition = Vector3.zero;

            weaponDragReference = weap;
            weaponDragReference.WeaponReference.SetParent(playerSlotTransf);
            weaponDragReference.WeaponReference.localPosition = Vector3.zero;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
