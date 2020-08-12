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

            _IDFA.text = AdvertisingIdentifierController.GetIDFA();
            
            _requestIDFA.onClick.AddListener(OnRequestAuthorizationHandler);
        }

        public void OnDestroy()
        {
            _requestIDFA.onClick.RemoveListener(OnRequestAuthorizationHandler);
        }

        private void OnRequestAuthorizationHandler()
        {
            AdvertisingIdentifierController.RequestAuthorization(RequestAuthorizationHandler);
        }

        private void RequestAuthorizationHandler(ATTrackingManagerAuthorizationStatus status)
        {
            _authorizationStatus.text = "Updated: " + status;
        }
    }
}