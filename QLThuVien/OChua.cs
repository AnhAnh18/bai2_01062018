using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class OChua : ILayout
    {
         public string MaO { get; set; }
         public String MaSach { get; set; }
         public int SoLuong { get; set; }// so luong sach trong o

        public OChua()
        {
        }

        public OChua(string maO, string maSach, int soLuong)
        {
            MaO = maO;
            MaSach = maSach;
            SoLuong = soLuong;
        }
        //public void xepVaoOChua(List<Sach> dsSach, List<OChua> dsOChua, Dictionary<string, int> sl, int n)
        //{
        //    if (n < dsSach.Count)//kiểm tra có đủ ô không
        //    {
        //        Console.WriteLine("\nSo o da day");
        //        return;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < dsOChua.Count; i++)
        //        {int count = 0;
        //            for(int j=0;j<dsSach.Count;j++)
        //            {

        //                if (dsOChua[i].MaSach == dsSach[j].MaSach)//nếu mã sách ở ô chứa trùng với mã sách khi nhập và
        //                {
        //                    if(sl[dsSach[j].MaSach] > 5)
        //                    {
        //                        sl[dsSach[j].MaSach] = sl[dsSach[j].MaSach] - 5;
        //                        dsOChua.Add(new OChua(genKey(), dsOChua[i].MaSach, sl[dsOChua[i].MaSach]));
        //                        dsOChua[i].SoLuong = 5;
        //                        count++;
        //                        break;
        //                    }
        //                }
        //                else
        //                {
        //                    dsOChua.Add(new OChua(genKey(), dsSach[j].MaSach, 1));//nếu mã sách nhập vào mới thì thêm ô chứa mới
        //                    count++;
        //                    break;
        //                }
        //            }
        //            if (count > 0) break;
        //        }
        //    }
        //}

        public List<OChua> getOChuabyMaSach(List<OChua> dsOChua, string maS)
        {
            List<OChua> res = new List<OChua>();
            for(int i=0;i<dsOChua.Count;i++)
            {
                if(dsOChua[i].MaSach == maS)
                {
                    res.Add(dsOChua[i]);
                }
            }
            return res;
        }

        public Boolean XepSach(List<OChua> lstOChua, Sach sach, int n)
        {
            List<OChua> temp = getOChuabyMaSach(lstOChua, sach.MaSach);
            if (temp.Count != 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].SoLuong < 5)
                    {
                        temp[i].SoLuong++;
                        return true;
                    }
                }
                if (HetOChua(lstOChua, n))
                {
                    return false;
                }
                else
                {
                    lstOChua.Add(new OChua(genKey(), sach.MaSach, 1));
                    return true;
                }
            }
            else
            {
                if (HetOChua(lstOChua, n))
                {
                    return false;
                }
                else
                {
                    lstOChua.Add(new OChua(genKey(), sach.MaSach, 1));
                    return true;
                }
            }
        }

        public Boolean HetOChua(List<OChua> lstOChua, int n)
        {
            if (lstOChua.Count >= n) return true;
            return false;
        }

        public string genKey()
        {
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            return "OC00" + hour + minute + second;
        }
        public Dictionary<String, int> getSLSachTrongOChua(List<OChua> lstOChua)
        {
            Dictionary<String, int> res = new Dictionary<String, int>();
            if (lstOChua.Count != 0)
            {
                for (int i = 0; i < lstOChua.Count; i++)
                {
                    if (res.Count == 0)
                    {
                        res.Add(lstOChua[i].MaSach, lstOChua[i].SoLuong);
                    }
                }
            }
            return res;
        }
        //public Dictionary<String, int> getSLSachChoMuon(Dictionary<String, int> SLMoiSach, Dictionary<String, int> SLSachTrongOChua)
        //{
        //    Dictionary<String, int> res = new Dictionary<string, int>();
        //    foreach (var i in SLMoiSach)
        //    {
        //        res.Add(i.Key, i.Value);
        //        foreach (var j in SLSachTrongOChua)
        //        {
        //            if (i.Key == j.Key)
        //            {
        //                res[i.Key] -= j.Value;
        //            }
        //        }
        //    }
        //    return res;
        //}
        public void LaySachTuO(List<OChua> dsOChua, string maO,Dictionary<string,int> sl)
        {
            OChua ochua = new OChua();
            if (maO == "")
            {
                ochua = getSLMinOChua(dsOChua);
            }
            else
            {
                ochua = getSLbyMaOChua(maO, dsOChua);
            }
            //if (ochua.SoLuong == 1)
            //{
            //    dsOChua.Remove(ochua);
            //}
            //else
            {
                ochua.SoLuong--;
            }
        }
        //public string getMaSachbyMaO(List<OChua> dsOChua,string maO)
        //{
        //    string mas = null;
        //    for(int i=0;i< dsOChua.Count;i++)
        //    {
        //        if(dsOChua[i].MaO == maO)
        //        {
        //            mas = dsOChua[i].MaSach;
        //        }
        //    }
        //    return mas;
        //}
        public OChua getSLbyMaOChua(String maO, List<OChua> dsOChua)
        {
            OChua ochua = new OChua();
            if (dsOChua.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < dsOChua.Count; i++)
            {
                if (dsOChua[i].MaO == maO)
                {
                    ochua = dsOChua[i];
                }
            }
            return ochua;
        }
        public OChua getSLMinOChua(List<OChua> lstOChua)
        {
            if (lstOChua.Count == 0)
            {
                return null;
            }
            OChua oChua = lstOChua[0];
            for (int i = 1; i < lstOChua.Count; i++)
            {
                if (lstOChua[i].SoLuong < oChua.SoLuong)
                {
                    oChua = lstOChua[i];
                }
            }
            return oChua;
        }

        public void showLayout()
        {
            Console.WriteLine("Ngày " + DateTime.Now + " -------- Bài toán thư viện "
                + "\n------------------------------------------------------------------------------------------------------------------------");
            throw new NotImplementedException();
        }
        //public Dictionary<string,int> getSoLuongFromOChua(List<OChua> dsOChua)
        //{
        //    Dictionary<string, int> dsCoTheChoMuon = new Dictionary<string, int>();
        //    for(int i=0;i<dsOChua.Count;i++)
        //    {
        //        if(dsOChua[i].SoLuong !=0)
        //        {
        //            dsCoTheChoMuon.Add(dsOChua[i].MaSach, dsOChua[i].SoLuong);
        //        }
        //    }
        //    return dsCoTheChoMuon;
        //}
    }
}
