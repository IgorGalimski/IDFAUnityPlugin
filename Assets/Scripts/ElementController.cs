using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ElementController : MonoBehaviour
    {
        [SerializeField] 
        private Text _authorizationStatus;
        
        [SerializeField] 
        private Text _isNeedToRequestIDFA;

        [SerializeField] 
        private Text _IDFA;

        [SerializeField] 
        private Button _requestIDFA;

        public void OnEnable()
        {
            _authorizationStatus.text = "Status: " + AdvertisingIdentifierController.GetAuthorizationStatus(); 
            
            _isNeedToRequestIDFA.text = "IsNeedToRequestIDFA:" + AdvertisingIdentifierController.IsNeedToRequestIDFA();

            _IDFA.text = AdvertisingIdentifierController.GetIDFA().ToString();
            
            _requestIDFA.onClick.AddListener(OnRequestIDFA);
        }

        public void OnDestroy()
        {
            _requestIDFA.onClick.RemoveListener(OnRequestIDFA);
        }

        private void OnRequestIDFA()
        {
            
        }
    }
}