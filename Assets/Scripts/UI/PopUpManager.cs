using UnityEngine;

namespace WhizzBang.UI
{
    public class PopUpManager : MonoBehaviour
    {
        [SerializeField] private PopUpText popUpTextPrefab;
        [SerializeField] private Camera mainCamera;

        private static PopUpManager _instance;
        public static PopUpManager Instance { get { return _instance; } }
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else
            {
                _instance = this;
            }
        }

        public void CreatePopUpText(string popUpText, Vector3 position)
        {
            var popUp = Instantiate(popUpTextPrefab, transform);
            popUp.transform.position = mainCamera.WorldToScreenPoint(position);
            popUp.SetText(popUpText);
        }
    }
}
