﻿using Common.Editor.Data.Entities;

namespace App.BaseGameEditor.Data.Entities.BaseGame
{
    public class ChassisHandlingEntity : EntityBase
    {
        public int TeamId { get; set; }
        public int Value { get; set; }
    }
}