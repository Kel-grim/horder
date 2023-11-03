using Horder.Common.Interfaces.Services;
using Horder.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Horder.API.Controllers;

[Controller]
[Route("accounts")]
public class AccountController : ControllerBase
{
    #region Constructors

    public AccountController(IAccountService accountService)
    {
        this._accountService = accountService;
    }

    #endregion

    #region Private Properties

    private IAccountService _accountService { get; }

    #endregion

    #region Public Methods

    [HttpGet()]
    public IActionResult Get()
    {
        try
        {
            var accounts = new List<Account>();

            accounts = this._accountService.Get();

            if (accounts.Count == 0)
            {
                return this.StatusCode(204);
            }
            else
            {
                return this.StatusCode(200, accounts);
            }
        }
        catch (ArgumentNullException argumentNullException)
        {
            return this.StatusCode(400);
        }
        catch (ArgumentException argumentException)
        {
            return this.StatusCode(400);
        }
        catch (Exception exception)
        {
            return this.StatusCode(500);
        }
    }

    #endregion
}