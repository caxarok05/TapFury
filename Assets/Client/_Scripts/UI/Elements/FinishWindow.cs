using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Scripts.UI.Elements
{
    public class FinishWindow : MonoBehaviour
    {
        public GameObject window;

        private IBossHpHandler _hpHandler;

        [Inject]
        public void Construct(IBossHpHandler hpHandler)
        {
            _hpHandler = hpHandler;
            _hpHandler.OnBossDefeated += ShowFinishWindow;
        }

        private void ShowFinishWindow()
        {
            window.SetActive(true);
        }


    }
}
