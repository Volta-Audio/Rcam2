using UnityEngine;
using UnityEngine.UI;

namespace Rcam2 {

sealed class StatusView : MonoBehaviour
{
    [SerializeField] Camera _camera = null;
    [SerializeField] Text _statusText = null;
        [SerializeField] Text _batteryLevelText = null;

        public static string Format(Vector3 v)
      => $"({v.x,7:F2}, {v.y,7:F2}, {v.z,7:F2})";

    void Update()
    {
#if UNITY_IOS
            var batteryLevel = SystemInfo.batteryLevel;
            _batteryLevelText.text = (batteryLevel * 100f).ToString() + "%";
            if (batteryLevel <= 0.3f)
            {
                _batteryLevelText.color = Color.red;
            }
            else
            {
                _batteryLevelText.color = Color.green;
            }
#endif
            _statusText.text =
        "Position: " + Format(_camera.transform.position) + "\n" +
        "Rotation: " + Format(_camera.transform.rotation.eulerAngles);
    }
}

} // namespace Rcam2
