﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Events
{
    public delegate void MouseEventHandler(object sender, MouseEventArgs e);


    public class MouseEventArgs : EventArgs
    {
        
        public float mouseX;
        public float mouseY;
        public UnityEngine.Vector3 worldPos;
        public MouseEventArgs(UnityEngine.Vector3 mousePos, UnityEngine.Camera cam)
        {
            mouseX = mousePos.x;
            mouseY = mousePos.y;
            RaycastHit hit;
            UnityEngine.Physics.Raycast(cam.ScreenPointToRay(mousePos), out hit);
            worldPos = hit.point;
        }
        public MouseEventArgs(UnityEngine.Vector3 mousePos, UnityEngine.Vector3 wpos)
        {
            mouseX = mousePos.x;
            mouseY = mousePos.y;
            worldPos.x = wpos.x;
            worldPos.y = wpos.y;
            worldPos.z = wpos.z;
        }
        
        
    }
}
