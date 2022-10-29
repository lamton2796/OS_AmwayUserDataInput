using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkcupGames {
    public class UIEffect : MonoBehaviour {
        public List<UIEffectElement> elements;
        public bool doEffectOnEnable = false;

        private void OnEnable() {
            if (doEffectOnEnable) {
                DoEffect();
            }
        }

        public void DoEffect() {
            gameObject.SetActive(true);

            for (int i = 0; i < elements.Count; i++) {
                elements[i].PrepareEffect();
            }

            StartCoroutine(IEDoEffect());
        }

        public IEnumerator IEDoEffect() {
            for (int i = 0; i < elements.Count; i++) {
                yield return elements[i].IEDoEffect();
            }
        }

        [ContextMenu("ContextMenu")]
        public void ContextMenu() {
            Debug.Log("Do someething");
            elements = new List<UIEffectElement>();
            elements.AddRange(gameObject.GetComponentsInChildren<UIEffectElement>());
        }
    }
}

