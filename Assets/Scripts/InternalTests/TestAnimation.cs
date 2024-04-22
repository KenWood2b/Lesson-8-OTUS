using System;
using Components;
using UnityEngine;

namespace InternalTests
{
    public class TestAnimation : MonoBehaviour
    {
        /*
         * Размеры и положения кнопок сделаны исходя из расширения по умолчанию для данного проекта 1024х576
         */
        
        [SerializeField] private HealthComponent _healthComponent;

        private void Awake()
        {
            if (!_healthComponent) throw new NotSupportedException("[TestAnimation]: Not init _healthComponent");
        }
        
        void OnGUI()
        {
            GUIStyle defaultGUIStyleButton = GUI.skin.button;

            GUIStyle customGUIStyleButton = new GUIStyle(defaultGUIStyleButton)
            {
                fontSize = 20 //must be int, obviously...
            };

            if (GUI.Button(new Rect(10, 50, 150, 50), "Make Damage", customGUIStyleButton))
                TestOnDamage();

            if (GUI.Button(new Rect(10, 150, 150, 50), "Make Death", customGUIStyleButton))
                TestOnDeath();
        }

        private void TestOnDamage()
        {
            if (_healthComponent.Health < 2)
            {
                if (_healthComponent.Health < 1)
                {
                    TestOnDeath();
                    return;
                }
                Debug.LogWarning("Can't Make Demage because I'm not Killer");
                return;
            }
            Debug.Log("Make Damage");
            _healthComponent.TakeDamage(1);
        }
        
        private void TestOnDeath()
        {
            if (_healthComponent.Health < 1)
            {
                Debug.LogWarning("Can't Make Death because I'm not working with corpses ");
                return;
            }
            Debug.Log("Make Death");
            _healthComponent.TakeDamage(_healthComponent.Health);
        }
    }
}