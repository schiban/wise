using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivate : MonoBehaviour
{
    public GameObject player, healthUI, introUI;

    IEnumerator Start()
    {
        // O protagonista e a vida aparece ao fim de 48.8 segundos (tempo do prólogo)
        yield return new WaitForSeconds(48.8f);
        player.SetActive(true);
        healthUI.SetActive(true);


        // O menu pausa ativa quando a timeline termina
        yield return new WaitForSeconds(6.4f);
        introUI.SetActive(false);
    }
}