using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Touch touch;
    Image im;

    private bool blockMovement;//Booleano que sera responsavel por bloquear o movimento se não tiver dinheiro suficiente
    private bool isBought;//Responsavel pra saber se a arma foi comprada
    [Header("TransformSettings")]
    [SerializeField] private Transform weaponReference;//A arma da cena que o objeto arrastavel referencia
    [SerializeField] private Transform initialParent;//guardar a posicao inicial do objeto, em caso de sobreescrita
    private Transform parentTransf;

    [Space]
    [SerializeField] private Transform parentVisible;//Variavel necessária, pois sem ela certas armas acabam ficando atras de outros objs na cena
    //Aqui, temos um obj que esta "por baixo" dos outros objs, permitindo que ele possa estar a frente dos outros
    [Header("ShopSettings")]
    [SerializeField] private int costOfWeapon;
    private PlayerCoin pCoin;
    public Transform ParentTransf { private get => parentTransf; set => parentTransf = value; }
    public Transform WeaponReference { get => weaponReference;  set => weaponReference = value; }
    public Transform InitialParent { get => initialParent; private set => initialParent = value; }
    public bool IsBought { get => isBought; set => isBought = value; }
    public int CostOfWeapon { get => costOfWeapon; private set => costOfWeapon = value; }

    void Start()
    {
        pCoin = FindObjectOfType<PlayerCoin>();
        im = GetComponent<Image>();
        if (!InitialParent)//Se initialParent nao estiver referenciada, referenciamos com o pai atual do objeto
            InitialParent = transform.parent;
        else//Senao, quer dizer que ele ja tem um pai, que aqui, faz referencia ao slot do Player. Logo, é como se a arma ja estivesse comprada
            isBought = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsBought && CostOfWeapon > pCoin.GetCoins())//Se nao tiver dinheiro suficiente
        {
            //Texto de erro
            Debug.LogError("Sem dinheiro pra essa arma!!!");
            blockMovement = true;
        }
            

        im.raycastTarget = false;
        ParentTransf = transform.parent;
        if(Input.touchCount > 0)
            touch = Input.GetTouch(0);
        transform.SetParent(parentVisible);
        //Debug.Log("Começo do drag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (blockMovement)
        {
            return;
        }
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
        if(blockMovement)
        {
            //Desaparecer texto de erro
            blockMovement = false;
        }
        im.raycastTarget = true;
        transform.SetParent(ParentTransf);
        transform.localPosition = Vector3.zero;
        //Debug.Log("Fim do drag");
    }
}
