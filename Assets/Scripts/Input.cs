using UnityEngine;

namespace MehmetCanAri.Commands
{
    public abstract class Input : MonoBehaviour
    {
        protected bool OnClicked()
        {
            if (!UnityEngine.Input.GetMouseButtonDown(0)) return false;

            return true;
        }
    
        protected bool OnKeyboardClick(KeyCode keyCode)
        {
            if (!UnityEngine.Input.GetKeyDown(keyCode)) return false;

            return true;
        }
    }
}
