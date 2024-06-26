﻿using System;
using Runtime.Enums;
using UnityEngine;

namespace UI.SelectShapeWindow
{
    public class SelectShapeModel
    {
        public SelectorInformation[] SelectorElements;
        public Action changeShaderModeCallback;
    }

    public class SelectorInformation
    {
        public EShapeType type;
        public Sprite icon;
        public Action onSelectCallback;
    }
}