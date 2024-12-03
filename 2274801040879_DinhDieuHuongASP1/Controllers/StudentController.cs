using _2274801040879_DinhDieuHuongASP1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2274801040879_DinhDieuHuongASP1.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SinhVienActions _svActions;
        public StudentController()
        {
            _svActions = new SinhVienActions(); // Khởi tạo SinhVienActions
        }

        // GET: api/<StudentController>
        [HttpGet]
        public string Get()
        {
            var dsSinhVien = _svActions.GetAll(); // Lấy tất cả sinh viên
                 //  return new string[] { "value1", "value2" };
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<IList<SinhVien>>(dsSinhVien, opt);
            return strJson; 
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var sv = _svActions.GetByID(id); // Lấy tất cả sinh viên
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = JsonSerializer.Serialize<SinhVien>(sv, opt);
            return strJson;
        }

        // GET api/<StudentController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] SinhVien sv)
        {
            if (!ModelState.IsValid)
            {
                return JsonSerializer.Serialize(new { error = "Invalid model state" });
            }

            var existing_sv = _svActions.GetByID(id);
            if (existing_sv == null)
            {
                return JsonSerializer.Serialize(new { error = "SinhVien not found" });
            }

            // Update the existing SinhVien with new values
            existing_sv.Tt = sv.Tt;
            existing_sv.Hodem = sv.Hodem;
            existing_sv.Ten = sv.Ten;
            existing_sv.Cccd = sv.Cccd;
            existing_sv.Nickname = sv.Nickname;
            existing_sv.Email = sv.Email;
            existing_sv.Dienthoai = sv.Dienthoai;
            existing_sv.Diem_tichluy = sv.Diem_tichluy;
            existing_sv.Diem_renluyen = sv.Diem_renluyen;
            // Add other properties as needed

            _svActions.Update(existing_sv);

            return JsonSerializer.Serialize(new { message = "Update successful" });
        }

        [HttpPost]
        public string Post([FromBody] SinhVien sv)
        {
            if (!ModelState.IsValid)
            {
                return JsonSerializer.Serialize(new { error = "Invalid model state" });
            }

            _svActions.Add(sv);
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            return JsonSerializer.Serialize(sv, opt);
        }


        // DELETE api/<StudentController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existing_sv = _svActions.GetByID(id);
        //    if (existing_sv == null)
        //    {
        //        return NotFound(new { error = "SinhVien not found" });
        //    }

        //    _svActions.DeleteByID(id);

        //    return NoContent(); // 204 No Content
        //}

        // DELETE (Cách 2)
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var existing_sv = _svActions.GetByID(id);
            if (existing_sv == null)
            {
                return JsonSerializer.Serialize(new { error = "SinhVien not found" });
            }

            _svActions.DeleteByID(id);

            return JsonSerializer.Serialize(new { message = "Delete successful" });
        }

        [HttpDelete]
        public string DeleteAll()
        {
            var allSinhViens = _svActions.GetAll();
            if (allSinhViens == null || !allSinhViens.Any())
            {
                return JsonSerializer.Serialize(new { message = "No SinhVien records to delete" });
            }

            foreach (var sv in allSinhViens)
            {
                _svActions.DeleteAll();
            }

            return JsonSerializer.Serialize(new { message = "All SinhVien records deleted successfully" });
        }
    }
}