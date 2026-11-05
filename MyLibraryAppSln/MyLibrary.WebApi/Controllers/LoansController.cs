using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.WebApi.DTOs.Request;
using MyLibrary.WebApi.Services.Contracts;

namespace MyLibrary.WebApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;
    private readonly IValidator<LoanRequestDTO> _validator;

    public LoansController(ILoanService loanService, IValidator<LoanRequestDTO> validator)
    {
        _loanService = loanService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var loans = await _loanService.GetAll();
        return Ok(loans);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByid(int id)
    {
        try
        {
            var loan = await _loanService.GetById(id);
            return Ok(loan);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("get-loans-by-userid/{userId}")]
    public async Task<IActionResult> GetLoansByUserId(int userId)
    {
        try
        {
            var loans = await _loanService.GetLoansByUserId(userId);
            return Ok(loans);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(LoanRequestDTO loanDto)
    {
        var validationResult = await _validator.ValidateAsync(loanDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        var loan = await _loanService.Add(loanDto);

        return Ok(loan);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, LoanRequestDTO loanDto)
    {
        try
        {
            var validationResult = await _validator.ValidateAsync(loanDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var loan = await _loanService.Update(id, loanDto);
            return Ok(loan);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var loan = await _loanService.Delete(id);
            return Ok(loan);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
