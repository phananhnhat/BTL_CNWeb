using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTLCongNgheWeb_Version2.Models
{
    public class ShopingCart
    {
        public List<CardItem> listItem;
        public int CustomerID { get; set; }
        public string TenKhachHang { get; set; }
        public string SDTLienLac { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public DateTime NgayNhanYeuCau;
        public DateTime NgayHoanThanh;
        public ShopingCart()
        {
            listItem = new List<CardItem>();
        }
        public void AddCard(CardItem item)
        {
            foreach (CardItem i in listItem)
            {
                if (i.id == item.id)
                {
                    i.so_luong++;
                    return;
                }
            }
            listItem.Add(item);
        }

        public void UpdateCard(int number, int id)
        {
            foreach (CardItem i in listItem)
            {
                if (i.id == id)
                {
                    i.so_luong = number;
                    return;
                }
            }
        }
        public void DeleteCard(int id)
        {
            foreach (CardItem i in listItem)
            {
                if (i.id == id)
                {
                    listItem.Remove(i);
                    return;
                }
            }
        }
        public double GetTotal()
        {
            double total = 0.0;
            foreach (CardItem i in listItem)
            {
                total += (i.gia * i.so_luong);
            }
            return total;
        }
    }
}