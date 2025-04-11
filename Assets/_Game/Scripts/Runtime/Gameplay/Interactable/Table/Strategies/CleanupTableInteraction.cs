﻿using Cysharp.Threading.Tasks;
using Game.Runtime.Framework.Services.Game;
using Game.Runtime.ServiceLocator;

namespace Game.Runtime.Gameplay.Interactives
{
    public class CleanupTableInteraction : IInteraction
    {
        public string DebugName => nameof(CleanupTableInteraction);

        public void ExecuteInteraction(InteractableObject interactable)
        {
            var gameService = ServiceLocator<GameService>.GetService();
            var orderData = gameService.GetOrderByTable(interactable.Id);
            if (orderData != null) gameService.CleanupTable(orderData);
        }
    }
}