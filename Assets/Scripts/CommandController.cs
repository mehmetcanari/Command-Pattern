using System.Collections.Generic;
using UnityEngine;

namespace MehmetCanAri.Commands
{
    public class CommandController : MonoBehaviour
    {
        private Stack<ICommand> _commandList;

        private void Awake()
        {
            _commandList = new Stack<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            _commandList.Push(command);
        }
    
        public void UndoCommand()
        {
            if (_commandList.Count == 0) return;
            _commandList.Pop().Undo();
        }
    }

    public interface ICommand
    {
        void Execute();
    
        void Undo();
    }
}

