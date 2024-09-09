using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSauce.Models;
namespace WebSauce.Models
{
    public class GioHang
    {
        QLTAEntities db = new QLTAEntities();
        public int imasp { set; get; }
        public string sTenSP { set; get; }
        public string sAnh { set; get; }
        public int iDonGia { set; get; }
        public int isL { set; get; }
        public int iThanhTien
        {
            get { return isL * iDonGia; }
        }
        
        //Khởi tạo giỏ hàng
        public GioHang(int msp)
        {
            imasp = msp;
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == imasp);
            sTenSP = sp.TENSP ;
            sAnh = sp.HINHANH ;
            iDonGia = int.Parse(sp.DONGIA.ToString());
            isL = 1;
        }





    }
}