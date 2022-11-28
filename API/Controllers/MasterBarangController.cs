using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class MasterBarangController
    {
        private readonly DataContext _context;
        public MasterBarangController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // api/MasterBarang
        public async Task<ActionResult<IEnumerable<MasterBarang>>> GetMasterBarang()
        {
                var item = await _context.MasterBarang.ToListAsync();
                return item;
        }

        [HttpGet("{id}")] // api/MasterBarang/{id}
        public async Task<ActionResult<MasterBarang>> GetMasterBarangByID(int id)
        {
                var item = await _context.MasterBarang.FindAsync(id);

                return item;
        }

        // api/MasterBarang/GetMasterBarangByKdBarang/{KdBarang}
        [HttpPost("GetMasterBarangByKdBarang")]
        public async Task<IEnumerable<GetMasterBarangByKdBarang>> GetMasterBarangByID(string KdBarang)
        {
            return await _context.GetProcedures().GetMasterBarangByKdBarang(KdBarang);
        }
    }
}