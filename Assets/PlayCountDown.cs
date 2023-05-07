using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class PlayCountDown : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text tmpText;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip countdownClip;
    public UnityEvent OnStart;
    public UnityEvent OnEnd;
    
    private void Start()
    {
        OnStart.Invoke();
        var sequence = DOTween.Sequence();
        tmpText.transform.localScale = Vector3.zero;
        tmpText.text = "3";
        audioManager.PlaySFX(countdownClip);
        sequence.Append(tmpText.transform.DOScale(
                Vector3.one,
                1).OnComplete(() =>
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "2";
            }));

        sequence.Append(tmpText.transform.DOScale(
                Vector3.one,
                1).OnComplete(() =>
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "1";
            }));

        sequence.Append(tmpText.transform.DOScale(
                Vector3.one,
                1).OnComplete(() =>
            {
                tmpText.transform.localScale = Vector3.zero;
                tmpText.text = "GO";
                OnEnd.Invoke();
            }));
   }
}
