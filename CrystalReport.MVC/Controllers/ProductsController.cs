using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using CrystalReport.MVC.Models;

using CrystalDecisions.CrystalReports.Engine;

namespace CrystalReport.MVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            // 報表文件類別
            ReportClass reportdoc = new ReportClass();
             
            // 讀取報表檔(建置動作改為:內容)          
            reportdoc.FileName = Server.MapPath("~/Views/Products/ProductReport.rpt");

            // 取得資料
            ProductRepository db = new ProductRepository();
            ProductDataSet ds = db.ExcuteDataSet();

            // 設定資料來源
            reportdoc.SetDataSource(ds);

            // 設定報表傳出格式 - PDF
            //Stream stream = reportdoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);                        
            //return File(stream, "application/pdf");

            // 設定報表傳出格式 - EXCEL
            Stream stream = reportdoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            return File(stream, "application/vnd.ms-excel");
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {            
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
