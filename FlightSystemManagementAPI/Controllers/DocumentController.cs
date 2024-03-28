using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
using System.Security.Claims;

namespace FlightSystemManagementAPI.Controllers
{
    public class DocumentController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DocumentController(DataContext dataContext,RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _dataContext = dataContext;
        }

        [HttpGet("GetDocTypes")]
        public async Task<IActionResult> GetDocTypes()
        {
            try
            {
                return Ok(await _dataContext.DocTypes.ToListAsync());
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet("GetDocType/{id}")]
        public async Task<IActionResult> GetDocTypeById(int id)
        {
            var result = await _dataContext.DocTypes.FirstOrDefaultAsync(d=>d.DocType_Id==id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Không tìm tháy loại tài liệu");
            }
        }

        [HttpPost("AddDocType")]
        public async Task<IActionResult> AddDocType([FromBody] DocType model)
        {
            var findDocT = _dataContext.DocTypes.Where(d => d.DocType_Id == model.DocType_Id).FirstOrDefault();
            if (findDocT != null)
            {
                return Ok("Already have in database");
            }
            else
            {

                DocType doctype  = new DocType
                {
                    Name = model.Name,
                    Note = model.Note,
                };
                
                _dataContext.DocTypes.Add(doctype);
                _dataContext.SaveChanges();
                return Ok("Đã thêm thành công loại tài liệu");
            }
        }

        [HttpPut("UpdateDocType/{id}")]
        public async Task<IActionResult> UpdateDocType(int id, [FromBody] DocType model)
        {
            if (id != model.DocType_Id)
            {
                return BadRequest("Sai thông tin loại tài liệu cần cập nhật");
            }

            var doctype = _dataContext.DocTypes.FirstOrDefault(dt => dt.DocType_Id == model.DocType_Id);
            var docCheck = await _dataContext.DocTypes.FindAsync(id);
            if (doctype == null)
            {
                return NotFound("Mã loại tài liệu không tồn tại");
            }
            else
            {
                docCheck.Name = model.Name;
                docCheck.Note = model.Note;

                _dataContext.DocTypes.Update(docCheck);
                await _dataContext.SaveChangesAsync();

                return Ok("Cập nhật thông tin loại tài liệu thành công");
            }

        }

        [HttpDelete("DeleteDocType/{id}")]
        public async Task<IActionResult> DeleteDocType(int id)
        {
            var doctype = await _dataContext.DocTypes.FindAsync(id);
            if (doctype == null)
            {
                return NotFound("Không tìm thấy loại tài liệu cần xoá");
            }

            _dataContext.DocTypes.Remove(doctype);
            await _dataContext.SaveChangesAsync();

            return Ok("Xoá thành công loại tài liệu!");
        }

        //CRUD Doc

        [HttpGet("GetDocs")]
        public async Task<IActionResult> GetDocs()
        {
            try
            {
                return Ok(await _dataContext.Documents.ToListAsync());
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpGet("GetDoc/{id}")]
        public async Task<IActionResult> GetDocById(int id)
        {
            var result = await _dataContext.Documents.FirstOrDefaultAsync(d => d.Id == id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Không tìm tháy loại tài liệu");
            }
        }

        [HttpPost("AddDoc")]
        public async Task<IActionResult> AddDoc([FromForm] Document model)
        {
            var findDoc = _dataContext.Documents.Where(d => d.Id == model.Id).FirstOrDefault();
            if (findDoc != null)
            {
                return Ok("Already have in database");
            }
            else
            {

                Document document = new Document
                {
                    Name = model.Name,
                    Note = model.Note,
                    TypeId = model.TypeId,
                    FlightId = model.FlightId,
                    /*RoleNameList = model.RoleNameList,*/
                };
                

                _dataContext.Documents.Add(document);
                _dataContext.SaveChanges();
                return Ok("Đã thêm thành công tài liệu");
            }
        }

        [HttpPut("UpdateDoc/{id}")]
        public async Task<IActionResult> UpdateDoc(int id, [FromForm] Document model)
        {
            if (id != model.Id)
            {
                return BadRequest("Sai thông tin tài liệu cần cập nhật");
            }

            var doc = _dataContext.Documents.FirstOrDefault(d => d.Id == model.Id);
            var docCheck = await _dataContext.Documents.FindAsync(id);
            if (doc == null)
            {
                return NotFound("Mã tài liệu không tồn tại");
            }
            else
            {
                docCheck.Name = model.Name;
                docCheck.Note = model.Note;
                
                docCheck.Id = model.TypeId;
                docCheck.FlightId = model.FlightId;
                /*docCheck.RoleNameList = model.RoleNameList;*/

                _dataContext.Documents.Update(docCheck);
                await _dataContext.SaveChangesAsync();

                return Ok("Cập nhật thông tin tài liệu thành công");
            }

        }

        [HttpDelete("DeleteDoc/{id}")]
        public async Task<IActionResult> DeleteDoc(int id)
        {
            var doc = await _dataContext.Documents.FindAsync(id);
            if (doc == null)
            {
                return NotFound("Không tìm thấy tài liệu cần xoá");
            }

            _dataContext.Documents.Remove(doc);
            await _dataContext.SaveChangesAsync();

            return Ok("Xoá thành công tài liệu!");
        }

       
    }
}

