using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace demo.Controllers
{
    public class SanPhamController : ApiController
    {
        testEntities db = new testEntities();
        [HttpGet]
        public List<SanPham> laySP()
        {
            return db.SanPhams.ToList();
        }
        [HttpGet]
        public List<SanPham> timSPtheoDM(int madm)
        {
            return db.SanPhams.Where(x => x.MaDanhMuc == madm).ToList();
        }
        [HttpGet]
        public SanPham timSPtheoMa(int ma)
        {
            return db.SanPhams.FirstOrDefault(x => x.Ma == ma);
        }
        [HttpPost]
        public bool themmoi(int ma, string ten,int gia,int madm)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == ma);
            if(sp == null)
            {
                SanPham sp1 = new SanPham();
                sp1.Ma = ma;
                sp1.Ten = ten;
                sp1.DonGia = gia;
                sp1.MaDanhMuc = madm;
                db.SanPhams.Add(sp1);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [HttpDelete]
        public bool xoa(int id)
        {
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Ma == id);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
