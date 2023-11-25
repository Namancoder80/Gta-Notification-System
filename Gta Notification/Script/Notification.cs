using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TeamFlyer.Message
{
    public class Notification : MonoBehaviour
    {
        [SerializeField] private GameObject NotificationPrefab;
        [SerializeField] private GameObject NotificationParent;
        private List<GameObject> SpawnNotification = new List<GameObject>();
        public void ShowNotification(string Message)
        {
            StartCoroutine(CreateNotification(Message));
        }
        private IEnumerator CreateNotification(string Subtitle)
        {
            GameObject _Notification = Instantiate(NotificationPrefab, NotificationParent.transform);
            SpawnNotification.Add(_Notification);

            for (int i = 0; i < SpawnNotification.Count; i++)
            {
                GameObject popup = SpawnNotification[i];
                TMP_Text[] TextHolder = popup.GetComponentsInChildren<TMP_Text>();
                if (TextHolder != null)
                {
                    TMP_Text _Subtitle = TextHolder[1];
                    _Subtitle.text = Subtitle;
                }
            }
            yield return new WaitForSeconds(6f);

            for (int i = 0; i < SpawnNotification.Count; i++)
            {
                GameObject popup = SpawnNotification[i];
                CanvasGroup canvasGroup = popup.GetComponent<CanvasGroup>();
                if (canvasGroup != null)
                {
                    canvasGroup.LeanAlpha(0, 1.5f);
                }
            }
            yield return new WaitForSeconds(2f);

            for (int i = 0; i < SpawnNotification.Count; i++)
            {
                Destroy(SpawnNotification[i]);
                SpawnNotification.RemoveAt(i);
            }

        }
    }
}