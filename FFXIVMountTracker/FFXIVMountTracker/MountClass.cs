using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVMountTracker
{
    public class MountClass
    {
        /*[PrimaryKey, AutoIncrement]
        public int _id { get; set; }*/
        [PrimaryKey, Unique]
        public int id { get; set; }
        [Unique]
        public string name { get; set; }
        public string description { get; set; }
        public string enhanced_description { get; set; }
        public string tooltip { get; set; }
        public string movement { get; set; }
        public int seats { get; set; }
        public int order { get; set; }
        public int order_group { get; set; }
        public string patch { get; set; }
        public int? item_id { get; set; }
        public string owned { get; set; }
        public string image { get; set; }
        public string icon { get; set; }
        //public object[] sources { get; set; }
        [Ignore]
        public List<SourceClass> sources { get; set; }

        public MountClass() { }
        public MountClass(int m_id, string m_name, string m_desc, string m_edesc, string m_tt, string m_movement, int m_seats, int m_ord, int m_ordgrp, string m_patch, int? m_itemId, string m_own, string m_img, string m_icon, List<SourceClass> m_sources)
        {
            id = m_id;
            name = m_name;
            description = m_desc;
            enhanced_description = m_edesc;
            tooltip = m_tt;
            movement = m_movement;
            seats = m_seats;
            order = m_ord;
            order_group = m_ordgrp;
            patch = m_patch;
            item_id = m_itemId;
            owned = m_own;
            image = m_img;
            icon = m_icon;
            sources = m_sources;
        }


    }
}
