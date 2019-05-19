﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter {
    public class PlayerController : SpaceShip
    {
        private Vector2 axisRotation;
        private Transform cameraTransform;
        private Quaternion cameraRot;
        private Transform playerTransform;
        private Quaternion playerRot;
        [SerializeField] bool smooth;
        [SerializeField] float smoothTime;
        [SerializeField] bool limitCamerRot;
        [SerializeField] float minAngle = -60;
        [SerializeField] float maxAngle = 60;
	    [SerializeField] float mouseSensitivty = 3.0f;
        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
		    Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
        }

        protected override void UpdateControlls() 
        {
            if(InputManager.Instance.GetButtonDown(InputManager.MiniGameButtons.BUTTON1)){
                Shoot();
            }
            if(InputManager.Instance.GetButton(InputManager.MiniGameButtons.BUTTON4)){
                Accelerate();
            }

            inputRotation.y = Input.GetAxis("Mouse X");
            inputRotation.x = -Input.GetAxis("Mouse Y");

        }
        void OnTriggerEnter(Collider other){
            if(other.name.ToLower().Contains("ring")){
                Debug.Log("HIT");
                health--;
                if(health <= 0)
                    spaceManager.EndGame(false);
            }
            else if(other.name.ToLower().Contains("innerzone")){
                Debug.Log("SCORE");
                spaceManager.score++;
            }
            else if(other.name.ToLower().Contains("bullet")){
                if(health <= 0)
                    spaceManager.EndGame(false);
            }
        }
    }
}
