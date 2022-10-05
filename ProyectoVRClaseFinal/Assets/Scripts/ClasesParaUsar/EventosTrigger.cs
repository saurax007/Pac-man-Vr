using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



    public class EventosTrigger : MonoBehaviour {
       
        [SerializeField] UnityEvent OnPointerEnter;
        [SerializeField] UnityEvent OnPointerDown;
        [SerializeField] UnityEvent OnPointerUp;

        
        [SerializeField] float duration = 3f;

        

        int state = 0;
        float t1 = 0, t2 = 0;

        void Awake() {
          
        }

        void Update() {
           
            
            if (state == 1)
            {
                
                if (t1 >= duration)
                {
                    PointerDown();
                    t1 = 0;
                    state = 2;
                }
                t1 += Time.deltaTime;
            }

            if (state == 3)
            {
                t2 += Time.deltaTime;
                if (t2 >= duration)
                {
                   
                    t1 = 0;
                    t2 = 0;
                    state = 0;
                }
            }
            Debug.Log("Estado: "+state);
        }

        public void PointerEnter() {
            print("Pointer enter");
            
            if (state == 0 || state == 3)
            {
                
                print("Pointer enter");
               OnPointerEnter.Invoke();
             

                t2 = 0;
                state = 1;
            }
        }

        public void PointerDown() {
            print("Pointer down");
           OnPointerDown.Invoke();
        }

        public void PointerExit() {
            print("Pointer exit");
            OnPointerUp.Invoke();
            
            if (state == 1)
            { 
               
                state = 3;
            }
            
            else
            {
               
                state = 0;
            }
        }
        
    }

   
