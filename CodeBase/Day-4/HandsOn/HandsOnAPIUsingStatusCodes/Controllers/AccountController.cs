using HandsOnAPIUsingStatusCodes.DTOs;
using HandsOnAPIUsingStatusCodes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandsOnAPIUsingStatusCodes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repo;

        public AccountController(IAccountRepository repo)
        {
            _repo = repo;
        }

        // =========================
        // 1. GET (200, 404)
        // =========================
        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var account = _repo.GetById(id);

            if (account == null)
            {
                return NotFound(
                    ApiResponse<string>.Fail(
                        new List<string> { "Account not found" },
                        "Resource Not Found",
                        statusCode: 404
                    )
                );
            }

            return Ok(ApiResponse<object>.Success(account, "Account fetched successfully"));
        }

        // =========================
        // 2. POST (201, 400, 409)
        // =========================
        [HttpPost]
        public IActionResult CreateAccount(CreateAccountDto dto)
        {
            // 400 Bad Request – Invalid Model
            if (!ModelState.IsValid)
            {
                var modelErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(
                    ApiResponse<string>.Fail(modelErrors, "Invalid data", 400)
                );
            }

            // 409 Conflict – Account already exists
            if (_repo.AccountNumberExists(dto.AccountNumber))
            {
                return Conflict(
                    ApiResponse<string>.Fail(
                        new List<string> { "Account number already exists" },
                        "Duplicate Entry",
                        statusCode: 409
                    )
                );
            }

            var createdAccount = _repo.Create(dto);

            return CreatedAtAction(nameof(GetAccount),
                new { id = createdAccount.Id },
                ApiResponse<object>.Success(createdAccount, "Account created successfully", 201)
            );
        }

        // =========================
        // 3. PUT (200, 400, 404)
        // =========================
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, UpdateAccountDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(ApiResponse<string>.Fail(errors, "Invalid data", 400));
            }

            var existing = _repo.GetById(id);

            if (existing == null)
            {
                return NotFound(
                    ApiResponse<string>.Fail(
                        new List<string> { "Account not found" },
                        "Resource Not Found",
                        statusCode: 404
                    )
                );
            }

            var updated = _repo.Update(id, dto);

            return Ok(ApiResponse<object>.Success(updated, "Account updated successfully"));
        }

        // =========================
        // 4. DELETE (204, 404)
        // =========================
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var exists = _repo.GetById(id);

            if (exists == null)
            {
                return NotFound(
                    ApiResponse<string>.Fail(
                        new List<string> { "Account not found" },
                        "Resource Not Found",
                        statusCode: 404
                    )
                );
            }

            _repo.Delete(id);

            return NoContent(); // 204
        }

        // =========================
        // 5. Protected route (401, 403)
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllAccounts()
        {
            var accounts = _repo.GetAll();
            return Ok(ApiResponse<object>.Success(accounts, "Admin data fetched"));
        }

        // =========================
        // 6. Example 500 Error (handled via try-catch)
        // =========================
        [HttpGet("test-error")]
        public IActionResult TestServerError()
        {
            try
            {
                throw new Exception("Test exception");
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    ApiResponse<string>.Fail(
                        new List<string> { ex.Message },
                        "Internal Server Error",
                        statusCode: 500
                    )
                );
            }
        }
    }

}
