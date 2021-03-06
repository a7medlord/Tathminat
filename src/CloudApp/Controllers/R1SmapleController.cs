﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CloudApp.Data;
using CloudApp.Models.BusinessModel;
using CloudApp.Models.ManpulateModel;
using CloudApp.RepositoriesClasses;
using CloudApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace CloudApp.Controllers
{
    public class R1SmapleController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHostingEnvironment _env;

        private readonly CustemerRepostry _cmsRepostry;

        private readonly SampleTowServices _towServices;

        public R1SmapleController(ApplicationDbContext context , UserManager<ApplicationUser> usermanger , IHostingEnvironment env)
        {
            _context = context;
            _userManager = usermanger;
            _env = env;
            _cmsRepostry = new  CustemerRepostry(context);
            _towServices = new SampleTowServices(context , _cmsRepostry);
        }

        public IActionResult GetSample1Report(long id)
        {

            byte[] rendervalue = _towServices.GetSample1ReportasStreem(id, HttpContext, _env);

            return File(rendervalue, "application/pdf");
        }
        
        public  IActionResult Create(int ids)
        {
            GetBinding();
            var cms = _cmsRepostry.GetbyId(ids);
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["cmsname"] = cms;
            return View(new R1Smaple());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind] R1Smaple r1Smaple , string ids)
        {
            if (ModelState.IsValid)
            {
                r1Smaple.Id = _towServices.GetAutoIncreesNumber(r1Smaple.DateOfBegin);
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] imgsids = ids.Split(';');
                    r1Smaple.AttachmentForR1Samples= new List<AttachmentForR1Sample>();
                    for (int i = 0; i < imgsids.Length - 1; i++)
                    {
                        r1Smaple.AttachmentForR1Samples.Add(new AttachmentForR1Sample() { AttachmentId = imgsids[i] });
                    }
                }

                if (r1Smaple.IsAduit && User.IsInRole("au"))
                {
                    r1Smaple.Adutit = _userManager.GetUserId(User);
                }
                if (r1Smaple.IsApproved && User.IsInRole("apr"))
                {
                    r1Smaple.Approver = _userManager.GetUserId(User);
                }
                if (r1Smaple.IsIntered && User.IsInRole("en"))
                {
                    r1Smaple.Intered = _userManager.GetUserId(User);
                }
                if (r1Smaple.IsThmin && User.IsInRole("th"))
                {
                    r1Smaple.Muthmen = _userManager.GetUserId(User);
                }

                _towServices.CreatNewTreamnt(r1Smaple);

                return RedirectToAction("Edit" , new {id= r1Smaple.Id});
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }

        public JsonResult RemoveFile(string name)
        {
            _context.Remove(_context.AttachmentForR1Samples.SingleOrDefault(treament => treament.AttachmentId == name));
            _context.SaveChanges();
            return Json("true");
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile()
        {
            string guid = Guid.NewGuid().ToString();
            string filepath = "sample2attachment/" + guid + ".jpg";
            var strem = new FileStream(Path.Combine(_env.WebRootPath, filepath), FileMode.Create);
            await Request.Form.Files[0].CopyToAsync(strem);
            strem.Close();
            strem.Dispose();
            return Json(guid);
        }

        public  IActionResult Edit(long id)
        {
            var r1Smaple = _towServices.GetTrementWithAttachmentFiles(id);
            if (r1Smaple == null)
            {
                return NotFound();
            }

            string files = "";
            foreach (AttachmentForR1Sample file in r1Smaple.AttachmentForR1Samples)
            {
                files += file.AttachmentId + ";";
            }
            ViewData["imgs"] = files;

           GetBinding();
            ViewData["City"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.City), "Value", "Value");
            ViewData["Gada"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Gada), "Value", "Value");
            ViewData["cmsname"] = r1Smaple.Custmer;
            if (User.IsInRole("apr") || User.IsInRole("au"))
            {
                var data = GetData(r1Smaple.Id);

                ViewData["pricemap"] = data;
            }
            return View(r1Smaple);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(long id, [Bind] R1Smaple r1Smaple , string ids)
        {
            if (id != r1Smaple.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ids))
                    {
                        string[] imgsids = ids.Split(';');
                        r1Smaple.AttachmentForR1Samples = new List<AttachmentForR1Sample>();
                        for (int i = 0; i < imgsids.Length - 1; i++)
                        {
                            r1Smaple.AttachmentForR1Samples.Add(new AttachmentForR1Sample() { AttachmentId = imgsids[i] });
                        }
                    }

                    if (r1Smaple.IsAduit && User.IsInRole("au"))
                    {
                        r1Smaple.Adutit = _userManager.GetUserId(User);
                    }
                    if (r1Smaple.IsApproved && User.IsInRole("apr"))
                    {
                        r1Smaple.Approver = _userManager.GetUserId(User);
                    }
                    if (r1Smaple.IsIntered && User.IsInRole("en"))
                    {
                        r1Smaple.Intered = _userManager.GetUserId(User);
                    }
                    if (r1Smaple.IsThmin && User.IsInRole("th"))
                    {
                        r1Smaple.Muthmen = _userManager.GetUserId(User);
                    }
                    _towServices.UpdateExistTreament(r1Smaple);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!R1SmapleExists(r1Smaple.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction("Index" , "MainSamples");
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", r1Smaple.ApplicationUserId);
            ViewData["CustmerId"] = new SelectList(_context.Custmer, "Id", "Name", r1Smaple.CustmerId);
            return View(r1Smaple);
        }
        
        public  void EditAprove(long id)
        {
            var row = _towServices.GetTrementById(id);
            row.IsApproved = true;
            _towServices.UpdateExistTreament(row);
        }

        void GetBinding()
        {
            IList<ApplicationUser> data = _userManager.GetUsersInRoleAsync("th").Result;

            ViewData["ApplicationUserId"] = new SelectList(data.ToList(), "Id", "EmployName");
            ViewData["aqartype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Aqar), "Value", "Value");
            ViewData["desinArch"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.DesginArch), "Value", "Value");
            ViewData["Mansob"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Mansob), "Value", "Value");
            ViewData["buldingtype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BuildingStatus), "Value", "Value");
            ViewData["butype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BulsingType), "Value", "Value");
            ViewData["AqarScope"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AqarScope), "Value", "Value");
            ViewData["BuldingBuzy"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.BuldingBuzy), "Value", "Value");
            ViewData["RoadSeflt"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.RoadSeflt), "Value", "Value");
            ViewData["RoadLighting"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.RoadLighting), "Value", "Value");
            ViewData["JarIsBulding"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.JarIsBulding), "Value", "Value");
            ViewData["AqarIsAttch"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AqarIsAttch), "Value", "Value");
            ViewData["TshteebType"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.TshteebType), "Value", "Value");
            ViewData["InterFaces"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.Interfaces), "Value", "Value");
            ViewData["AsqfType"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.SqfTypeAndArch), "Value", "Value");
            ViewData["azltype"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.AzlType), "Value", "Value");
            ViewData["downstair"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.DownSir), "Value", "Value");

            ViewData["ArchConstract"] = new SelectList(_context.Flag.Where(d => d.FlagValue == FlagsName.ArchConstract), "Value", "Value");

        }
      
        private bool R1SmapleExists(long id)
        {
            return _context.R1Smaple.Any(e => e.Id == id);
        }

        public List<PriceMapModelView> FilterExpr1()
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith1 = _context.Treatment.ToList();

            foreach (Treatment treatment in allTrementWith1)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.Tbuild,
                    Type = 1,
                    Id = treatment.Id,
                    Area = treatment.Area,
                    Classfications = "لا يوجد",
                    PriceOfMeter = treatment.MeterPriceForBulding.ToString(),
                    SoqfPrice = treatment.TotalPriceNumber.ToString(),
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute,
                    IconUrl = "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                };
                reslt.Add(item);
            }

            return reslt;
        }

        public List<PriceMapModelView> FilterExpr2(long id)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith2 = _context.R1Smaple.Where(treatment => treatment.Id != id).ToList();

            foreach (R1Smaple treatment in allTrementWith2)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.AqarType,
                    Type = 2,
                    Id = treatment.Id,
                    Area = "لا يوجد",
                    Classfications = "لا يوجد",
                    PriceOfMeter = "لا يوجد",
                    SoqfPrice = "لا يوجد",
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute,
                    IconUrl = "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                };
                reslt.Add(item);
            }

            return reslt;
        }

        public List<PriceMapModelView> FilterExpr3()
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();

            var allTrementWith3 = _context.R2Smaple.ToList();

            foreach (R2Smaple treatment in allTrementWith3)
            {
                PriceMapModelView item = new PriceMapModelView()
                {
                    TypeOfAqar = treatment.BuldingType,
                    Type = 3,
                    Id = treatment.Id,
                    Area = "لا يوجد",
                    Classfications = "لا يوجد",
                    PriceOfMeter = "لا يوجد",
                    SoqfPrice = "لا يوجد",
                    Longtut = treatment.Longtute,
                    Latutue = treatment.Latute,
                    IconUrl = "http://maps.google.com/mapfiles/ms/icons/green-dot.png"
                };
                reslt.Add(item);
            }

            return reslt;
        }
        
        List<PriceMapModelView> GetData(long id)
        {
            List<PriceMapModelView> reslt = new List<PriceMapModelView>();
            var data1 = FilterExpr1();
            var data2 = FilterExpr2(id);
            var data3 = FilterExpr3();

            reslt.AddRange(data1);
            reslt.AddRange(data2);
            reslt.AddRange(data3);


            return reslt;


        }
    }
}
