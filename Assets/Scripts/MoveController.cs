using UnityEngine;

namespace MehmetCanAri.Commands
{
    public class MoveController : Input
    {
        [SerializeField] private CommandController commandController;
        private void Update()
        {
            if (OnClicked())
            {
                CallMove();
            }

            if (OnKeyboardClick(KeyCode.U))
            {
                CallUndo();
            }
        }

        private void CallMove()
        {
            var ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (!hit.transform.TryGetComponent(out CubeObject cubeObject)) return;
                cubeObject.MoveToSlot();
            }
        }

        private void CallUndo()
        {
            commandController.UndoCommand();
        }
    }
}
