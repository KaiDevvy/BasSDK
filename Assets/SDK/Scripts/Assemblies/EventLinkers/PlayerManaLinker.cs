﻿#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
using System;
#endif
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ThunderRoad
{
    [HelpURL("https://kospy.github.io/BasSDK/Components/ThunderRoad/FocusLinker")]
    [AddComponentMenu("ThunderRoad/Player Mana Linker")]
    public class PlayerManaLinker : EventLinker
    {
        public enum PlayerManaEvent
        {
            OnLinkerStart = 0,
            OnFocusDepleted = 1,
            OnFocusConsumed = 2,
            OnFocusGained = 3,
            OnFocusFilled = 4,
            OnSpellLoaded = 5,
            OnSpellUnloaded = 6,
            OnPowerUseStart = 7,
            OnPowerUseEnd = 8,
            OnPowerUnuseStart = 9,
            OnPowerUnuseEnd = 10,
            OnMergeLoaded = 11,
            OnMergeUnloaded = 12,
            OnStartCast = 13,
            OnChargeStart = 14,
            OnChargeMax = 15,
            OnChargeSprayable = 16,
            OnChargeThrowable = 17,
            OnSprayStart = 18,
            OnSprayEnd = 19,
            OnChargeStop = 20,
            OnStopCast = 21,
            OnMergeStart = 22,
            OnMergeCharged = 23,
            OnMergeFireStart = 24,
            OnMergeFireEnd = 25,
            OnMergeStop = 26,
        }

        [System.Serializable]
        public class PlayerManaUnityEvent
        {
            public PlayerManaEvent manaEvent;
            [Tooltip("Only applies to the focus consumed/gained events!")]
#if ODIN_INSPECTOR
            [MinMaxSlider(0f, 1f)]
#endif
            public Vector2 focusPercentRange = new Vector2(0f, 1f);
            public string spellID;
            public SideSelection casterSide = SideSelection.Either;
            public UnityEvent onActivate;
        }

        public enum SideSelection
        {
            Right = 0,
            Left = 1,
            Either = 2,
        }

        public List<PlayerManaUnityEvent> manaEvents = new List<PlayerManaUnityEvent>();


        public override void UnsubscribeNamedMethods()
        {
        }

        public void TryLoadSpellRight(string spellID)
        {
        }

        public void TryLoadSpellLeft(string spellID)
        {
        }

        public void EnableTK(string side)
        {
        }

        public void DisableTK(string side)
        {
        }

        public void ChangeFocusClamped(float amount)
        {
        }

        public void ChangeFocusUnclamped(float amount)
        {
        }

        public void CastRight(bool press)
        {
        }

        public void CastLeft(bool press)
        {
        }

        public void PowerButtonDown(string powerID)
        {
        }

        public void PowerButtonUp(string powerID)
        {
        }

    }
}
