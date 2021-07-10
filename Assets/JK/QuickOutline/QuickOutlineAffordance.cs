using DG.Tweening;
using JK.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JK.QuickOutline
{
    [RequireComponent(typeof(Outline))]
    public class QuickOutlineAffordance : AffordanceBehaviour
    {
        #region Inspector

        public float alphaSeconds = 0.25f;

        private void Reset()
        {
            var outline = GetComponent<Outline>();
            outline.OutlineMode = Outline.Mode.OutlineAndSilhouette;
            outline.OutlineWidth = 4;
        }

        #endregion

        private Tween tween;
        private Color color;

        protected override void Start()
        {
            base.Start();

            var outline = GetComponent<Outline>();
            color = outline.OutlineColor;
            outline.OutlineColor = GetFadedColor();
        }

        protected override void StartHighlight(RaycastHit hit)
        {
            var outline = GetComponent<Outline>();
            outline.enabled = true;

            if (tween != null)
                tween.Kill();

            tween = DOTween.To(
                () => outline.OutlineColor,
                color => outline.OutlineColor = color,
                color,
                alphaSeconds
            );
        }

        protected override void StayHighlight(RaycastHit hit)
        {
            // nothing to do
        }

        protected override void StopHighlight()
        {
            if (tween != null)
                tween.Kill();
            
            var outline = GetComponent<Outline>();

            tween = DOTween.To(
                () => outline.OutlineColor,
                color => outline.OutlineColor = color,
                GetFadedColor(),
                alphaSeconds
            );

            tween.onComplete += () => outline.enabled = false;
        }

        private Color GetFadedColor()
        {
            Color faded = color;
            faded.a = 0;

            return faded;
        }
    }

    [Serializable]
    public class UnityEventQuickOutlineAffordance : UnityEvent<QuickOutlineAffordance> { }
}