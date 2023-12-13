using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Touch touch;
    Image im;
    [SerializeField] private Transform weaponReference;

    [SerializeField] private Transform initialParent;//guardar a posicao inicial do objeto, em caso de sobreescrita
    private Transform parentTransf;
    [Space]
    [SerializeField] private Transform parentVisible;//Variavel necessária, pois sem ela certas armas acabam ficando atras de outros objs na cena

    public Transform ParentTransf { private get => parentTransf; set => parentTransf = value; }
    public Transform WeaponReference { get => weaponReference;  set => weaponReference = value; }
    public Transform InitialParent { get => initialParent; private set => initialParent = value; }

    //Aqui, temos um obj que esta "por baixo" dos outros objs, permitindo que ele possa estar a frente dos outros
    void Start()
    {
        im = GetComponent<Image>();
        if(!InitialParent)
            InitialParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        im.raycastTarget = false;
        ParentTransf = transform.parent;
        if(Input.touchCount > 0)
            touch = Input.GetTouch(0);
        transform.SetParent(parentVisible);
        //Debug.Log("Começo do drag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(Input.touchCount > 0)//Movimentação das armas pelo celular
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            transform.position = touchPos;
        }
        else//Joel-Movimentacao pelo PC apenas para testar, pois estou com problemas para conectar o cel no Pc
        {
            transform.position = Input.mousePosition;
        }
        //Debug.Log("Drag");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        im.raycastTarget = true;
        transform.SetParent(ParentTransf);
        transform.localPosition = Vector3.zero;
        //Debug.Log("Fim do drag");
    }
}
