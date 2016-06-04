﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLCongNgheWeb_Version2.Models
{
    public class CardItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int so_luong { get; set; }
        public double gia { get; set; }
        public CardItem(int _id,string _name,int _soluong,double _gia)
        {
            id = _id;
            name = _name;
            so_luong = _soluong;
            gia = _gia;
        }
    }
}