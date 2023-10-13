using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour//Com certeza esse script nao foi feito seguindo as melhores praticas(dava pra isso tranquilamente ser
//um script pai e 3 filhos), mas como estamos com o tempo apertado, vou tentar refazer ele apenas se sobrar tempo das outras tarefas.
{
    [SerializeField] protected int currentLife;
    protected int maxLife;
    
    void Start()
    {
        maxLife = currentLife;
    }
    
    
    public virtual void OnDamage(int dmg)
    {
        currentLife -= dmg;
    }
}
