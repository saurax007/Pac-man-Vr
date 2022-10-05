using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MyCameraPointer : MonoBehaviour {

        

        private const float maxDistance = 50f;
        EventosTrigger trigger = null;

       

        void Update() {

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistance)) {
                
                EventosTrigger trigger = hit.transform.GetComponent<EventosTrigger>();
                if (trigger != null && trigger != this.trigger) 
                {
                    if (this.trigger)
                    {
                        trigger.PointerExit();
                    }
                
                        this.trigger = trigger;
                        trigger.PointerEnter();
                }
                
                if (trigger == null) {

                    if (this.trigger)
                    {
                    this.trigger.PointerExit();
                    }
                    
                    this.trigger = null;
                }


            } else 
            {
            
                if (this.trigger)
                {
                    trigger.PointerExit();
                }
                
                trigger = null;
            }

            // Checks for screen touches.
            //if (Google.XR.Cardboard.Api.IsTriggerPressed) {
            //    trigger.PointerDown();
            //}
        }
    }
