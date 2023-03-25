using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

namespace MehmetCanAri.Commands
{
    public class CubeObject : MonoBehaviour
    {
        public CommandController commandController;
    
        private List<Slot> targetSlot;
        public void GetAllSlots() => targetSlot = FindObjectsOfType<Slot>().ToList();
        public Slot GetRandomSlot() => targetSlot[Random.Range(0, targetSlot.Count)];

        private void Awake()
        {
            GetAllSlots();
        }

        public void MoveToSlot()
        {
            var move = new Move(GetRandomSlot().transform, transform, 0.25f) as ICommand;
            commandController.AddCommand(move);
            move.Execute();
        }
    }
}

