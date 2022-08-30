using System.Linq;
using TMPro;
using UnityEngine;
namespace MobileDebug
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private float[] _fpsForLastUpdates;
        private uint _updates;
        private void Awake()
        {
            _fpsForLastUpdates = new float[100];
            if (Application.isMobilePlatform)
                QualitySettings.vSyncCount = 0;
        }

        private void Update()
        {
            var fps = 1 / Time.deltaTime;
            _updates++;
            _fpsForLastUpdates[_updates % (_fpsForLastUpdates.Length)] = fps;
            _text.text = $"fps:{fps:0.0}\nAverage:{_fpsForLastUpdates.Sum()/_fpsForLastUpdates.Length:0.0}";
        }
    }
}