using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ElementController : MonoBehaviour
    {
        [SerializeField] 
        private Text _IDFA;
        
        [SerializeField] 
        private Text _authorizationStatus;
        
        [SerializeField] 
        private Text _updatedAuthorizationStatus;
        
        [SerializeField] 
        private Text _isNeedToRequestIDFA;

        [SerializeField] 
        private Button _requestIDFA;

        public void OnEnable()
        {
            _IDFA.text = AdvertisingIdentifierController.GetIDFA();

            _authorizationStatus.text += AdvertisingIdentifierController.GetAuthorizationStatus(); 
            
            _isNeedToRequestIDFA.text += AdvertisingIdentifierController.IsNeedToRequestIDFA();

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
            _updatedAuthorizationStatus.text += status;
        }
    }
}