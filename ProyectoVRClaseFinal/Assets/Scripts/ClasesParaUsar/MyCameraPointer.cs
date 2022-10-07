using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyCameraPointer : MonoBehaviour
{



    private const float maxDistance = 50f;
    EventosTrigger trigger = null;
    [SerializeField] MenuManager menuManager;

    void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }



    void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance))
        {

            EventosTrigger trigger = hit.collider.gameObject.GetComponent<EventosTrigger>();

            if (trigger != null && trigger != this.trigger)
            {
                if (this.trigger)
                {
                    trigger.PointerExit();
                }
                
                this.trigger = trigger;
                trigger.PointerEnter();
                switch (hit.collider.gameObject.name)
                {
                    case "RestartButton":
                        menuManager.RestartButton();
                        break;
                    case "StartButton":
                        menuManager.StartButton();
                        break;
                    case "SettingsButton":
                        menuManager.SettingsButton();
                        break;
                }
            }

            if (trigger == null)
            {

                if (this.trigger)
                {
                    this.trigger.PointerExit();
                }
                menuManager.None();
                this.trigger = null;
            }


        }
        else
        {

            if (this.trigger)
            {
                trigger.PointerExit();
            }
            menuManager.None();
            trigger = null;
        }

        // Checks for screen touches.
        //if (Google.XR.Cardboard.Api.IsTriggerPressed) {
        //    trigger.PointerDown();
        //}
    }
}
