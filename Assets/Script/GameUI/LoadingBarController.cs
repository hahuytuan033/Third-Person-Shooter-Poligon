using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tundayne
{
    public class LoadingBarController : MonoBehaviour
    {
        public Slider loadingSlider;
        public TMP_Text percentageText;
        public float duration = 2f;

        void Start()
        {
            StartCoroutine(AnimateLoadingBar());
        }

        IEnumerator AnimateLoadingBar()
        {
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float progress = elapsedTime / duration;
                loadingSlider.value = progress;
                percentageText.text = Mathf.RoundToInt(progress * 100) + "%";

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Đảm bảo giá trị cuối cùng là 100%
            loadingSlider.value = 100f;
            percentageText.text = "100%";

            Debug.Log("Hoàn thành quá trình chạy thanh loading.");
        }
    }
}
