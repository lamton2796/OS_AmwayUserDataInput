using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SplashingLight : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    public GameObject light;

    private void Start() {
        StartCoroutine(IEEffect());
    }
    IEnumerator IEEffect() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0f, 1f));

            light.SetActive(true);
            light.transform.position = position1.transform.position;
            light.transform.DOMove(position2.transform.position, 2f).OnComplete(() => {
                light.SetActive(false);
            });

            yield return new WaitForSeconds(Random.Range(3f, 4f));
        }
    }
}
