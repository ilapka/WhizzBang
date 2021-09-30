using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

namespace WhizzBang.UI
{
    public class PopUpText : MonoBehaviour
    {
        [SerializeField]  TextMeshProUGUI popUpText;
        [SerializeField] private float lifeTime;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        public void SetText(string text)
        {
            popUpText.text = text;
        }
    }
}
