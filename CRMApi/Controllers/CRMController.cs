using CRMApi.Interface;
using CRMApi.Models.Model;
using CRMApi.Models.ModelUtils;
using CRMApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRMApi.Models.Entity;
using System.IO;
using CRMApi.Utils;
using System.Data;
using Microsoft.Extensions.Configuration;
using CRMApi.Entity;
using System.Data.SqlClient;

namespace CRMApi.Controllers
{
    /// <summary>
    /// CRM调用接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CRMController : ControllerBase
    {
        private readonly ILogger<CRMController> _logger;
        private readonly IBaseService _baseService;
        //private readonly DBConnectionOption _dBConnectionOption;
        private readonly IConfiguration _configuration;

        public CRMController(ILogger<CRMController> logger, IBaseService baseService,
            IConfiguration configuration)
        { 
            _logger = logger;
            _baseService = baseService;
            _configuration = configuration;
        }
        

        /// <summary>
        /// 插入CRM任务单
        /// </summary>
        /// <param name="crmpPlanList">多个任务单列表</param>
        /// <returns>插入结果</returns>
        [Route("CRMPlanApply")]
        [Authorize]
        [HttpPost]
        
        public async Task<ApiResult> AddCRMPlanApply([FromBody]List<CRMPlanWriter> crmpPlanList)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                string conStr = _configuration["ConnectionStrings:MainConnectionString"];
                Task<DataTable> dtTask = _baseService.ClassToDataTableAsync(typeof(CRMPlanList));
                DataTable dt = null;
                foreach (CRMPlanWriter temp in crmpPlanList)
                {
                    //DateTime dtt1 = DateTime.Now;
                    DateTime dtt2 = DateTime.Now;

                    CRMPlanHead crmpHeader =(CRMPlanHead) _baseService.ParseValue(temp, typeof(CRMPlanHead));
                    //Debug.WriteLine("分解数据："+(DateTime.Now - dtt1).TotalMilliseconds);
                    //dtt1 = DateTime.Now;
                    Task<CRMPlanHead> cmphAsync = _baseService.InsertAsync(crmpHeader);
                    //dtt1 = DateTime.Now;
                    if(dt==null)
                        dt = await dtTask;
                    //Debug.WriteLine("预插入数据：" + (DateTime.Now - dtt1).TotalMilliseconds);
                    dt.Clear();
                    CRMPlanList crmpList = null;
                    foreach (CRMPlanListWriter cpwTemp in temp.CRMPlanLists)
                    {
                        crmpList = (CRMPlanList)_baseService.ParseValue(cpwTemp, typeof(CRMPlanList));
                        if (crmpHeader.ID == 0)
                            crmpHeader = (CRMPlanHead)await cmphAsync;

                        crmpList.CRMPlanHead_Id = crmpHeader.ID;
                        dt= _baseService.ParsePrintItem(dt, crmpList);
                    }
                    _baseService.SetDataTableToTable(dt, "CRMPlanList", conStr);

                    //Debug.WriteLine("预插入子数据：" + (DateTime.Now - dtt1  ).TotalMilliseconds);
                    Debug.WriteLine("总用时：" + (DateTime.Now - dtt2).TotalSeconds);

                }
                apiResult.code = 1000;
                apiResult.message = "success";
                apiResult.data = string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                apiResult.code = 1001;
                apiResult.message = "fail";
                apiResult.data = ex.ToString();
            }
            
            return apiResult;
        }

        /// <summary>
        /// 预热接口，减少初次执行时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<string> Get()
        {
            //_baseService.SqlQuery<WarnItem>("select '1' item");
            await _baseService.CountAsync<CRMPlanHead>(null, ReadWriteEnum.Write);
            await _baseService.CountAsync<CRMPlanList>(null, ReadWriteEnum.Write);

            Debug.WriteLine(110);
            return "OK";
        }

        #region CoreApi文件上传
        /*
        [HttpPost, Route("UpFile")]
        public async Task<ApiResult> UpFile([FromForm] IFormCollection formcollection)
        {
            ApiResult result = new ApiResult();
            try
            {
                var files = formcollection.Files;//formcollection.Count > 0 这样的判断为错误的
                if (files != null && files.Any())
                {
                    var file = files[0];
                    string contentType = file.ContentType;
                    string fileOrginname = file.FileName;//新建文本文档.txt  原始的文件名称
                    string fileExtention = Path.GetExtension(fileOrginname);
                    string cdipath = Directory.GetCurrentDirectory();

                    string fileupName = Guid.NewGuid().ToString("d") + fileExtention;
                    string upfilePath = Path.Combine(cdipath + "/myupfiles/", fileupName);
                    if (!System.IO.File.Exists(upfilePath))
                    {
                        using var Stream = System.IO.File.Create(upfilePath);
                    }

                    #region MyRegion
                    //using (FileStream fileStream = new FileStream(upfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    //{
                    //    using (Stream stream = file.OpenReadStream()) //理论上这个方法高效些
                    //    {
                    //        await stream.CopyToAsync(fileStream);//ok
                    //        result.message = "上传成功！"; result.code = statuCode.success;
                    //    }
                    //}

                    //using (FileStream fileStream = new FileStream(upfilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    //{
                    //    await file.CopyToAsync(fileStream);//ok
                    //    result.message = "上传成功！"; result.code = statuCode.success;
                    //}

                    #endregion

                    double count = await UpLoadFileStreamHelper.UploadWriteFileAsync(file.OpenReadStream(), upfilePath);
                    result.message = "上传成功！"; result.code = StatusCodeS.success; result.data = $"上传的文件大小为:{count}MB";
                }
            }
            catch (Exception ex)
            {
                result.message = "上传异常,原因:" + ex.Message;
            }
            return result;

        }

        /// <summary>
        /// 文件上传 [FromForm]需要打上这个特性
        /// </summary>
        /// <param name="model">上传的字段固定为: file</param>
        /// <returns></returns>

        [HttpPost, Route("UpFile02")]
        public async Task<ApiResult> UpFileBymodel([FromForm] UpFileModel model)// 这里一定要加[FromForm]的特性，模型里面可以不用加
        {
            ApiResult result = new ApiResult();
            try
            {
                bool falg = await UpLoadFileStreamHelper.UploadWriteFileByModelAsync(model);
                result.code = falg ? StatusCodeS.success : StatusCodeS.fail;
                result.message = falg ? "上传成功" : "上传失败";
            }
            catch (Exception ex)
            {
                result.message = "上传异常,原因:" + ex.Message;
            }
            return result;
        }

        [HttpPost, Route("UpFile03")]
        public async Task<ApiResult> UpFile03(IFormFile file)// 这里一定要加[FromForm]的特性，模型里面可以不用加
        {
            ApiResult result = new ApiResult();
            try
            {
                bool flag = await UpLoadFileStreamHelper.UploadWriteFileAsync(file);
                result.code = flag ? StatusCodeS.success : StatusCodeS.fail;
                result.message = flag ? "上传成功" : "上传失败";
            }
            catch (Exception ex)
            {
                result.message = "上传异常,原因:" + ex.Message;
            }
            return result;
        }
        */
        #endregion


    }
}
