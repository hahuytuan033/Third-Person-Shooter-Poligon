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
        public GameSettings gameSettings;
        bool updateUI;


        void Start()
        {
            if (gameSettings == null)
            {
                gameSettings = Resources.Load("GameSettings") as GameSettings;
            }
            gameSettings.r_manager.Init();
            InitInGame();
        }

        public void InitInGame()
        {
            p_references.Init();
            if (states.r_manager == null)
            {
                states.r_manager = gameSettings.r_manager;
            }
            states.LoadPlayerprofile(gameSettings.playerProfile, gameSettings.r_manager);
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

            //cameraHandler.FixedTick(delta);


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

            if (states.rigid.velocity.sqrMagnitude > 0.5f)
            {
                p_references.targetSpread.value = 250;
            }
            // else
            // {
            //     p_references.targetSpread.value = 30;
            // }
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
            if (reloadInput)
            {
                bool isReloading = states.Reload();
                if (isReloading)
                {
                    aimInput = false;
                    shootInput = false;
                    updateUI = true;
                }
            }

            states.statesManager.isAiming = aimInput;
            if (shootInput)
            {
                states.statesManager.isAiming = true;
                bool shootActual = states.ShootWeapon(Time.realtimeSinceStartup);
                if (shootActual)
                {
                    p_references.targetSpread.value += 80;
                    updateUI = true;
                }
            }

            p_references.isAiming.value = states.statesManager.isAiming;

            if (pivotInput)
            {
                p_references.isLeftPivot.value = !p_references.isLeftPivot.value;
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
            pivotInput = Input.GetButtonDown(StaticStrings.Pivot);
            reloadInput = Input.GetButtonDown(StaticStrings.Reload);
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
            p_references.curCarrying.value = r.curCarrying;
        }
        #endregion
    }

    public enum GamePhase
    {
        inGame,
        inMenu
    }
}

