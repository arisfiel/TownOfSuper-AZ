using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Collections;
using UnhollowerBaseLib;
using UnityEngine;
using System.Linq;
using HarmonyLib;
using Hazel;

namespace TownOfSuper
{
    public static class ModHelpers
    {
        public static PlayerControl playerById(byte id)
        {
            foreach (PlayerControl player in PlayerControl.AllPlayerControls)
                if (player.PlayerId == id)
                    return player;
            return null;
        }

        public static string DeleteHTML(this string name)
        {
            var PlayerName = name.Replace("\n", "").Replace("\r", "");
            while (PlayerName.Contains("<") || PlayerName.Contains(">"))
            {
                PlayerName = PlayerName.Remove(PlayerName.IndexOf("<"), PlayerName.IndexOf(">") - PlayerName.IndexOf("<") + 1);
            }
            return PlayerName;
        }

        public static string ColorToHex(Color32 color)
        {
            string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
            return hex;
        }

        public static string GetColorHEX(InnerNet.ClientData Client)
        {
            try
            {
                return ColorToHex(Palette.PlayerColors[Client.ColorId]);
            }
            catch
            {
                return "";
            }
        }

        public static PlayerControl GetPlayerById(int PlayerId)
        {
            return PlayerControl.AllPlayerControls.ToArray().Where(pc => pc.PlayerId == PlayerId).FirstOrDefault();
        }


    }
}