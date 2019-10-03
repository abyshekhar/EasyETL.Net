﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyETL.Xml.Configuration
{
    public class EasyETLUser : EasyETLConfiguration
    {
        public string UserName;
        public string DisplayName;
        public string Role;
        public EasyETLPermission Permissions;

        public override void ReadSettingsFromDictionary()
        {
            UserName = GetSetting("UserName");
            DisplayName = GetSetting("DisplayName");
            Role = GetSetting("Role", "No Role");

            Permissions = new EasyETLPermission();
            Permissions.AttributesDictionary = new Dictionary<string, string>(AttributesDictionary);
            Permissions.ReadSettingsFromDictionary();
        }

        public override void WriteSettingsToDictionary()
        {
            Permissions.WriteSettingsToDictionary();
            AttributesDictionary = new Dictionary<string, string>(Permissions.AttributesDictionary);
            SetSetting("UserName", UserName);
            SetSetting("DisplayName", DisplayName);
            SetSetting("Role", Role);
        }
    }
}
