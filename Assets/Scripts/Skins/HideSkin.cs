using System;
using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "HideSkin", menuName = "ScriptableObjects/HideSkin")]
    public class HideSkin : Skin
    {
        public HideSkinType type;
    }
}