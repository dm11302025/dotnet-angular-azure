using HandsOnAPIUsingStatusCodes.DTOs;
using HandsOnAPIUsingStatusCodes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingStatusCodes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _repo;

        public AccountsController(IAccountRepository repo)
        {
            _repo = repo;
        }

        // ========================================
        // GET /api/accounts/5   → 200 or 404
        // ========================================
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var account = _repo.GetById(id);

            if (account == null)
                return NotFound();                 // 404

            return Ok(account);                   // 200
        }

        // ========================================
        // POST /api/accounts   → 201, 400, 409
        // ========================================
        [HttpPost]
        public IActionResult CreateAccount(CreateAccountDto dto)
        {
            // 400 – Invalid Model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);     // 400

            // 409 – Duplicate account number
            if (_repo.AccountNumberExists(dto.AccountNumber))
                return Conflict("Account number already exists"); // 409

            var newAccount = _repo.Create(dto);

            return CreatedAtAction(
                nameof(GetAccount),
                new { id = newAccount.Id },
                newAccount
            );
            // Returns 201 Created
        }

        // ========================================
        // PUT /api/accounts/5   → 200, 400, 404
        // ========================================
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, UpdateAccountDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);     // 400

            var existing = _repo.GetById(id);

            if (existing == null)
                return NotFound();                // 404

            var updated = _repo.Update(id, dto);

            return Ok(updated);                   // 200
        }

        // ========================================
        // DELETE /api/accounts/5   → 204, 404
        // ========================================
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var account = _repo.GetById(id);

            if (account == null)
                return NotFound();                 // 404

            _repo.Delete(id);

            return NoContent();                    // 204
        }

        // ========================================
        // Protected endpoint → 401, 403
        // ========================================
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var accounts = _repo.GetAll();
            return Ok(accounts);                   // 200
        }

        // ========================================
        // Simulated 500 error
        // ========================================
        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            try
            {
                throw new Exception("Something went wrong");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");  // 500
            }
        }
    }

}
