using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Horror
{
    [RequireComponent(typeof(RawImage))]
    public class RenderTextureResizer : MonoBehaviour
    {
        #region Inspector



        #endregion

        [Inject(Id = "player.camera")]
        private Camera playerCamera = null;

        private bool isFirst = true;

        private void Start()
        {
            UpdateRenderTextureSize();
        }

        private RenderTexture UpdateRenderTextureSize()
        {
            var rawImage = GetComponent<RawImage>();
            RenderTexture renderTexture = rawImage.texture as RenderTexture;

            var copy = new RenderTexture(renderTexture)
            {
                height = (int)(renderTexture.width * rawImage.rectTransform.rect.height / rawImage.rectTransform.rect.width),
            };

            copy.filterMode = renderTexture.filterMode;
            rawImage.texture = copy;
            playerCamera.targetTexture = copy;

            renderTexture.DiscardContents();
            renderTexture.Release();

            if (isFirst)
                isFirst = true;
            else
                Destroy(renderTexture);

            //Debug.Log($"updating to {copy.width}x{copy.height}");

            return renderTexture;
        }

        private void OnRectTransformDimensionsChange()
        {
            if (playerCamera != null)
                UpdateRenderTextureSize();
        }
    }
}