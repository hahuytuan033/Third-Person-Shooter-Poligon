using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tundayne
{
    public class InputHandler : MonoBehaviour
    {
        float horizontal;
        float vertical;

        bool aimInput;
        bool sprintInput;
        bool shootInput;
        bool crouchInput;
        bool reloadInput;
        bool switchInput;
        bool pivotInput;

        bool isInit;
        float delta;

        public StatesManager states;
        public CameraHandler cameraHandler;
        public PlayerReferences p_references;
        bool updateUI;


        void Start()
        {
            InitInGame();
        }

        public void InitInGame()
        {
            states.Init();
            cameraHandler.Init(this);
            UpdatePlayerReferencesForWeapon(states.w_manager.GetCurrent());
            updateUI = true;
            isInit = true;
        }

        #region FixedUpdate
        void FixedUpdate()
        {
            if (!isInit)
            {
                return;
            }
            delta = Time.fixedDeltaTime;
            AimPosition();
            GetInputFixedUpdate();
            InGame_UpdateStates_FixedUpdate();
            states.FixedTick(delta);

            cameraHandler.FixedTick(delta);


        }

        void GetInputFixedUpdate()
        {
            vertical = Input.GetAxis(StaticStrings.Vertical);
            horizontal = Input.GetAxis(StaticStrings.Horizontal);
        }

        void InGame_UpdateStates_FixedUpdate()
        {
            states.input.horizontal = horizontal;
            states.input.vertical = vertical;

            states.input.moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));

            Vector3 moveDirection = cameraHandler.mTransform.forward * vertical;
            moveDirection += cameraHandler.mTransform.right * horizontal;
            moveDirection.Normalize();
            states.input.moveDirection = moveDirection;

            states.input.rotateDirection = cameraHandler.mTransform.forward;

            if (states.rigid.velocity.sqrMagnitude > 0)
            {
                p_references.targetSpread.value = 120;
            }
            else
            {
                p_references.targetSpread.value = 30;
            }
        }
        #endregion

        public bool debugAim;

        #region Update
        void Update()
        {
            if (!isInit)
            {
                return;
            }
            delta = Time.deltaTime;
            AimPosition();
            GetInput_Update();

            InGame_UpdateStates_Update();

            if (debugAim)
            {
                states.statesManager.isAiming = true; ;
            }

            states.Tick(delta);

            if (updateUI)
            {
                updateUI = false;
                UpdatePlayerReferencesForWeapon(states.w_manager.GetCurrent());
                p_references.e_UpdateUI.Raise();
            }
        }

        void InGame_UpdateStates_Update()
        {
            states.statesManager.isAiming = aimInput;
            if (shootInput)
            {
                states.statesManager.isAiming = true;
                bool shootActual = states.ShootWeapon(Time.realtimeSinceStartup);
                if (shootActual)
                {
                    updateUI = true;
                }
            }

        }

        void GetInput_Update()
        {
            aimInput = Input.GetMouseButton(1);
            shootInput = Input.GetMouseButton(0);
            // if (Input.GetKeyDown(KeyCode.M))
            // {
            //     aimInput = !aimInput;
            // }

        }

        void AimPosition()
        {
            Ray ray = new Ray(cameraHandler.camTrans.position, cameraHandler.camTrans.forward);
            states.input.aimPosition = ray.GetPoint(30);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, states.ignoreLayer))
            {
                states.input.aimPosition = hit.point;
            }
        }
        #endregion

        #region Manager Functions
        public void UpdatePlayerReferencesForWeapon(RuntimeWeapon r)
        {
            p_references.curAmmo.value = r.curAmmo;
            p_references.curArrying.value = r.curCarrying;
        }
        #endregion
    }

    public enum GamePhase
    {
        inGame,
        inMenu
    }
}

