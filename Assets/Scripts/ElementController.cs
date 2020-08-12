using UnityEngine;
using UnityEngine.UI;

namespace UDFAUnityPlugin
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
            AdvertisingIdentifierController.ATTrackingManagerAuthorizationStatusEvent += OnATTrackingManagerAuthorizationStatusHandler;
            
            UpdateIDFA();
            UpdateStatuses();

            _requestIDFA.onClick.AddListener(OnRequestAuthorizationHandler);
        }

        public void OnDestroy()
        {
            _requestIDFA.onClick.RemoveListener(OnRequestAuthorizationHandler);
        }

        private void OnRequestAuthorizationHandler()
        {
            AdvertisingIdentifierController.RequestAuthorization();
        }
        
        private void OnATTrackingManagerAuthorizationStatusHandler(ATTrackingManagerAuthorizationStatus status)
        {
            UpdateIDFA();
            
            _updatedAuthorizationStatus.text += status;
        }

        private void UpdateIDFA()
        {
            _IDFA.text = AdvertisingIdentifierController.GetIDFA();
        }

        private void UpdateStatuses()
        {
            _authorizationStatus.text += AdvertisingIdentifierController.GetAuthorizationStatus(); 
            
            _isNeedToRequestIDFA.text += AdvertisingIdentifierController.IsNeedToRequestIDFA();
        }
    }
}